using System;

namespace ServiceSystem.Models
{
    public class UnitHistoryItem
    {
        public string Type { get; set; }        // "Service" / "Maintenance" / "Electric" / "Payment"
        public DateTime Month { get; set; }
        public decimal Debt { get; set; }        // 0 for payments
        public decimal Paid { get; set; }        // 0 for bills
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    // Small helper for balance summary
    public class UnitBalance
    {
        public decimal TotalCharged { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Balance { get; set; }
    }
}
