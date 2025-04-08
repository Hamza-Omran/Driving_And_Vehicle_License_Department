using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Local_Driving_License
{
    public partial class frmShowLicense : Form
    {
        private int _LicenseID;

        public frmShowLicense(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseCard1.LoadInfo(_LicenseID);

            if (ctrlLicenseCard1.License == null)
            {
                MessageBox.Show("No License with ID=" + _LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            btnClose.Select();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
