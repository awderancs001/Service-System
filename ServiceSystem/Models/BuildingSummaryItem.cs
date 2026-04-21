namespace ServiceSystem.Models
{
    public class BuildingSummaryItem
    {
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public int UnitCount { get; set; }
        public decimal TotalCharged { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Balance { get; set; }
    }
}