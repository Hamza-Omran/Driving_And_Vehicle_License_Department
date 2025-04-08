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
    public static class clsSettingsData
    {
        public static bool GetSettingByID(int ID, ref string Service, ref int ValidityLength)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);
            string query = "SELECT * FROM Settings WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    Service = reader["Service"].ToString();
                    ValidityLength = Convert.ToInt32(reader["ValidityLength"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get setting by id.", EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }        
    }
}

