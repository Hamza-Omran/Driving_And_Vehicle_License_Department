using DVLD_Presentation_Layer.Applications;
using DVLD_Presentation_Layer.Applications.International_Driving_License;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using DVLD_Presentation_Layer.Detain;
using DVLD_Presentation_Layer.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmMain : Form
    {
        frmLogin _login;

        public frmMain(frmLogin login)
        {
            InitializeComponent();

            _login = login;
        }

        private void signOUtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msManagePeople_Click(object sender, EventArgs e)
        {
            new frmManagePeople().ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserInfoCard(clsGlobal.SysUser.UserID).ShowDialog();

        }

        private void msManageUsers_Click(object sender, EventArgs e)
        {
            new frmManageUsers().ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmChangeUserPassword(clsGlobal.SysUser.UserID).ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageApplicationTypes().ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageTestTypes().ShowDialog();

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAddOrEditLDL().ShowDialog();

        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageLocalDrivingApplications().ShowDialog();
        }

        private void MainScreenForm_Resize(object sender, EventArgs e)
        {
            int centerX = (this.Width - panel1.Width) / 2 - 10;
            int centerY = (this.Height - panel1.Height) / 2;

            // Set the PictureBox's location
            panel1.Location = new Point(centerX, centerY);
        }

        private void msManageDrivers_Click(object sender, EventArgs e)
        {
            new frmManageDrivers().ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmNewInternationalLicenseApplication().ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageInternationalLicenses().ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
             new frmRenewLocalDrivingLicense().ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReplaceLicense().ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDetainLicense().ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReleaseDetainLicense().ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageDetainedLicenses().ShowDialog();
        }

        private void MainScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Opacity = 1;  // Show after maximizing
        }
    }
}
