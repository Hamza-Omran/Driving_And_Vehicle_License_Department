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
    public partial class frmAddOrEditUser : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        enum enMode { AddMode, EditMode };
        private enMode Mode;

        private int _UserID = -1;
        private clsUsers _User;

        //private bool _EnablePasswordValidation = true;

        public frmAddOrEditUser()
        {
            InitializeComponent();

            Mode = enMode.AddMode;
        }

        public frmAddOrEditUser(int UserID)
        {
            InitializeComponent();

            Mode = enMode.EditMode;
            _UserID = UserID;
        }

        private void frmAddOrEditUser_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if (Mode == enMode.AddMode)
            {
                this.Text = "Add New User Screen";
                lbHeader.Text = "Add New User";
                _User = new clsUsers();
            }
            else
            {
                this.Text = "Edit User Screen";
                lbHeader.Text = "Update User";

                //lbPassword.Visible = false;
                //tbPassword.Visible = false;
                //pbPassword.Visible = false;

                //lbConfirmPassword.Visible = false;
                //tbConfirmPassword.Visible = false;
                //pbConfirmPassword.Visible = false;

                //_EnablePasswordValidation = false;

                //cbIsActive.Location = tbPassword.Location;

                LoadUserInfo(_UserID);
            }
        }

        private void LoadUserInfo(int UserID)
        {
            _User = clsUsers.Find(UserID);
            _UserID = UserID;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlFilterPerson2.LoadPersonInfo(_User.PersonID);

            if (ctrlFilterPerson2.SelectedPersonInfo == null)
            {
                MessageBox.Show("No Person Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbUserIDVal.Text = _User.UserID.ToString();
            tbUserName.Text = _User.UserName;
            cbIsActive.Checked = _User.IsActive;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbAddOrEditUsers.SelectedIndex = 1;
        }

        private void tbAddOrEditUsers_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (ctrlFilterPerson2.PersonID != -1)
                {
                    if (Mode == enMode.EditMode || !clsUsers.ExistsByPersonID(ctrlFilterPerson2.PersonID))
                    {
                        tbAddOrEditUsers.SelectedIndex = 1;
                        btnNext.Visible = false;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selected Person Already Has a User, Choose Another One", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        btnSave.Enabled = false;
                        ctrlFilterPerson2.FilterFocus();
                    }
                }
                else
                {
                    MessageBox.Show("You Must Find A Person First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    btnSave.Enabled = false;
                    ctrlFilterPerson2.FilterFocus();
                }
            }
            else // means going to page 0
            {
                btnNext.Visible = true;
                btnSave.Enabled = false;
            }
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                epValidation.SetError(tbUserName, "The Field Is Required.");
                e.Cancel = true;
            }
            else if (_User.UserName != tbUserName.Text.Trim()) 
            {
                if (clsUsers.Exists(tbUserName.Text.Trim()))
                {
                    epValidation.SetError(tbUserName, "This User Name Is Used Enter Another One!");
                    e.Cancel = true;
                } 
            }
            else
            {
                epValidation.SetError(tbUserName, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            //if (!_EnablePasswordValidation) return;

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                epValidation.SetError(tbPassword, "The Field Is Required.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(tbPassword, "");
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            //if (!_EnablePasswordValidation) return;

            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                epValidation.SetError(tbConfirmPassword, "This Password Doesn't Match Entered Password.");
                e.Cancel = true;
            }
            else
                epValidation.SetError(tbConfirmPassword, "");
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

            _User.PersonID = ctrlFilterPerson2.PersonID;
            _User.UserName = tbUserName.Text;
            _User.Password = clsUtil.ComputeHash(tbPassword.Text.Trim());
            _User.IsActive = cbIsActive.Checked;
            _User.Save();

            lbUserIDVal.Text = _User.UserID.ToString();
            btnSave.Enabled = false;

            Refresh?.Invoke();
            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();

            MessageBox.Show("Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddOrEditUser_Activated(object sender, EventArgs e)
        {
            ctrlFilterPerson2.FilterFocus();
        }
    }
}
