using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlUserInfoCard : UserControl
    {

        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _UserID;
        private clsUsers _User;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public clsUsers User
        {
            get { return _User; }
        }

        public ctrlUserInfoCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            LoadUserData(UserID);
            ctrlPersonInfo2.LoadPersonInfo(_User.PersonID);

            Refresh?.Invoke();
        }

        private void LoadUserData(int UserID)
        {
            _User = clsUsers.Find(UserID);
            _UserID = UserID;

            lbUserIDVal1.Text = UserID.ToString();
            lbUserNameVal1.Text = _User.UserName.ToString();
            lbIsActiveVal1.Text = _User.IsActive ? "Yes." : "No.";
        }
    }
}
