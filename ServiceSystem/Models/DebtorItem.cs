

namespace ServiceSystem.Models
{
    // One row in the Debtors List report
    public class DebtorItem
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string OwnerFullName { get; set; }
        public string OwnerPhone { get; set; }
        public decimal TotalCharged { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Balance { get; set; }
    }
}
