namespace ServiceSystem.Models
{
    public class Unit
    {
        public int UnitID { get; set; }

        // Which building this unit belongs to
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }   // we fill this when we read from database

        public string UnitName { get; set; }
        public string UnitType { get; set; }       // A / B / C / D / E

        // Owner information
        public string OwnerFullName { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerOtherPhone { get; set; }
        public string OwnerNation { get; set; }

        // Tenant information
        public bool HasTenant { get; set; }
        public string TenantFullName { get; set; }
        public string TenantPhone { get; set; }
        public string TenantOtherPhone { get; set; }
        public string TenantNation { get; set; }

        public decimal MonthlyServiceAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
