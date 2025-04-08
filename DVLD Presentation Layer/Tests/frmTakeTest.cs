using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business_Layer.clsTests;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.Take_Appointment.Controls
{
    public partial class frmTakeTest : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _AppointmentID;
        private clsTestTypes.enTestType _TestType;

        private int _TestID = -1;
        private clsTests _Test;

        public frmTakeTest(int AppointmentID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSheduledTest1.TestTypeID = _TestType;

            ctrlSheduledTest1.LoadInfo(_AppointmentID);

            if (ctrlSheduledTest1.TestAppointment == null)
            {
                MessageBox.Show("No Test Appointment Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (ctrlSheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int _TestID = ctrlSheduledTest1.TestID;

            if (_TestID != -1)
            {
                _Test = clsTests.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                tbNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }

            else
                _Test = new clsTests();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Save? After That You Can't Change The Pass/Fail Results After You Save?.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = tbNotes.Text.Trim();
            _Test.CreatedBy = clsGlobal.SysUser.UserID;

            if (!_Test.Save())
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlSheduledTest1.LabelTestID = _Test.ID;
            btnSave.Enabled = false;
            rbPass.Enabled = false;
            rbFail.Enabled = false;
            Refresh?.Invoke();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
