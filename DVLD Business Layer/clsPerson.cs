using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsPerson
    {
        public int ID { set; get; }

        public string NationalNumber { set; get; }

        public string FirstName { set; get; }

        public string SecondName { set; get; }

        public string ThirdName { set; get; }

        public string LastName { set; get; }

        public DateTime DateOfBirth { set; get; }

        public short Gender { set; get; }

        public string GenderText
        {
            get { return this.Gender == 0 ? "Male" : "Female"; }
        }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public int CountryID { set; get; }
        public string ImagePath { set; get; }

        public string CountryName { set; get; }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }

        enum enMode { AddMode, UpdateMode };
        public enum enGender { Male = 0, Female = 1 };

        enMode _Mode;

        public clsPerson()
        {
            this.ID = -1;
            this.NationalNumber = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryID = -1;
            this.CountryName = "";
            this.ImagePath = "";

            _Mode = enMode.AddMode;
        }

        private clsPerson(int ID, string NationalNumber, string FirstName,
                string SecondName, string ThirdName, string LastName,
                DateTime DateOfBirth, short Gender, string Address,
                string Phone, string Email, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNumber = NationalNumber;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.CountryName = clsCountry.Find(CountryID).CountryName;
            this.ImagePath = ImagePath;

            _Mode = enMode.UpdateMode;
        }

        public static clsPerson Find(int ID)
        {
            string nationalNumber = "", firstName = "", secondName = "", thirdName = "", lastName = "", address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = DateTime.MinValue;
            short gender = 0;
            int countryID = -1;

            if (clsPersonData.GetPersonInfoByID(ID, ref nationalNumber, ref firstName, ref secondName, ref thirdName,
                ref lastName, ref dateOfBirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagePath))
            {
                return new clsPerson(ID, nationalNumber, firstName, secondName, thirdName, lastName,
                                     dateOfBirth, gender, address, phone, email, countryID, imagePath);
            }
            return null;
        }

        public static clsPerson Find(string nationalNumber)
        {
            int id = -1;
            string firstName = "", secondName = "", thirdName = "", lastName = "", address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = DateTime.MinValue;
            short gender = 0;
            int countryID = -1;

            if (clsPersonData.GetPersonInfoByNationalNo(nationalNumber, ref id, ref firstName, ref secondName, ref thirdName,
                ref lastName, ref dateOfBirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagePath))
            {
                return new clsPerson(id, nationalNumber, firstName, secondName, thirdName, lastName,
                                     dateOfBirth, gender, address, phone, email, countryID, imagePath);
            }
            return null;
        }

        public static clsPerson FindByDriverID(int DriverID)
        {
            int id = -1;
            string firstName = "", secondName = "", thirdName = "", lastName = "", address = "", phone = "", email = "", imagePath = "", nationalNumber = "";
            DateTime dateOfBirth = DateTime.MinValue;
            short gender = 0;
            int countryID = -1;

            if (clsPersonData.GetPersonInfoDriverID(DriverID, ref nationalNumber, ref id, ref firstName, ref secondName, ref thirdName,
                ref lastName, ref dateOfBirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagePath))
            {
                return new clsPerson(id, nationalNumber, firstName, secondName, thirdName, lastName,
                                     dateOfBirth, gender, address, phone, email, countryID, imagePath);
            }
            return null;
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddPerson(this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                    this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.ID, this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                    this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddNewPerson())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdatePerson();
            }
            return false;
        }

        public bool Delete()
        {
            return clsPersonData.DeletePerson(this.ID);
        }

        public static bool Exists(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        public static DataTable GetAll()
        {
            return clsPersonData.GetAllPersons();
        }
    }
}

