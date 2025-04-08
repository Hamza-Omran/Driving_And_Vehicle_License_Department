using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business_Layer
{
    public class clsApplications
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enum enMode { AddMode, UpdateMode };

        public enMode Mode = enMode.AddMode;

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public DateTime ApplicationDate { get; set; }

        public clsApplicationTypes.enApplicationType ApplicationTypeID { get; set; }

        public clsApplicationTypes ApplicationTypeInfo { get; set; }

        public enApplicationStatus ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }

        public float PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.Mode = enMode.AddMode;
            this.ApplicantPersonID = -1;
            this.PersonInfo = new clsPerson();
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
        }

        private clsApplications(int ID, enMode Mode, int ApplicantPersonID, DateTime ApplicationDate,
            clsApplicationTypes.enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ID;
            this.Mode = Mode;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.Find((int)ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static clsApplications Find(int applicationID)
        {
            int applicantPersonID = -1, applicationTypeID = -1, applicationStatus = -1, createdByUserID = -1;
            DateTime applicationDate = DateTime.MinValue, lastStatusDate = DateTime.MinValue;
            float paidFees = 0;

            if (clsApplicationsData.GetApplicationByID(applicationID, ref applicantPersonID, ref applicationDate,
                ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplications(applicationID, enMode.UpdateMode, applicantPersonID, applicationDate,
                    (clsApplicationTypes.enApplicationType)applicationTypeID, (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
            }

            return null;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddApplication(
                this.ApplicantPersonID, this.ApplicationDate,
                (int)this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                (int)this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public bool Save()
        {
            if (this.Mode == enMode.AddMode)
            {
                if (_AddNewApplication())
                {
                    this.Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (this.Mode == enMode.UpdateMode)
            {

                return _UpdateApplication();
            }
            return false;
        }

        public bool Delete()
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }

        public bool Cancel()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, 2);
        }

        public bool SetComplete()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, 3);
        }
    }
}

