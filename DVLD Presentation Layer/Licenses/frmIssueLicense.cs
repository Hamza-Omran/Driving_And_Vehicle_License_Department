using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
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

namespace DVLD_Presentation_Layer.Applications.Local_Driving_License
{
    public partial class frmIssueLicense : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _localAppID;
        public frmIssueLicense(int LDLAppID)
        {
            InitializeComponent();

            _localAppID = LDLAppID;
        }

        private void frmIssueLicense_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseAppInfo1.LoadAppInfo(_localAppID);

            if (ctrlDrivingLicenseAppInfo1.LocalAppInfo == null)
            {
                MessageBox.Show("No Applicaiton with ID=" + _localAppID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!clsLocalDrivingLicenseApplication.PassedAllTests(ctrlDrivingLicenseAppInfo1.LocalAppID))
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = ctrlDrivingLicenseAppInfo1.LocalAppInfo.GetActiveLicenseID();
            if (LicenseID != -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = ctrlDrivingLicenseAppInfo1.LocalAppInfo.IssueLicenseForTheFirtTime(tbNotes.Text.Trim(), clsGlobal.SysUser.UserID);

            if (LicenseID == -1)
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = false;
            tbNotes.Enabled = false;
            ctrlDrivingLicenseAppInfo1.LicenseID = LicenseID;
            Refresh?.Invoke();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show($"License Issued Successfully With ID = {LicenseID}", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
