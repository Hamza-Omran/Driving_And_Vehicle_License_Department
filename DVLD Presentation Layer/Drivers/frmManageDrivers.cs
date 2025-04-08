using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.International_Driving_License;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Drivers
{
    public partial class frmManageDrivers : Form
    {
        private DataTable _dtAllDrivers = new DataTable();

        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            LoadDriversDGV();
        }


        // DGV related code
        private void LoadDriversDGV()
        {
            _dtAllDrivers = clsDrivers.GetAll();

            _dtAllDrivers.Columns["DriverID"].ColumnName = "Driver ID";
            _dtAllDrivers.Columns["PersonID"].ColumnName = "Person ID";
            _dtAllDrivers.Columns["NationalNo"].ColumnName = "National No.";
            _dtAllDrivers.Columns["FullName"].ColumnName = "Full Name";
            _dtAllDrivers.Columns["CreatedDate"].ColumnName = "Date";
            _dtAllDrivers.Columns["NumberOfActiveLicenses"].ColumnName = "Active Licenses";


            dgvDrivers.DataSource = _dtAllDrivers;

            dgvDrivers.Columns["Full Name"].Width = 230;
            dgvDrivers.Columns["Date"].Width = 150;

            lbRecordsVal.Text = _dtAllDrivers.Rows.Count.ToString();
        }

        private void dgvDrivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvDrivers.ClearSelection(); // Clear any existing selection
                dgvDrivers.Rows[e.RowIndex].Selected = true;

                dgvDrivers.CurrentCell = dgvDrivers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void RefreshDGV()
        {
            LoadDriversDGV();

            if (tbFilterBy.Visible)
                tbFilterBy_TextChanged(null,null);
        }


        // Filteration
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllDrivers.DefaultView.RowFilter = "true";
            lbRecordsVal.Text = _dtAllDrivers.DefaultView.Count.ToString();

            if (cbFilterBy.SelectedIndex == 0)
            {
                tbFilterBy.Visible = false;
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
                if (cbFilterBy.Text != "Driver ID" && cbFilterBy.Text != "Person ID")
                    _dtAllDrivers.DefaultView.RowFilter = $"Convert([{cbFilterBy.SelectedItem.ToString()}], 'System.String') LIKE '%{tbFilterBy.Text.Replace("'", "''").Replace("%", "[%]").Replace("*", "[*]")}%'";
                else
                    _dtAllDrivers.DefaultView.RowFilter = $"Convert([{cbFilterBy.SelectedItem.ToString()}], 'System.String') = '{tbFilterBy.Text.Replace("'", "''").Replace("%", "[%]").Replace("*", "[*]")}'";
            }
            else
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Empty;
            }

            lbRecordsVal.Text = _dtAllDrivers.DefaultView.Count.ToString();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
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


        // buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // context menu options
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["Person ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["Person ID"].Value));

            frm.Refresh += LoadDriversDGV;
            frm.ShowDialog();
        }
    }
}
