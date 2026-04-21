using System;

namespace ServiceSystem.Models
{
    public class ElectricBill
    {
        public int ElectricID { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }       // filled when reading from database
        public string BuildingName { get; set; }   // filled when reading from database
        public string OwnerName { get; set; }
        public DateTime BillMonth { get; set; }
        public decimal BeginReading { get; set; }
        public decimal EndReading { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalAmount { get; set; }   // SQL calculates this — we just read it
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
