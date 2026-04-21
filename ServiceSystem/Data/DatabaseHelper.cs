using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ServiceSystem.Data
{
    public class DatabaseHelper
    {
        // This reads the connection string from App.config file
        // We store the server name and database name there
        // So if the database moves to another server, 
        // we only change App.config — not every file
        private static string connectionString = ConfigurationManager.ConnectionStrings["ServiceDB"].ConnectionString;
        
        
        public static SqlConnection GetConnection()
        {
            // This method gives you a ready-to-use connection
            // Call it any time you need to talk to the database
            return new SqlConnection(connectionString);
        }
    }
}
