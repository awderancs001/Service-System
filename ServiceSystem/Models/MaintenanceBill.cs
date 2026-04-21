using System;

namespace ServiceSystem.Models
{
    public class MaintenanceBill
    {
        public int MaintenanceID { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }       // filled when reading from database
        public string BuildingName { get; set; }   // filled when reading from database
        public DateTime BillMonth { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public string OwnerName { get; set; }
    }
}
