using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace DVLD_Data_Access_Layer
{
    public static class clsUsersData
    {
        // Get user information by UserID
        public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@UserID", UserID);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not Find User By ID.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(ref int UserID, ref int PersonID, string UserName, string Password, ref bool IsActive)
        {
            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = Convert.ToInt32(reader["UserID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                clsUtil.ExceptionLog("Could Not Find User By Credentials.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        // Add a new user
        public static int AddUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive) 
                             VALUES (@PersonID, @UserName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int UserID = -1;

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not Inser User.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return UserID;
        }

        // Update an existing user
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = @"UPDATE Users SET 
                             PersonID = @PersonID, UserName = @UserName, Password = @Password, IsActive = @IsActive 
                             WHERE UserID = @UserID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int RowsAffected = 0;

            try
            {
                conn.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not Update User.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return RowsAffected > 0;
        }

        // Delete a user
        public static bool DeleteUser(int UserID)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@UserID", UserID);

            int RowsAffected = 0;

            try
            {
                conn.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not Delete User.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return RowsAffected > 0;
        }

        // Get all users
        public static DataTable GetAllUsers()
        {
            string query = @"SELECT Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID;";
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not return all users.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            string query = "SELECT 1 FROM Users WHERE PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if user exists by id.", EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        // Check if a user exists by UserName
        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            string query = "SELECT 1 FROM Users WHERE UserName = @UserName;";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if user exists by name.", EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }
    }
}