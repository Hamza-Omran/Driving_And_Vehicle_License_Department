using DVLD_Business_Layer;

namespace DVLD_Presentation_Layer
{
    partial class ctrlUserInfoCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbUserName1 = new System.Windows.Forms.Label();
            this.lbUserNameVal1 = new System.Windows.Forms.Label();
            this.lbIsActive1 = new System.Windows.Forms.Label();
            this.lbIsActiveVal1 = new System.Windows.Forms.Label();
            this.lbUserID1 = new System.Windows.Forms.Label();
            this.lbUserIDVal1 = new System.Windows.Forms.Label();
            this.ctrlPersonInfo2 = new DVLD_Presentation_Layer.ctrlPersonInfo();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbUserName1);
            this.panel2.Controls.Add(this.lbUserNameVal1);
            this.panel2.Controls.Add(this.lbIsActive1);
            this.panel2.Controls.Add(this.lbIsActiveVal1);
            this.panel2.Controls.Add(this.lbUserID1);
            this.panel2.Controls.Add(this.lbUserIDVal1);
            this.panel2.Location = new System.Drawing.Point(9, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1385, 100);
            this.panel2.TabIndex = 1;
            // 
            // lbUserName1
            // 
            this.lbUserName1.AutoSize = true;
            this.lbUserName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName1.Location = new System.Drawing.Point(530, 34);
            this.lbUserName1.Name = "lbUserName1";
            this.lbUserName1.Size = new System.Drawing.Size(169, 32);
            this.lbUserName1.TabIndex = 4;
            this.lbUserName1.Text = "User name:";
            // 
            // lbUserNameVal1
            // 
            this.lbUserNameVal1.AutoSize = true;
            this.lbUserNameVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserNameVal1.Location = new System.Drawing.Point(705, 34);
            this.lbUserNameVal1.Name = "lbUserNameVal1";
            this.lbUserNameVal1.Size = new System.Drawing.Size(82, 32);
            this.lbUserNameVal1.TabIndex = 5;
            this.lbUserNameVal1.Text = "????";
            // 
            // lbIsActive1
            // 
            this.lbIsActive1.AutoSize = true;
            this.lbIsActive1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsActive1.Location = new System.Drawing.Point(950, 34);
            this.lbIsActive1.Name = "lbIsActive1";
            this.lbIsActive1.Size = new System.Drawing.Size(138, 32);
            this.lbIsActive1.TabIndex = 6;
            this.lbIsActive1.Text = "Is Active:";
            // 
            // lbIsActiveVal1
            // 
            this.lbIsActiveVal1.AutoSize = true;
            this.lbIsActiveVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsActiveVal1.Location = new System.Drawing.Point(1094, 34);
            this.lbIsActiveVal1.Name = "lbIsActiveVal1";
            this.lbIsActiveVal1.Size = new System.Drawing.Size(82, 32);
            this.lbIsActiveVal1.TabIndex = 7;
            this.lbIsActiveVal1.Text = "????";
            // 
            // lbUserID1
            // 
            this.lbUserID1.AutoSize = true;
            this.lbUserID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID1.Location = new System.Drawing.Point(163, 34);
            this.lbUserID1.Name = "lbUserID1";
            this.lbUserID1.Size = new System.Drawing.Size(123, 32);
            this.lbUserID1.TabIndex = 2;
            this.lbUserID1.Text = "User ID:";
            // 
            // lbUserIDVal1
            // 
            this.lbUserIDVal1.AutoSize = true;
            this.lbUserIDVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserIDVal1.Location = new System.Drawing.Point(292, 34);
            this.lbUserIDVal1.Name = "lbUserIDVal1";
            this.lbUserIDVal1.Size = new System.Drawing.Size(82, 32);
            this.lbUserIDVal1.TabIndex = 3;
            this.lbUserIDVal1.Text = "????";
            // 
            // ctrlPersonInfo2
            // 
            this.ctrlPersonInfo2.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInfo2.LabelLinkEnable = true;
            this.ctrlPersonInfo2.Location = new System.Drawing.Point(3, 2);
            this.ctrlPersonInfo2.Name = "ctrlPersonInfo2";
            this.ctrlPersonInfo2.NationalNo = null;
            this.ctrlPersonInfo2.PersonID = -1;
            this.ctrlPersonInfo2.PersonInfo = null;
            this.ctrlPersonInfo2.Size = new System.Drawing.Size(1402, 325);
            this.ctrlPersonInfo2.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbTitle.Location = new System.Drawing.Point(52, 320);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(222, 32);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "User Information";
            // 
            // ctrlUserInfoCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ctrlPersonInfo2);
            this.Name = "ctrlUserInfoCard";
            this.Size = new System.Drawing.Size(1400, 450);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbLoginInfoHeader;
        private System.Windows.Forms.Label lbIsActiveVal;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label lbUsernameVal;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbUserIDVal;
        private System.Windows.Forms.Label lbUserID;
        private ctrlPersonInfo ctrlPersonInfo2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbUserName1;
        private System.Windows.Forms.Label lbUserNameVal1;
        private System.Windows.Forms.Label lbIsActive1;
        private System.Windows.Forms.Label lbIsActiveVal1;
        private System.Windows.Forms.Label lbUserID1;
        private System.Windows.Forms.Label lbUserIDVal1;
        private System.Windows.Forms.Label lbTitle;
    }
}
