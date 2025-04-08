using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;


namespace DVLD_Business_Layer
{
    public class clsUsers
    {
        public int UserID { set; get; }

        public int PersonID { set; get; }

        public clsPerson PersonInfo { set; get; }

        public string UserName { set; get; }

        public string Password { set; get; }

        public bool IsActive { set; get; }

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            PersonInfo = new clsPerson();
            UserName = "";
            Password = "";
            IsActive = false;
            _Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            _Mode = enMode.Update;
        }

        public static clsUsers Find(int UserID)
        {
            int personID = -1;
            string userName = "", password = "";
            bool isActive = false;

            if (clsUsersData.GetUserInfoByID(UserID, ref personID, ref userName, ref password, ref isActive))
            {
                return new clsUsers(UserID, personID, userName, password, isActive);
            }

            return null;
        }

        public static clsUsers FindByUserNameAndPassword(string userName, string passWord)
        {
            int userID = -1, personID = -1;
            bool isActive = false;

            if (clsUsersData.GetUserInfoByUserNameAndPassword(ref userID, ref personID, userName, passWord, ref isActive))
            {
                return new clsUsers(userID, personID, userName, passWord, isActive);
            }

            return null;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }


        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNewUser())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else
            {
                return _UpdateUser();
            }
        }

        public static bool Delete(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool ExistsByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        public static bool Exists(string userName)
        {
            return clsUsersData.IsUserExist(userName);
        }

        public static DataTable GetAll()
        {
            return clsUsersData.GetAllUsers();
        }
    }
}

