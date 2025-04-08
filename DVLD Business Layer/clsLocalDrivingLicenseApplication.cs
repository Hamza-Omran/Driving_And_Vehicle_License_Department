using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data_Access_Layer
{
    public class clsLocalDrivingLicenseApplication : clsApplications
    {
        private enum enMode { AddMode, UpdateMode };
        private enMode _Mode;

        public int LocalApplicationID { set; get; }

        public int LicenseClassID { set; get; }

        public clsLicenseClasses LicenseClassInfo { set; get; }

        public string PersonFullName
        {
            get
            {
                return base.PersonInfo.FullName();
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalApplicationID = -1;
            this.LicenseClassID = -1;

            _Mode = enMode.AddMode;
        }

        private clsLocalDrivingLicenseApplication(int localApplicationID, int applicationID, int licenseClassID, int ApplicantPersonID, 
            DateTime ApplicationDate, clsApplicationTypes.enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.LocalApplicationID = localApplicationID;
            this.LicenseClassID = licenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.Find(this.LicenseClassID);

            // base class
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.Find((int)ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;


            this._Mode = enMode.UpdateMode;
        }

        public static DataTable GetAll()
        {
            return clsLocalDrivingLicenseApplicationData.GetAll();
        }

        public static clsLocalDrivingLicenseApplication Find(int localApplicationID)
        {
            int applicationID = -1, licenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalApplicationByID(localApplicationID, ref applicationID, ref licenseClassID);

            if (IsFound)
            {
                clsApplications Application = clsApplications.Find(applicationID);

                return new clsLocalDrivingLicenseApplication(localApplicationID, applicationID, licenseClassID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalApplicationID = clsLocalDrivingLicenseApplicationData.AddLocalDrivingLicense(ApplicationID, this.LicenseClassID);
            return (this.LocalApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalApplication(this.LocalApplicationID, ApplicationID, this.LicenseClassID);
        }

        public bool Save()
        {
            base.Mode = (clsApplications.enMode)this.Mode;
            if (!base.Save())
                return false;

            if (_Mode == enMode.AddMode)
            {
                if (_AddNewLocalDrivingLicenseApplication())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateLocalDrivingLicenseApplication();
            }

            return false;
        }

        public bool Delete()
        {
            if (!clsLocalDrivingLicenseApplicationData.DeleteLocalApplication(this.LocalApplicationID))
                return false;
            return base.Delete();
        }

        public byte GetPassedTestCount()
        {
            return clsLocalDrivingLicenseApplicationData.GetPassedTestCount(this.LocalApplicationID);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {
            //this will get the license id that belongs to this application
            return clsLicenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalApplicationID, (int)TestTypeID);
        }

        public static int GetActiveLocalAppID(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.GetActiveLocalAppIDByPersonIDAndLicenseClassID(PersonID, LicenseClassID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsLocalDrivingLicenseApplicationData.GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDrivers Driver = clsDrivers.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDrivers();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicenses License = new clsLicenses();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpiryDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalApplicationID, (int)TestTypeID);
        }
    }
}
