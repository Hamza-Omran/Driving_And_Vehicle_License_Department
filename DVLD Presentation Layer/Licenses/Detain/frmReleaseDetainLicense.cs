using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using DVLD_Presentation_Layer.Global_Classes;
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

namespace DVLD_Presentation_Layer.Detain
{
    public partial class frmReleaseDetainLicense : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LicenseID = -1;
        private clsApplicationTypes _App = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense);

        public frmReleaseDetainLicense()
        {
            InitializeComponent();

            btnRelease.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
            llbShowLicenseInfo.Enabled = false;
        }

        public frmReleaseDetainLicense(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;

            ctrlFilterLicense1.LoadLicenseInfo(_LicenseID);

            if (ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("No License with ID=" + _LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlFilterLicense1.FilterEnabled = false;
            SetDetainInfo();
        }

        private void FilterRefreshed(int LicenseID)
        {
            _LicenseID = LicenseID;

            if (ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("No License Found.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlFilterLicense1.License.IsDetained)
            {
                btnRelease.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                MessageBox.Show("Selected License Is Not Detained.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            SetDetainInfo();

            btnRelease.Enabled = true;
            llbShowLicenseHistory.Enabled = true;
        }

        private void SetDetainInfo()
        {
            lbAppFeesVal.Text = _App.ApplicationFees.ToString();

            lbLicenseIDVal.Text = ctrlFilterLicense1.LicenseID.ToString();

            if (ctrlFilterLicense1.License.DetainInfo != null)
            {
                lbDetainIDVal.Text = ctrlFilterLicense1.License.DetainInfo.ID.ToString();
                lbDetainDateVal.Text = clsFormat.DateToShort(ctrlFilterLicense1.License.DetainInfo.DetainDate);
                lbCreatedByVal.Text = ctrlFilterLicense1.License.DetainInfo.CreatedByUserID.ToString();
                lbFineFeesVal.Text = ctrlFilterLicense1.License.DetainInfo.DetainFees.ToString();
                lbTotalFeesVal.Text = (ctrlFilterLicense1.License.DetainInfo.DetainFees + _App.ApplicationFees).ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release Driving License?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int AppID = -1;

            if(!ctrlFilterLicense1.License.ReleaseDetainedLicense(clsGlobal.SysUser.UserID, ref AppID, _App.ApplicationFees))
            {
                MessageBox.Show("Couldn't Release License.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbRAppIDVal.Text = AppID.ToString();

            Refresh?.Invoke();

            btnRelease.Enabled = false;
            llbShowLicenseInfo.Enabled = true;
            ctrlFilterLicense1.pFind.Enabled = false;
            btnClose.Select();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();

            MessageBox.Show("Released Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmShowLicense(_LicenseID).ShowDialog();
        }

        private void RefreshLicenseInfo()
        {
            ctrlFilterLicense1.LoadLicenseInfo(_LicenseID);

            if (ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("No License with ID=" + _LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            FilterRefreshed(_LicenseID);
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(ctrlFilterLicense1.License.Driver.PersonID);

            frm.Refresh += RefreshLicenseInfo;
            frm.ShowDialog();
        }

        private void frmReleaseDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlFilterLicense1.txtLicenseIDFocus();
        }

    }
}
