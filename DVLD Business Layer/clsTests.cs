using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsTests
    {
        private enum enMode { AddMode, UpdateMode };

        private enMode _Mode;

        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }

        public clsTests()
        {
            this.ID = -1;
            this._Mode = enMode.AddMode;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedBy = -1;
        }

        private clsTests(int id, enMode mode, int testAppointmentID, bool testResult, string notes, int createdBy)
        {
            this.ID = id;
            _Mode = mode;
            this.TestAppointmentID = testAppointmentID;
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedBy = createdBy;
        }

        public static clsTests Find(int id)
        {
            int testAppointmentID = -1;
            bool testResult = false;
            string notes = string.Empty;
            int createdBy = -1;

            if (clsTestsData.GetTestByID(id, ref testAppointmentID, ref testResult, ref notes, ref createdBy))
            {
                return new clsTests(id, enMode.UpdateMode, testAppointmentID, testResult, notes, createdBy);
            }

            return null;
        }

        private bool _AddNewTest()
        {
            this.ID = clsTestsData.AddTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedBy);
            return (this.ID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(this.ID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedBy);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddNewTest())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateTest();
            }
            return false;
        }

        public static bool IsTestTypePassed(int _TestTypeID, int _LDLAppID)
        {
            return clsTestsData.IsTestTypePassed(_TestTypeID, _LDLAppID);
        }
    }
}



