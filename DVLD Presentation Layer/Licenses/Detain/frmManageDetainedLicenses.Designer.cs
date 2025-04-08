namespace DVLD_Presentation_Layer.Detain
{
    partial class frmManageDetainedLicenses
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
            this.lbRecordsVal = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvDetain = new System.Windows.Forms.DataGridView();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsoShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsoLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.cbFilterYesNo = new System.Windows.Forms.ComboBox();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetain)).BeginInit();
            this.cmsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRecordsVal
            // 
            this.lbRecordsVal.AutoSize = true;
            this.lbRecordsVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsVal.Location = new System.Drawing.Point(195, 751);
            this.lbRecordsVal.Name = "lbRecordsVal";
            this.lbRecordsVal.Size = new System.Drawing.Size(65, 32);
            this.lbRecordsVal.TabIndex = 31;
            this.lbRecordsVal.Text = "???";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1509, 745);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 54);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(730, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // dgvDetain
            // 
            this.dgvDetain.AllowUserToAddRows = false;
            this.dgvDetain.AllowUserToDeleteRows = false;
            this.dgvDetain.AllowUserToOrderColumns = true;
            this.dgvDetain.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetain.ContextMenuStrip = this.cmsOptions;
            this.dgvDetain.Location = new System.Drawing.Point(12, 361);
            this.dgvDetain.Name = "dgvDetain";
            this.dgvDetain.ReadOnly = true;
            this.dgvDetain.RowHeadersWidth = 62;
            this.dgvDetain.RowTemplate.Height = 28;
            this.dgvDetain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetain.Size = new System.Drawing.Size(1632, 378);
            this.dgvDetain.TabIndex = 30;
            this.dgvDetain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetained_CellMouseDown);
            // 
            // cmsOptions
            // 
            this.cmsOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsoShowDetails,
            this.toolStripSeparator2,
            this.cmsoShowLicense,
            this.toolStripSeparator3,
            this.cmsoLicenseHistory,
            this.releaseDetainToolStripMenuItem});
            this.cmsOptions.Name = "contextMenuStrip1";
            this.cmsOptions.Size = new System.Drawing.Size(318, 144);
            // 
            // cmsoShowDetails
            // 
            this.cmsoShowDetails.Image = global::DVLD_Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.cmsoShowDetails.Name = "cmsoShowDetails";
            this.cmsoShowDetails.Size = new System.Drawing.Size(317, 32);
            this.cmsoShowDetails.Text = "Show Person Details";
            this.cmsoShowDetails.Click += new System.EventHandler(this.cmsoShowDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(314, 6);
            // 
            // cmsoShowLicense
            // 
            this.cmsoShowLicense.Image = global::DVLD_Presentation_Layer.Properties.Resources.License_View_32;
            this.cmsoShowLicense.Name = "cmsoShowLicense";
            this.cmsoShowLicense.Size = new System.Drawing.Size(317, 32);
            this.cmsoShowLicense.Text = "Show License";
            this.cmsoShowLicense.Click += new System.EventHandler(this.cmsoShowLicense_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(314, 6);
            // 
            // cmsoLicenseHistory
            // 
            this.cmsoLicenseHistory.Image = global::DVLD_Presentation_Layer.Properties.Resources.PersonLicenseHistory_32;
            this.cmsoLicenseHistory.Name = "cmsoLicenseHistory";
            this.cmsoLicenseHistory.Size = new System.Drawing.Size(317, 32);
            this.cmsoLicenseHistory.Text = "Show Person License History";
            this.cmsoLicenseHistory.Click += new System.EventHandler(this.cmsoLicenseHistory_Click);
            // 
            // releaseDetainToolStripMenuItem
            // 
            this.releaseDetainToolStripMenuItem.Image = global::DVLD_Presentation_Layer.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainToolStripMenuItem.Name = "releaseDetainToolStripMenuItem";
            this.releaseDetainToolStripMenuItem.Size = new System.Drawing.Size(317, 32);
            this.releaseDetainToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainToolStripMenuItem_Click);
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Location = new System.Drawing.Point(421, 319);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(232, 26);
            this.tbFilterBy.TabIndex = 27;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            this.tbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "none",
            "D.ID",
            "L.ID",
            "D.Date",
            "Is Released",
            "Fine Fees",
            "Release Date",
            "N.No.",
            "Full Name",
            "Release App ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(165, 319);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(232, 28);
            this.cbFilterBy.TabIndex = 26;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 751);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 32);
            this.label3.TabIndex = 25;
            this.label3.Text = "# Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(609, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 46);
            this.label1.TabIndex = 23;
            this.label1.Text = "List Detained Licenses";
            // 
            // btnDetain
            // 
            this.btnDetain.Image = global::DVLD_Presentation_Layer.Properties.Resources.Detain_32;
            this.btnDetain.Location = new System.Drawing.Point(1554, 269);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(90, 78);
            this.btnDetain.TabIndex = 28;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Image = global::DVLD_Presentation_Layer.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.Location = new System.Drawing.Point(1431, 269);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(108, 78);
            this.btnRelease.TabIndex = 33;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // cbFilterYesNo
            // 
            this.cbFilterYesNo.FormattingEnabled = true;
            this.cbFilterYesNo.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterYesNo.Location = new System.Drawing.Point(421, 319);
            this.cbFilterYesNo.Name = "cbFilterYesNo";
            this.cbFilterYesNo.Size = new System.Drawing.Size(177, 28);
            this.cbFilterYesNo.TabIndex = 34;
            this.cbFilterYesNo.SelectedIndexChanged += new System.EventHandler(this.cbFilterYesNo_SelectedIndexChanged);
            // 
            // dtpFilter
            // 
            this.dtpFilter.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(421, 321);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(142, 26);
            this.dtpFilter.TabIndex = 35;
            this.dtpFilter.Value = new System.DateTime(2095, 2, 15, 15, 18, 0, 0);
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1659, 807);
            this.Controls.Add(this.dtpFilter);
            this.Controls.Add(this.cbFilterYesNo);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.lbRecordsVal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvDetain);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetain)).EndInit();
            this.cmsOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRecordsVal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvDetain;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem cmsoShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsoShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsoLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFilterYesNo;
        private System.Windows.Forms.DateTimePicker dtpFilter;
    }
}