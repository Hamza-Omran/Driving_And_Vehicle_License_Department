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
    public partial class frmDetainLicense : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LicenseID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lbDetainDateVal.Text = DateTime.Now.ToShortDateString();
            lbCreatedByVal.Text = clsGlobal.SysUser.UserName;

            llbShowLicenseInfo.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
            btnDetain.Enabled = false;
        }

        private void FilterRefreshed(int LicenseID)
        {
            if (ctrlFilterLicense1.LicenseID == -1)
                return;

            _LicenseID = LicenseID;

            if(ctrlFilterLicense1.License == null)
            {
                MessageBox.Show("No License Found.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsDetainedLicenses.IsLicenseDetained(ctrlFilterLicense1.LicenseID))
            {
                btnDetain.Enabled = false;
                llbShowLicenseHistory.Enabled = false;
                llbShowLicenseInfo.Enabled = false;
                MessageBox.Show("Selected License Is Already Detained.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDetain.Enabled = true;
            llbShowLicenseHistory.Enabled = true;

            tbFees.Focus();
            lbLicenseIDVal.Text = ctrlFilterLicense1.LicenseID.ToString();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Detain Driving License?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int DetainID = ctrlFilterLicense1.License.Detain(Convert.ToSingle(tbFees.Text), clsGlobal.SysUser.UserID);

            if (DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbDetainIDVal.Text = DetainID.ToString();
            llbShowLicenseInfo.Enabled = true;
            btnDetain.Enabled = false;
            ctrlFilterLicense1.pFind.Enabled = false;

            Refresh?.Invoke();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Detained Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnClose.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.IsNumber(tbFees.Text))
            {
                e.Cancel = true;
                epValidation.SetError(tbFees, "Invalid Number.");
            }
            else if (String.IsNullOrEmpty(tbFees.Text))
            {
                epValidation.SetError(tbFees, "The Field Is Required.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(tbFees, "");
            }
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
            FilterRefreshed(_LicenseID);
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(ctrlFilterLicense1.License.Driver.PersonID);

            frm.Refresh += RefreshLicenseInfo;
            frm.ShowDialog();
        }
    }
}
