using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DVLD_Presentation_Layer
{
    public partial class frmManagePeople : Form
    {
        private DataTable _dtPeople = new DataTable();
        private DateTime time = DateTime.Now;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void ManagePeopleForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Visible = false;

            FillCountryComboBox();
            LoadDGVManagePeople();
        }

        private void FillCountryComboBox()
        {
            foreach (DataRow row in clsCountry.GetAllCountries().Rows)
            {
                cbFilter.Items.Add(row["CountryName"]);
            }
        }

        private void LoadDGVManagePeople()
        {
            _dtPeople = clsPerson.GetAll().DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            _dtPeople.Columns["PersonID"].ColumnName = "Person ID";
            _dtPeople.Columns["NationalNo"].ColumnName = "National No.";
            _dtPeople.Columns["FirstName"].ColumnName = "First Name";
            _dtPeople.Columns["SecondName"].ColumnName = "Second Name";
            _dtPeople.Columns["ThirdName"].ColumnName = "Third Name";
            _dtPeople.Columns["LastName"].ColumnName = "Last Name";
            _dtPeople.Columns["GendorCaption"].ColumnName = "Gender";
            _dtPeople.Columns["DateOfBirth"].ColumnName = "Date Of Birth";
            _dtPeople.Columns["CountryName"].ColumnName = "Country";

            dgvManagePeople.DataSource = _dtPeople;

            lbNumRecords.Text = "# Records: " + _dtPeople.Rows.Count;
        }

        private void dgvManagePeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvManagePeople.ClearSelection(); // Clear any existing selection
                dgvManagePeople.Rows[e.RowIndex].Selected = true;

                dgvManagePeople.CurrentCell = dgvManagePeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void RefreshDGV()
        {
            LoadDGVManagePeople();

            if (tbFilterValue.Visible)
                tbFilterValue_TextChanged(null, null);
            else if (dtpFilter.Visible)
                dtpFilter_ValueChanged(null, null);
            else if (cbFilter.Visible)
                cbFilter_SelectedIndexChanged(null, null);
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            tbFilterValue.Visible = false;
            cbFilter.Visible = false;
            dtpFilter.Visible = false;

            lbNumRecords.Text = "# Records: " + _dtPeople.Rows.Count;
            _dtPeople.DefaultView.RowFilter = "true";

            if (cbFilterBy.SelectedIndex == 0)
            {
                return;
            }
            else if (cbFilterBy.SelectedIndex == 8)
            {
                dtpFilter.Value = time;
                dtpFilter.Visible = true;
            }
            else if (cbFilterBy.SelectedIndex == 9)
            {
                cbFilter.Visible = true;
                cbFilter.SelectedIndex = 0;
            }
            else
            {
                tbFilterValue.Visible = true;
                tbFilterValue.Text = "";
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFilterValue.Text) && cbFilterBy.SelectedIndex != 0)
            {
                if (cbFilterBy.Text != "Person ID" && cbFilterBy.Text != "Phone" && cbFilterBy.Text != "Gender")
                    _dtPeople.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem.ToString()}] LIKE '%{tbFilterValue.Text}%'";
                else
                    _dtPeople.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem.ToString()}] = '{tbFilterValue.Text}'";
            }
            else
                _dtPeople.DefaultView.RowFilter = "";

            lbNumRecords.Text = "# Records: " + _dtPeople.DefaultView.Count;
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Phone")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
            else if (cbFilterBy.Text != "Email" && cbFilterBy.Text != "National No." && cbFilterBy.Text != "Date Of Birth")
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFilter.Value != time)
                _dtPeople.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem}] >= #{dtpFilter.Value:MM/dd/yyyy}# AND [{cbFilterBy.SelectedItem}] <= #{dtpFilter.Value.AddHours(23).AddMinutes(59):MM/dd/yyyy}#";
            else
                _dtPeople.DefaultView.RowFilter = string.Empty;

            lbNumRecords.Text = "# Records: " + _dtPeople.DefaultView.Count;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
                _dtPeople.DefaultView.RowFilter = $"{cbFilterBy.SelectedItem.ToString()} = '{cbFilter.Text}'";
            else
                _dtPeople.DefaultView.RowFilter = string.Empty;

            lbNumRecords.Text = "# Records: " + _dtPeople.DefaultView.Count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshAFterAddorEdit(int ID)
        {
            RefreshDGV();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frm = new frmAddOrEditPerson();

            frm.Refresh += RefreshAFterAddorEdit;
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(Convert.ToInt32(dgvManagePeople.SelectedRows[0].Cells["Person ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frm = new frmAddOrEditPerson(Convert.ToInt32(dgvManagePeople.SelectedRows[0].Cells["Person ID"].Value));

            frm.Refresh += RefreshAFterAddorEdit;
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvManagePeople.CurrentRow.Cells["Person ID"].Value);

            if (MessageBox.Show("Are You Sure You Want To Delete Person [" + PersonID + "]?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.Find(PersonID).Delete())
                {
                    RefreshDGV();
                    new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
                    MessageBox.Show("Person Deleted Successfully.", "Successfull");
                }
                else
                    MessageBox.Show("Person Was Not Deleted Because It Has Data Linked To It.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendEmailOrMakePhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
