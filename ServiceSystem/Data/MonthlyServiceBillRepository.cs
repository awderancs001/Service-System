using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    public class MonthlyServiceBillRepository
    {
        // -------------------------------------------------------
        // BILL EXISTS — check if a bill already exists for this
        // unit and month. We always check before saving to avoid
        // creating duplicate bills for the same unit/month.
        // -------------------------------------------------------
        public bool BillExists(int unitID, DateTime month)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM MonthlyServiceBills
                               WHERE UnitID = @UnitID
                               AND BillMonth = @BillMonth
                               AND IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID",    unitID);
                cmd.Parameters.AddWithValue("@BillMonth", new DateTime(month.Year, month.Month, 1));
                con.Open();

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // -------------------------------------------------------
        // SAVE — creates a bill for ONE unit
        // Returns the new BillID
        // -------------------------------------------------------
        public int Save(MonthlyServiceBill bill)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"INSERT INTO MonthlyServiceBills (UnitID, BillMonth, Amount, Notes, CreatedBy)
                               VALUES (@UnitID, @BillMonth, @Amount, @Notes, @CreatedBy);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID",    bill.UnitID);
                cmd.Parameters.AddWithValue("@BillMonth", new DateTime(bill.BillMonth.Year, bill.BillMonth.Month, 1));
                cmd.Parameters.AddWithValue("@Amount",    bill.Amount);
                cmd.Parameters.AddWithValue("@Notes",     string.IsNullOrEmpty(bill.Notes) ? (object)DBNull.Value : bill.Notes);
                cmd.Parameters.AddWithValue("@CreatedBy", SessionManager.CurrentUser.UserID);
                con.Open();

                return int.Parse(cmd.ExecuteScalar().ToString());
            }
        }

        // -------------------------------------------------------
        // SAVE BULK — creates bills for ALL units in a building
        // for a specific month. Skips units that already have
        // a bill for that month. Returns how many bills created.
        // -------------------------------------------------------
        public int SaveBulk(int month, int year)
        {
            DateTime billMonth = new DateTime(year, month, 1);
            int count = 0;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();

                // Start a transaction — everything below is all-or-nothing
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        // Get ALL active units across all buildings
                        string getUnits = @"SELECT UnitID, MonthlyServiceAmount
                                    FROM Units
                                    WHERE IsActive = 1";

                        SqlCommand getCmd = new SqlCommand(getUnits, con, tx);

                        List<(int unitID, decimal amount)> units = new List<(int, decimal)>();

                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                units.Add(((int)reader["UnitID"], (decimal)reader["MonthlyServiceAmount"]));
                            }
                        }

                        // For each unit, insert a bill only if one doesn't already exist
                        foreach (var unit in units)
                        {
                            string checkSql = @"SELECT COUNT(*) FROM MonthlyServiceBills
                                        WHERE UnitID = @UnitID AND BillMonth = @BillMonth
                                        AND IsDeleted = 0";

                            SqlCommand checkCmd = new SqlCommand(checkSql, con, tx);
                            checkCmd.Parameters.AddWithValue("@UnitID", unit.unitID);
                            checkCmd.Parameters.AddWithValue("@BillMonth", billMonth);

                            int exists = (int)checkCmd.ExecuteScalar();
                            if (exists > 0) continue;  // already has a bill this month — skip

                            string insertSql = @"INSERT INTO MonthlyServiceBills (UnitID, BillMonth, Amount, CreatedBy)
                                         VALUES (@UnitID, @BillMonth, @Amount, @CreatedBy)";

                            SqlCommand insertCmd = new SqlCommand(insertSql, con, tx);
                            insertCmd.Parameters.AddWithValue("@UnitID", unit.unitID);
                            insertCmd.Parameters.AddWithValue("@BillMonth", billMonth);
                            insertCmd.Parameters.AddWithValue("@Amount", unit.amount);
                            insertCmd.Parameters.AddWithValue("@CreatedBy", SessionManager.CurrentUser.UserID);
                            insertCmd.ExecuteNonQuery();

                            count++;
                        }

                        // All inserts succeeded — commit (make them permanent)
                        tx.Commit();
                    }
                    catch
                    {
                        // Something went wrong — undo everything inserted so far
                        tx.Rollback();
                        throw;  // re-throw so the form can show the error
                    }
                }
            }

            return count;
        }

        // -------------------------------------------------------
        // GET BY UNIT — all bills for one specific unit
        // Used in unit history view
        // -------------------------------------------------------
        public List<MonthlyServiceBill> GetByUnit(int unitID)
        {
            List<MonthlyServiceBill> list = new List<MonthlyServiceBill>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT b.BillID, b.UnitID, b.BillMonth, b.Amount, b.Notes, b.CreatedDate,
                                      u.UnitName, bld.BuildingName, u.OwnerFullName
                               FROM MonthlyServiceBills b
                               INNER JOIN Units u ON u.UnitID = b.UnitID
                               INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                               WHERE b.UnitID = @UnitID AND b.IsDeleted = 0
                               ORDER BY b.BillMonth DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(ReadBill(reader));
            }

            return list;
        }

        // -------------------------------------------------------
        // GET BY MONTH — all bills for a specific month
        // Used in monthly overview and reports
        // -------------------------------------------------------
        public List<MonthlyServiceBill> GetByMonth(DateTime month)
        {
            List<MonthlyServiceBill> list = new List<MonthlyServiceBill>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT b.BillID, b.UnitID, b.BillMonth, b.Amount, b.Notes, b.CreatedDate,
                                      u.UnitName, bld.BuildingName,u.OwnerFullName
                               FROM MonthlyServiceBills b
                               INNER JOIN Units u ON u.UnitID = b.UnitID
                               INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                               WHERE b.BillMonth = @BillMonth AND b.IsDeleted = 0
                               ORDER BY bld.BuildingName, u.UnitName";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BillMonth", new DateTime(month.Year, month.Month, 1));
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(ReadBill(reader));
            }

            return list;
        }

        // -------------------------------------------------------
        // GET BY ID — one bill, used to build delete description
        // -------------------------------------------------------
        public MonthlyServiceBill GetByID(int billID)
        {
            MonthlyServiceBill b = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT b.BillID, b.UnitID, b.BillMonth, b.Amount, b.Notes, b.CreatedDate,
                                      u.UnitName, bld.BuildingName, u.OwnerFullName
                               FROM MonthlyServiceBills b
                               INNER JOIN Units u ON u.UnitID = b.UnitID
                               INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                               WHERE b.BillID = @BillID AND b.IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BillID", billID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    b = ReadBill(reader);
            }

            return b;
        }

        // -------------------------------------------------------
        // SOFT DELETE — hides the bill and logs it in DeletedRecords
        // -------------------------------------------------------
        public void Delete(int billID)
        {
            MonthlyServiceBill b = GetByID(billID);
            if (b == null) return;

            string description = string.Format(
                "Service Bill {0:N0} — Unit {1} ({2}) — {3:yyyy-MM}",
                b.Amount, b.UnitName, b.OwnerName, b.BillMonth);

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE MonthlyServiceBills SET IsDeleted = 1 WHERE BillID = @BillID;

                               INSERT INTO DeletedRecords (TableName, RecordID, RecordDescription, DeletedBy, DeletedByName)
                               VALUES ('MonthlyServiceBills', @BillID, @Description, @DeletedBy, @DeletedByName);";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BillID",        billID);
                cmd.Parameters.AddWithValue("@Description",   description);
                cmd.Parameters.AddWithValue("@DeletedBy",     SessionManager.CurrentUser.UserID);
                cmd.Parameters.AddWithValue("@DeletedByName", SessionManager.CurrentUser.FullName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------
        // PRIVATE HELPER — reads one bill from the reader
        // -------------------------------------------------------
        private MonthlyServiceBill ReadBill(SqlDataReader reader)
        {
            return new MonthlyServiceBill
            {
                BillID       = (int)reader["BillID"],
                UnitID       = (int)reader["UnitID"],
                UnitName     = reader["UnitName"].ToString(),
                BuildingName = reader["BuildingName"].ToString(),
                OwnerName    = reader["OwnerFullName"].ToString(),
                BillMonth    = (DateTime)reader["BillMonth"],
                Amount       = (decimal)reader["Amount"],
                Notes        = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString(),
                CreatedDate  = (DateTime)reader["CreatedDate"]
            };
        }
    }
}
