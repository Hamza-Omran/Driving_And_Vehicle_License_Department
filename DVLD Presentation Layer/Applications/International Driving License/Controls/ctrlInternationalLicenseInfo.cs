using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private int _InterLicenseID = -1;
        private clsInternationalLicense _InterLicense;

        public int InterLicenseID
        {
            get { return _InterLicenseID; }
            set { _InterLicenseID = value; }
        }

        public clsInternationalLicense InterLicense
        {
            get { return _InterLicense; }
            set { _InterLicense = value; }
        }

        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInterLicenseInfo(int InterLicenseID)
        {
            _InterLicense = clsInternationalLicense.Find(InterLicenseID);

            if (_InterLicense == null)
                return;

            _InterLicenseID = InterLicenseID;

            lblNameVal.Text = _InterLicense.PersonInfo.FullName();
            lbInterLicenseIDVal.Text = _InterLicenseID.ToString();
            lbLicenseIDVal.Text = _InterLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNoVal.Text = _InterLicense.PersonInfo.NationalNumber;
            lbAppIDVal.Text = _InterLicense.ApplicationID.ToString();
            lblGenderVal.Text = _InterLicense.PersonInfo.GenderText;

            lbIssueDateVal.Text = clsFormat.DateToShort(_InterLicense.IssueDate);
            lblDOBVal.Text = clsFormat.DateToShort(_InterLicense.PersonInfo.DateOfBirth);
            lbExpiryDateVal.Text = clsFormat.DateToShort(_InterLicense.ExpirationDate);
            lbIsActiveVal.Text = _InterLicense.IsActive? "Yes." : "No.";

            lbDriverIDVal.Text = _InterLicense.DriverID.ToString();

            SetImage();
        }

        private void SetImage()
        {
            if (!String.IsNullOrEmpty(_InterLicense.PersonInfo.ImagePath))
                pbPersonImage.Load(_InterLicense.PersonInfo.ImagePath);
            else if (_InterLicense.PersonInfo.Gender == 0)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

    }
}
