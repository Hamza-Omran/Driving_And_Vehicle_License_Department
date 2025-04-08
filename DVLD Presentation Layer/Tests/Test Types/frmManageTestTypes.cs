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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();

        }

        private void ManageTestTypesForm_Load(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        public void RefreshDGV()
        {
            DataTable sourceTable = clsTestTypes.GetAll();

            sourceTable.Columns["TestTypeID"].ColumnName = "ID";
            sourceTable.Columns["TestTypeTitle"].ColumnName = "Title";
            sourceTable.Columns["TestTypeDescription"].ColumnName = "Description";
            sourceTable.Columns["TestTypeFees"].ColumnName = "Fees";

            dgvTestTypes.DataSource = sourceTable;

            dgvTestTypes.Columns[1].Width = 170;
            dgvTestTypes.Columns[2].Width = 420;

            lbRecordsVal.Text = sourceTable.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((clsTestTypes.enTestType)Convert.ToInt32(dgvTestTypes.SelectedRows[0].Cells["ID"].Value));

            frm.Refresh += RefreshDGV;
            frm.ShowDialog();
        }

        private void dgvTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvTestTypes.ClearSelection();
                dgvTestTypes.Rows[e.RowIndex].Selected = true;

                dgvTestTypes.CurrentCell = dgvTestTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
