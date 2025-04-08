using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsDetainedLicenses
    {
        private enum enMode { AddMode, UpdateMode };
        private enMode _Mode;

        public int ID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float DetainFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers CreatedByUserInfo { set; get; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUsers ReleasedByUserInfo { set; get; }
        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicenses()
        {
            this.ID = -1;
            _Mode = enMode.AddMode;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.DetainFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
        }

        private clsDetainedLicenses(int id, int licenseID, DateTime detainDate, float detainFees,
                                     int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            this.ID = id;
            _Mode = enMode.UpdateMode;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.DetainFees = detainFees;
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUserInfo = clsUsers.Find(this.CreatedByUserID);
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleasedByUserInfo = clsUsers.Find(this.ReleasedByUserID);
            this.ReleaseApplicationID = releaseApplicationID;
        }

        private bool _AddNewDetainedLicense()
        {
            this.ID = clsDetainedLicensesData.AddDetainedLicense(
                this.LicenseID, this.DetainDate, this.DetainFees, this.CreatedByUserID);

            return (this.ID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(
                this.ID, this.LicenseID, this.DetainDate, this.DetainFees, this.CreatedByUserID);
        }

        public static clsDetainedLicenses FindByLicenseID(int licenseID)
        {
            int id = -1, createdByUserID = -1, releasedByUserID = -1, releaseApplicationID = -1;
            bool isReleased = false;
            DateTime detainDate = DateTime.MinValue, releaseDate = DateTime.MinValue;
            float detainFees = 0;

            if (clsDetainedLicensesData.GetDetainedLicenseByID(ref id, licenseID, ref detainDate, ref detainFees,
                                                               ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetainedLicenses(id, licenseID, detainDate, detainFees,
                                               createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            return null;
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddNewDetainedLicense())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateDetainedLicense();
            }
            return false;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicensesData.ReleaseDetainedLicense(this.ID, ReleasedByUserID, ReleaseApplicationID);
        }

        public static bool IsLicenseDetained(int licenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetained(licenseID);
        }

        public static DataTable GetAll()
        {
            return clsDetainedLicensesData.GetAll();
        }
    }
}
