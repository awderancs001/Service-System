namespace ServiceSystem.Models
{
    public class Building
    {
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public string BuildingCategory { get; set; } // "House" or "Apartment"
        public string Notes { get; set; }
    }
}
