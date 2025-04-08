namespace DVLD_Presentation_Layer.Take_Appointment
{
    partial class frmAddOrEditTestAppointment
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlSheduleTest1 = new DVLD_Presentation_Layer.Tests.Controls.ctrlSheduleTest();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::DVLD_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(307, 801);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 58);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlSheduleTest1
            // 
            this.ctrlSheduleTest1.BackColor = System.Drawing.Color.White;
            this.ctrlSheduleTest1.LocalAppInfo = null;
            this.ctrlSheduleTest1.Location = new System.Drawing.Point(6, 3);
            this.ctrlSheduleTest1.Name = "ctrlSheduleTest1";
            this.ctrlSheduleTest1.Size = new System.Drawing.Size(698, 787);
            this.ctrlSheduleTest1.TabIndex = 59;
            this.ctrlSheduleTest1.TestTypeID = DVLD_Business_Layer.clsTestTypes.enTestType.StreetTest;
            // 
            // frmAddOrEditTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 871);
            this.Controls.Add(this.ctrlSheduleTest1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOrEditTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddTestAppointment";
            this.Activated += new System.EventHandler(this.frmAddOrEditTestAppointment_Activated);
            this.Load += new System.EventHandler(this.frmAddOrEditTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private Tests.Controls.ctrlSheduleTest ctrlSheduleTest1;
    }
}