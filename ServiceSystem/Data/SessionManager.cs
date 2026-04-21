using ServiceSystem.Models;

namespace ServiceSystem.Data
{

    //it remembers who is logged in:
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public static bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.Role == "Admin";
        }
    }
}
