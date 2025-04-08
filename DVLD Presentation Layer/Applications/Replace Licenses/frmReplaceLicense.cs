using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.Applications
{
    public partial class frmReplaceLicense : Form
    {
        private int _LicenseID = -1;
        private clsApplicationTypes _App;

        public frmReplaceLicense()
        {
            InitializeComponent();
            ctrlFilterLicense1.OnLicenseSelected += RefreshInfo;
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {        
            FillData();

            llbShowLicenseInfo.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
            btnSave.Enabled = false;
        }
        private void FillData()
        {
            _App = clsApplicationTypes.Find(4);
            lbAppFeesVal.Text = _App.ApplicationFees.ToString();

            lbAppDateVal.Text = DateTime.Now.ToShortDateString();

            lbCreatedByVal.Text = clsGlobal.SysUser.UserName;
        }

        private void RefreshInfo(int LicenseID)
        {
            _LicenseID = LicenseID;

            if (ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("No License Found.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlFilterLicense1.License.IsActive) // must be expired
            {
                btnSave.Enabled = true;

                lbOldLicenseVal.Text = ctrlFilterLicense1.LicenseID.ToString();
            }
            else
            {
                btnSave.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
                MessageBox.Show("License Must Be Active.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llbShowLicenseHistory.Enabled = true;
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lbHeader.Text = "Replacement For Damaged License";
            _App = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReplaceDamagedDrivingLicense);

            lbAppFeesVal.Text = _App.ApplicationFees.ToString();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lbHeader.Text = "Replacement For Lost License";
            _App = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReplaceLostDrivingLicense);

            lbAppFeesVal.Text = _App.ApplicationFees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmShowLicense(ctrlFilterLicense1.LicenseID).ShowDialog();
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
            RefreshInfo(_LicenseID);
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(ctrlFilterLicense1.License.Driver.PersonID);

            frm.Refresh += RefreshLicenseInfo;
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replace Driving License?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicenses.enIssueReason IssueReason;

            if (_App.ApplicationTypeID == (int)clsApplicationTypes.enApplicationType.ReplaceDamagedDrivingLicense)
                IssueReason = clsLicenses.enIssueReason.DamagedReplacement;
            else
                IssueReason = clsLicenses.enIssueReason.LostReplacement;

            clsLicenses license = ctrlFilterLicense1.License.Replace(IssueReason, clsGlobal.SysUser.UserID);
            

            if (license == null)
            {
                MessageBox.Show("Couldn't Issue a replacemnet for this License.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbRAppIDVal.Text = license.ApplicationID.ToString();
            lbRLicenseVal.Text = license.LicenseID.ToString();


            llbShowLicenseInfo.Enabled = true;

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show($"Issued Successfully With License ID={license.LicenseID}.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            ctrlFilterLicense1.pFind.Enabled = false;
            pReason.Enabled = false;
            btnClose.Select();
        }

    }
}
