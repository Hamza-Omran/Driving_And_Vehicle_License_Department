using DVLD_Business_Layer;
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
    public partial class frmManageUsers : Form
    {

        private DataTable _dtAllUsers = new DataTable();

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbFilterValue.SelectedIndex = 0;

            LoadDGVManageUsers();
        }

        public void LoadDGVManageUsers()
        {
            _dtAllUsers = clsUsers.GetAll();

            _dtAllUsers.Columns["UserID"].ColumnName = "User ID";
            _dtAllUsers.Columns["FullName"].ColumnName = "Full Name";
            _dtAllUsers.Columns["PersonID"].ColumnName = "Person ID";
            _dtAllUsers.Columns["UserName"].ColumnName = "User Name";
            _dtAllUsers.Columns["IsActive"].ColumnName = "Is Active";

            dgvManageUsers.DataSource = _dtAllUsers;
            dgvManageUsers.Columns["User ID"].Width = 80;
            dgvManageUsers.Columns["Person ID"].Width = 80;
            dgvManageUsers.Columns["Is Active"].Width = 80;
            dgvManageUsers.Columns["Full Name"].Width = 250;

            lbRecordsVal.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void RefreshDGV()
        {
            LoadDGVManageUsers();

            if(tbFilterBy.Visible)
                tbFilterBy_TextChanged(null, null);
            else if(cbFilterBy.Visible)
                cbFilterValue_SelectedIndexChanged(null, null);
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFilterBy.Text))
            {
                if (cbFilterBy.Text != "Person ID" && cbFilterBy.Text != "User ID")
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbFilterBy.SelectedItem.ToString(), tbFilterBy.Text.Trim());
                else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", cbFilterBy.SelectedItem.ToString(), tbFilterBy.Text.Trim());
            }
            else 
                _dtAllUsers.DefaultView.RowFilter = "true";

            lbRecordsVal.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private void cbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterValue.Text == "Yes")
            {
                _dtAllUsers.DefaultView.RowFilter = "[Is Active] = true";
            }
            else if (cbFilterValue.Text == "No")
            {
                _dtAllUsers.DefaultView.RowFilter = "[Is Active] = false";
            }
            else
                _dtAllUsers.DefaultView.RowFilter = "true";

            lbRecordsVal.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private void FilterBy_Changed(object sender, EventArgs e)
        {

            tbFilterBy.Visible = false;
            cbFilterValue.Visible = false;

            if (cbFilterBy.SelectedIndex == 0)
            {
                return;
            }
            else if (cbFilterBy.SelectedIndex != 5)
            {
                tbFilterBy.Visible = true;
                tbFilterBy.Text = "";
            }
            else
            {
                cbFilterValue.Visible = true;
                cbFilterValue.SelectedIndex = 0;
            }

            _dtAllUsers.DefaultView.RowFilter = "true";
            lbRecordsVal.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text.ToString() == "Person ID" || cbFilterBy.Text.ToString() == "User ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true; // Ignore the input
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void dgvManageUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvManageUsers.ClearSelection(); // Clear any existing selection
                dgvManageUsers.Rows[e.RowIndex].Selected = true;

                dgvManageUsers.CurrentCell = dgvManageUsers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddOrEditUser frm = new frmAddOrEditUser();

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvManageUsers.SelectedRows[0].Cells["User ID"].Value);

            DialogResult result = MessageBox.Show("Are You Sure You Want To Delete User [" + UserID + "]?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (clsUsers.Delete(UserID))
                {
                    RefreshDGV();
                    MessageBox.Show("User Deleted Successfully.", "Successfull");
                }
                else
                {
                    MessageBox.Show("User Was Not Deleted Because It Has Data Linked To It.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void phoneCallOrSendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfoCard frm = new frmUserInfoCard(Convert.ToInt32(dgvManageUsers.SelectedRows[0].Cells["User ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrEditUser frm = new frmAddOrEditUser(Convert.ToInt32(dgvManageUsers.SelectedRows[0].Cells["User ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmChangeUserPassword(Convert.ToInt32(dgvManageUsers.SelectedRows[0].Cells["User ID"].Value)).ShowDialog();
        }

    }
}
