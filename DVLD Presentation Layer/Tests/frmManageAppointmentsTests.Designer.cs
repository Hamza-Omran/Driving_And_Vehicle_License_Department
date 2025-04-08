namespace DVLD_Presentation_Layer.Applications.Take_Appointment
{
    partial class frmManageAppointmentsTests
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
            this.dgvTestsAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointmentOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecordsVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.ctrlDrivingLicenseAppInfo1 = new DVLD_Presentation_Layer.Applications.Controls.ctrlDrivingLicenseAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsAppointments)).BeginInit();
            this.cmsAppointmentOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 667);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appointments";
            // 
            // dgvTestsAppointments
            // 
            this.dgvTestsAppointments.AllowUserToAddRows = false;
            this.dgvTestsAppointments.AllowUserToDeleteRows = false;
            this.dgvTestsAppointments.AllowUserToOrderColumns = true;
            this.dgvTestsAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestsAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestsAppointments.ContextMenuStrip = this.cmsAppointmentOptions;
            this.dgvTestsAppointments.Location = new System.Drawing.Point(14, 713);
            this.dgvTestsAppointments.Name = "dgvTestsAppointments";
            this.dgvTestsAppointments.ReadOnly = true;
            this.dgvTestsAppointments.RowHeadersWidth = 62;
            this.dgvTestsAppointments.RowTemplate.Height = 28;
            this.dgvTestsAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestsAppointments.Size = new System.Drawing.Size(1234, 169);
            this.dgvTestsAppointments.TabIndex = 2;
            // 
            // cmsAppointmentOptions
            // 
            this.cmsAppointmentOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsAppointmentOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditTestToolStripMenuItem,
            this.TakeTestToolStripMenuItem});
            this.cmsAppointmentOptions.Name = "cmsAppointmentOptions";
            this.cmsAppointmentOptions.Size = new System.Drawing.Size(249, 101);
            // 
            // EditTestToolStripMenuItem
            // 
            this.EditTestToolStripMenuItem.Image = global::DVLD_Presentation_Layer.Properties.Resources.edit_32;
            this.EditTestToolStripMenuItem.Name = "EditTestToolStripMenuItem";
            this.EditTestToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.EditTestToolStripMenuItem.Text = "Edit";
            this.EditTestToolStripMenuItem.Click += new System.EventHandler(this.EditAppointment);
            // 
            // TakeTestToolStripMenuItem
            // 
            this.TakeTestToolStripMenuItem.Image = global::DVLD_Presentation_Layer.Properties.Resources.Test_32;
            this.TakeTestToolStripMenuItem.Name = "TakeTestToolStripMenuItem";
            this.TakeTestToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.TakeTestToolStripMenuItem.Text = "Take Test";
            this.TakeTestToolStripMenuItem.Click += new System.EventHandler(this.TakeTest);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 901);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "#Records:";
            // 
            // lbRecordsVal
            // 
            this.lbRecordsVal.AutoSize = true;
            this.lbRecordsVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsVal.Location = new System.Drawing.Point(153, 901);
            this.lbRecordsVal.Name = "lbRecordsVal";
            this.lbRecordsVal.Size = new System.Drawing.Size(55, 29);
            this.lbRecordsVal.TabIndex = 4;
            this.lbRecordsVal.Text = "[??]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(399, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 40);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vision Tests Appointments";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.Vision_512;
            this.pictureBox1.Location = new System.Drawing.Point(556, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1117, 901);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 52);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Image = global::DVLD_Presentation_Layer.Properties.Resources.AddAppointment_32;
            this.btnAddAppointment.Location = new System.Drawing.Point(1170, 641);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(78, 64);
            this.btnAddAppointment.TabIndex = 5;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // ctrlDrivingLicenseAppInfo1
            // 
            this.ctrlDrivingLicenseAppInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseAppInfo1.Location = new System.Drawing.Point(8, 196);
            this.ctrlDrivingLicenseAppInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDrivingLicenseAppInfo1.Name = "ctrlDrivingLicenseAppInfo1";
            this.ctrlDrivingLicenseAppInfo1.Size = new System.Drawing.Size(1249, 438);
            this.ctrlDrivingLicenseAppInfo1.TabIndex = 7;
            // 
            // frmManageAppointmentsTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 957);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlDrivingLicenseAppInfo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lbRecordsVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTestsAppointments);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageAppointmentsTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Manage Screen";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsAppointments)).EndInit();
            this.cmsAppointmentOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTestsAppointments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecordsVal;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnClose;
        private Controls.ctrlDrivingLicenseAppInfo ctrlDrivingLicenseAppInfo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsAppointmentOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem EditTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TakeTestToolStripMenuItem;
    }
}