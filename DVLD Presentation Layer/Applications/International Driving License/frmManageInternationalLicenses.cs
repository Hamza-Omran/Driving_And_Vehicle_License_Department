using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DVLD_Presentation_Layer.Applications.International_Driving_License
{
    public partial class frmManageInternationalLicenses : Form
    {
        private DataTable _dtAllInterLicenses = new DataTable();
        private DateTime time = DateTime.Now;

        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;

            LoadInterLicenseDGV();
        }


        // DGV related code
        private void LoadInterLicenseDGV()
        {
            _dtAllInterLicenses = clsInternationalLicense.GetAll();

            _dtAllInterLicenses.Columns["InternationalLicenseID"].ColumnName = "Int.License ID";
            _dtAllInterLicenses.Columns["ApplicationID"].ColumnName = "Application ID";
            _dtAllInterLicenses.Columns["DriverID"].ColumnName = "Driver ID";
            _dtAllInterLicenses.Columns["IssuedUsingLocalLicenseID"].ColumnName = "L.License ID";
            _dtAllInterLicenses.Columns["IssueDate"].ColumnName = "Issue Date";
            _dtAllInterLicenses.Columns["ExpirationDate"].ColumnName = "Expiration Date";
            _dtAllInterLicenses.Columns["IsActive"].ColumnName = "Is Active";

            dgvInterLicenses.DataSource = _dtAllInterLicenses;

            dgvInterLicenses.Columns["Issue Date"].Width = 200;
            dgvInterLicenses.Columns["Expiration Date"].Width = 200;

            lbRecordsVal.Text = _dtAllInterLicenses.DefaultView.Count.ToString();
        }

        private void dgvApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvInterLicenses.ClearSelection(); // Clear any existing selection
                dgvInterLicenses.Rows[e.RowIndex].Selected = true;

                dgvInterLicenses.CurrentCell = dgvInterLicenses.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void RefreshDGV()
        {
            LoadInterLicenseDGV();

            if(dtpFilter.Visible)
                dtpFilter_ValueChanged(null, null);
            else if(tbFilterBy.Visible)
                tbFilterBy_TextChanged(null, null);
            else if(cbIsActive.Visible)
                cbIsActive_SelectedIndexChanged(null, null);
        }


        // Filteration
        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFilter.Value != time)
                _dtAllInterLicenses.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem}] >= #{dtpFilter.Value:MM/dd/yyyy}# AND [{cbFilterBy.SelectedItem}] <= #{dtpFilter.Value.AddHours(23).AddMinutes(59):MM/dd/yyyy}#";
            else
                _dtAllInterLicenses.DefaultView.RowFilter = string.Empty;

            lbRecordsVal.Text = _dtAllInterLicenses.DefaultView.Count.ToString();
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFilterBy.Text))
            {
                _dtAllInterLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", cbFilterBy.SelectedItem.ToString(), tbFilterBy.Text);
            }
            else
                _dtAllInterLicenses.DefaultView.RowFilter = string.Empty;

            lbRecordsVal.Text = _dtAllInterLicenses.DefaultView.Count.ToString();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedIndex == 0)
            {
                _dtAllInterLicenses.DefaultView.RowFilter = "true";
            }
            else if (cbIsActive.SelectedIndex == 1)
            {
                _dtAllInterLicenses.DefaultView.RowFilter = "[Is Active] = true";
            }
            else
            {
                _dtAllInterLicenses.DefaultView.RowFilter = "[Is Active] = false";
            }

            lbRecordsVal.Text = _dtAllInterLicenses.DefaultView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Visible = false;
            dtpFilter.Visible = false;
            cbIsActive.Visible = false;

            _dtAllInterLicenses.DefaultView.RowFilter = "true";
            lbRecordsVal.Text = _dtAllInterLicenses.DefaultView.Count.ToString();

            if (cbFilterBy.SelectedIndex == 0)
            {
                return;
            }
            else if(cbFilterBy.SelectedIndex == 7)
            {
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else if(cbFilterBy.SelectedIndex == 5 || cbFilterBy.SelectedIndex == 6)
            {
                dtpFilter.Value = time;
                dtpFilter.Visible = true;
            }
            else
            {
                tbFilterBy.Visible = true;
                tbFilterBy.Text = "";
            }
        }


        // buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }



        // context menu Options
        private void cmsoShowDetails_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(clsPerson.FindByDriverID(Convert.ToInt32(dgvInterLicenses.SelectedRows[0].Cells["Driver ID"].Value)).ID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoShowLicense_Click(object sender, EventArgs e)
        {
            new frmInternationalLicenseInfo(Convert.ToInt32(dgvInterLicenses.SelectedRows[0].Cells["Int.License ID"].Value)).ShowDialog();
        }

        private void cmsoLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(clsPerson.FindByDriverID(Convert.ToInt32(dgvInterLicenses.SelectedRows[0].Cells["Driver ID"].Value)).ID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }
    }
}
