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
    public static class clsDriversData
    {
        public static int AddDriver(int PersonID, int CreatedByUserID)
        {
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate) 
                             VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            int DriverID = -1;

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not add driver.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return DriverID;
        }

        // Update an existing driver record
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            string query = @"UPDATE Drivers SET 
                             PersonID = @PersonID, 
                             CreatedByUserID = @CreatedByUserID, 
                             CreatedDate = @CreatedDate
                             WHERE DriverID = @DriverID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            int rowsAffected = 0;

            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not update driver.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected > 0;
        }

        // Retrieve a driver record by ID
        public static bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find driver.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find driver by person id.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            string query = "SELECT DriverID FROM Drivers WHERE PersonID = @PersonID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            int DriverID = -1;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find driver id by person id.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return DriverID;
        }

        // Get all drivers
        public static DataTable GetAllDrivers()
        {
            string query = "SELECT * FROM Drivers_View;";

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
                clsUtil.ExceptionLog("Could Not return all driver.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
    }
}
