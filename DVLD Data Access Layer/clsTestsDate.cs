using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DVLD_Data_Access_Layer
{
    public static class clsTestsData
    {
        public static bool GetTestByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            string query = "SELECT * FROM Tests WHERE TestID = @TestID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@TestID", TestID);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                    TestResult = Convert.ToBoolean(reader["TestResult"]);
                    Notes = reader["Notes"].ToString();
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find test by id.", EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static int AddTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID) 
                             VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                            
                             UPDATE TestAppointments 
                                SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;
                             SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int TestID = -1;

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not add test.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return TestID;
        }

        public static bool IsTestTypePassed(int _TestTypeID, int _LDLAppID)
        {
            string query = @"
             SELECT MAX(CAST(Tests.TestResult AS TINYINT)) AS TestResult
             FROM   Tests INNER JOIN
             TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
			 where TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestTypeID", _TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", _LDLAppID);

            bool IsPassed = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        IsPassed = Convert.ToInt32(reader["TestResult"]) == 1;
                    }
                }
                else
                    IsPassed = false;
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not inform if test passed.", EventLogEntryType.Error);
                IsPassed = false;
            }
            finally
            {
                conn.Close();
            }

            return IsPassed;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string query = @"UPDATE Tests SET 
                             TestAppointmentID = @TestAppointmentID, 
                             TestResult = @TestResult, 
                             Notes = @Notes, 
                             CreatedByUserID = @CreatedByUserID 
                             WHERE TestID = @TestID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int RowsAffected = 0;

            try
            {
                conn.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not update test.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return RowsAffected > 0;
        }
    }
}
