using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business_Layer.clsLicenseClasses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer
{
    public partial class frmAddOrEditLDL : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        enum enMode { AddMode, EditMode };
        private enMode _Mode;

        private int _LocalAppID;
        private clsLocalDrivingLicenseApplication _LocalApplication;
        private clsApplicationTypes _AppType = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewDrivingLicense);

        private int _cbSelectedIndex = -1;

        public frmAddOrEditLDL()
        {
            InitializeComponent();

            _Mode = enMode.AddMode;
        }

        public frmAddOrEditLDL(int LocalAppID)
        {
            InitializeComponent();

            _LocalAppID = LocalAppID;

            _Mode = enMode.EditMode;
        }

        private void AddNewDrivingLicense_Load(object sender, EventArgs e)
        {
            LoadClassesComboBox();
            LoadData();
            btnSave.Enabled = false;
        }

        private void LoadData()
        {
            if (_Mode == enMode.AddMode)
            {
                this.Text = "Add New L.D.L App Screen";
                _LocalApplication = new clsLocalDrivingLicenseApplication();
                lbApplicationDateVal.Text = DateTime.Today.ToShortDateString();
                lbApplicationFeesVal.Text = _AppType.ApplicationFees.ToString();
            }
            else
            {
                this.Text = "Edit L.D.L App Screen";
                _LocalApplication = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

                if (_LocalApplication == null)
                {
                    MessageBox.Show("No Application Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _cbSelectedIndex = cbLicenseClass.FindString(_LocalApplication.LicenseClassInfo.ClassName);
                cbLicenseClass.SelectedIndex = _cbSelectedIndex;

                this.ctrlFilterPerson1.LoadPersonInfo(_LocalApplication.ApplicantPersonID);

                if (ctrlFilterPerson1.SelectedPersonInfo == null)
                {
                    MessageBox.Show("No Application Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lbApplicationDateVal.Text = _LocalApplication.ApplicationDate.ToShortDateString();
                lbApplicationFeesVal.Text = _LocalApplication.PaidFees.ToString();
                lbApplicationIDVal.Text = _LocalAppID.ToString();
            }

            lbCreatedByVal.Text = clsGlobal.SysUser.UserName;
        }

        private void LoadClassesComboBox()
        {
            foreach (DataRow row in clsLicenseClasses.GetAllLicenseClasses().Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }

            cbLicenseClass.SelectedIndex = 2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicenseClasses LicenseClass = clsLicenseClasses.Find(cbLicenseClass.SelectedItem.ToString());
            int LocalAppID = clsLocalDrivingLicenseApplication.GetActiveLocalAppID(ctrlFilterPerson1.PersonID, LicenseClass.LicenseClassID);

            if (LocalAppID != -1)
            {
                MessageBox.Show($"Choose Another License Class, the selected person already has an active application for the selected class with ID = {LocalAppID}.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicenses.ExistsByPersonIDAndLicenseClassID(ctrlFilterPerson1.PersonID, LicenseClass.LicenseClassID))
            {
                MessageBox.Show($"Person Already has a license with the same applied driving class, Choose another driving class.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_Mode == enMode.AddMode)
            {
                _LocalApplication.ApplicantPersonID = ctrlFilterPerson1.PersonID;
                _LocalApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
                _LocalApplication.PaidFees = _AppType.ApplicationFees;
                _LocalApplication.ApplicationTypeID = clsApplicationTypes.enApplicationType.NewDrivingLicense;
                _LocalApplication.CreatedByUserID = clsGlobal.SysUser.UserID;
                _LocalApplication.LicenseClassInfo = LicenseClass;
            }

            _LocalApplication.LicenseClassID = LicenseClass.LicenseClassID;

            if (!_LocalApplication.Save())
            {
                MessageBox.Show("Something Went Wrong, Couldn't Save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lbApplicationIDVal.Text = _LocalApplication.ApplicationID.ToString();

            btnSave.Enabled = false;
            Refresh?.Invoke();

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbAddApplication.SelectedIndex = 1;
        }

        private void tbAddApplication_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Mode == enMode.EditMode)
                return;

            if (e.TabPageIndex == 1)
            {
                if (ctrlFilterPerson1.PersonID != -1)
                {
                    btnSave.Enabled = true;
                    return;
                }

                MessageBox.Show("You Must Find A Person First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the tab change
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Mode == enMode.EditMode)
                btnSave.Enabled = (cbLicenseClass.SelectedIndex + 1) != _cbSelectedIndex + 1;
        }

        private void frmAddOrEditLDL_Activated(object sender, EventArgs e)
        {
            ctrlFilterPerson1.FilterFocus();
        }
    }
}
