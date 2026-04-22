using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    public class PaymentRepository
    {

        public int Save(Payment payment)
        {

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
            INSERT INTO Payments
            (UnitID, ForMonth, ToMonth, PaymentDate, Amount, Comment, ReceivedBy, CreatedDate)
            VALUES
            (@UnitID, @ForMonth, @ToMonth, @PaymentDate, @Amount, @Comment, @ReceivedBy, @CreatedDate);
            SELECT SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UnitID", payment.UnitID);
                cmd.Parameters.AddWithValue("@ForMonth", payment.ForMonth);
                cmd.Parameters.AddWithValue("@ToMonth", payment.ToMonth.HasValue ? (object)payment.ToMonth.Value : (object)DBNull.Value
                 );
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@Comment",
                    string.IsNullOrEmpty(payment.Comment) ? (object)DBNull.Value : payment.Comment);
                cmd.Parameters.AddWithValue("@ReceivedBy", SessionManager.CurrentUser.UserID);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
             

                conn.Open();

                return int.Parse(cmd.ExecuteScalar().ToString());

            }
        }

        public List<Payment> GetByMonth(int month, int year)
        {
            List<Payment> list = new List<Payment>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT p.PaymentID, p.UnitID, p.ForMonth, p.ToMonth, p.PaymentDate,
                                p.Amount, p.Comment, p.CreatedDate,
                                u.UnitName, u.OwnerFullName, bld.BuildingName
                         FROM Payments p
                         INNER JOIN Units u ON u.UnitID = p.UnitID
                         INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                         WHERE p.IsDeleted = 0
                           AND MONTH(p.PaymentDate) = @Month
                           AND YEAR(p.PaymentDate) = @Year
                         ORDER BY p.PaymentDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(ReadPayment(reader));
            }
            return list;
        }

        public List<Payment> Search(string keyword)
        {
            List<Payment> list = new List<Payment>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT p.PaymentID, p.UnitID, p.ForMonth, p.ToMonth, p.PaymentDate,
                                        p.Amount, p.Comment, p.CreatedDate,
                                        u.UnitName, u.OwnerFullName, bld.BuildingName
                                 FROM Payments p
                                 INNER JOIN Units u ON u.UnitID = p.UnitID
                                 INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                                 WHERE p.IsDeleted = 0
                                   AND (u.UnitName LIKE @Keyword
                                        OR u.OwnerFullName LIKE @Keyword)
                                 ORDER BY p.PaymentDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(ReadPayment(reader));
            }
            return list;
        }

        public Payment GetByID(int paymentID)
        {
            Payment p = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT p.PaymentID, p.UnitID, p.ForMonth, p.ToMonth, p.PaymentDate,
                                        p.Amount, p.Comment, p.CreatedDate,
                                        u.UnitName, u.OwnerFullName, bld.BuildingName
                                 FROM Payments p
                                 INNER JOIN Units u ON u.UnitID = p.UnitID
                                 INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                                 WHERE p.PaymentID = @PaymentID
                                   AND p.IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    p = ReadPayment(reader);
            }
            return p;
        }

        // -------------------------------------------------------
        // SOFT DELETE — hides the payment and logs it in DeletedRecords
        // Description is auto-built from the payment data so the admin
        // can recognize what was deleted even if the unit info changes later
        // -------------------------------------------------------
        public void Delete(int paymentID)
        {
            // 1. Read the payment first so we can build a readable description
            Payment p = GetByID(paymentID);
            if (p == null) return;   // already deleted or not found

            string description = string.Format(
                "Payment {0:N0} for Unit {1} ({2}) — {3:yyyy-MM-dd}",
                p.Amount, p.UnitName, p.OwnerFullName, p.PaymentDate);

            // 2. Hide payment + log it — one SQL call, two statements
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE Payments SET IsDeleted = 1 WHERE PaymentID = @PaymentID;

                               INSERT INTO DeletedRecords (TableName, RecordID, RecordDescription, DeletedBy, DeletedByName)
                               VALUES ('Payments', @PaymentID, @Description, @DeletedBy, @DeletedByName);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PaymentID",     paymentID);
                cmd.Parameters.AddWithValue("@Description",   description);
                cmd.Parameters.AddWithValue("@DeletedBy",     SessionManager.CurrentUser.UserID);
                cmd.Parameters.AddWithValue("@DeletedByName", SessionManager.CurrentUser.FullName);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        private Payment ReadPayment(SqlDataReader reader)
        {
            return new Payment
            {
                PaymentID    = (int)reader["PaymentID"],
                UnitID       = (int)reader["UnitID"],
                UnitName     = reader["UnitName"].ToString(),
                BuildingName = reader["BuildingName"].ToString(),
                OwnerFullName = reader["OwnerFullName"].ToString(),
                ForMonth     = (DateTime)reader["ForMonth"],
                ToMonth      = reader["ToMonth"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["ToMonth"],
                PaymentDate  = (DateTime)reader["PaymentDate"],
                Amount       = (decimal)reader["Amount"],
                Comment      = reader["Comment"] == DBNull.Value ? "" : reader["Comment"].ToString(),
                CreatedDate  = (DateTime)reader["CreatedDate"]
            };
        }
    }
}
