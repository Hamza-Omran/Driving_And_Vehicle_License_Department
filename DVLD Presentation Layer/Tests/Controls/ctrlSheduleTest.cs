using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
using DVLD_Presentation_Layer.Applications.Controls;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static DVLD_Business_Layer.clsTests;

namespace DVLD_Presentation_Layer.Tests.Controls
{
    public partial class ctrlSheduleTest : UserControl
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        enum enMode { AddMode, EditMode };
        private enMode _Mode;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private int _Trial, _AppointmentID = -1, _LocalAppID = -1;
        private float _TotalTestFees;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;

        private clsLocalDrivingLicenseApplication _LocalAppInfo;
        private clsTestsAppointments appointment;

        public clsLocalDrivingLicenseApplication LocalAppInfo
        {
            get { return _LocalAppInfo; }
            set { _LocalAppInfo = value; } 
        }

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
                            lbHeader.Text = "Vision Test";
                            pbMain.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            lbHeader.Text = "Written Test";
                            pbMain.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            lbHeader.Text = "Street Test";
                            pbMain.Image = Resources.driving_test_512;
                            break;
                        }
                }
            }
        }
                 

        public ctrlSheduleTest()
        {
            InitializeComponent();
        }

        // in each time this control is used this form should be called
        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddMode;
            else
            {
                _Mode = enMode.EditMode;
                _AppointmentID = AppointmentID;
            }

            _LocalAppID = LocalDrivingLicenseApplicationID;
            _LocalAppInfo = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

            if (_LocalAppInfo == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalAppID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            //decide if the createion mode is retake test or not based if the person attended this test before
            if (_LocalAppInfo.DoesAttendTestType(_TestTypeID))

                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lbRetakeFeesVal.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).ApplicationFees.ToString();
                pInner.Enabled = true;
                lbHeader.Text = "Schedule Retake Test";
                lbReTestAppIDVal.Text = "0";
            }
            else
            {
                pInner.Enabled = false;
            }

            lbDLAppIDVal.Text = _LocalAppInfo.LocalApplicationID.ToString();
            lbDClassVal.Text = _LocalAppInfo.LicenseClassInfo.ClassName;
            lbNameVal.Text = _LocalAppInfo.PersonFullName;

            //this will show the trials for this test before  
            lbTrialVal.Text = _LocalAppInfo.TotalTrialsPerTest(_TestTypeID).ToString();

            if (_Mode == enMode.AddMode)
            {
                lbFeesVal.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                dtpDate.MinDate = DateTime.Now;
                lbReTestAppIDVal.Text = "N/A";

                appointment = new clsTestsAppointments();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            _TotalTestFees = Convert.ToSingle(lbFeesVal.Text);
            lbTotalFeesVAl.Text = (_TotalTestFees + Convert.ToSingle(lbRetakeFeesVal.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddMode && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalAppID, _TestTypeID))
            {
                lbUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _LoadTestAppointmentData()
        {
            appointment = clsTestsAppointments.Find(_AppointmentID);

            if (appointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _AppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lbFeesVal.Text = appointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, appointment.AppointmentDate) < 0)
                dtpDate.MinDate = DateTime.Now;
            else
                dtpDate.MinDate = appointment.AppointmentDate;

            dtpDate.Value = appointment.AppointmentDate;

            if (appointment.RetakeTestApplicationID == -1)
            {
                pInner.Enabled = false;

                lbRetakeFeesVal.Text = "0";
                lbReTestAppIDVal.Text = "N/A";
            }
            else
            {
                lbRetakeFeesVal.Text = appointment.RetakeTestAppInfo.PaidFees.ToString();
                pInner.Enabled = true;
                lbHeader.Text = "Schedule Retake Test";
                lbReTestAppIDVal.Text = appointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (appointment.IsLocked)
            {
                lbUserMessage.Visible = true;
                lbUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lbUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lbUserMessage.Visible = false;

                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalAppInfo.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lbUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lbUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lbUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }


                    return true;

                case clsTestTypes.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalAppInfo.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lbUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lbUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lbUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private bool _HandleRetakeApplicationSave()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddMode && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplications Application = new clsApplications();

                Application.ApplicantPersonID = _LocalAppInfo.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = clsApplicationTypes.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).ApplicationFees;
                Application.CreatedByUserID = clsGlobal.SysUser.UserID;

                if (!Application.Save())
                {
                    appointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                appointment.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplicationSave())
                return;

            if (_Mode == enMode.AddMode)
            {
                appointment.TestTypeID = (int)TestTypeID;
                appointment.LocalDrivingLicenseApplicationID = _LocalAppID;
                appointment.PaidFees = _TotalTestFees;
                appointment.CreatedByUserID = clsGlobal.SysUser.UserID;
            }

            appointment.AppointmentDate = dtpDate.Value;

            if (!appointment.Save())
            {
                MessageBox.Show("Failed To Save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(appointment.RetakeTestApplicationID != -1)
                lbReTestAppIDVal.Text = appointment.RetakeTestApplicationID.ToString();

            btnSave.Enabled = false;
            Refresh?.Invoke();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DTPFocus()
        {
            dtpDate.Focus();
        }
    }
}
