using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_Business_Layer;

namespace DVLD_Presentation_Layer
{
    public partial class frmLogin : Form
    {
        string username, pass;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void LoginScreenForm_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                username = UserName;
                pass = Password;
                tbUserNameVal.Text = UserName;
                tbPasswordVal.Text = Password;
                cbRememberMe.Checked = true;
                btnLogin.Select();
            }
            else
            {
                cbRememberMe.Checked = false;
                tbUserNameVal.Select();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         
            clsGlobal.SysUser = clsUsers.FindByUserNameAndPassword(tbUserNameVal.Text.Trim(), clsUtil.ComputeHash(tbPasswordVal.Text.Trim()));

            if (clsGlobal.SysUser == null)
            {
                MessageBox.Show("Wrong UserName/Password!!", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserNameVal.Focus();
                return;
            }

            if (!clsGlobal.SysUser.IsActive)
            {
                MessageBox.Show("Your Account Is Not Active!\nPlease Contact Your Admin.", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbRememberMe.Checked)
            {
                clsGlobal.RememberUsernameAndPassword(tbUserNameVal.Text, tbPasswordVal.Text.Trim());
            }
            else
            {
                clsGlobal.RememberUsernameAndPassword("", "");
                tbUserNameVal.Text = string.Empty;
                tbPasswordVal.Text = string.Empty;
            }

            this.Hide();
            frmMain frm = new frmMain(this);
            frm.Opacity = 0;
            frm.ShowDialog();
        }

    }
}
