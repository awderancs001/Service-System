using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSystem.Models;
using System.Data.SqlClient;


namespace ServiceSystem.Data
{
    public class ElectricBillRepository
    {
        public int Save(ElectricBill bill)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO ElectricBills
           ( UnitID
           , BillMonth
           , BeginReading
           , EndReading
           , PricePerUnit
           , Notes
           , CreatedBy)
     VALUES
           (@UnitID
           ,@BillMonth
           ,@BeginReading
           ,@EndReading
           ,@PricePerUnit
           ,@Notes
           ,@CreatedBy);
            SELECT SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UnitID", bill.UnitID);
                cmd.Parameters.AddWithValue("@BillMonth", 
                    new DateTime(bill.BillMonth.Year, bill.BillMonth.Month, 1));
                cmd.Parameters.AddWithValue("@BeginReading",bill.BeginReading);
                cmd.Parameters.AddWithValue("@EndReading", bill.EndReading);
                cmd.Parameters.AddWithValue("@PricePerUnit", bill.PricePerUnit);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(bill.Notes)?
                    (object)DBNull.Value : bill.Notes);
                cmd.Parameters.AddWithValue("@CreatedBy", SessionManager.CurrentUser.UserID);

                conn.Open();

                return int.Parse(cmd.ExecuteScalar().ToString());

            }
        }

        public bool IsBillExist(int unitID, DateTime Month)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"select COUNT(*) from ElectricBills
                                    where UnitID = @unitID
                                    and BillMonth = @Month";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@unitID", unitID);
                cmd.Parameters.AddWithValue("@Month", new DateTime(Month.Year, Month.Month, 1));

                conn.Open();
                return (int)cmd.ExecuteScalar()>0;

            }

            
        }

        public List<ElectricBill> GetByMonth(DateTime Month)
        {
            List<ElectricBill> list = new List<ElectricBill>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT b.ElectricID, b.UnitID, b.BillMonth,
                                        b.BeginReading, b.EndReading, b.PricePerUnit,
                                        b.TotalAmount, b.Notes, b.CreatedDate,
                                        u.UnitName, bld.BuildingName, u.OwnerFullName
                                 FROM ElectricBills b
                                 INNER JOIN Units u ON u.UnitID = b.UnitID
                                 INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID
                                 WHERE b.BillMonth = @BillMonth
                                 ORDER BY bld.BuildingName, u.UnitName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BillMonth", new DateTime(Month.Year, Month.Month, 1));
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(ReadBill(reader));
            }
            return list;
        }

        public void Delete(int electricID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM ElectricBills WHERE ElectricID = @ElectricID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ElectricID", electricID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private ElectricBill ReadBill(SqlDataReader reader)
        {
            return new ElectricBill
            {
                ElectricID   = (int)reader["ElectricID"],
                UnitID       = (int)reader["UnitID"],
                UnitName     = reader["UnitName"].ToString(),
                BuildingName = reader["BuildingName"].ToString(),
                OwnerName    = reader["OwnerFullName"].ToString(),
                BillMonth    = (DateTime)reader["BillMonth"],
                BeginReading = (decimal)reader["BeginReading"],
                EndReading   = (decimal)reader["EndReading"],
                PricePerUnit = (decimal)reader["PricePerUnit"],
                TotalAmount  = (decimal)reader["TotalAmount"],
                Notes        = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString(),
                CreatedDate  = (DateTime)reader["CreatedDate"]
            };
        }
    }
}
