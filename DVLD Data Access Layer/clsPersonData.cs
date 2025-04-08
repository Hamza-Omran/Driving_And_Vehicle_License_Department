using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Data;
using System.Diagnostics;

namespace DVLD_Data_Access_Layer
{
    public static class clsPersonData
    {

        public static bool GetPersonInfoByID(int ID, ref string NationalNumber, ref string FirstName,
                ref string SecondName, ref string ThirdName, ref string LastName,
                ref DateTime DateOfBirth, ref short Gender, ref string Address,
                ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            string query = "select * from People where PersonID = @ID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ID", ID);

            bool isFound=false;

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNumber = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = short.Parse(reader["Gendor"].ToString());
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    ImagePath = reader["ImagePath"].ToString();

                    
                }
            } 
            catch (Exception ex)
            {
                isFound = false;
                clsUtil.ExceptionLog("Could Not find person by id.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }
            return isFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNumber, ref int ID, ref string FirstName,
    ref string SecondName, ref string ThirdName, ref string LastName,
    ref DateTime DateOfBirth, ref short Gender, ref string Address,
    ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNumber;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            bool isFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = short.Parse(reader["Gendor"].ToString());
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    ImagePath = reader["ImagePath"].ToString();
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not find person by national no.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool GetPersonInfoDriverID(int DriverID, ref string NationalNumber, ref int ID, ref string FirstName,
    ref string SecondName, ref string ThirdName, ref string LastName,
    ref DateTime DateOfBirth, ref short Gender, ref string Address,
    ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            string query = "select People.* from People inner join Drivers on People.PersonID = Drivers.PersonID where DriverID = @DriverID;";

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
                    ID = Convert.ToInt32(reader["PersonID"]);
                    NationalNumber = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = short.Parse(reader["Gendor"].ToString());
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    ImagePath = reader["ImagePath"].ToString();
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not get person by driver id.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static int AddPerson(string NationalNumber, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, short Gender, string Address, string Phone, string Email,
            int CountryID, string ImagePath)
        {
            string query = @"INSERT INTO People 
                (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath) 
                VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @CountryID, @ImagePath);
                SELECT SCOPE_IDENTITY();";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@NationalNo", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            int PersonID = -1;

            try
            {
                conn.Open();
                object result =  command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not add person.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }
            return PersonID;
        }

        public static bool DeletePerson(int ID)
        {
            string query = "DELETE People WHERE PersonID = @ID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ID", ID);

            int RowsAffected = 0;

            try
            {
                conn.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not delete person.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return RowsAffected > 0;
        }

        public static bool UpdatePerson(int ID, string NationalNumber, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, short Gender, string Address, string Phone, string Email,
            int CountryID, string ImagePath)
        {
            string query = @"UPDATE People SET 
                NationalNo = @NationalNo, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, 
                LastName = @LastName, DateOfBirth = @DateOfBirth, Gendor = @Gender, Address = @Address, 
                Phone = @Phone, Email = @Email, NationalityCountryID = @CountryID, ImagePath = @ImagePath 
                WHERE PersonID = @ID;";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            int RowsAffected = 0;

            try
            {
                conn.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not update person.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }
            return RowsAffected > 0;
        }

        public static DataTable GetAllPersons()
        {
            string query = @"SELECT People.PersonID, People.NationalNo,
                              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			                  People.DateOfBirth, People.Gendor,  
				                  CASE
                                  WHEN People.Gendor = 0 THEN 'Male'

                                  ELSE 'Female'

                                  END as GendorCaption ,
			                  People.Address, People.Phone, People.Email, 
                              People.NationalityCountryID, Countries.CountryName, People.ImagePath
                              FROM            People INNER JOIN
                                         Countries ON People.NationalityCountryID = Countries.CountryID
                                ORDER BY People.FirstName";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.connection);
            SqlCommand command = new SqlCommand(query, conn);
            DataTable dt= new DataTable();

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
                clsUtil.ExceptionLog("Could Not get all persons.", EventLogEntryType.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static bool IsPersonExist(string NationalNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connection);

            string query = "SELECT 1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsUtil.ExceptionLog("Could Not check if person exists id.", EventLogEntryType.Error);
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
