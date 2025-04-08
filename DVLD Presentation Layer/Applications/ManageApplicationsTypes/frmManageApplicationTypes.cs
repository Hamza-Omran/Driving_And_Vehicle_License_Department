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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypesForm_Load(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        public void RefreshDGV()
        {
            DataTable sourceTable = clsApplicationTypes.GetAll();

            sourceTable.Columns["ApplicationTypeID"].ColumnName = "ID";
            sourceTable.Columns["ApplicationTypeTitle"].ColumnName = "Title";
            sourceTable.Columns["ApplicationFees"].ColumnName = "Fees";

            dgvApplicationTypes.DataSource = sourceTable;

            dgvApplicationTypes.Columns[1].Width = 290;

            lbRecordsVal.Text = sourceTable.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvApplicationTypes.ClearSelection(); // Clear any existing selection
                dgvApplicationTypes.Rows[e.RowIndex].Selected = true;

                dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType(Convert.ToInt32(dgvApplicationTypes.SelectedRows[0].Cells["ID"].Value));

            frm.Refresh += RefreshDGV;

            frm.ShowDialog();

        }
    }
}
