using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
using DVLD_Presentation_Layer.Global_Classes;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business_Layer.clsTests;

namespace DVLD_Presentation_Layer.Tests.Controls
{
    public partial class ctrlSheduledTest : UserControl
    {

        private clsTestTypes.enTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestTypes.enTestType.VisionTest:
                        {
                            lbTitle.Text = "Vision Test";
                            pbMain.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            lbTitle.Text = "Written Test";
                            pbMain.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            lbTitle.Text = "Street Test";
                            pbMain.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        public int LabelTestID
        {
            set
            {
                lbTestIDVal.Text = value.ToString();
            }
        }

        public clsTestsAppointments TestAppointment
        {
            get
            {
                return _TestAppointment;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestsAppointments _TestAppointment;

        public void LoadInfo(int TestAppointmentID)
        { 
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestsAppointments.Find(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbDLAppIDVal.Text = _LocalDrivingLicenseApplication.LocalApplicationID.ToString();
            lbDClassVal.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lbNameVal.Text = _LocalDrivingLicenseApplication.PersonFullName;

            //this will show the trials for this test before 
            lbTrialVal.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            lblDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lbTestIDVal.Text = (_TestID == -1) ? "Not Taken Yet" : _TestID.ToString();

        }

        public ctrlSheduledTest()
        {
            InitializeComponent();
        }
    }
}
