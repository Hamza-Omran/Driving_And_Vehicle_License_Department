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
    public partial class frmUserInfoCard : Form
    {

        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _UserID = -1;
        public frmUserInfoCard(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            ctrlUserInfoCard1.Refresh += RefreshInfo;
        }

        private void frmUserInfoCard_Load(object sender, EventArgs e)
        {
            ctrlUserInfoCard1.LoadUserInfo(_UserID);

            if (ctrlUserInfoCard1.User == null)
            {
                MessageBox.Show("No User Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void RefreshInfo()
        {
            Refresh?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
