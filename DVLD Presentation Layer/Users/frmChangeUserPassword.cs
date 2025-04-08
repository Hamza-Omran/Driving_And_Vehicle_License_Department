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

namespace DVLD_Presentation_Layer
{
    public partial class frmChangeUserPassword : Form
    {
        private int _UserID = -1;

        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            ctrlUserInfoCard1.LoadUserInfo(_UserID);

            if (ctrlUserInfoCard1.User == null)
            {
                MessageBox.Show("No User Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlUserInfoCard1.User.Password = clsUtil.ComputeHash(tbNewPassword.Text.Trim());
            if(!ctrlUserInfoCard1.User.Save())
            {
                MessageBox.Show("Couldn't Save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text))
            {
                e.Cancel = true;
                epValidation.SetError(tbCurrentPassword, "The Field Is Required.");
            }
            else if (clsUtil.ComputeHash(tbCurrentPassword.Text.Trim()) != ctrlUserInfoCard1.User.Password)
            {
                e.Cancel = true;
                epValidation.SetError(tbCurrentPassword, "The Password Is Incorrect.");
            }
            else
            {
                epValidation.SetError(tbCurrentPassword, "");
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text))
            {
                e.Cancel = true;
                epValidation.SetError(tbNewPassword, "The Field Is Required.");
            }
            else
            {
                epValidation.SetError(tbNewPassword, "");
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbConfirmPassword.Text))
            {
                e.Cancel = true;
                epValidation.SetError(tbConfirmPassword, "The Field Is Required.");
            }
            else if (tbNewPassword.Text != tbConfirmPassword.Text)
            {
                e.Cancel = true;
                epValidation.SetError(tbConfirmPassword, "This Password Doesn't Match Entered Password.");
            }
            else
                epValidation.SetError(tbConfirmPassword, "");
        }
    }
}
