using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business_Layer
{
    public class clsLicenses
    {
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        enum enMode { AddMode, UpdateMode };

        private enMode _Mode;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDrivers Driver { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public clsDetainedLicenses DetainInfo { set; get; }
        public bool IsDetained
        {
            get
            {
                return clsDetainedLicenses.IsLicenseDetained(this.LicenseID);
            }
        }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }


        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpiryDate = DateTime.MinValue;
            this.Notes = string.Empty;
            this.PaidFees = 0.0f;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            this.IsActive = false;

            this.Driver = new clsDrivers();
            this.LicenseClass = new clsLicenseClasses();
            this.DetainInfo = new clsDetainedLicenses();

            _Mode = enMode.AddMode;
        }

        private clsLicenses(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expiryDate, string notes, float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClassID = licenseClass;
            this.IssueDate = issueDate;
            this.ExpiryDate = expiryDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;
            this.IsActive = isActive;


            this.Driver = clsDrivers.Find(this.DriverID);
            this.LicenseClass = clsLicenseClasses.Find(this.LicenseClassID);
            this.DetainInfo = clsDetainedLicenses.FindByLicenseID(this.LicenseID);

            _Mode = enMode.UpdateMode;
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicensesData.AddLicense(this.ApplicationID, this.DriverID, this.LicenseClassID,
               this.IssueDate, this.ExpiryDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicensesData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClassID,
               this.IssueDate, this.ExpiryDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static clsLicenses Find(int licenseID)
        {
            int applicationID = -1, driverID = -1, licenseClass = -1, issueReason = -1, createdByUserID = -1;
            bool isActive = false;
            DateTime issueDate = DateTime.MinValue, expiryDate = DateTime.MinValue;
            string notes = string.Empty;
            float paidFees = 0.0f;

            if (clsLicensesData.GetLicenseInfoByID(licenseID, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expiryDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))
            {
                return new clsLicenses(licenseID, applicationID, driverID, licenseClass, issueDate, expiryDate, notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID);
            }
            return null;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddNewLicense())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateLicense();
            }
            return false;
        }
        
        public static bool ExistsByPersonIDAndLicenseClassID(int PersonID, int licenseID)
        {
            return GetActiveLicenseIDByPersonID(PersonID, licenseID) != -1;
        }

        public int IssueInternationalLicense(clsSettings Setting, int CreatedByUserID, float Fees, ref int AppID)
        {
            clsInternationalLicense InterLicense = new clsInternationalLicense();

            // base Class Info
            InterLicense.ApplicantPersonID = Driver.PersonID;
            InterLicense.ApplicationDate = DateTime.Now;
            InterLicense.LastStatusDate = DateTime.Now;
            InterLicense.ApplicationTypeID = clsApplicationTypes.enApplicationType.NewInternationalLicense;
            InterLicense.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            InterLicense.PaidFees = Fees;
            InterLicense.CreatedByUserID = CreatedByUserID;

            // International Class Info
            InterLicense.DriverID = this.DriverID;
            InterLicense.IssuedUsingLocalLicenseID = this.LicenseID;
            InterLicense.IssueDate = DateTime.Now;

            if (this.ExpiryDate >= DateTime.Now.AddYears(Setting.ValidityLength))
                InterLicense.ExpirationDate = DateTime.Now.AddYears(Setting.ValidityLength);
            else
                InterLicense.ExpirationDate = this.ExpiryDate;

            InterLicense.IsActive = true;
            InterLicense.CreatedByUserID = CreatedByUserID;

            if (!InterLicense.Save())
            {
                return -1;
            }

            AppID = InterLicense.ApplicationID;
            return InterLicense.InternationalLicenseID;
        }

        public bool ReleaseDetainedLicense(int CreatedByUserID, ref int AppID, float Fees)
        {
            clsApplications application = new clsApplications();

            application.ApplicantPersonID = this.Driver.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.ApplicationTypeID = clsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense;
            application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            application.PaidFees = Fees;
            application.CreatedByUserID = CreatedByUserID;

            if (!application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            AppID = application.ApplicationID;

            return this.DetainInfo.ReleaseDetainedLicense(CreatedByUserID, application.ApplicationID);
        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesData.DeactivateLicense(this.LicenseID));
        }

        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = this.Driver.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = clsApplicationTypes.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RenewDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClass.DefaultValidityLength;

            NewLicense.ExpiryDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicenses Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = this.Driver.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                clsApplicationTypes.enApplicationType.ReplaceDamagedDrivingLicense :
                clsApplicationTypes.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpiryDate = this.ExpiryDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicenses detainedLicense = new clsDetainedLicenses();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.DetainFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {
                return -1;
            }

            return detainedLicense.ID;
        }

        public Boolean IsLicenseExpired()
        {
            return (this.ExpiryDate < DateTime.Now);
        }
    }
}
