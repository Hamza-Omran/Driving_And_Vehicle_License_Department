using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsInternationalLicense : clsApplications
    {
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDrivers DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        enum enMode { AddMode, UpdateMode };
        enMode _Mode;

        public clsInternationalLicense()
        {
            //here we set the applicaiton type to New International License.
            this.ApplicationTypeID = clsApplicationTypes.enApplicationType.NewInternationalLicense;

            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.DriverInfo = new clsDrivers();
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUserID = -1; 
            
            _Mode = enMode.AddMode;
        }

        private clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, 
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            //this is for the base clase
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = clsApplicationTypes.enApplicationType.NewInternationalLicense;
            base.ApplicationTypeInfo = clsApplicationTypes.Find((int)this.ApplicationTypeID);
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;


            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDrivers.Find(DriverID);
            this.PersonInfo = DriverInfo.PersonInfo;
            _Mode = enMode.UpdateMode;
        }

        public static DataTable GetAll()
        {
            return clsInternationalData.GetAll();
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID =
                clsInternationalData.AddInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalData.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);
        }

        public static clsInternationalLicense Find(int ID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            bool IsActive = false;

            if (clsInternationalData.GetInternationalLicenseByID(ID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
                                                                  ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                clsApplications app = clsApplications.Find(ApplicationID);

                return new clsInternationalLicense(ApplicationID, app.ApplicantPersonID, app.ApplicationDate, app.ApplicationStatus, 
                    app.LastStatusDate, app.PaidFees, app.CreatedByUserID,
                    ID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);
            }
            return null;
        }

        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplications.enMode)_Mode;
            if (!base.Save())
                return false;

            if (_Mode == enMode.AddMode)
            {
                if (_AddNewInternationalLicense())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateInternationalLicense();
            }
            return false;
        }

        public static bool ExistsActiveInterLicenseByDriverID(int DriverID)
        {
            return clsInternationalData.IsInternationalLicenseExistByDriverIDAndActive(DriverID);
        }

    }
}
