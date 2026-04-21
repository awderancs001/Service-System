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
                                 WHERE MONTH(p.PaymentDate) = @Month AND YEAR(p.PaymentDate) = @Year
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
                                 WHERE u.UnitName LIKE @Keyword
                                    OR u.OwnerFullName LIKE @Keyword
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
                                 WHERE p.PaymentID = @PaymentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    p = ReadPayment(reader);
            }
            return p;
        }

        public void Delete(int paymentID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();

                try
                {
                    // 1. Delete the invoice linked to this payment first (if any)
                    //    We must delete the child (Invoice) before the parent (Payment)
                    //    because of the foreign key constraint
                    string deleteInvoice = "DELETE FROM Invoices WHERE PaymentID = @PaymentID";
                    SqlCommand cmdInvoice = new SqlCommand(deleteInvoice, conn, tx);
                    cmdInvoice.Parameters.AddWithValue("@PaymentID", paymentID);
                    cmdInvoice.ExecuteNonQuery();

                    // 2. Now delete the payment safely
                    string deletePayment = "DELETE FROM Payments WHERE PaymentID = @PaymentID";
                    SqlCommand cmdPayment = new SqlCommand(deletePayment, conn, tx);
                    cmdPayment.Parameters.AddWithValue("@PaymentID", paymentID);
                    cmdPayment.ExecuteNonQuery();

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
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
