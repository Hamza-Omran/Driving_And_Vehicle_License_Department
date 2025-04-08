using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.International_Driving_License;
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

namespace DVLD_Presentation_Layer.Applications.Local_Driving_License
{
    public partial class frmRenewLocalDrivingLicense : Form
    {

        private int _LicenseID = -1;
        private float _AppFees = 0, _LicenseFees = 0;

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            ctrlFilterLicense1.OnLicenseSelected += RefreshInfo;
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            FillData();

            llbShowLicenseInfo.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
            btnRenew.Enabled = false;
        }

        private void FillData()
        {
            _AppFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RenewDrivingLicense).ApplicationFees;
            lbAppFeesVal.Text = _AppFees.ToString();

            lbAppDateVal.Text = clsFormat.DateToShort(DateTime.Now);
            lbIssueDateVal.Text = lbAppDateVal.Text;

            lbCreatedByVal.Text = clsGlobal.SysUser.UserName;
        }

        private void RefreshInfo(int LicenseID)
        {
            _LicenseID = LicenseID;

            if(ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("There Is No License Found", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlFilterLicense1.License.IsLicenseExpired()) // must be expired
            {
                btnRenew.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                MessageBox.Show($"Selected License Is Not Yet Expired, It Will Expire On: {ctrlFilterLicense1.License.ExpiryDate}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            //check the license is Active.
            if (!ctrlFilterLicense1.License.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRenew.Enabled = false;
                return;
            }

            DateTime _ExpireDate;

            _ExpireDate = DateTime.Now.AddYears(ctrlFilterLicense1.License.LicenseClass.DefaultValidityLength);
            lbExpirationDateVal.Text = _ExpireDate.ToShortDateString();

            lbOldLicenseVal.Text = ctrlFilterLicense1.LicenseID.ToString();

            _LicenseFees = ctrlFilterLicense1.License.LicenseClass.ClassFees;
            lbLicenseFeesVal.Text = _LicenseFees.ToString();
            lbTotalFeesVal.Text = (_LicenseFees + _AppFees).ToString();

            tbNotes.Text = ctrlFilterLicense1.License.Notes;

            btnRenew.Enabled = true;
            llbShowLicenseHistory.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew Driving License?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!ctrlFilterLicense1.License.IsActive)
            {
                MessageBox.Show($"The License Must Be Active.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsLicenses NewLicense = ctrlFilterLicense1.License.RenewLicense(tbNotes.Text, clsGlobal.SysUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbRAppIDVal.Text = NewLicense.ApplicationID.ToString();
            lbRLicenseVal.Text = NewLicense.LicenseID.ToString();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Issued Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrlFilterLicense1.pFind.Enabled = false;
            llbShowLicenseInfo.Enabled = true;
            btnClose.Select();
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

        private void frmRenewLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlFilterLicense1.txtLicenseIDFocus();
        }
    }
}
