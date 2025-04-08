using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.Controls;
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
using static DVLD_Business_Layer.clsSettings;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.Applications.International_Driving_License
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LicenseID = -1, _InterLicenseID = -1;

        private float _Fees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicense).ApplicationFees;

        private clsSettings _Setting = clsSettings.Find((int)enSettings.NewInternationalLicense);

        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();

            ctrlFilterLicense1.OnLicenseSelected += RefreshAppPanel;
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lbCreatedByVal.Text = clsGlobal.SysUser.UserName;
            lbFeesVal.Text = _Fees.ToString();

            llbShowLicenseInfo.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
            btnIssue.Enabled = false;
        }

        private void RefreshAppPanel(int LicenseID)
        {
            if (LicenseID == -1)
                return;

            _LicenseID = LicenseID;

            if(ctrlFilterLicense1.License == null)
            {
                MessageBox.Show($"There Is No License", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

             if (ctrlFilterLicense1.License.LicenseClass.LicenseClassID != (int)clsLicenseClasses.enLicenseClasses.OrdinaryDrivingLicense) // must be ordinary driving license
            {
                btnIssue.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                MessageBox.Show($"Choose Another License, the license must be Ordinary Class", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsInternationalLicense.ExistsActiveInterLicenseByDriverID(ctrlFilterLicense1.License.Driver.DriverID))
            {
                MessageBox.Show($"Person Already has International license.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlFilterLicense1.License.ExpiryDate >= DateTime.Now.AddYears(_Setting.ValidityLength))
                lbExpirationDateVal.Text = clsFormat.DateToShort(DateTime.Now.AddYears(_Setting.ValidityLength));
            else
                lbExpirationDateVal.Text = clsFormat.DateToShort(ctrlFilterLicense1.License.ExpiryDate);

            lbAppDateVal.Text = clsFormat.DateToShort(DateTime.Now);
            lbIssueDateVal.Text = clsFormat.DateToShort(DateTime.Now);

            btnIssue.Enabled = true;
            llbShowLicenseHistory.Enabled = true;
            lbLocalLicenseVal.Text = _LicenseID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(_LicenseID > 0))
            {
                MessageBox.Show($"You Must Search For A License First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlFilterLicense1.License.IsActive)
            {
                MessageBox.Show($"The License Must Be Active.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            if (MessageBox.Show("Are you sure you want to issue International Driving License?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int AppID = -1;
            _InterLicenseID = ctrlFilterLicense1.License.IssueInternationalLicense(_Setting, clsGlobal.SysUser.UserID, _Fees, ref AppID);

            if (_InterLicenseID == -1)
            {
                MessageBox.Show("Couldn't Save", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbILAppIDVal.Text = AppID.ToString();
            lbInterLicenseVal.Text = _InterLicenseID.ToString();
            Refresh?.Invoke();

            llbShowLicenseInfo.Enabled = true;
            ctrlFilterLicense1.FilterEnabled = false;
            btnIssue.Enabled = false;

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Issued Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshInfo()
        {
            ctrlFilterLicense1.LoadLicenseInfo(_LicenseID);

            if (ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("No License with ID=" + _LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            RefreshAppPanel(_LicenseID);
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(ctrlFilterLicense1.License.Driver.PersonID);

            frm.Refresh += RefreshInfo;
            frm.ShowDialog();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmInternationalLicenseInfo(_InterLicenseID).ShowDialog();
        }

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlFilterLicense1.txtLicenseIDFocus();
        }
    }
}
