using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.International_Driving_License;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace DVLD_Presentation_Layer.Detain
{
    public partial class frmManageDetainedLicenses : Form
    {
        private DataTable _dtAllDetainedLicenses = new DataTable();
        private DateTime time = DateTime.Now;

        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbFilterYesNo.SelectedIndex = 0;
            dtpFilter.Value = time;

            LoadDetainedLicenses();
        }

        private void dgvDetained_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvDetain.ClearSelection(); // Clear any existing selection
                dgvDetain.Rows[e.RowIndex].Selected = true;

                dgvDetain.CurrentCell = dgvDetain.Rows[e.RowIndex].Cells[e.ColumnIndex];

                releaseDetainToolStripMenuItem.Enabled = !Convert.ToBoolean(dgvDetain.SelectedRows[0].Cells["Is Released"].Value);
            }
        }

        private void LoadDetainedLicenses()
        {
            _dtAllDetainedLicenses = clsDetainedLicenses.GetAll();

            _dtAllDetainedLicenses.Columns["DetainID"].ColumnName = "D.ID";
            _dtAllDetainedLicenses.Columns["LicenseID"].ColumnName = "L.ID";
            _dtAllDetainedLicenses.Columns["DetainDate"].ColumnName = "D.Date";
            _dtAllDetainedLicenses.Columns["IsReleased"].ColumnName = "Is Released";
            _dtAllDetainedLicenses.Columns["FineFees"].ColumnName = "Fine Fees";
            _dtAllDetainedLicenses.Columns["ReleaseDate"].ColumnName = "Release Date";
            _dtAllDetainedLicenses.Columns["NationalNo"].ColumnName = "N.No.";
            _dtAllDetainedLicenses.Columns["FullName"].ColumnName = "Full Name";
            _dtAllDetainedLicenses.Columns["ReleaseApplicationID"].ColumnName = "Release App ID";

            dgvDetain.DataSource = _dtAllDetainedLicenses;

            dgvDetain.Columns["D.Date"].Width = 130;
            dgvDetain.Columns["Release Date"].Width = 130;
            dgvDetain.Columns["Full Name"].Width = 160;

            lbRecordsVal.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }

        private void RefreshDGV()
        {
            LoadDetainedLicenses();
            if (tbFilterBy.Visible)
                tbFilterBy_TextChanged(null, null);
            else if (cbFilterYesNo.Visible)
                cbFilterYesNo_SelectedIndexChanged(null, null);
            else if (dtpFilter.Visible)
                dtpFilter_ValueChanged(null, null);
        }


        // Filteration
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Visible = false;
            cbFilterYesNo.Visible = false;
            dtpFilter.Visible = false;

            _dtAllDetainedLicenses.DefaultView.RowFilter = "true";
            lbRecordsVal.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();

            if (cbFilterBy.SelectedIndex == 0)
            {
                return;
            }
            else if (cbFilterBy.SelectedIndex == 3 || cbFilterBy.SelectedIndex == 6)
            {
                dtpFilter.Visible = true;
                dtpFilter.Value = time;
            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                cbFilterYesNo.Visible = true;
                cbFilterYesNo.SelectedIndex = 0;
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
                if (cbFilterBy.Text == "Full Name" || cbFilterBy.Text == "N.No.")
                    _dtAllDetainedLicenses.DefaultView.RowFilter = $"Convert([{cbFilterBy.SelectedItem.ToString()}], 'System.String') LIKE '%{tbFilterBy.Text.Replace("'", "''").Replace("%", "[%]").Replace("*", "[*]")}%'";
                else
                    _dtAllDetainedLicenses.DefaultView.RowFilter = $"Convert([{cbFilterBy.SelectedItem.ToString()}], 'System.String') = '{tbFilterBy.Text.Replace("'", "''").Replace("%", "[%]").Replace("*", "[*]")}'";
            }
            else
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Empty;
            }

            lbRecordsVal.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Full Name")
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && cbFilterBy.Text != "N.No.")
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFilter.Value != time)
                _dtAllDetainedLicenses.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem}] >= #{dtpFilter.Value:MM/dd/yyyy}# AND [{cbFilterBy.SelectedItem}] <= #{dtpFilter.Value.AddHours(23).AddMinutes(59):MM/dd/yyyy}#";
            else
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Empty;

            lbRecordsVal.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }

        private void cbFilterYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterYesNo.Text == "All")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "true";
            }
            else if (cbFilterYesNo.Text == "Yes")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "[Is Released] = true";
            }
            else if (cbFilterYesNo.Text == "No")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "[Is Released] = false";
            }

            lbRecordsVal.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }

        // buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frm = new frmReleaseDetainLicense();

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }


        // context menu options
        private void cmsoShowDetails_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(clsPerson.Find(dgvDetain.SelectedRows[0].Cells["N.No."].Value.ToString()).ID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void cmsoShowLicense_Click(object sender, EventArgs e)
        {
            new frmShowLicense(Convert.ToInt32(dgvDetain.SelectedRows[0].Cells["L.ID"].Value)).ShowDialog();
        }

        private void cmsoLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(clsPerson.Find(dgvDetain.SelectedRows[0].Cells["N.No."].Value.ToString()).ID);

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void releaseDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frm = new frmReleaseDetainLicense(Convert.ToInt32(dgvDetain.CurrentRow.Cells["L.ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

    }
}
