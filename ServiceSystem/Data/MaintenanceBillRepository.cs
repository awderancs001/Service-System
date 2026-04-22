using ServiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ServiceSystem.Data
{
    public class MaintenanceBillRepository
    {
        public int Save(MaintenanceBill bill)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO MaintenanceBills(UnitID, BillMonth, Amount, Description, CreatedBy)
                                 VALUES(@UnitID, @BillMonth, @Amount, @Description, @CreatedBy);
                                    SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UnitID", bill.UnitID);
                cmd.Parameters.AddWithValue("@BillMonth", new DateTime(bill.BillMonth.Year, bill.BillMonth.Month, 1));
                cmd.Parameters.AddWithValue("@Amount", bill.Amount);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(bill.Description) ? (object)DBNull.Value : bill.Description);
                cmd.Parameters.AddWithValue("@CreatedBy", SessionManager.CurrentUser.UserID);
                conn.Open();

                return int.Parse(cmd.ExecuteScalar().ToString());

            }


        }

        public int SaveBulk(int month, int year, decimal amount, string Description)
        {
            DateTime billMonth = new DateTime(year, month, 1);
            int count = 0;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"SELECT UnitID FROM Units WHERE IsActive = 1";

                SqlCommand getcmd = new SqlCommand(query, conn);
                SqlDataReader reader = getcmd.ExecuteReader();

                List<int> units = new List<int>();

                while (reader.Read())
                {
                    units.Add((int)reader["UnitID"]);
                }

                reader.Close();

                foreach (var u in units)
                {
                    string insertSql = @"INSERT INTO MaintenanceBills (UnitID, BillMonth, Amount, Description, CreatedBy)
                         VALUES (@UnitID, @BillMonth, @Amount, @Description, @CreatedBy)";

                    SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("@UnitID", u);
                    insertCmd.Parameters.AddWithValue("@BillMonth", billMonth);
                    insertCmd.Parameters.AddWithValue("@Amount", amount);        // same for everyone
                    insertCmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? (object)DBNull.Value : Description);
                    insertCmd.Parameters.AddWithValue("@CreatedBy", SessionManager.CurrentUser.UserID);
                    insertCmd.ExecuteNonQuery();

                    count++;
                }
                return count;
            }

        }

        public List<MaintenanceBill> GetByMonth(DateTime month)
        {
            List<MaintenanceBill> list = new List<MaintenanceBill>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())

            {
                string query = @"SELECT b.MaintenanceID, b.UnitID, b.BillMonth, b.Amount, b.Description, b.CreatedDate,
                                      u.UnitName, bld.BuildingName,u.OwnerFullName
                               FROM MaintenanceBills b
                               INNER JOIN Units u ON u.UnitID = b.UnitID
                               INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                               WHERE b.BillMonth = @BillMonth AND b.IsDeleted = 0
                               ORDER BY bld.BuildingName, u.UnitName";

                SqlCommand getMonth = new SqlCommand(query, conn);
                getMonth.Parameters.AddWithValue("@BillMonth", new DateTime(month.Year, month.Month, 1));
                
                conn.Open();
                SqlDataReader reader = getMonth.ExecuteReader();
                
                while (reader.Read())
                list.Add(ReadBill(reader));
                }

                return list;
            
        }

        private MaintenanceBill ReadBill(SqlDataReader reader)
        {
            return new MaintenanceBill
            {
                MaintenanceID = (int)reader["MaintenanceID"],
                UnitID = (int)reader["UnitID"],
                BillMonth = (DateTime)reader["BillMonth"],
                Amount = (decimal)reader["Amount"],
                Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),  // ✅
                CreatedDate = (DateTime)reader["CreatedDate"],
                UnitName = reader["UnitName"].ToString(),
                BuildingName = reader["BuildingName"].ToString(),
                OwnerName = reader["OwnerFullName"].ToString(),

            };
        }

        public MaintenanceBill GetByID(int billID)
        {
            MaintenanceBill b = null;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT b.MaintenanceID, b.UnitID, b.BillMonth, b.Amount, b.Description, b.CreatedDate,
                                        u.UnitName, bld.BuildingName, u.OwnerFullName
                                 FROM MaintenanceBills b
                                 INNER JOIN Units u ON u.UnitID = b.UnitID
                                 INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                                 WHERE b.MaintenanceID = @BillID AND b.IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BillID", billID);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    b = ReadBill(reader);
            }

            return b;
        }

        public void Delete(int billID)
        {
            MaintenanceBill b = GetByID(billID);
            if (b == null) return;

            string description = string.Format(
                "Maintenance Bill {0:N0} — Unit {1} ({2}) — {3:yyyy-MM}",
                b.Amount, b.UnitName, b.OwnerName, b.BillMonth);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE MaintenanceBills SET IsDeleted = 1 WHERE MaintenanceID = @BillID;

                                 INSERT INTO DeletedRecords (TableName, RecordID, RecordDescription, DeletedBy, DeletedByName)
                                 VALUES ('MaintenanceBills', @BillID, @Description, @DeletedBy, @DeletedByName);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BillID",        billID);
                cmd.Parameters.AddWithValue("@Description",   description);
                cmd.Parameters.AddWithValue("@DeletedBy",     SessionManager.CurrentUser.UserID);
                cmd.Parameters.AddWithValue("@DeletedByName", SessionManager.CurrentUser.FullName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
