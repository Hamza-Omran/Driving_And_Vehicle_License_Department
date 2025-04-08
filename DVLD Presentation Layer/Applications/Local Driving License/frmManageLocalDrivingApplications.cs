using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
using DVLD_Presentation_Layer.Applications.Controls;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using DVLD_Presentation_Layer.Applications.Take_Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DVLD_Presentation_Layer
{
    public partial class frmManageLocalDrivingApplications : Form
    {
        private DataTable _dtAllLocalApps = new DataTable();

        public frmManageLocalDrivingApplications()
        {
            InitializeComponent();
        }

        private void ManageApplicationsForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            LoadDGVApplications();
        }


        // DGV Related Code
        public void LoadDGVApplications()
        {
            _dtAllLocalApps = clsLocalDrivingLicenseApplication.GetAll();

            _dtAllLocalApps.Columns[0].ColumnName = "L.D.L.AppID";
            _dtAllLocalApps.Columns[1].ColumnName = "Driving Class";
            _dtAllLocalApps.Columns[2].ColumnName = "National No.";
            _dtAllLocalApps.Columns[3].ColumnName = "Full Name";
            _dtAllLocalApps.Columns[4].ColumnName = "Application Date";
            _dtAllLocalApps.Columns[5].ColumnName = "Passed Tests";

            dgvApplications.DataSource = _dtAllLocalApps;

            dgvApplications.Columns["Driving Class"].Width = 230;
            dgvApplications.Columns["Full Name"].Width = 200;
            dgvApplications.Columns["Application Date"].Width = 150;

            lbRecordsVal.Text = _dtAllLocalApps.DefaultView.Count.ToString();
        }

        private void dgvApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvApplications.ClearSelection(); // Clear any existing selection
                dgvApplications.Rows[e.RowIndex].Selected = true;

                dgvApplications.CurrentCell = dgvApplications.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void RefreshDGV()
        {
            LoadDGVApplications();

            if (cbStatus.Visible)
                cbStatus_SelectedIndexChanged(null, null);
            else if (tbFilterBy.Visible)
                tbFilterBy_TextChanged(null, null);
        }


        // Filteration
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Visible = false;
            cbStatus.Visible = false;

            _dtAllLocalApps.DefaultView.RowFilter = "true";
            lbRecordsVal.Text = _dtAllLocalApps.DefaultView.Count.ToString();

            if (cbFilterBy.SelectedIndex == 0)
            {
                return;
            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                tbFilterBy.Visible = true;
                tbFilterBy.Text = "";
            }
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFilterBy.Text) && cbFilterBy.SelectedIndex != 0)
            {
                if (cbFilterBy.Text != "L.D.L.AppID")
                    _dtAllLocalApps.DefaultView.RowFilter = $"Convert([{cbFilterBy.SelectedItem.ToString()}], 'System.String') LIKE '%{tbFilterBy.Text.Replace("'", "''").Replace("%", "[%]").Replace("*", "[*]")}%'";
                else
                    _dtAllLocalApps.DefaultView.RowFilter = $"Convert([{cbFilterBy.SelectedItem.ToString()}], 'System.String') = '{tbFilterBy.Text.Replace("'", "''").Replace("%", "[%]").Replace("*", "[*]")}'";
            }
            else
            {
                _dtAllLocalApps.DefaultView.RowFilter = string.Empty;
            }

            lbRecordsVal.Text = _dtAllLocalApps.DefaultView.Count.ToString();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
            else if (char.IsDigit(e.KeyChar) && cbFilterBy.Text != "National No.")
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex == 0)
            {
                _dtAllLocalApps.DefaultView.RowFilter = "true";
            }
            else
            {
                _dtAllLocalApps.DefaultView.RowFilter = string.Format("[{0}] = {1}", cbFilterBy.SelectedItem.ToString(), cbStatus.SelectedItem.ToString());
            }

            lbRecordsVal.Text = _dtAllLocalApps.DefaultView.Count.ToString();
        }


        // Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddOrEditLDL frm = new frmAddOrEditLDL();

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }


        // context menu
        private void cmsoIssueLicense_Click(object sender, EventArgs e)
        {
            frmIssueLicense frm = new frmIssueLicense(Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoVisionTest_Click(object sender, EventArgs e)
        {
            frmManageAppointmentsTests frm = new frmManageAppointmentsTests(Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value), 1);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoWrittenTest_Click(object sender, EventArgs e)
        {
            frmManageAppointmentsTests frm = new frmManageAppointmentsTests(Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value), 2);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoStreetTest_Click(object sender, EventArgs e)
        {
            frmManageAppointmentsTests frm = new frmManageAppointmentsTests(Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value), 3);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoShowDetails_Click(object sender, EventArgs e)
        {
            frmShowApplicationDetails frm = new frmShowApplicationDetails(Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoShowLicense_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication local = clsLocalDrivingLicenseApplication.Find(Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value));
            
            new frmShowLicense(local.GetActiveLicenseID()).ShowDialog();
        }

        private void cmsoDelete_Click(object sender, EventArgs e)
        {
            int LocalAppID = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value);

            if (MessageBox.Show("Are You Sure You Want To Delete Application [" + LocalAppID + "]?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalAppID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    RefreshDGV();
                    MessageBox.Show("Application Deleted Successfully.", "Successfull");
                }
                else
                    MessageBox.Show("You Can't Delete This Application, Please Contact Developer", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsoCancel_Click(object sender, EventArgs e)
        {
            int LocalAppID = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["L.D.L.AppID"].Value);

            if (MessageBox.Show("Are You Sure You Want To Delete Application [" + LocalAppID + "]?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalAppID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    RefreshDGV();
                    MessageBox.Show("Application Cancelled Successfully.", "Successfull");
                }
                else
                    MessageBox.Show("You Can't Cancel This Application, Please Contact Developer", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsoLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(clsPerson.Find(dgvApplications.SelectedRows[0].Cells["National No."].Value.ToString()).ID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoEdit_Click(object sender, EventArgs e)
        {
            frmAddOrEditLDL frm = new frmAddOrEditLDL(Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsOptions_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            cmsoIssueLicense.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            cmsoShowLicense.Enabled = LicenseExists;
            cmsoEdit.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);
            cmsoScheduleTest.Enabled = !LicenseExists;

            //We only canel the applications with status = new.
            cmsoCancel.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New) && (int)dgvApplications.CurrentRow.Cells[5].Value != 0;

            //We only allow delete in case the passed tests = 0 and the application status is new --> not complete nor Cancelled.
            cmsoDelete.Enabled = (cmsoCancel.Enabled) && (int)dgvApplications.CurrentRow.Cells[5].Value == 0;

            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

            cmsoScheduleTest.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            if (cmsoScheduleTest.Enabled)
            {
                cmsoVisionTest.Enabled = !PassedVisionTest;

                cmsoWrittenTest.Enabled = PassedVisionTest && !PassedWrittenTest;

                cmsoStreetTest.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }
        }
    }
}
