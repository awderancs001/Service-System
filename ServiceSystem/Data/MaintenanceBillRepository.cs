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
                               WHERE b.BillMonth = @BillMonth
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

        public void Delete(int billID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                
                string query = @"delete from MaintenanceBills where MaintenanceID  = @billID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@billID", billID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
