using System;

namespace DVLD_Presentation_Layer
{
    partial class frmAddOrEditPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.llbRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llbSetImage = new System.Windows.Forms.LinkLabel();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cbCountryVal = new System.Windows.Forms.ComboBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lbPersonIDVal = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tbPhoneVal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbAddressVal = new System.Windows.Forms.TextBox();
            this.txEmailVal = new System.Windows.Forms.TextBox();
            this.txNationalNoVal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txLastNameVal = new System.Windows.Forms.TextBox();
            this.txThirdNameVal = new System.Windows.Forms.TextBox();
            this.txSecondNameVal = new System.Windows.Forms.TextBox();
            this.txFirstNameVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.epValidation = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.Location = new System.Drawing.Point(12, 51);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(135, 29);
            this.lbPersonID.TabIndex = 64;
            this.lbPersonID.Text = "Person ID:";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_Presentation_Layer.Properties.Resources.Number_32;
            this.pictureBox10.Location = new System.Drawing.Point(181, 96);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(35, 40);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 68;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Presentation_Layer.Properties.Resources.Email_32;
            this.pictureBox3.Location = new System.Drawing.Point(180, 201);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD_Presentation_Layer.Properties.Resources.Address_32;
            this.pictureBox9.Location = new System.Drawing.Point(180, 266);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(35, 40);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 66;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_Presentation_Layer.Properties.Resources.Country_32;
            this.pictureBox8.Location = new System.Drawing.Point(673, 201);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(35, 40);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 65;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_Presentation_Layer.Properties.Resources.Phone_32;
            this.pictureBox7.Location = new System.Drawing.Point(673, 147);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(35, 40);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 64;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Presentation_Layer.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(673, 95);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(35, 40);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 63;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Presentation_Layer.Properties.Resources.Person_32;
            this.pictureBox5.Location = new System.Drawing.Point(180, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 62;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Presentation_Layer.Properties.Resources.Woman_32;
            this.pictureBox2.Location = new System.Drawing.Point(318, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.Man_32;
            this.pictureBox1.Location = new System.Drawing.Point(181, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(659, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 58);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Presentation_Layer.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(807, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 58);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeader.Location = new System.Drawing.Point(471, 7);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(334, 46);
            this.lblHeader.TabIndex = 65;
            this.lblHeader.Text = "Add New Person";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // llbRemoveImage
            // 
            this.llbRemoveImage.AutoSize = true;
            this.llbRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.llbRemoveImage.Location = new System.Drawing.Point(1007, 378);
            this.llbRemoveImage.Name = "llbRemoveImage";
            this.llbRemoveImage.Size = new System.Drawing.Size(176, 29);
            this.llbRemoveImage.TabIndex = 55;
            this.llbRemoveImage.TabStop = true;
            this.llbRemoveImage.Text = "Remove Image";
            this.llbRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbRemoveImage_LinkClicked);
            // 
            // llbSetImage
            // 
            this.llbSetImage.AutoSize = true;
            this.llbSetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.llbSetImage.Location = new System.Drawing.Point(1031, 339);
            this.llbSetImage.Name = "llbSetImage";
            this.llbSetImage.Size = new System.Drawing.Size(122, 29);
            this.llbSetImage.TabIndex = 44;
            this.llbSetImage.TabStop = true;
            this.llbSetImage.Text = "Set Image";
            this.llbSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSetImage_LinkClicked);
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(712, 111);
            this.dtpDOB.MinDate = new System.DateTime(1819, 12, 31, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(237, 26);
            this.dtpDOB.TabIndex = 37;
            // 
            // cbCountryVal
            // 
            this.cbCountryVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountryVal.FormattingEnabled = true;
            this.cbCountryVal.Location = new System.Drawing.Point(712, 213);
            this.cbCountryVal.Name = "cbCountryVal";
            this.cbCountryVal.Size = new System.Drawing.Size(237, 28);
            this.cbCountryVal.TabIndex = 42;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbFemale.Location = new System.Drawing.Point(359, 159);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(102, 29);
            this.rbFemale.TabIndex = 39;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbMale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbMale.Location = new System.Drawing.Point(224, 160);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(80, 29);
            this.rbMale.TabIndex = 38;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(552, 209);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(109, 29);
            this.lblCountry.TabIndex = 46;
            this.lblCountry.Text = "Country:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(566, 163);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(95, 29);
            this.lblPhone.TabIndex = 45;
            this.lblPhone.Text = "Phone:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(492, 111);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(169, 29);
            this.lblDOB.TabIndex = 44;
            this.lblDOB.Text = "Date Of Birth:";
            // 
            // lbPersonIDVal
            // 
            this.lbPersonIDVal.AutoSize = true;
            this.lbPersonIDVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonIDVal.Location = new System.Drawing.Point(230, 51);
            this.lbPersonIDVal.Name = "lbPersonIDVal";
            this.lbPersonIDVal.Size = new System.Drawing.Size(56, 29);
            this.lbPersonIDVal.TabIndex = 63;
            this.lbPersonIDVal.Text = "N/A";
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = global::DVLD_Presentation_Layer.Properties.Resources.Male_512;
            this.pbPersonImage.Location = new System.Drawing.Point(999, 106);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(194, 213);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 53;
            this.pbPersonImage.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Presentation_Layer.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(191, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            // 
            // tbPhoneVal
            // 
            this.tbPhoneVal.Location = new System.Drawing.Point(712, 159);
            this.tbPhoneVal.Name = "tbPhoneVal";
            this.tbPhoneVal.Size = new System.Drawing.Size(237, 26);
            this.tbPhoneVal.TabIndex = 40;
            this.tbPhoneVal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox_Validating);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox10);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox9);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.llbRemoveImage);
            this.panel1.Controls.Add(this.llbSetImage);
            this.panel1.Controls.Add(this.pbPersonImage);
            this.panel1.Controls.Add(this.dtpDOB);
            this.panel1.Controls.Add(this.cbCountryVal);
            this.panel1.Controls.Add(this.rbFemale);
            this.panel1.Controls.Add(this.rbMale);
            this.panel1.Controls.Add(this.lblCountry);
            this.panel1.Controls.Add(this.lblPhone);
            this.panel1.Controls.Add(this.lblDOB);
            this.panel1.Controls.Add(this.tbPhoneVal);
            this.panel1.Controls.Add(this.tbAddressVal);
            this.panel1.Controls.Add(this.txEmailVal);
            this.panel1.Controls.Add(this.txNationalNoVal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txLastNameVal);
            this.panel1.Controls.Add(this.txThirdNameVal);
            this.panel1.Controls.Add(this.txSecondNameVal);
            this.panel1.Controls.Add(this.txFirstNameVal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblGender);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Location = new System.Drawing.Point(11, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 555);
            this.panel1.TabIndex = 62;
            // 
            // tbAddressVal
            // 
            this.tbAddressVal.Location = new System.Drawing.Point(224, 270);
            this.tbAddressVal.Multiline = true;
            this.tbAddressVal.Name = "tbAddressVal";
            this.tbAddressVal.Size = new System.Drawing.Size(725, 157);
            this.tbAddressVal.TabIndex = 43;
            this.tbAddressVal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox_Validating);
            // 
            // txEmailVal
            // 
            this.txEmailVal.Location = new System.Drawing.Point(224, 215);
            this.txEmailVal.Name = "txEmailVal";
            this.txEmailVal.Size = new System.Drawing.Size(237, 26);
            this.txEmailVal.TabIndex = 41;
            this.txEmailVal.Validating += new System.ComponentModel.CancelEventHandler(this.txEmailVal_Validating);
            // 
            // txNationalNoVal
            // 
            this.txNationalNoVal.Location = new System.Drawing.Point(224, 111);
            this.txNationalNoVal.Name = "txNationalNoVal";
            this.txNationalNoVal.Size = new System.Drawing.Size(237, 26);
            this.txNationalNoVal.TabIndex = 36;
            this.txNationalNoVal.Validating += new System.ComponentModel.CancelEventHandler(this.txNationalNoVal_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(1043, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 29);
            this.label5.TabIndex = 39;
            this.label5.Text = "Last";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(782, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 29);
            this.label4.TabIndex = 38;
            this.label4.Text = "Third";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(543, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 29);
            this.label3.TabIndex = 37;
            this.label3.Text = "Second";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(308, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "First";
            // 
            // txLastNameVal
            // 
            this.txLastNameVal.Location = new System.Drawing.Point(956, 59);
            this.txLastNameVal.Name = "txLastNameVal";
            this.txLastNameVal.Size = new System.Drawing.Size(237, 26);
            this.txLastNameVal.TabIndex = 35;
            this.txLastNameVal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox_Validating);
            // 
            // txThirdNameVal
            // 
            this.txThirdNameVal.Location = new System.Drawing.Point(712, 59);
            this.txThirdNameVal.Name = "txThirdNameVal";
            this.txThirdNameVal.Size = new System.Drawing.Size(237, 26);
            this.txThirdNameVal.TabIndex = 34;
            // 
            // txSecondNameVal
            // 
            this.txSecondNameVal.Location = new System.Drawing.Point(468, 58);
            this.txSecondNameVal.Name = "txSecondNameVal";
            this.txSecondNameVal.Size = new System.Drawing.Size(237, 26);
            this.txSecondNameVal.TabIndex = 33;
            this.txSecondNameVal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox_Validating);
            // 
            // txFirstNameVal
            // 
            this.txFirstNameVal.Location = new System.Drawing.Point(224, 59);
            this.txFirstNameVal.Name = "txFirstNameVal";
            this.txFirstNameVal.Size = new System.Drawing.Size(237, 26);
            this.txFirstNameVal.TabIndex = 32;
            this.txFirstNameVal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "National No:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(15, 158);
            this.lblGender.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(107, 29);
            this.lblGender.TabIndex = 29;
            this.lblGender.Text = "Gender:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(15, 54);
            this.lblName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 29);
            this.lblName.TabIndex = 27;
            this.lblName.Text = "Name:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(15, 211);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(86, 29);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(15, 265);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(116, 29);
            this.lblAddress.TabIndex = 31;
            this.lblAddress.Text = "Address:";
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // frmAddOrEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 657);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lbPersonIDVal);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddOrEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddOrEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel llbRemoveImage;
        private System.Windows.Forms.LinkLabel llbSetImage;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cbCountryVal;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lbPersonIDVal;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tbPhoneVal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbAddressVal;
        private System.Windows.Forms.TextBox txEmailVal;
        private System.Windows.Forms.TextBox txNationalNoVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txLastNameVal;
        private System.Windows.Forms.TextBox txThirdNameVal;
        private System.Windows.Forms.TextBox txSecondNameVal;
        private System.Windows.Forms.TextBox txFirstNameVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ErrorProvider epValidation;
    }
}