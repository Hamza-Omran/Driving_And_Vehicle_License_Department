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
    public partial class frmPersonInfo : Form
    {

        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _PersonID = -1;
        public frmPersonInfo(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            ctrlPersonInfo1.Refresh += RefreshData;
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {         
            ctrlPersonInfo1.LoadPersonInfo(_PersonID);

            if(ctrlPersonInfo1.PersonInfo == null)
            {
                MessageBox.Show("No Person Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshData()
        {
            Refresh.Invoke();
        }
    }
}
