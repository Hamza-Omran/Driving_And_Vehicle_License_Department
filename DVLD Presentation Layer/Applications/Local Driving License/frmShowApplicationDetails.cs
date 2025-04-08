using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Local_Driving_License
{
    public partial class frmShowApplicationDetails : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LocalID = -1;

        public frmShowApplicationDetails(int LocalID)
        {
            InitializeComponent();

            _LocalID = LocalID;
            this.ctrlDrivingLicenseAppInfo1.Refresh += RefreshInfo;
        }

        private void frmShowApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseAppInfo1.LoadAppInfo(_LocalID);

            if (ctrlDrivingLicenseAppInfo1.LocalAppInfo == null)
            {
                MessageBox.Show("No Applicaiton with ID=" + _LocalID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void RefreshInfo()
        {
            Refresh?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
