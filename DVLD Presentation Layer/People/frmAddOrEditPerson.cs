using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmAddOrEditPerson : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler(int ID);

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        enum enMode { AddMode, EditMode };

        private enMode _Mode;

        private clsPerson _Person;
        private int _PersonID;

        public frmAddOrEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.AddMode;
        }

        public frmAddOrEditPerson(int ID)
        {
            InitializeComponent();

            this._PersonID = ID;
            _Mode = enMode.EditMode;
        }

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
            dtpDOB.MaxDate = DateTime.Today.AddYears(-18);

            LoadCountryComboBox();

            if (_Mode == enMode.EditMode)
            {
                lblHeader.Text = "Update Person";

                LoadPersonData();
            }
            else
            {
                _Person = new clsPerson();

                llbRemoveImage.Visible = false;
                rbMale.Checked = true;
            }
        }


        // Fill Data
        private void LoadCountryComboBox()
        {
            foreach (DataRow row in clsCountry.GetAllCountries().Rows)
            {
                cbCountryVal.Items.Add(row["CountryName"]);
            }

            cbCountryVal.SelectedIndex = cbCountryVal.FindString("Palestine");
        }

        private void LoadInPersonObject()
        {
            _Person.FirstName = txFirstNameVal.Text;
            _Person.LastName = txLastNameVal.Text;
            _Person.SecondName = txSecondNameVal.Text;
            _Person.ThirdName = txThirdNameVal.Text;
            _Person.Gender = (short)(rbMale.Checked ? clsPerson.enGender.Male : clsPerson.enGender.Female);
            _Person.NationalNumber = txNationalNoVal.Text;
            _Person.Email = txEmailVal.Text;
            _Person.Address = tbAddressVal.Text;
            _Person.Phone = tbPhoneVal.Text;
            _Person.DateOfBirth = dtpDOB.Value;
            _Person.CountryID = clsCountry.Find(cbCountryVal.Items[cbCountryVal.SelectedIndex].ToString()).ID;
        }

        private void LoadPersonData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("Contact Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Populate the form fields with the values from _Person
            lbPersonIDVal.Text = _PersonID.ToString();
            txFirstNameVal.Text = _Person.FirstName;
            txLastNameVal.Text = _Person.LastName;
            txSecondNameVal.Text = _Person.SecondName;
            txThirdNameVal.Text = _Person.ThirdName;
            rbMale.Checked = _Person.Gender == (short)clsPerson.enGender.Male ? true : false;
            rbFemale.Checked = !rbMale.Checked;
            txNationalNoVal.Text = _Person.NationalNumber;
            txEmailVal.Text = _Person.Email;
            tbAddressVal.Text = _Person.Address;
            tbPhoneVal.Text = _Person.Phone;
            dtpDOB.Value = _Person.DateOfBirth.Date;
            cbCountryVal.SelectedIndex = cbCountryVal.FindString(clsCountry.Find(_Person.CountryID).CountryName);

            // Set the image path if available
            if (File.Exists(_Person.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
                llbRemoveImage.Visible = true;
            }
            else
            {
                SetDefaultImage();
                llbRemoveImage.Visible = false;
            }
        }


        // Image Related Code
        private void RemoveImage(string oldImageLocation)
        {
            // Delete the old image in edit mode if it exists
            if (File.Exists(oldImageLocation))
            {
                File.Delete(oldImageLocation);
            }
        }

        private bool SaveImage()
        {
            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                string SourceImageFile = pbPersonImage.ImageLocation;

                if (_Mode == enMode.EditMode)
                {
                    if (_Person.ImagePath == SourceImageFile)
                        return true;

                    RemoveImage(_Person.ImagePath);
                }

                // Update the Person.ImagePath property to store only the new file name
                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbPersonImage.ImageLocation = SourceImageFile;
                    _Person.ImagePath = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                RemoveImage(_Person.ImagePath);
                _Person.ImagePath = "";
                return true;
            }
        }

        private void SetDefaultImage()
        {
            if (_Person.Gender == (short)clsPerson.enGender.Female)
                pbPersonImage.Image = Properties.Resources.Female_512;
            else
                pbPersonImage.Image = Properties.Resources.Male_512;

            pbPersonImage.ImageLocation = null;
        }

                            // label Links
        private void llbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.ImageLocation = openFileDialog1.FileName;
                llbRemoveImage.Visible = true;
            }
        }

        private void llbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llbRemoveImage.Visible = false;

            SetDefaultImage();
        }


        // Radio Buttons
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                pbPersonImage.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                pbPersonImage.Image = Properties.Resources.Female_512;
        }


        // Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("there is filed(s) that is required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadInPersonObject();

            if (!SaveImage())
            {
                MessageBox.Show("Could not Save Image, Please Contact Developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_Person.Save())
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.EditMode;

            lbPersonIDVal.Text = _Person.ID.ToString();
            lblHeader.Text = "Update Person";

            Refresh?.Invoke(_Person.ID);

            new SoundPlayer(@"C:\Windows\Media\notify.wav").Play();
            MessageBox.Show("Data Saved Successfully!", "Saved");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Validating
        private void ValidateEmptyTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);

            if (String.IsNullOrEmpty(Temp.Text))
            {
                epValidation.SetError(Temp, "The Field Is Required.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(Temp, "");
            }
        }

        private void txEmailVal_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.ValidateEmail(txEmailVal.Text))
            {
                e.Cancel = true;
                epValidation.SetError(txEmailVal, "Invalid Email Address Format!");
            }
            else if (string.IsNullOrEmpty(txEmailVal.Text))
            {
                epValidation.SetError(txEmailVal, "The Email Is Required Field.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(txEmailVal, "");
            }
        }

        private void txNationalNoVal_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txNationalNoVal.Text))
            {
                epValidation.SetError(txNationalNoVal, "The Field Is Required.");
                e.Cancel = true;
            }
            else if (clsPerson.Exists(txNationalNoVal.Text) && txNationalNoVal.Text.Trim() != _Person.NationalNumber)
            {
                epValidation.SetError(txNationalNoVal, "The National Number Is Used For Another Person.");
                e.Cancel = true;
            }
            else
            {
                epValidation.SetError(txNationalNoVal, "");
            }
        }

    }

}
