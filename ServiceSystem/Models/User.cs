namespace ServiceSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }           // "Admin" / "User" / "Viewer"
        public bool IsActive { get; set; }

        // We never store the password here
        // Password only travels as a hash when logging in
    }
}
