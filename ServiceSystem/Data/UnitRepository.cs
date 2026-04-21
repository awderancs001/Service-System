using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    public class UnitRepository
    {
        // -------------------------------------------------------
        // GET ALL — returns every active unit with building name
        // Notice: we JOIN Buildings table to get BuildingName
        // -------------------------------------------------------
        public List<Unit> GetAll()
        {
            List<Unit> list = new List<Unit>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT u.UnitID, u.UnitName, u.UnitType,
                                      u.BuildingID, b.BuildingName, b.BuildingCategory,
                                      u.OwnerFullName, u.OwnerPhone, u.OwnerOtherPhone, u.OwnerNation,
                                      u.HasTenant, u.TenantFullName, u.TenantPhone, u.TenantOtherPhone, u.TenantNation,
                                      u.MonthlyServiceAmount, u.IsActive
                               FROM Units u
                               INNER JOIN Buildings b ON b.BuildingID = u.BuildingID
                               WHERE u.IsActive = 1
                               ORDER BY b.BuildingName, u.UnitName";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadUnit(reader));
                }
            }

            return list;
        }

        // -------------------------------------------------------
        // GET BY ID — returns one unit by its ID
        // -------------------------------------------------------
        public Unit GetByID(int unitID)
        {
            Unit u = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT u.UnitID, u.UnitName, u.UnitType,
                                      u.BuildingID, b.BuildingName, b.BuildingCategory,
                                      u.OwnerFullName, u.OwnerPhone, u.OwnerOtherPhone, u.OwnerNation,
                                      u.HasTenant, u.TenantFullName, u.TenantPhone, u.TenantOtherPhone, u.TenantNation,
                                      u.MonthlyServiceAmount, u.IsActive
                               FROM Units u
                               INNER JOIN Buildings b ON b.BuildingID = u.BuildingID
                               WHERE u.UnitID = @UnitID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    u = ReadUnit(reader);
                }
            }

            return u;
        }

        // -------------------------------------------------------
        // GET BY NAME — search unit by name inside a building
        // Used in forms when user types unit name to autofill
        // -------------------------------------------------------
        public Unit GetByName(string unitName, int buildingID)
        {
            Unit u = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT u.UnitID, u.UnitName, u.UnitType,
                                      u.BuildingID, b.BuildingName, b.BuildingCategory,
                                      u.OwnerFullName, u.OwnerPhone, u.OwnerOtherPhone, u.OwnerNation,
                                      u.HasTenant, u.TenantFullName, u.TenantPhone, u.TenantOtherPhone, u.TenantNation,
                                      u.MonthlyServiceAmount, u.IsActive
                               FROM Units u
                               INNER JOIN Buildings b ON b.BuildingID = u.BuildingID
                               WHERE u.UnitName = @UnitName AND u.BuildingID = @BuildingID
                                 AND u.IsActive = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitName",   unitName);
                cmd.Parameters.AddWithValue("@BuildingID", buildingID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    u = ReadUnit(reader);
                }
            }

            return u;
        }

        // -------------------------------------------------------
        // GET BY BUILDING — all units in one specific building
        // Used in building reports and billing forms
        // -------------------------------------------------------
        public List<Unit> GetByBuilding(int buildingID)
        {
            List<Unit> list = new List<Unit>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT u.UnitID, u.UnitName, u.UnitType,
                                      u.BuildingID, b.BuildingName, b.BuildingCategory,
                                      u.OwnerFullName, u.OwnerPhone, u.OwnerOtherPhone, u.OwnerNation,
                                      u.HasTenant, u.TenantFullName, u.TenantPhone, u.TenantOtherPhone, u.TenantNation,
                                      u.MonthlyServiceAmount, u.IsActive
                               FROM Units u
                               INNER JOIN Buildings b ON b.BuildingID = u.BuildingID
                               WHERE u.BuildingID = @BuildingID AND u.IsActive = 1
                               ORDER BY u.UnitName";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingID", buildingID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadUnit(reader));
                }
            }

            return list;
        }

        // -------------------------------------------------------
        // SEARCH — find units by owner name or unit name
        // Used in the search box on Unit management form
        // -------------------------------------------------------
        public List<Unit> Search(string keyword)
        {
            List<Unit> list = new List<Unit>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT u.UnitID, u.UnitName, u.UnitType,
                   u.BuildingID, b.BuildingName, b.BuildingCategory,
                   u.OwnerFullName, u.OwnerPhone, u.OwnerOtherPhone, u.OwnerNation,
                   u.HasTenant, u.TenantFullName, u.TenantPhone, u.TenantOtherPhone, u.TenantNation,
                   u.MonthlyServiceAmount, u.IsActive
                   FROM Units u
                  INNER JOIN Buildings b ON b.BuildingID = u.BuildingID
                    WHERE u.IsActive = 1
                    AND (u.UnitName     LIKE @Keyword
                       OR  u.OwnerFullName LIKE @Keyword
                       OR  u.OwnerPhone    LIKE @Keyword)
                     ORDER BY b.BuildingName, u.UnitName";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadUnit(reader));
                }
            }

            return list;
        }

        // -------------------------------------------------------
        // SAVE — inserts a new unit
        // Returns the new UnitID
        // -------------------------------------------------------
        public int Save(Unit u)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"INSERT INTO Units
                                (BuildingID, UnitName, UnitType,
                                 OwnerFullName, OwnerPhone, OwnerOtherPhone, OwnerNation,
                                 HasTenant, TenantFullName, TenantPhone, TenantOtherPhone, TenantNation,
                                 MonthlyServiceAmount, CreatedBy)
                               VALUES
                                (@BuildingID, @UnitName, @UnitType,
                                 @OwnerFullName, @OwnerPhone, @OwnerOtherPhone, @OwnerNation,
                                 @HasTenant, @TenantFullName, @TenantPhone, @TenantOtherPhone, @TenantNation,
                                 @MonthlyServiceAmount, @CreatedBy);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingID",           u.BuildingID);
                cmd.Parameters.AddWithValue("@UnitName",             u.UnitName);
                cmd.Parameters.AddWithValue("@UnitType",             string.IsNullOrEmpty(u.UnitType)        ? (object)DBNull.Value : u.UnitType);
                cmd.Parameters.AddWithValue("@OwnerFullName",        u.OwnerFullName);
                cmd.Parameters.AddWithValue("@OwnerPhone",           u.OwnerPhone);
                cmd.Parameters.AddWithValue("@OwnerOtherPhone",      string.IsNullOrEmpty(u.OwnerOtherPhone) ? (object)DBNull.Value : u.OwnerOtherPhone);
                cmd.Parameters.AddWithValue("@OwnerNation",          string.IsNullOrEmpty(u.OwnerNation)     ? (object)DBNull.Value : u.OwnerNation);
                cmd.Parameters.AddWithValue("@HasTenant",            u.HasTenant);
                cmd.Parameters.AddWithValue("@TenantFullName",       string.IsNullOrEmpty(u.TenantFullName)  ? (object)DBNull.Value : u.TenantFullName);
                cmd.Parameters.AddWithValue("@TenantPhone",          string.IsNullOrEmpty(u.TenantPhone)     ? (object)DBNull.Value : u.TenantPhone);
                cmd.Parameters.AddWithValue("@TenantOtherPhone",     string.IsNullOrEmpty(u.TenantOtherPhone)? (object)DBNull.Value : u.TenantOtherPhone);
                cmd.Parameters.AddWithValue("@TenantNation",         string.IsNullOrEmpty(u.TenantNation)    ? (object)DBNull.Value : u.TenantNation);
                cmd.Parameters.AddWithValue("@MonthlyServiceAmount", u.MonthlyServiceAmount);
                cmd.Parameters.AddWithValue("@CreatedBy",            SessionManager.CurrentUser.UserID);
                con.Open();

                int newID = int.Parse(cmd.ExecuteScalar().ToString());
                return newID;
            }
        }

        // -------------------------------------------------------
        // UPDATE — updates an existing unit
        // -------------------------------------------------------
        public void Update(Unit u)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE Units SET
                                BuildingID           = @BuildingID,
                                UnitName             = @UnitName,
                                UnitType             = @UnitType,
                                OwnerFullName        = @OwnerFullName,
                                OwnerPhone           = @OwnerPhone,
                                OwnerOtherPhone      = @OwnerOtherPhone,
                                OwnerNation          = @OwnerNation,
                                HasTenant            = @HasTenant,
                                TenantFullName       = @TenantFullName,
                                TenantPhone          = @TenantPhone,
                                TenantOtherPhone     = @TenantOtherPhone,
                                TenantNation         = @TenantNation,
                                MonthlyServiceAmount = @MonthlyServiceAmount
                               WHERE UnitID = @UnitID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingID",           u.BuildingID);
                cmd.Parameters.AddWithValue("@UnitName",             u.UnitName);
                cmd.Parameters.AddWithValue("@UnitType",             string.IsNullOrEmpty(u.UnitType)         ? (object)DBNull.Value : u.UnitType);
                cmd.Parameters.AddWithValue("@OwnerFullName",        u.OwnerFullName);
                cmd.Parameters.AddWithValue("@OwnerPhone",           u.OwnerPhone);
                cmd.Parameters.AddWithValue("@OwnerOtherPhone",      string.IsNullOrEmpty(u.OwnerOtherPhone)  ? (object)DBNull.Value : u.OwnerOtherPhone);
                cmd.Parameters.AddWithValue("@OwnerNation",          string.IsNullOrEmpty(u.OwnerNation)      ? (object)DBNull.Value : u.OwnerNation);
                cmd.Parameters.AddWithValue("@HasTenant",            u.HasTenant);
                cmd.Parameters.AddWithValue("@TenantFullName",       string.IsNullOrEmpty(u.TenantFullName)   ? (object)DBNull.Value : u.TenantFullName);
                cmd.Parameters.AddWithValue("@TenantPhone",          string.IsNullOrEmpty(u.TenantPhone)      ? (object)DBNull.Value : u.TenantPhone);
                cmd.Parameters.AddWithValue("@TenantOtherPhone",     string.IsNullOrEmpty(u.TenantOtherPhone) ? (object)DBNull.Value : u.TenantOtherPhone);
                cmd.Parameters.AddWithValue("@TenantNation",         string.IsNullOrEmpty(u.TenantNation)     ? (object)DBNull.Value : u.TenantNation);
                cmd.Parameters.AddWithValue("@MonthlyServiceAmount", u.MonthlyServiceAmount);
                cmd.Parameters.AddWithValue("@UnitID",               u.UnitID);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------
        // SOFT DELETE — marks unit as inactive, does NOT delete data
        // All bills and payments linked to this unit stay safe
        // Also logs the deletion to DeletedRecords table
        // -------------------------------------------------------
        public void Delete(int unitID, string description)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                // Two SQL statements in one call:
                // 1. Mark unit as inactive
                // 2. Log it in DeletedRecords
                string sql = @"UPDATE Units SET IsActive = 0 WHERE UnitID = @UnitID;

                               INSERT INTO DeletedRecords (TableName, RecordID, RecordDescription, DeletedBy, DeletedByName)
                               VALUES ('Units', @UnitID, @Description, @DeletedBy, @DeletedByName);";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID",        unitID);
                cmd.Parameters.AddWithValue("@Description",   description);
                cmd.Parameters.AddWithValue("@DeletedBy",     SessionManager.CurrentUser.UserID);
                cmd.Parameters.AddWithValue("@DeletedByName", SessionManager.CurrentUser.FullName);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------
        // NAME EXISTS — check for duplicate unit name in same building
        // excludeID is used when editing — exclude the unit itself
        // -------------------------------------------------------
        public bool NameExists(string unitName, int buildingID, int excludeID = 0)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Units
                               WHERE UnitName = @UnitName
                                 AND BuildingID = @BuildingID
                                 AND UnitID != @ExcludeID
                                 AND IsActive = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitName",   unitName);
                cmd.Parameters.AddWithValue("@BuildingID", buildingID);
                cmd.Parameters.AddWithValue("@ExcludeID",  excludeID);
                con.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // -------------------------------------------------------
        // GET BALANCE — quick totals for one unit
        // Reads from the SQL view vw_UnitBalances (already calculated by DB)
        // Returns: TotalCharged, TotalPaid, Balance
        // -------------------------------------------------------
        public UnitBalance GetBalance(int unitID)
        {
            UnitBalance bal = new UnitBalance();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT TotalCharged, TotalPaid, Balance
                               FROM vw_UnitBalances
                               WHERE UnitID = @UnitID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bal.TotalCharged = (decimal)reader["TotalCharged"];
                    bal.TotalPaid    = (decimal)reader["TotalPaid"];
                    bal.Balance      = (decimal)reader["Balance"];
                }
            }

            return bal;
        }

        // -------------------------------------------------------
        // GET HISTORY — full history of debts and payments for a unit
        // Combines 3 bill tables + Payments table with UNION ALL
        //   - Bills go into the Debt column   (Paid = 0)
        //   - Payments go into the Paid column (Debt = 0)
        // Ordered by CreatedDate (newest first) so the most recent
        // activity appears at the top of the grid.
        // -------------------------------------------------------
        public List<UnitHistoryItem> GetHistory(int unitID)
        {
            List<UnitHistoryItem> list = new List<UnitHistoryItem>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"
                    SELECT 'Service' AS Type, BillMonth AS Month,
                           Amount AS Debt, 0 AS Paid,
                           Notes AS Note, CreatedDate
                    FROM MonthlyServiceBills
                    WHERE UnitID = @UnitID

                    UNION ALL

                    SELECT 'Maintenance', BillMonth,
                           Amount, 0,
                           Description, CreatedDate
                    FROM MaintenanceBills
                    WHERE UnitID = @UnitID

                    UNION ALL

                    SELECT 'Electric', BillMonth,
                           TotalAmount, 0,
                           Notes, CreatedDate
                    FROM ElectricBills
                    WHERE UnitID = @UnitID

                    UNION ALL

                    SELECT 'Payment', ForMonth,
                           0, Amount,
                           Comment, CreatedDate
                    FROM Payments
                    WHERE UnitID = @UnitID

                    ORDER BY CreatedDate DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new UnitHistoryItem
                    {
                        Type        = reader["Type"].ToString(),
                        Month       = (DateTime)reader["Month"],
                        Debt        = (decimal)reader["Debt"],
                        Paid        = (decimal)reader["Paid"],
                        Note        = reader["Note"] == DBNull.Value ? "" : reader["Note"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
            }

            return list;
        }

        public List<UnitHistoryItem> GetHistoryByDateRange(int unitID, DateTime from, DateTime to)
        {
            List<UnitHistoryItem> list = new List<UnitHistoryItem>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"
            SELECT 'Service' AS Type, BillMonth AS Month,
                   Amount AS Debt, 0 AS Paid,
                   Notes AS Note, CreatedDate
            FROM MonthlyServiceBills
            WHERE UnitID = @UnitID
              AND BillMonth BETWEEN @From AND @To

            UNION ALL

            SELECT 'Maintenance', BillMonth,
                   Amount, 0,
                   Description, CreatedDate
            FROM MaintenanceBills
            WHERE UnitID = @UnitID
              AND BillMonth BETWEEN @From AND @To

            UNION ALL

            SELECT 'Electric', BillMonth,
                   TotalAmount, 0,
                   Notes, CreatedDate
            FROM ElectricBills
            WHERE UnitID = @UnitID
              AND BillMonth BETWEEN @From AND @To

            UNION ALL

            SELECT 'Payment', ForMonth,
                   0, Amount,
                   Comment, CreatedDate
            FROM Payments
            WHERE UnitID = @UnitID
              AND ForMonth BETWEEN @From AND @To

            ORDER BY CreatedDate DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                cmd.Parameters.AddWithValue("@From", from);
                cmd.Parameters.AddWithValue("@To", to);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new UnitHistoryItem
                    {
                        Type = reader["Type"].ToString(),
                        Month = (DateTime)reader["Month"],
                        Debt = (decimal)reader["Debt"],
                        Paid = (decimal)reader["Paid"],
                        Note = reader["Note"] == DBNull.Value ? "" : reader["Note"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
            }
            return list;
        }

        // -------------------------------------------------------
        // PRIVATE HELPER — reads one unit from the reader
        // We use this in every method above to avoid repeating
        // the same 15 lines of reader["field"] code everywhere
        // -------------------------------------------------------
        private Unit ReadUnit(SqlDataReader reader)
        {
            Unit u = new Unit();
            u.UnitID               = (int)reader["UnitID"];
            u.BuildingID           = (int)reader["BuildingID"];
            u.BuildingName         = reader["BuildingName"].ToString();
            u.UnitName             = reader["UnitName"].ToString();
            u.UnitType             = reader["UnitType"]        == DBNull.Value ? "" : reader["UnitType"].ToString();
            u.OwnerFullName        = reader["OwnerFullName"].ToString();
            u.OwnerPhone           = reader["OwnerPhone"].ToString();
            u.OwnerOtherPhone      = reader["OwnerOtherPhone"] == DBNull.Value ? "" : reader["OwnerOtherPhone"].ToString();
            u.OwnerNation          = reader["OwnerNation"]     == DBNull.Value ? "" : reader["OwnerNation"].ToString();
            u.HasTenant            = (bool)reader["HasTenant"];
            u.TenantFullName       = reader["TenantFullName"]  == DBNull.Value ? "" : reader["TenantFullName"].ToString();
            u.TenantPhone          = reader["TenantPhone"]     == DBNull.Value ? "" : reader["TenantPhone"].ToString();
            u.TenantOtherPhone     = reader["TenantOtherPhone"]== DBNull.Value ? "" : reader["TenantOtherPhone"].ToString();
            u.TenantNation         = reader["TenantNation"]    == DBNull.Value ? "" : reader["TenantNation"].ToString();
            u.MonthlyServiceAmount = (decimal)reader["MonthlyServiceAmount"];
            u.IsActive             = (bool)reader["IsActive"];
            return u;
        }
    }
}
