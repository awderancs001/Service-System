using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ServiceSystem.Models;

namespace ServiceSystem.Data
{
    public class BuildingRepository
    {
        // -------------------------------------------------------
        // GET ALL — returns every building as a list
        // Used in: dropdowns, building management form
        // -------------------------------------------------------
        public List <Building> GetAll()
        {
            List <Building> list = new List<Building>();

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT BuildingID, BuildingName, BuildingCategory, Notes FROM Buildings ORDER BY BuildingName";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Building b = new Building();
                    b.BuildingID       = (int)reader["BuildingID"];
                    b.BuildingName     = reader["BuildingName"].ToString();
                    b.BuildingCategory = reader["BuildingCategory"].ToString();
                    b.Notes            = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString();

                    list.Add(b);
                }
            }

            return list;
        }

        // -------------------------------------------------------
        // GET BY ID — returns one building by its ID
        // Used in: edit form, when you need one specific building
        // -------------------------------------------------------
        public Building GetByID(int buildingID)
        {
            Building b = null;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT BuildingID, BuildingName, BuildingCategory, Notes FROM Buildings WHERE BuildingID = @BuildingID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingID", buildingID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    b = new Building();
                    b.BuildingID       = (int)reader["BuildingID"];
                    b.BuildingName     = reader["BuildingName"].ToString();
                    b.BuildingCategory = reader["BuildingCategory"].ToString();
                    b.Notes            = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString();
                }
            }

            return b;
        }

        // -------------------------------------------------------
        // SAVE — inserts a new building into the database
        // Returns the new BuildingID that SQL Server generated
        // -------------------------------------------------------
        public int Save(Building b)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                // SCOPE_IDENTITY() returns the new ID that was just inserted
                string sql = @"INSERT INTO Buildings (BuildingName, BuildingCategory, Notes, CreatedBy)
                               VALUES (@BuildingName, @BuildingCategory, @Notes, @CreatedBy);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingName",     b.BuildingName);
                cmd.Parameters.AddWithValue("@BuildingCategory", b.BuildingCategory);
                cmd.Parameters.AddWithValue("@Notes",            string.IsNullOrEmpty(b.Notes) ? (object)DBNull.Value : b.Notes);
                cmd.Parameters.AddWithValue("@CreatedBy",        SessionManager.CurrentUser.UserID);
                con.Open();

                // ExecuteScalar returns one single value — the new ID
                int newID = int.Parse(cmd.ExecuteScalar().ToString());
                return newID;
            }
        }

        // -------------------------------------------------------
        // UPDATE — changes an existing building's data
        // -------------------------------------------------------
        public void Update(Building b)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = @"UPDATE Buildings
                               SET BuildingName     = @BuildingName,
                                   BuildingCategory = @BuildingCategory,
                                   Notes            = @Notes
                               WHERE BuildingID = @BuildingID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingName",     b.BuildingName);
                cmd.Parameters.AddWithValue("@BuildingCategory", b.BuildingCategory);
                cmd.Parameters.AddWithValue("@Notes",            string.IsNullOrEmpty(b.Notes) ? (object)DBNull.Value : b.Notes);
                cmd.Parameters.AddWithValue("@BuildingID",       b.BuildingID);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------
        // DELETE — soft-deletes all units inside the building,
        // then permanently deletes the building itself.
        // Both steps run inside one transaction — if anything
        // fails, the whole thing is rolled back automatically.
        // -------------------------------------------------------
        public void Delete(int buildingID)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Step 1: soft-delete every unit in this building
                    string softDeleteUnits = @"
                        UPDATE Units SET IsActive = 0
                        WHERE BuildingID = @BuildingID AND IsActive = 1";

                    SqlCommand cmd1 = new SqlCommand(softDeleteUnits, con, transaction);
                    cmd1.Parameters.AddWithValue("@BuildingID", buildingID);
                    cmd1.ExecuteNonQuery();

                    // Step 2: now delete the building (no FK violation because units are deactivated,
                    // but rows still exist — so we must delete units rows entirely first)
                    string deleteUnits = "DELETE FROM Units WHERE BuildingID = @BuildingID";
                    SqlCommand cmd2 = new SqlCommand(deleteUnits, con, transaction);
                    cmd2.Parameters.AddWithValue("@BuildingID", buildingID);
                    cmd2.ExecuteNonQuery();

                    // Step 3: delete the building
                    string deleteBuilding = "DELETE FROM Buildings WHERE BuildingID = @BuildingID";
                    SqlCommand cmd3 = new SqlCommand(deleteBuilding, con, transaction);
                    cmd3.Parameters.AddWithValue("@BuildingID", buildingID);
                    cmd3.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;  // let the form show the error
                }
            }
        }

        // -------------------------------------------------------
        // EXISTS — checks if a building name is already used
        // Used before saving to prevent duplicate names
        // -------------------------------------------------------
        public bool NameExists(string buildingName, int excludeID = 0)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Buildings WHERE BuildingName = @BuildingName AND BuildingID != @ExcludeID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BuildingName", buildingName);
                cmd.Parameters.AddWithValue("@ExcludeID",    excludeID);
                con.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
