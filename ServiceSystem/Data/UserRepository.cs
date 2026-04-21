using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    public class UserRepository
    {
        // -------------------------------------------------------
        // HASH PASSWORD
        // Never store plain text password in database
        // This converts "admin123" to a long random-looking string
        // Same password always produces same hash — so we compare hashes
        // This is a private method — only this class uses it
        // -------------------------------------------------------
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder result = new StringBuilder();
                foreach (byte b in bytes)
                {
                    result.Append(b.ToString("x2"));
                }

                return result.ToString();
            }
        }

        // -------------------------------------------------------
        // LOGIN — checks username and password
        // Returns the User object if correct, null if wrong
        // This is the most important method in this class
        // -------------------------------------------------------
        public User Login(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT UserID, Username, FullName, Role, IsActive
                               FROM Users
                               WHERE Username = @Username
                                 AND PasswordHash = @PasswordHash
                                 AND IsActive = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username",     username);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User u = new User();
                    u.UserID   = (int)reader["UserID"];
                    u.Username = reader["Username"].ToString();
                    u.FullName = reader["FullName"].ToString();
                    u.Role     = reader["Role"].ToString();
                    u.IsActive = (bool)reader["IsActive"];
                    return u;
                }

                // Username or password was wrong — return null
                return null;
            }
        }

        // -------------------------------------------------------
        // GET ALL — returns all users
        // Used in User Management form
        // -------------------------------------------------------
        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT UserID, Username, FullName, Role, IsActive
                               FROM Users
                               ORDER BY FullName";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadUser(reader));
                }
            }

            return list;
        }

        // -------------------------------------------------------
        // GET BY ID — returns one user
        // -------------------------------------------------------
        public User GetByID(int userID)
        {
            User u = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT UserID, Username, FullName, Role, IsActive
                               FROM Users
                               WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    u = ReadUser(reader);
                }
            }

            return u;
        }

        // -------------------------------------------------------
        // SAVE — creates a new user with hashed password
        // -------------------------------------------------------
        public int Save(User u, string plainPassword)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive)
                               VALUES (@Username, @PasswordHash, @FullName, @Role, 1);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username",     u.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(plainPassword));
                cmd.Parameters.AddWithValue("@FullName",     u.FullName);
                cmd.Parameters.AddWithValue("@Role",         u.Role);
                con.Open();

                int newID = int.Parse(cmd.ExecuteScalar().ToString());
                return newID;
            }
        }

        // -------------------------------------------------------
        // UPDATE — updates user info (not password)
        // Password is changed separately with ChangePassword()
        // -------------------------------------------------------
        public void Update(User u)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE Users
                               SET FullName = @FullName,
                                   Role     = @Role,
                                   IsActive = @IsActive
                               WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FullName", u.FullName);
                cmd.Parameters.AddWithValue("@Role",     u.Role);
                cmd.Parameters.AddWithValue("@IsActive", u.IsActive);
                cmd.Parameters.AddWithValue("@UserID",   u.UserID);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------
        // CHANGE PASSWORD — updates password only
        // Separate from Update() because password needs hashing
        // -------------------------------------------------------
        public void ChangePassword(int userID, string newPlainPassword)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE Users
                               SET PasswordHash = @PasswordHash
                               WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(newPlainPassword));
                cmd.Parameters.AddWithValue("@UserID",       userID);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------
        // USERNAME EXISTS — check for duplicate username
        // -------------------------------------------------------
        public bool UsernameExists(string username, int excludeID = 0)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Users
                               WHERE Username = @Username AND UserID != @ExcludeID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username",  username);
                cmd.Parameters.AddWithValue("@ExcludeID", excludeID);
                con.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // -------------------------------------------------------
        // CHECK PERMISSION — does this user have access to a form?
        // Used when opening any form to check if user can see it
        // -------------------------------------------------------
        public bool HasAccess(int userID, string formName)
        {
            // Admin always has access to everything
            User u = GetByID(userID);
            if (u != null && u.Role == "Admin") return true;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT CanAccess FROM UserFormPermissions
                               WHERE UserID = @UserID AND FormName = @FormName";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserID",   userID);
                cmd.Parameters.AddWithValue("@FormName", formName);
                con.Open();

                object result = cmd.ExecuteScalar();

                // If no permission record exists — deny access by default
                if (result == null) return false;

                return (bool)result;
            }
        }

        // -------------------------------------------------------
        // PRIVATE HELPER — reads one user from reader
        // -------------------------------------------------------
        private User ReadUser(SqlDataReader reader)
        {
            User u = new User();
            u.UserID   = (int)reader["UserID"];
            u.Username = reader["Username"].ToString();
            u.FullName = reader["FullName"].ToString();
            u.Role     = reader["Role"].ToString();
            u.IsActive = (bool)reader["IsActive"];
            return u;
        }

        // -------------------------------------------------------
        // COUNT ACTIVE ADMINS — used for last-admin protection
        // -------------------------------------------------------
        public int CountActiveAdmins()
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT COUNT(*) FROM Users
                       WHERE Role = 'Admin' AND IsActive = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
