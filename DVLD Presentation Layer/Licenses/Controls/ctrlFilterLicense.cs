using DVLD_Business_Layer;
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

namespace DVLD_Presentation_Layer
{
    public partial class ctrlFilterLicense : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;

        private bool _FilterEnabled = true;

        public int LicenseID
        {
            get { return ctrlLicenseCard1.LicenseID; }
            set { ctrlLicenseCard1.LicenseID = value; }
        }

        public clsLicenses License
        {
            get { return ctrlLicenseCard1.License; }
            set { ctrlLicenseCard1.License = value; }
        }

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                pFind.Enabled = _FilterEnabled;
            }
        }

        public ctrlFilterLicense()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            tbLicenseIDVal.Text = LicenseID.ToString();
            pFind.Enabled = false;
            btnSearch_Click(null, null);
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }   
        }

        public void txtLicenseIDFocus()
        {
            tbLicenseIDVal.Focus();
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlLicenseCard1.LoadInfo(Convert.ToInt32(tbLicenseIDVal.Text));

            if (pFind.Enabled)
            {
                new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();

                if (OnLicenseSelected != null)
                    OnLicenseSelected(ctrlLicenseCard1.LicenseID);
            }

            if (ctrlLicenseCard1.License == null)
            {
                ctrlLicenseCard1.ResetDefaultValues();
                return;
            }
        }

        private void tbLicenseIDVal_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbLicenseIDVal.Text))
            {
                epValidation.SetError(tbLicenseIDVal, "The Field Is Required.");
            }
            else
            {
                epValidation.SetError(tbLicenseIDVal, "");
            }
        }
    }
}
