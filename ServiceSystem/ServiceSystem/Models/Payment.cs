using System;

namespace ServiceSystem.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }       // filled when reading from database
        public string BuildingName { get; set; }   // filled when reading from database
        public string OwnerFullName { get; set; }  // filled when reading from database

        // ForMonth = first month this payment covers
        // ToMonth  = last month  (null means only one month)
        public DateTime ForMonth { get; set; }
        public DateTime? ToMonth { get; set; }     // ? means it can be null

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public string ReceivedByName { get; set; } // filled when reading from database
        public DateTime CreatedDate { get; set; }
    }
}
