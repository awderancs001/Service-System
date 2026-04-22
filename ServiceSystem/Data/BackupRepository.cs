using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ServiceSystem.Data
{
    public class BackupRepository
    {
        // Fixed folder where all backups live
        private const string BackupFolder = @"D:\ServiceSystemBackups\";

        // Make sure folder exists (auto-create on first use)
        private void EnsureFolder()
        {
            if (!Directory.Exists(BackupFolder))
                Directory.CreateDirectory(BackupFolder);
        }

        // -------------------------------------------------------
        // BACKUP — saves the database to a timestamped .bak file
        // Returns the full file path so the form can show it
        // -------------------------------------------------------
        public string Backup()
        {
            EnsureFolder();

            string fileName = string.Format(
                "ServiceSystemDB_{0:yyyy-MM-dd_HH-mm-ss}.bak",
                DateTime.Now);

            string fullPath = Path.Combine(BackupFolder, fileName);

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string sql = @"BACKUP DATABASE ServiceSystemDB
                               TO DISK = @Path
                               WITH FORMAT, INIT";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Path", fullPath);
                cmd.CommandTimeout = 120;   // 2 minutes — BACKUP can take a while
                cmd.ExecuteNonQuery();
            }

            return fullPath;
        }

        // -------------------------------------------------------
        // RESTORE — restores database from a .bak file
        // This KICKS EVERYONE OUT first (single-user mode), then restores,
        // then lets everyone back in.
        // -------------------------------------------------------
        public void Restore(string backupFile)
        {
            // RESTORE can't run on the target database while we're connected to it,
            // so we connect to master database instead
            string connStr = ConfigurationManager.ConnectionStrings["ServiceDB"].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connStr);
            builder.InitialCatalog = "master";

            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();

                // 1. Kick out all connections
                SqlCommand kick = new SqlCommand(
                    "ALTER DATABASE ServiceSystemDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE", con);
                kick.ExecuteNonQuery();

                try
                {
                    // 2. Restore
                    SqlCommand restore = new SqlCommand(
                        "RESTORE DATABASE ServiceSystemDB FROM DISK = @Path WITH REPLACE", con);
                    restore.Parameters.AddWithValue("@Path", backupFile);
                    restore.CommandTimeout = 300;   // 5 minutes — restore can be slow
                    restore.ExecuteNonQuery();
                }
                finally
                {
                    // 3. Always put DB back in multi-user, even if restore failed
                    SqlCommand allow = new SqlCommand(
                        "ALTER DATABASE ServiceSystemDB SET MULTI_USER", con);
                    allow.ExecuteNonQuery();
                }
            }
        }

        // -------------------------------------------------------
        // GET BACKUP FOLDER — so form can show it in a message
        // -------------------------------------------------------
        public string GetBackupFolder()
        {
            return BackupFolder;
        }
    }
}