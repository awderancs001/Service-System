using System;
using System.Data.SqlClient;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    public class InvoiceRepository
    {
        private SettingsRepository settingsRepo = new SettingsRepository();

        // -------------------------------------------------------
        // GENERATE INVOICE NUMBER
        // Reads current value of LastInvoiceNumber from SystemSettings,
        // adds 1, and formats it:   INV-2026-0001
        //
        // NOTE: we only GENERATE the number here — we don't save it.
        // The Save() method below saves the invoice AND updates
        // LastInvoiceNumber inside a transaction so both succeed together.
        // -------------------------------------------------------
        public string GenerateInvoiceNumber()
        {
            string prefix     = settingsRepo.GetValue("InvoicePrefix");         // "INV"
            string lastNumStr = settingsRepo.GetValue("LastInvoiceNumber");     // "42"

            int lastNum;
            if (!int.TryParse(lastNumStr, out lastNum))
                lastNum = 0;

            int nextNum = lastNum + 1;

            // Format: INV-2026-0001
            // D4 pads with zeros to 4 digits: 1 -> "0001", 42 -> "0042"
            return string.Format("{0}-{1}-{2}",
                prefix,
                DateTime.Now.Year,
                nextNum.ToString("D4"));
        }

        // -------------------------------------------------------
        // SAVE — inserts a new invoice AND increments LastInvoiceNumber
        // Both happen inside ONE transaction so they either both
        // succeed or both roll back. This keeps the numbering safe.
        // Returns the new InvoiceID.
        // -------------------------------------------------------
        public int Save(Invoice inv)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    // 1. INSERT invoice
                    string insertSql = @"
                        INSERT INTO Invoices
                        (InvoiceNumber, PaymentID, UnitID,
                         GiverName, GiverNameKurdish,
                         ReceiverName, ReceiverNameKurdish,
                         DebtMonth, DebtToMonth, PaymentDate, Amount, BillType,
                         InvoiceContent, InvoiceContentKurdish,
                         CreatedBy, CreatedByName)
                        VALUES
                        (@InvoiceNumber, @PaymentID, @UnitID,
                         @GiverName, @GiverNameKurdish,
                         @ReceiverName, @ReceiverNameKurdish,
                         @DebtMonth, @DebtToMonth, @PaymentDate, @Amount, @BillType,
                         @InvoiceContent, @InvoiceContentKurdish,
                         @CreatedBy, @CreatedByName);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(insertSql, con, tx);
                    cmd.Parameters.AddWithValue("@InvoiceNumber",         inv.InvoiceNumber);
                    cmd.Parameters.AddWithValue("@PaymentID",             inv.PaymentID.HasValue ? (object)inv.PaymentID.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UnitID",                inv.UnitID);
                    cmd.Parameters.AddWithValue("@GiverName",             inv.GiverName);
                    cmd.Parameters.AddWithValue("@GiverNameKurdish",      string.IsNullOrEmpty(inv.GiverNameKurdish)      ? (object)DBNull.Value : inv.GiverNameKurdish);
                    cmd.Parameters.AddWithValue("@ReceiverName",          inv.ReceiverName);
                    cmd.Parameters.AddWithValue("@ReceiverNameKurdish",   string.IsNullOrEmpty(inv.ReceiverNameKurdish)   ? (object)DBNull.Value : inv.ReceiverNameKurdish);
                    cmd.Parameters.AddWithValue("@DebtMonth",             inv.DebtMonth);
                    cmd.Parameters.AddWithValue("@DebtToMonth",           inv.DebtToMonth.HasValue ? (object)inv.DebtToMonth.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PaymentDate",           inv.PaymentDate);
                    cmd.Parameters.AddWithValue("@Amount",                inv.Amount);
                    cmd.Parameters.AddWithValue("@BillType",              string.IsNullOrEmpty(inv.BillType) ? "Mixed" : inv.BillType);
                    cmd.Parameters.AddWithValue("@InvoiceContent",        string.IsNullOrEmpty(inv.InvoiceContent)        ? (object)DBNull.Value : inv.InvoiceContent);
                    cmd.Parameters.AddWithValue("@InvoiceContentKurdish", string.IsNullOrEmpty(inv.InvoiceContentKurdish) ? (object)DBNull.Value : inv.InvoiceContentKurdish);
                    cmd.Parameters.AddWithValue("@CreatedBy",             SessionManager.CurrentUser.UserID);
                    cmd.Parameters.AddWithValue("@CreatedByName",         SessionManager.CurrentUser.FullName);

                    int newID = int.Parse(cmd.ExecuteScalar().ToString());

                    // 2. UPDATE LastInvoiceNumber in settings
                    //    Pull the number out of "INV-2026-0001" (last 4 chars)
                    string numPart = inv.InvoiceNumber.Substring(inv.InvoiceNumber.LastIndexOf('-') + 1);
                    int numValue = int.Parse(numPart);

                    // UPSERT: update if row exists, insert if it doesn't
                    // This is safe even if LastInvoiceNumber row is missing from the table
                    string updSql = @"
                        IF EXISTS (SELECT 1 FROM SystemSettings WHERE SettingKey = 'LastInvoiceNumber')
                            UPDATE SystemSettings SET SettingValue = @Value WHERE SettingKey = 'LastInvoiceNumber'
                        ELSE
                            INSERT INTO SystemSettings (SettingKey, SettingValue) VALUES ('LastInvoiceNumber', @Value)";
                    SqlCommand upd = new SqlCommand(updSql, con, tx);
                    upd.Parameters.AddWithValue("@Value", numValue.ToString());
                    upd.ExecuteNonQuery();

                    // Both succeeded — commit the transaction
                    tx.Commit();
                    return newID;
                }
                catch
                {
                    // Something failed — undo everything
                    tx.Rollback();
                    throw;
                }
            }
        }

        // -------------------------------------------------------
        // GET BY ID — read one invoice
        // -------------------------------------------------------
        public Invoice GetByID(int invoiceID)
        {
            Invoice inv = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT i.*, u.UnitName
                               FROM Invoices i
                               INNER JOIN Units u ON u.UnitID = i.UnitID
                               WHERE i.InvoiceID = @ID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", invoiceID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    inv = ReadInvoice(reader);
            }
            return inv;
        }

        // -------------------------------------------------------
        // GET BY PAYMENT ID — check if an invoice already exists
        // for a given payment. Returns null if none.
        // Used to prevent printing duplicate invoices for same payment.
        // -------------------------------------------------------
        public Invoice GetByPaymentID(int paymentID)
        {
            Invoice inv = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT i.*, u.UnitName
                               FROM Invoices i
                               INNER JOIN Units u ON u.UnitID = i.UnitID
                               WHERE i.PaymentID = @PaymentID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    inv = ReadInvoice(reader);
            }
            return inv;
        }

        // -------------------------------------------------------
        // PRIVATE HELPER — map one reader row to an Invoice object
        // -------------------------------------------------------
        private Invoice ReadInvoice(SqlDataReader reader)
        {
            return new Invoice
            {
                InvoiceID             = (int)reader["InvoiceID"],
                InvoiceNumber         = reader["InvoiceNumber"].ToString(),
                PaymentID             = reader["PaymentID"]             == DBNull.Value ? (int?)null : (int)reader["PaymentID"],
                UnitID                = (int)reader["UnitID"],
                UnitName              = reader["UnitName"].ToString(),
                GiverName             = reader["GiverName"].ToString(),
                GiverNameKurdish      = reader["GiverNameKurdish"]      == DBNull.Value ? "" : reader["GiverNameKurdish"].ToString(),
                ReceiverName          = reader["ReceiverName"].ToString(),
                ReceiverNameKurdish   = reader["ReceiverNameKurdish"]   == DBNull.Value ? "" : reader["ReceiverNameKurdish"].ToString(),
                DebtMonth             = (DateTime)reader["DebtMonth"],
                DebtToMonth           = reader["DebtToMonth"]           == DBNull.Value ? (DateTime?)null : (DateTime)reader["DebtToMonth"],
                PaymentDate           = (DateTime)reader["PaymentDate"],
                Amount                = (decimal)reader["Amount"],
                BillType              = reader["BillType"].ToString(),
                InvoiceContent        = reader["InvoiceContent"]        == DBNull.Value ? "" : reader["InvoiceContent"].ToString(),
                InvoiceContentKurdish = reader["InvoiceContentKurdish"] == DBNull.Value ? "" : reader["InvoiceContentKurdish"].ToString(),
                CreatedByName         = reader["CreatedByName"]         == DBNull.Value ? "" : reader["CreatedByName"].ToString(),
                CreatedDate           = (DateTime)reader["CreatedDate"]
            };
        }
    }
}
