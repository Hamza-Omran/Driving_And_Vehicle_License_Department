using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsDrivers
    {

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo { set; get; }

        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; }

        enum enMode { AddMode, UpdateMode };
        private enMode _Mode;

        public clsDrivers()
        {
            this.DriverID = -1;
            _Mode = enMode.AddMode;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            this.PersonID = -1;
            this.PersonInfo = new clsPerson();
        }

        private clsDrivers(int ID, enMode Mode, int personID, int UserID, DateTime CreatedDate)
        {
            this.DriverID = ID;
            _Mode = Mode;
            this.CreatedByUserID = UserID;
            this.CreatedDate = CreatedDate;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(PersonID);
        }

        public static clsDrivers Find(int ID)
        {
            DateTime CreatedDate = DateTime.MinValue;
            int personID = -1, UserID = -1;

            if (clsDriversData.GetDriverInfoByID(ID, ref personID, ref UserID, ref CreatedDate))
            {
                return new clsDrivers(ID, enMode.UpdateMode, personID, UserID, CreatedDate);
            }
            return null;
        }

        public static clsDrivers FindByPersonID(int ID)
        {
            DateTime CreatedDate = DateTime.MinValue;
            int DriverID = -1, UserID = -1;

            if (clsDriversData.GetDriverInfoByPersonID(ID, ref DriverID, ref UserID, ref CreatedDate))
            {
                return new clsDrivers(DriverID, enMode.UpdateMode, ID, UserID, CreatedDate);
            }
            return null;
        }

        public static int FindDriverIDByPersonID(int PerosonID)
        {
            return clsDriversData.GetDriverIDByPersonID(PerosonID);
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriversData.AddDriver(PersonID, CreatedByUserID);


            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddNewDriver())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateDriver();
            }
            return false;
        }

        public static DataTable GetAll()
        {
            return clsDriversData.GetAllDrivers();
        }

        public static DataTable GetLocalLicenses(int DriverID)
        {
            return clsLicensesData.GetAllLicensesOfDriver(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalData.GetAllLicensesOfDriver(DriverID);
        }
    }
}