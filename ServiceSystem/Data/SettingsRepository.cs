using System.Data.SqlClient;

namespace ServiceSystem.Data
{
    // -------------------------------------------------------
    // SettingsRepository
    // Reads / writes the SystemSettings key-value table
    // Example keys: CompanyName, InvoicePrefix, LastInvoiceNumber
    // -------------------------------------------------------
    public class SettingsRepository
    {
        // -------------------------------------------------------
        // GET VALUE — returns one setting by its key
        // If the key does not exist OR value is NULL, returns ""
        // -------------------------------------------------------
        public string GetValue(string key)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT SettingValue FROM SystemSettings WHERE SettingKey = @Key";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Key", key);
                con.Open();

                object result = cmd.ExecuteScalar();

                // ExecuteScalar returns:
                //   null        -> row not found
                //   DBNull.Value -> row exists but value is SQL NULL
                //   actual value -> row exists with value
                if (result == null || result == System.DBNull.Value)
                    return "";

                return result.ToString();
            }
        }

        // -------------------------------------------------------
        // SET VALUE — updates one setting (used for LastInvoiceNumber)
        // -------------------------------------------------------
        public void SetValue(string key, string value)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE SystemSettings
                               SET SettingValue = @Value
                               WHERE SettingKey = @Key";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Key",   key);
                cmd.Parameters.AddWithValue("@Value", value);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
