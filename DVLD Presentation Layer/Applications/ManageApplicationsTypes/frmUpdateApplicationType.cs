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
using static DVLD_Business_Layer.clsTests;

namespace DVLD_Presentation_Layer
{
    public partial class frmUpdateApplicationType : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _ApplicationID = -1;
        private clsApplicationTypes _Application;

        public frmUpdateApplicationType(int ApplicationID)
        {
            InitializeComponent();

            _ApplicationID = ApplicationID;
        }

        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {
            _Application = clsApplicationTypes.Find(_ApplicationID);

            lbIDVal.Text = _ApplicationID.ToString();
            tbTitle.Text = _Application.ApplicationTypeTitle;
            tbFees.Text = _Application.ApplicationFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("there is filed(s) that is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Application == null)
            {
                MessageBox.Show("Not Found, Contact The Developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Application.ApplicationTypeTitle = tbTitle.Text;
            _Application.ApplicationFees = Convert.ToSingle(tbFees.Text);

            if (_Application.Save())
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
    }
}
