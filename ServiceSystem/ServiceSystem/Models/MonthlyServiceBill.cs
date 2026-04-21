using System;

namespace ServiceSystem.Models
{
    public class MonthlyServiceBill
    {
        public int BillID { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }       // filled when reading from database
        public string BuildingName { get; set; }   // filled when reading from database
        public DateTime BillMonth { get; set; }    // always 1st of month e.g. 2024-04-01
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
