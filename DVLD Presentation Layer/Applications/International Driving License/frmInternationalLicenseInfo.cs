using DVLD_Presentation_Layer.Applications.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.International_Driving_License
{
    public partial class frmInternationalLicenseInfo : Form
    {
        private int _InterLicenseID = -1;
        public frmInternationalLicenseInfo(int InterLicenseID)
        {
            InitializeComponent();

            _InterLicenseID = InterLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadInterLicenseInfo(_InterLicenseID);

            if(ctrlInternationalLicenseInfo1.InterLicense == null)
            {
                MessageBox.Show("No International License with ID = " + ctrlInternationalLicenseInfo1.InterLicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}
