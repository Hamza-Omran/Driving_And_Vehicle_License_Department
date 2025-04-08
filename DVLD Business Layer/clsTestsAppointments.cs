using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsTestsAppointments
    {
        private enum enMode { AddMode, UpdateMode }
        private enMode _Mode;

        public int TestAppointmentID { set; get; }

        public int TestTypeID { set; get; }

        public int LocalDrivingLicenseApplicationID { set; get; }

        public DateTime AppointmentDate { set; get; }

        public float PaidFees { set; get; }

        public int CreatedByUserID { set; get; }

        public bool IsLocked { set; get; }

        public int RetakeTestApplicationID { set; get; }

        public clsApplications RetakeTestAppInfo { set; get; }

        public int TestID
        {
            get { return _GetTestID(); }
        }

        public clsTestsAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            this.IsLocked = false;

            _Mode = enMode.AddMode;
        }

        private clsTestsAppointments(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplications.Find(RetakeTestApplicationID);
            this.IsLocked = isLocked;

            _Mode = enMode.UpdateMode;
        }

        public static clsTestsAppointments Find(int testAppointmentID)
        {
            int testTypeID = -1, localDrivingLicenseApplicationID = -1, createdByUserID = -1, RetakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.MinValue;
            float paidFees = 0;
            bool isLocked = false;

            if (clsTestsAppointmentData.GetTestAppointmentInfoByID(testAppointmentID, ref testTypeID, ref localDrivingLicenseApplicationID,
                ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref RetakeTestApplicationID))
            {
                return new clsTestsAppointments(testAppointmentID, testTypeID, localDrivingLicenseApplicationID,
                    appointmentDate, paidFees, createdByUserID, isLocked, RetakeTestApplicationID);
            }

            return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestsAppointmentData.AddTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                    this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestsAppointmentData.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID,
                    this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddNewTestAppointment())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }

                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateTestAppointment();
            }

            return false;
        }

        public static DataTable GetAppointmentsOfLocalAppIDAndTestType(int LDLAppID, clsTestTypes.enTestType TestType)
        {
            return clsTestsAppointmentData.GetAppointmentsOfLocalAppIDAndTestType(LDLAppID, (int)TestType);
        }

        public static bool IsThereActiveTestAppointments(clsTestTypes.enTestType TestTypeID, int LocalAppID)
        {
            return clsTestsAppointmentData.IsThereActiveTestAppointments((int)TestTypeID, LocalAppID);
        }

        private int _GetTestID()
        {
            return clsTestsAppointmentData.GetTestID(TestAppointmentID);
        }
    }
}
