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
    public static class clsTestsAppointmentData
    {
        public static bool GetTestAppointmentInfoByID(int testAppointmentID, ref int testTypeID, ref int localDrivingLicenseApplicationID,
            ref DateTime appointmentDate, ref float paidFees, ref int createdByUserID, ref bool isLocked, ref int RetakeTestApplicationID)
        {
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    testTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    localDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isLocked = Convert.ToBoolean(reader["IsLocked"]);
                    RetakeTestApplicationID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find test appointment by id.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static int AddTestAppointment(int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate,
            float paidFees, int createdByUserID, bool IsLocked, int RetakeTestAppID)
        {
            string query = @"INSERT INTO TestAppointments 
                (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID) 
                VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestAppID);
                SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            
            if(RetakeTestAppID == -1)
                command.Parameters.AddWithValue("@RetakeTestAppID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestAppID", RetakeTestAppID);

            int testAppointmentID = -1;

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    testAppointmentID = insertedID;
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not add test appointment.", EventLogEntryType.Error);
                testAppointmentID = -1;
            }
            finally
            {
                conn.Close();
            }

            return testAppointmentID;
        }

        public static bool UpdateTestAppointment(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            string query = @"UPDATE TestAppointments SET 
                TestTypeID = @TestTypeID, LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID, 
                AppointmentDate = @AppointmentDate, PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID, 
                IsLocked = @IsLocked , RetakeTestApplicationID = @RetakeTestApplicationID
                WHERE TestAppointmentID = @TestAppointmentID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            if (RetakeTestApplicationID == -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            int rowsAffected = 0;

            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not update test appointment.", EventLogEntryType.Error);
                rowsAffected = 0;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected > 0;
        }

        public static bool IsThereActiveTestAppointments(int testTypeID, int localDrivingLicenseApplicationID)
        {
            string query = @"SELECT TOP 1 1 IsFound
                                FROM TestAppointments
                                WHERE TestTypeID = @TestTypeID
                                AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                And IsLocked = 0 
                                ORDER BY IsLocked ASC;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            bool isThere = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isThere = Convert.ToBoolean(reader["IsFound"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if test appointment exists.", EventLogEntryType.Error);
                isThere = false;
            }
            finally
            {
                conn.Close();
            }

            return isThere;
        }

        public static DataTable GetAppointmentsOfLocalAppIDAndTestType(int LDLAppID, int TestTypeID)
        {
            string query = @"SELECT TestAppointmentID, TestTypeID, AppointmentDate, PaidFees, IsLocked 
                             FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @ID AND TestTypeID = @TestTypeID
                             Order By AppointmentDate DESC;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
                clsUtil.ExceptionLog("Could Not Get Appointments Of Local App ID And Test Type.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find test by test appointment id.", EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }
    }
}
