using DVLD_Business_Layer;
using DVLD_Data_Access_Layer;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using DVLD_Presentation_Layer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Controls
{
    public partial class ctrlDrivingLicenseAppInfo : UserControl
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LocalAppID = -1, _LicenseID = -1;
        private clsLocalDrivingLicenseApplication _LocalApp;

        public int LocalAppID
        {
            get { return _LocalAppID; }
        }

        public clsLocalDrivingLicenseApplication LocalAppInfo
        {
            get { return _LocalApp; }
        }

        public int LicenseID
        {
            set
            {
                _LicenseID = value;
                llbShowLicenseInfo.Enabled = _LicenseID != -1;
            }
        }

        public ctrlDrivingLicenseAppInfo()
        {
            InitializeComponent();
        }

        public void LoadAppInfo(int LDLAppID)
        {
            _LocalAppID = LDLAppID;

            _LocalApp = clsLocalDrivingLicenseApplication.Find(_LocalAppID);
            
            if (_LocalApp == null)
                return;

            _LicenseID = _LocalApp.GetActiveLicenseID();

            llbShowLicenseInfo.Enabled = _LicenseID != -1;

            // Driving License Info
            lbDLAppIDVal.Text = _LocalAppID.ToString();
            lbAppliedForLicenseVal.Text = _LocalApp.LicenseClassInfo.ClassName;
            lbPassedTestsVal.Text = _LocalApp.GetPassedTestCount().ToString() + "/3";

            // Application Info
            lbAppIDVal.Text = _LocalApp.ApplicationID.ToString();
            lbStatusVal.Text = _LocalApp.StatusText;
            lbFeesVal.Text = _LocalApp.PaidFees.ToString();
            lbTypeVal.Text = _LocalApp.ApplicationTypeInfo.ApplicationTypeTitle;
            lbApplicantNameVal.Text = _LocalApp.PersonInfo.FullName();
            lbDateVal.Text = clsFormat.DateToShort(_LocalApp.ApplicationDate);
            lbStatusDateVal.Text = clsFormat.DateToShort(_LocalApp.LastStatusDate);
            lbCreatedByVal.Text = _LocalApp.CreatedByUserID.ToString();
        }

        private void refresh()
        {
            LoadAppInfo(_LocalAppID);
        }

        private void llbViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo personInfo = new frmPersonInfo(_LocalApp.ApplicantPersonID);

            personInfo.Refresh += refresh;
            personInfo.ShowDialog();
            Refresh?.Invoke();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmShowLicense(_LicenseID).ShowDialog();
        }
    }
}
