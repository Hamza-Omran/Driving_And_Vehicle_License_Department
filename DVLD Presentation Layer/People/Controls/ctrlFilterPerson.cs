using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlFilterPerson : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;

        public int PersonID
        {
            get { return ctrlPersonInfo1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonInfo1.PersonInfo; }
        }

        public bool FilterEnabled
        {
            get
            {
                return pFind.Enabled;
            }
            set
            {
                pFind.Enabled = value;
            }
        }

        public ctrlFilterPerson()
        {
            InitializeComponent();
        }

        private void ctrlFilterPerson_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0;
            ctrlPersonInfo1.LabelLinkEnable = false;
            tbFindByVal.Focus();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFindBy.SelectedIndex = 1;
            tbFindByVal.Text = PersonID.ToString();
            pFind.Enabled = false;
            btnFind_Click(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("You Must Enter Text In The Search Box.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbFindBy.SelectedIndex == 0)
                ctrlPersonInfo1.LoadPersonInfo(tbFindByVal.Text.Trim());
            else
                ctrlPersonInfo1.LoadPersonInfo(Convert.ToInt32(tbFindByVal.Text));

            if (ctrlPersonInfo1.PersonInfo != null && pFind.Enabled)
            {
                new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();

                if (OnPersonSelected != null)
                    OnPersonSelected(ctrlPersonInfo1.PersonID);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson addOrEditForm = new frmAddOrEditPerson();

            addOrEditForm.Refresh += AddOrEditForm_Save; // Subscribe to the CloseForm event
            addOrEditForm.ShowDialog();
        }

        private void AddOrEditForm_Save(int ID)
        {
            cbFindBy.SelectedIndex = 1;
            tbFindByVal.Text = ID.ToString();
            ctrlPersonInfo1.LoadPersonInfo(ID);
        }

        private void tbFindByVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFindBy.Text.ToString() == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           tbFindByVal.Text = "";
           tbFindByVal.Focus();
        }

        public void FilterFocus()
        {
            tbFindByVal.Focus();
        }

        private void tbFindByVal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFindByVal.Text.Trim()))
            {
                epValidation.SetError(tbFindByVal, "This Field Is Required!");
            }
            else
            {
                epValidation.SetError(tbFindByVal, null);
            }
        }
    }
}
