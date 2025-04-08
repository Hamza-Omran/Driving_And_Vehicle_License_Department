namespace DVLD_Presentation_Layer
{
    partial class frmManageLocalDrivingApplications
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsoShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsoDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsoVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsoWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsoStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoIssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.lbRecordsVal = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(488, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(662, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Applications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 844);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "# Records:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "none",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(172, 340);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(232, 28);
            this.cbFilterBy.TabIndex = 5;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Location = new System.Drawing.Point(428, 340);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(232, 26);
            this.tbFilterBy.TabIndex = 6;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            this.tbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.AllowUserToOrderColumns = true;
            this.dgvApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.ContextMenuStrip = this.cmsOptions;
            this.dgvApplications.Location = new System.Drawing.Point(12, 383);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersWidth = 62;
            this.dgvApplications.RowTemplate.Height = 28;
            this.dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.Size = new System.Drawing.Size(1595, 435);
            this.dgvApplications.TabIndex = 9;
            this.dgvApplications.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApplications_CellMouseDown);
            // 
            // cmsOptions
            // 
            this.cmsOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsoShowDetails,
            this.toolStripSeparator1,
            this.cmsoEdit,
            this.cmsoDelete,
            this.toolStripSeparator3,
            this.cmsoCancel,
            this.toolStripSeparator7,
            this.cmsoScheduleTest,
            this.toolStripSeparator4,
            this.cmsoIssueLicense,
            this.toolStripSeparator5,
            this.cmsoShowLicense,
            this.toolStripSeparator6,
            this.cmsoLicenseHistory});
            this.cmsOptions.Name = "contextMenuStrip1";
            this.cmsOptions.Size = new System.Drawing.Size(347, 296);
            this.cmsOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOptions_Opening);
            // 
            // cmsoShowDetails
            // 
            this.cmsoShowDetails.Image = global::DVLD_Presentation_Layer.Properties.Resources.Users_2_64;
            this.cmsoShowDetails.Name = "cmsoShowDetails";
            this.cmsoShowDetails.Size = new System.Drawing.Size(346, 32);
            this.cmsoShowDetails.Text = "Show Application Details";
            this.cmsoShowDetails.Click += new System.EventHandler(this.cmsoShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(343, 6);
            // 
            // cmsoEdit
            // 
            this.cmsoEdit.Image = global::DVLD_Presentation_Layer.Properties.Resources.edit_32;
            this.cmsoEdit.Name = "cmsoEdit";
            this.cmsoEdit.Size = new System.Drawing.Size(346, 32);
            this.cmsoEdit.Text = "Edit Application";
            this.cmsoEdit.Click += new System.EventHandler(this.cmsoEdit_Click);
            // 
            // cmsoDelete
            // 
            this.cmsoDelete.Image = global::DVLD_Presentation_Layer.Properties.Resources.Delete_32_2;
            this.cmsoDelete.Name = "cmsoDelete";
            this.cmsoDelete.Size = new System.Drawing.Size(346, 32);
            this.cmsoDelete.Text = "Delete Application";
            this.cmsoDelete.Click += new System.EventHandler(this.cmsoDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(343, 6);
            // 
            // cmsoCancel
            // 
            this.cmsoCancel.Image = global::DVLD_Presentation_Layer.Properties.Resources.Delete_32;
            this.cmsoCancel.Name = "cmsoCancel";
            this.cmsoCancel.Size = new System.Drawing.Size(346, 32);
            this.cmsoCancel.Text = "Cancel Application";
            this.cmsoCancel.Click += new System.EventHandler(this.cmsoCancel_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(343, 6);
            // 
            // cmsoScheduleTest
            // 
            this.cmsoScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsoVisionTest,
            this.cmsoWrittenTest,
            this.cmsoStreetTest});
            this.cmsoScheduleTest.Image = global::DVLD_Presentation_Layer.Properties.Resources.TestType_32;
            this.cmsoScheduleTest.Name = "cmsoScheduleTest";
            this.cmsoScheduleTest.Size = new System.Drawing.Size(346, 32);
            this.cmsoScheduleTest.Text = "Schedule Tests";
            // 
            // cmsoVisionTest
            // 
            this.cmsoVisionTest.Image = global::DVLD_Presentation_Layer.Properties.Resources.Vision_Test_32;
            this.cmsoVisionTest.Name = "cmsoVisionTest";
            this.cmsoVisionTest.Size = new System.Drawing.Size(278, 34);
            this.cmsoVisionTest.Text = "Schedule Vision Test";
            this.cmsoVisionTest.Click += new System.EventHandler(this.cmsoVisionTest_Click);
            // 
            // cmsoWrittenTest
            // 
            this.cmsoWrittenTest.Image = global::DVLD_Presentation_Layer.Properties.Resources.Written_Test_32;
            this.cmsoWrittenTest.Name = "cmsoWrittenTest";
            this.cmsoWrittenTest.Size = new System.Drawing.Size(278, 34);
            this.cmsoWrittenTest.Text = "Schedule WrittenTest";
            this.cmsoWrittenTest.Click += new System.EventHandler(this.cmsoWrittenTest_Click);
            // 
            // cmsoStreetTest
            // 
            this.cmsoStreetTest.Image = global::DVLD_Presentation_Layer.Properties.Resources.Street_Test_32;
            this.cmsoStreetTest.Name = "cmsoStreetTest";
            this.cmsoStreetTest.Size = new System.Drawing.Size(278, 34);
            this.cmsoStreetTest.Text = "Schedule Street Test";
            this.cmsoStreetTest.Click += new System.EventHandler(this.cmsoStreetTest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(343, 6);
            // 
            // cmsoIssueLicense
            // 
            this.cmsoIssueLicense.Image = global::DVLD_Presentation_Layer.Properties.Resources.Driver_License_48;
            this.cmsoIssueLicense.Name = "cmsoIssueLicense";
            this.cmsoIssueLicense.Size = new System.Drawing.Size(346, 32);
            this.cmsoIssueLicense.Text = "Issue Driving License (First Time)";
            this.cmsoIssueLicense.Click += new System.EventHandler(this.cmsoIssueLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(343, 6);
            // 
            // cmsoShowLicense
            // 
            this.cmsoShowLicense.Image = global::DVLD_Presentation_Layer.Properties.Resources.License_View_32;
            this.cmsoShowLicense.Name = "cmsoShowLicense";
            this.cmsoShowLicense.Size = new System.Drawing.Size(346, 32);
            this.cmsoShowLicense.Text = "Show License";
            this.cmsoShowLicense.Click += new System.EventHandler(this.cmsoShowLicense_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(343, 6);
            // 
            // cmsoLicenseHistory
            // 
            this.cmsoLicenseHistory.Image = global::DVLD_Presentation_Layer.Properties.Resources.PersonLicenseHistory_512;
            this.cmsoLicenseHistory.Name = "cmsoLicenseHistory";
            this.cmsoLicenseHistory.Size = new System.Drawing.Size(346, 32);
            this.cmsoLicenseHistory.Text = "Show Person License History";
            this.cmsoLicenseHistory.Click += new System.EventHandler(this.cmsoLicenseHistory_Click);
            // 
            // lbRecordsVal
            // 
            this.lbRecordsVal.AutoSize = true;
            this.lbRecordsVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsVal.Location = new System.Drawing.Point(189, 844);
            this.lbRecordsVal.Name = "lbRecordsVal";
            this.lbRecordsVal.Size = new System.Drawing.Size(65, 32);
            this.lbRecordsVal.TabIndex = 10;
            this.lbRecordsVal.Text = "???";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Presentation_Layer.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(905, 75);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1470, 829);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 64);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.Image = global::DVLD_Presentation_Layer.Properties.Resources.New_Application_32;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1521, 281);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(86, 85);
            this.btnAddNewApplication.TabIndex = 7;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(695, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Completed",
            "Cancelled"});
            this.cbStatus.Location = new System.Drawing.Point(428, 340);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(156, 28);
            this.cbStatus.TabIndex = 12;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // frmManageLocalDrivingApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1619, 906);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbRecordsVal);
            this.Controls.Add(this.dgvApplications);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageLocalDrivingApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Applications Screen";
            this.Load += new System.EventHandler(this.ManageApplicationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.Label lbRecordsVal;
        private System.Windows.Forms.ToolStripMenuItem cmsoShowDetails;
        private System.Windows.Forms.ToolStripMenuItem cmsoEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsoDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsoCancel;
        private System.Windows.Forms.ToolStripMenuItem cmsoScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem cmsoIssueLicense;
        private System.Windows.Forms.ToolStripMenuItem cmsoShowLicense;
        private System.Windows.Forms.ToolStripMenuItem cmsoLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem cmsoVisionTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsoWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmsoStreetTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbStatus;
    }
}