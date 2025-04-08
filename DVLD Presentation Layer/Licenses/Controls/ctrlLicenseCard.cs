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
    public partial class ctrlLicenseCard : UserControl
    {
        private int _LicenseID = -1;
        clsLicenses _License;

        public int LicenseID
        {
            get { return _LicenseID; }
            set { _LicenseID = value; }
        }

        public clsLicenses License
        {
            get { return _License; }
            set { _License = value; }
        }

        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LicenseID)
        {
            _License = clsLicenses.Find(LicenseID);
            _LicenseID = LicenseID;

            if (_License != null)
            {
                SetLicenseInfo();
            }
        }
        private void SetImage()
        {
            if (!String.IsNullOrEmpty(_License.Driver.PersonInfo.ImagePath))
                pbPersonImage.ImageLocation = _License.Driver.PersonInfo.ImagePath;
            else if (_License.Driver.PersonInfo.Gender == 0)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private void SetLicenseInfo()
        {
            lbClassVal.Text = _License.LicenseClass.ClassName;
            lblNameVal.Text = _License.Driver.PersonInfo.FullName();
            lbLicenseIDVal.Text = _License.LicenseID.ToString();
            lblNationalNoVal.Text = _License.Driver.PersonInfo.NationalNumber;
            lblGenderVal.Text = _License.Driver.PersonInfo.GenderText;
            lbIssueDateVal.Text = clsFormat.DateToShort(_License.IssueDate);
            lblDOBVal.Text = clsFormat.DateToShort(_License.Driver.PersonInfo.DateOfBirth);
            lbExpiryDateVal.Text = clsFormat.DateToShort(_License.ExpiryDate);
            lbIssueReasonVal.Text = _License.IssueReasonText;
            lbDriverIDVal.Text = _License.DriverID.ToString();
            lbIsActiveVal.Text = _License.IsActive ? "Yes." : "No.";
            lbIsDetainedVal.Text = _License.IsDetained ? "Yes." : "No.";

            if (!string.IsNullOrEmpty(_License.Notes))
                lbNotesVal.Text = _License.Notes;

            SetImage();
        }

        public void ResetDefaultValues()
        {
            lbClassVal.Text = "[????]";
            lblNameVal.Text = "[????]";
            lbLicenseIDVal.Text = "[????]";
            lblNationalNoVal.Text = "[????]";
            lblGenderVal.Text = "[????]";
            lbIssueDateVal.Text = "[????]";
            lblDOBVal.Text = "[????]";
            lbExpiryDateVal.Text = "[????]";
            lbIssueReasonVal.Text = "[????]";
            lbDriverIDVal.Text = "[????]";
            lbIsActiveVal.Text = "[????]";
            lbIsDetainedVal.Text =  "[????]";
            lbNotesVal.Text = "No Notes.";

            pbPersonImage.ImageLocation = null;
        }
    }
}
