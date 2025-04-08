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
    public static class clsLicensesData
    {
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get active license id by person id.", EventLogEntryType.Error);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }

        public static DataTable GetAllLicensesOfDriver(int DriverID)
        {
            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            DataTable dt = new DataTable();

            command.Parameters.AddWithValue("@DriverID", DriverID);

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
                clsUtil.ExceptionLog("Could Not get all licenses of driver.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static int AddLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            string query = @"INSERT INTO Licenses 
                            (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID) 
                            VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int LicenseID = -1;
            try
            {
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not add new license.", EventLogEntryType.Error);

            }
            finally
            {
                conn.Close();
            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            bool isUpdated = false;

            string query = @"UPDATE Licenses SET 
                            ApplicationID = @ApplicationID, 
                            DriverID = @DriverID, 
                            LicenseClass = @LicenseClass, 
                            IssueDate = @IssueDate, 
                            ExpirationDate = @ExpirationDate, 
                            PaidFees = @PaidFees, 
                            Notes = @Notes,
                            IsActive = @IsActive, 
                            IssueReason = @IssueReason, 
                            CreatedByUserID = @CreatedByUserID 
                            WHERE LicenseID = @LicenseID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();
                isUpdated = command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not update license.", EventLogEntryType.Error);
                isUpdated = false;
            }
            finally
            {
                conn.Close();
            }

            return isUpdated;
        }

        public static bool GetLicenseInfoByID(int LicenseID, ref int applicationID, ref int driverID, ref int licenseClass, ref DateTime issueDate, ref DateTime expiryDate, ref string notes, ref float paidFees, ref bool isActive, ref int issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    applicationID = Convert.ToInt32(reader["ApplicationID"]);
                    driverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClass = Convert.ToInt32(reader["LicenseClass"]);

                    issueDate = DateTime.Parse(reader["IssueDate"].ToString());
                    expiryDate = DateTime.Parse(reader["ExpirationDate"].ToString());

                    notes = reader["Notes"].ToString();

                    paidFees = float.Parse(reader["PaidFees"].ToString());

                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToInt32(reader["IssueReason"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get license by id.", EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not de activaite license.", EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}