using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global_Classes;
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

namespace DVLD_Presentation_Layer
{
    public partial class frmUpdateTestType : Form
    {

        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private clsTestTypes.enTestType _TestTypeID ;
        private clsTestTypes _TestType;

        public frmUpdateTestType(clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void UpdateTestTypeForm_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find(_TestTypeID);

            lbIDVal.Text = _TestTypeID.ToString();
            tbTitle.Text = _TestType.TestTypeTitle;
            tbDescription.Text = _TestType.TestTypeDescription;
            tbFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("there is filed(s) that is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_TestType == null)
            {
                MessageBox.Show("Contact The Developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestTypeTitle = tbTitle.Text;
            _TestType.TestTypeDescription = tbDescription.Text;
            _TestType.TestTypeFees = float.Parse(tbFees.Text);

            if (_TestType.Save())
            {

                Refresh.Invoke();

                new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();

                MessageBox.Show("Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                epValidation.SetError(tbTitle, "The Field Is Required.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(tbTitle, "");
            }
        }
        
        private void tbFees_Validating(object sender, CancelEventArgs e)
        {

            if (!clsValidation.IsNumber(tbFees.Text))
            {
                e.Cancel = true;
                epValidation.SetError(tbFees, "Invalid Number.");
            }
            else if (string.IsNullOrEmpty(tbFees.Text))
            {
                epValidation.SetError(tbFees, "The Field Is Required.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(tbFees, "");
            }
        }

        private void lbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                epValidation.SetError(tbDescription, "The Field Is Required.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(tbDescription, "");
            }
        }

        private void tbDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }        
    }
}
