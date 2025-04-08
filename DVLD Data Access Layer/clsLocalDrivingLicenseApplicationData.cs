using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace DVLD_Data_Access_Layer
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        public static int GetActiveLocalAppIDByPersonIDAndLicenseClassID(int PersonID, int licenseClassID)
        {
            int AppID = -1;

            string query = @"SELECT LocalDrivingLicenseApplicationID from LocalDrivingLicenseFullApplications_View
                             WHERE ApplicantPersonID = @PersonID AND LicenseClassID = @LicenseClassID AND ApplicationStatus = 1";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get Active Local Application ID By Person ID And License Class ID.", EventLogEntryType.Error);
                AppID = -1;
            }
            finally
            {
                conn.Close();
            }

            return AppID;
        }
       
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if passed test type for app id and test type.", EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

        public static bool GetLocalApplicationByID(int LDLAppID, ref int applicationID, ref int licenseClassID)
        {
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);

            bool isFound = false;
            
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    applicationID = Convert.ToInt32(reader["ApplicationID"]);
                    licenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get local app by id.", EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static byte GetPassedTestCount(int LDLAppID)
        {
            string query = "select PassedTestCount from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);

            byte PassedTests = 0;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PassedTests = Convert.ToByte(reader["PassedTestCount"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get passed test count by local app id.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return PassedTests;
        }

        public static int AddLocalDrivingLicense(int ApplicationID, int LicenseClassID)
        {

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) Values (@ApplicationID, @LicenseClassID); 
                             SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int LDLAppID = -1;

            try
            {
                conn.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LDLAppID = insertedID;
                }


            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not add local driving license.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }
            return LDLAppID;
        }

        public static bool UpdateLocalApplication(int LocalApplicationID, int ApplicationID, int LicenseClassID)
        {
            string query = @"UPDATE LocalDrivingLicenseApplications 
                SET LicenseClassID = @LicenseClassID,
                ApplicationID = @ApplicationID
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int rowsAffected = 0;

            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not update local driving license.", EventLogEntryType.Error);

            }
            finally
            {
                conn.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeleteLocalApplication(int LocalID)
        {
            string query = "DELETE FROM LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplications;";
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplications", LocalID);

            int rowsAffected = 0;

            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not delete local driving license.", EventLogEntryType.Error);
                rowsAffected = 0;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAll()
        {
            string query = "select * from LocalDrivingLicenseApplications_View";
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
                clsUtil.ExceptionLog("Could Not get all local driving license.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                    TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    Result = true;
                }
            }

            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if Is There Active Scheduled Test.", EventLogEntryType.Error);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if attends test type for this local app.", EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get total trials per test for the local app id and test type id.", EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }
    }
}
