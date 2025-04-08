using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Take_Appointment;
using DVLD_Presentation_Layer.Take_Appointment.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Take_Appointment
{
    public partial class frmManageAppointmentsTests : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LDLAppID;

        private clsTestTypes.enTestType _TestTypeID;
        public frmManageAppointmentsTests(int LDLAppID, int TestTypeID)
        {
            InitializeComponent();

            this.dgvTestsAppointments.CellMouseDown += dgvManagePeople_CellMouseDown;

            _LDLAppID = LDLAppID;
            _TestTypeID = (clsTestTypes.enTestType)TestTypeID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            if (_TestTypeID == clsTestTypes.enTestType.WrittenTest)
            {
                pictureBox1.Image = Properties.Resources.Written_Test_512;
                label3.Text = "Written Test Appointment";
            }
            else if (_TestTypeID == clsTestTypes.enTestType.StreetTest)
            {
                pictureBox1.Image = Properties.Resources.driving_test_512;
                label3.Text = "Street Test Appointment";
            }

            ctrlDrivingLicenseAppInfo1.LoadAppInfo(_LDLAppID);

            if (ctrlDrivingLicenseAppInfo1.LocalAppInfo == null)
            {
                MessageBox.Show("No Applicaiton with ID=" + _LDLAppID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadDGV();
        }

        private void LoadDGV()
        {
            DataTable Data = clsTestsAppointments.GetAppointmentsOfLocalAppIDAndTestType(_LDLAppID, _TestTypeID);

            if (Data.Rows.Count > 0)
            {
                Data.Columns["TestAppointmentID"].ColumnName = "Appointment ID";
                Data.Columns["AppointmentDate"].ColumnName = "Appointment Date";
                Data.Columns["PaidFees"].ColumnName = "Paid Fees";
                Data.Columns["IsLocked"].ColumnName = "Is Locked";

                dgvTestsAppointments.DataSource = Data;

                dgvTestsAppointments.Columns["Appointment ID"].Width = 150;
                dgvTestsAppointments.Columns["Appointment Date"].Width = 150;

                lbRecordsVal.Text = Data.Rows.Count.ToString();
            }
            else 
                lbRecordsVal.Text = "0";
        }

        private void RefreshDGV()
        {
            LoadDGV();
            Refresh?.Invoke();
        }

        private void dgvManagePeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvTestsAppointments.ClearSelection(); // Clear any existing selection
                dgvTestsAppointments.Rows[e.RowIndex].Selected = true;

                dgvTestsAppointments.CurrentCell = dgvTestsAppointments.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (dgvTestsAppointments.Rows.Count > 0)
            {
                if (clsTests.IsTestTypePassed((int)_TestTypeID, _LDLAppID))
                {
                    MessageBox.Show("This Person Already Passed This Test Before, You Can Only Retake Failed Test.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(clsTestsAppointments.IsThereActiveTestAppointments(_TestTypeID, _LDLAppID))
                {
                    MessageBox.Show("Person Already Has An Active Appointment For This Test, You Can't Add New Appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            frmAddOrEditTestAppointment frm = new frmAddOrEditTestAppointment(ctrlDrivingLicenseAppInfo1.LocalAppID, (int)_TestTypeID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void EditAppointment(object sender, EventArgs e)
        {
            frmAddOrEditTestAppointment frm = new frmAddOrEditTestAppointment(ctrlDrivingLicenseAppInfo1.LocalAppID, (int)_TestTypeID, Convert.ToInt32(dgvTestsAppointments.CurrentRow.Cells["Appointment ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void TakeTest(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest(Convert.ToInt32(dgvTestsAppointments.CurrentRow.Cells["Appointment ID"].Value), (clsTestTypes.enTestType)_TestTypeID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
