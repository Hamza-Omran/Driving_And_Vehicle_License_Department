using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.International_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Local_Driving_License
{
    public partial class frmShowLicenseHistory : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _personID;
        private int _DriverID;
        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();

            ctrlFilterPerson1.OnPersonSelected += PersonInfoChanged;
            _personID = PersonID;

        }

        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlFilterPerson1.LoadPersonInfo(_personID);

            if (ctrlFilterPerson1.SelectedPersonInfo == null)
            {
                MessageBox.Show("No Person Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _DriverID = clsDrivers.FindDriverIDByPersonID(_personID);

            RefreshLocal();
            RefreshInternational();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgv.ClearSelection(); // Clear any existing selection
                dgv.Rows[e.RowIndex].Selected = true;

                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void PersonInfoChanged(int obj)
        {
            RefreshLocal();
            RefreshInternational();
            Refresh?.Invoke();
        }

        private void RefreshLocal()
        {
            DataTable sourceTable = clsDrivers.GetLocalLicenses(_DriverID);

            if(sourceTable.Rows.Count == 0)
            {
                lbMessage1.Visible = true;
                return;
            }

            sourceTable.Columns["LicenseID"].ColumnName = "License ID";
            sourceTable.Columns["ApplicationID"].ColumnName = "App ID";
            sourceTable.Columns["ClassName"].ColumnName = "Class Name";
            sourceTable.Columns["IssueDate"].ColumnName = "Issue Date";
            sourceTable.Columns["ExpirationDate"].ColumnName = "Expiration Date";
            sourceTable.Columns["IsActive"].ColumnName = "Is Active";


            dgvLocalLicense.DataSource = sourceTable;

            dgvLocalLicense.Columns["Class Name"].Width = 230;
            dgvLocalLicense.Columns["Issue Date"].Width = 150;
            dgvLocalLicense.Columns["Expiration Date"].Width = 150;

            lbRecordsVal.Text = sourceTable.Rows.Count.ToString();
        }

        private void RefreshInternational()
        {
            DataTable sourceTable = clsDrivers.GetInternationalLicenses(_DriverID);

            if (sourceTable.Rows.Count == 0)
            {
                lbMessage2.Visible = true;
                return;
            }

            sourceTable.Columns["InternationalLicenseID"].ColumnName = "I.License ID";
            sourceTable.Columns["ApplicationID"].ColumnName = "App ID";
            sourceTable.Columns["IssuedUsingLocalLicenseID"].ColumnName = "L.License ID";
            sourceTable.Columns["IssueDate"].ColumnName = "Issue Date";
            sourceTable.Columns["ExpirationDate"].ColumnName = "Expiration Date";
            sourceTable.Columns["IsActive"].ColumnName = "Is Active";


            dgvInternational.DataSource = sourceTable;

            dgvInternational.Columns["Issue Date"].Width = 150;
            dgvInternational.Columns["Expiration Date"].Width = 150;

            lbRecordsVal2.Text = sourceTable.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmShowLicense((int)dgvLocalLicense.CurrentRow.Cells["License ID"].Value).ShowDialog();
        }

        private void showInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmInternationalLicenseInfo((int)dgvInternational.CurrentRow.Cells["I.License ID"].Value).ShowDialog();
        }
    }
}
