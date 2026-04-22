using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    // -------------------------------------------------------
    // ReportsRepository
    // Read-only queries that combine data across tables
    // for reports — debtors, payment history, unpaid bills, etc.
    // -------------------------------------------------------
    public class ReportsRepository
    {

        public List<Unit> GetUnitDirectory()
        {
            List<Unit> list = new List<Unit>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT u.UnitName, u.OwnerFullName, u.OwnerPhone,
                        u.MonthlyServiceAmount, bld.BuildingName 
                        FROM Units u
                        INNER JOIN Buildings  bld ON bld.BuildingID = u.BuildingID
                        WHERE u.isActive = 1
                        ORDER BY BuildingName, UnitName";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Unit
                    {
                        // Fill these from reader["ColumnName"]
                        UnitName = reader["UnitName"].ToString(),
                        OwnerFullName = reader["OwnerFullName"].ToString(),
                        OwnerPhone = reader["OwnerPhone"].ToString(),
                        BuildingName = reader["BuildingName"].ToString(),
                        MonthlyServiceAmount = (decimal)reader["MonthlyServiceAmount"]
                    });
                }
            }
            return list;
        }

        public List<DebtorItem> GetDebtorsList(
             DateTime from, DateTime to,
             bool includeService, bool includeMaintenance, bool includeElectric)
        {
            List<DebtorItem> list = new List<DebtorItem>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
            SELECT
                u.UnitID,
                u.UnitName,
                u.OwnerFullName,
                u.OwnerPhone,
                bld.BuildingName,
                ISNULL(charges.Total, 0) AS TotalCharged,
                ISNULL(pays.Total, 0)    AS TotalPaid,
                ISNULL(charges.Total, 0) - ISNULL(pays.Total, 0) AS Balance
            FROM Units u
            INNER JOIN Buildings bld ON bld.BuildingID = u.BuildingID

            LEFT JOIN (
                SELECT UnitID, SUM(Amount) AS Total
                FROM (
                    SELECT UnitID, Amount FROM MonthlyServiceBills
                        WHERE BillMonth BETWEEN @From AND @To AND @IncludeService = 1 AND IsDeleted = 0
                    UNION ALL
                    SELECT UnitID, Amount FROM MaintenanceBills
                        WHERE BillMonth BETWEEN @From AND @To AND @IncludeMaintenance = 1 AND IsDeleted = 0
                    UNION ALL
                    SELECT UnitID, TotalAmount FROM ElectricBills
                        WHERE BillMonth BETWEEN @From AND @To AND @IncludeElectric = 1 AND IsDeleted = 0
                ) allBills
                GROUP BY UnitID
            ) charges ON charges.UnitID = u.UnitID

            LEFT JOIN (
                SELECT UnitID, SUM(Amount) AS Total
                FROM Payments
                WHERE ForMonth BETWEEN @From AND @To AND IsDeleted = 0
                GROUP BY UnitID
            ) pays ON pays.UnitID = u.UnitID

            WHERE u.IsActive = 1
              AND (ISNULL(charges.Total, 0) - ISNULL(pays.Total, 0)) > 0
            ORDER BY Balance DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@From", from);
                cmd.Parameters.AddWithValue("@To", to);
                cmd.Parameters.AddWithValue("@IncludeService", includeService ? 1 : 0);
                cmd.Parameters.AddWithValue("@IncludeMaintenance", includeMaintenance ? 1 : 0);
                cmd.Parameters.AddWithValue("@IncludeElectric", includeElectric ? 1 : 0);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DebtorItem
                    {
                        UnitID = (int)reader["UnitID"],
                        UnitName = reader["UnitName"].ToString(),
                        OwnerFullName = reader["OwnerFullName"].ToString(),
                        OwnerPhone = reader["OwnerPhone"] == DBNull.Value ? "" : reader["OwnerPhone"].ToString(),
                        BuildingName = reader["BuildingName"].ToString(),
                        TotalCharged = (decimal)reader["TotalCharged"],
                        TotalPaid = (decimal)reader["TotalPaid"],
                        Balance = (decimal)reader["Balance"]
                    });
                }
            }
            return list;
        }

        public void GetGlobalDateRange(out DateTime min, out DateTime max)
        {
            // Default values if there's no data yet
            min = DateTime.Now;
            max = DateTime.Now;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = @"
            SELECT MIN(d) AS MinDate, MAX(d) AS MaxDate
            FROM (
                SELECT BillMonth AS d FROM MonthlyServiceBills WHERE IsDeleted = 0
                UNION ALL
                SELECT BillMonth FROM MaintenanceBills WHERE IsDeleted = 0
                UNION ALL
                SELECT BillMonth FROM ElectricBills WHERE IsDeleted = 0
                UNION ALL
                SELECT ForMonth FROM Payments WHERE IsDeleted = 0
            ) allDates";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["MinDate"] != DBNull.Value) min = (DateTime)reader["MinDate"];
                    if (reader["MaxDate"] != DBNull.Value) max = (DateTime)reader["MaxDate"];
                }
            }
        }

        public List<Payment> GetPaymentHistory(DateTime from, DateTime to)
        {
            List<Payment> list = new List<Payment>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
            SELECT p.PaymentID, p.UnitID, p.ForMonth, p.ToMonth, p.PaymentDate,
                   p.Amount, p.Comment, p.CreatedDate,
                   u.UnitName, u.OwnerFullName, bld.BuildingName,
                   usr.FullName AS ReceivedByName
            FROM Payments p
            INNER JOIN Units u         ON u.UnitID = p.UnitID
            INNER JOIN Buildings bld   ON bld.BuildingID = u.BuildingID
            LEFT JOIN Users usr        ON usr.UserID = p.ReceivedBy
            WHERE p.PaymentDate BETWEEN @From AND @To AND p.IsDeleted = 0
            ORDER BY p.PaymentDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@From", from);
                cmd.Parameters.AddWithValue("@To", to);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Payment
                    {
                        PaymentID = (int)reader["PaymentID"],
                        UnitID = (int)reader["UnitID"],
                        UnitName = reader["UnitName"].ToString(),
                        BuildingName = reader["BuildingName"].ToString(),
                        OwnerFullName = reader["OwnerFullName"].ToString(),
                        ForMonth = (DateTime)reader["ForMonth"],
                        ToMonth = reader["ToMonth"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["ToMonth"],
                        PaymentDate = (DateTime)reader["PaymentDate"],
                        Amount = (decimal)reader["Amount"],
                        Comment = reader["Comment"] == DBNull.Value ? "" : reader["Comment"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
            }
            return list;
        }


        public List<BuildingSummaryItem> GetBuildingSummary(
                    DateTime from, DateTime to,
                    bool includeService, bool includeMaintenance, bool includeElectric)
        {
            List<BuildingSummaryItem> list = new List<BuildingSummaryItem>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
        SELECT 
            b.BuildingID,
            b.BuildingName,
            (SELECT COUNT(*) FROM Units u WHERE u.BuildingID = b.BuildingID AND u.IsActive = 1) AS UnitCount,

            ISNULL((
                SELECT SUM(sb.Amount) FROM MonthlyServiceBills sb
                INNER JOIN Units u ON u.UnitID = sb.UnitID
                WHERE u.BuildingID = b.BuildingID
                  AND sb.BillMonth BETWEEN @From AND @To
                  AND @IncludeService = 1
                  AND sb.IsDeleted = 0
            ), 0)
            +
            ISNULL((
                SELECT SUM(mb.Amount) FROM MaintenanceBills mb
                INNER JOIN Units u ON u.UnitID = mb.UnitID
                WHERE u.BuildingID = b.BuildingID
                  AND mb.BillMonth BETWEEN @From AND @To
                  AND @IncludeMaintenance = 1
                  AND mb.IsDeleted = 0
            ), 0)
            +
            ISNULL((
                SELECT SUM(eb.TotalAmount) FROM ElectricBills eb
                INNER JOIN Units u ON u.UnitID = eb.UnitID
                WHERE u.BuildingID = b.BuildingID
                  AND eb.BillMonth BETWEEN @From AND @To
                  AND @IncludeElectric = 1
                  AND eb.IsDeleted = 0
            ), 0) AS TotalCharged,

            ISNULL((
                SELECT SUM(p.Amount) FROM Payments p
                INNER JOIN Units u ON u.UnitID = p.UnitID
                WHERE u.BuildingID = b.BuildingID
                  AND p.PaymentDate BETWEEN @From AND @To
                  AND p.IsDeleted = 0
            ), 0) AS TotalPaid

        FROM Buildings b
        ORDER BY b.BuildingName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@From", from);
                cmd.Parameters.AddWithValue("@To", to);
                cmd.Parameters.AddWithValue("@IncludeService", includeService ? 1 : 0);
                cmd.Parameters.AddWithValue("@IncludeMaintenance", includeMaintenance ? 1 : 0);
                cmd.Parameters.AddWithValue("@IncludeElectric", includeElectric ? 1 : 0);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BuildingSummaryItem item = new BuildingSummaryItem
                    {
                        BuildingID = (int)reader["BuildingID"],
                        BuildingName = reader["BuildingName"].ToString(),
                        UnitCount = (int)reader["UnitCount"],
                        TotalCharged = (decimal)reader["TotalCharged"],
                        TotalPaid = (decimal)reader["TotalPaid"]
                    };
                    item.Balance = item.TotalCharged - item.TotalPaid;
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
