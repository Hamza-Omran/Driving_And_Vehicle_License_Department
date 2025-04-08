using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplicationTypes
    {
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public int ApplicationTypeID { set; get; }

        public string ApplicationTypeTitle { set; get; }

        public float ApplicationFees { set; get; }

        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationTypeFees;
        }

        public bool Save()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public static DataTable GetAll()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        public static clsApplicationTypes Find(int ID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;

            if (clsApplicationTypesData.Find(ID, ref ApplicationTypeTitle, ref ApplicationFees))

                return new clsApplicationTypes(ID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;
        }
    }
}
