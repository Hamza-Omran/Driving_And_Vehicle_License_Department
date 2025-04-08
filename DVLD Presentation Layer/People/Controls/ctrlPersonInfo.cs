using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global_Classes;
using DVLD_Presentation_Layer.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlPersonInfo : UserControl
    {

        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;


        private int _PersonID = -1;
        private string _NationalNo;
        private clsPerson _PersonInfo;

        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

        public string NationalNo
        {
            get { return _NationalNo; }
            set { _NationalNo = value; }
        }

        public clsPerson PersonInfo
        {
            get { return _PersonInfo; }
            set { _PersonInfo = value; }
        }

        public bool LabelLinkEnable
        {
            get { return llblEditPersonInfo.Enabled; }
            set { llblEditPersonInfo.Enabled = value; }
        }

        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonInfo != null)
            {
                frmAddOrEditPerson frm = new frmAddOrEditPerson(_PersonInfo.ID);

                frm.Refresh += RefreshEvent;
                frm.ShowDialog();
            }
        }

        public void LoadPersonInfo(int ID)
        {
            _PersonInfo = clsPerson.Find(ID);

            if (_PersonInfo == null)
            {
                _PersonID = -1;
                ResetCardInfo();
                MessageBox.Show("No Person with Person ID. = " + ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PersonID = ID;
            _NationalNo = _PersonInfo.NationalNumber;

            FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _PersonInfo = clsPerson.Find(NationalNo);

            if (_PersonInfo == null)
            {
                _PersonID = -1; 
                ResetCardInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PersonID = _PersonInfo.ID;
            _NationalNo = _PersonInfo.NationalNumber;

            FillPersonInfo();
        }

        private void FillPersonInfo()
        {
            lblAddressVal.Text = _PersonInfo.Address;
            lblCountryVal.Text = _PersonInfo.CountryName;
            lblPersonIDVal.Text = _PersonInfo.ID.ToString();
            lblNameVal.Text = _PersonInfo.FullName();
            lblNationalNoVal.Text = _PersonInfo.NationalNumber;
            lblPhoneVal.Text = _PersonInfo.Phone;
            lblEmailVal.Text = _PersonInfo.Email;
            lblGenderVal.Text = _PersonInfo.Gender == 0 ? "Male" : "Female";
            pbGender.Image = _PersonInfo.Gender == 0 ? Resources.Man_32 : Resources.Woman_32;
            lblDOBVal.Text = clsFormat.DateToShort(_PersonInfo.DateOfBirth); // Example format

            if (!String.IsNullOrEmpty(_PersonInfo.ImagePath.ToString()))
                pbPersonImage.ImageLocation = PersonInfo.ImagePath;
            else if (_PersonInfo.Gender == 0)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            llblEditPersonInfo.Enabled = true;
        }

        private void ResetCardInfo()
        {
            _PersonID = -1;
            lblPersonIDVal.Text = "[????]";
            lblNationalNoVal.Text = "[????]";
            lblNameVal.Text = "[????]";
            pbGender.Image = Resources.Man_32;
            lblGenderVal.Text = "[????]";
            lblEmailVal.Text = "[????]";
            lblPhoneVal.Text = "[????]";
            lblDOBVal.Text = "[????]";
            lblCountryVal.Text = "[????]";
            lblAddressVal.Text = "[????]";
            llblEditPersonInfo.Enabled = false;
            pbPersonImage.Image = Resources.Male_512;
        }

        private void RefreshEvent(int ID)
        {
            LoadPersonInfo(ID);
            Refresh?.Invoke();
        }

    }
}
