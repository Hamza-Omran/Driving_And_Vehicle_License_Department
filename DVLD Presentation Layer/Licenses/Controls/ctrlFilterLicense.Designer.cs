namespace DVLD_Presentation_Layer
{
    partial class ctrlFilterLicense
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
            this.components = new System.ComponentModel.Container();
            this.pFind = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbLicenseIDVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLicenseCard1 = new DVLD_Presentation_Layer.ctrlLicenseCard();
            this.epValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.pFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // pFind
            // 
            this.pFind.BackColor = System.Drawing.Color.White;
            this.pFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFind.Controls.Add(this.btnSearch);
            this.pFind.Controls.Add(this.tbLicenseIDVal);
            this.pFind.Controls.Add(this.label2);
            this.pFind.Location = new System.Drawing.Point(12, 24);
            this.pFind.Name = "pFind";
            this.pFind.Size = new System.Drawing.Size(681, 72);
            this.pFind.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVLD_Presentation_Layer.Properties.Resources.License_View_32;
            this.btnSearch.Location = new System.Drawing.Point(588, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 57);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbLicenseIDVal
            // 
            this.tbLicenseIDVal.Location = new System.Drawing.Point(271, 21);
            this.tbLicenseIDVal.Name = "tbLicenseIDVal";
            this.tbLicenseIDVal.Size = new System.Drawing.Size(285, 26);
            this.tbLicenseIDVal.TabIndex = 3;
            this.tbLicenseIDVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            this.tbLicenseIDVal.Validating += new System.ComponentModel.CancelEventHandler(this.tbLicenseIDVal_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(132, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "License ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(48, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlLicenseCard1
            // 
            this.ctrlLicenseCard1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseCard1.License = null;
            this.ctrlLicenseCard1.LicenseID = -1;
            this.ctrlLicenseCard1.Location = new System.Drawing.Point(0, 98);
            this.ctrlLicenseCard1.Name = "ctrlLicenseCard1";
            this.ctrlLicenseCard1.Size = new System.Drawing.Size(1337, 369);
            this.ctrlLicenseCard1.TabIndex = 2;
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // ctrlFilterLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlLicenseCard1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pFind);
            this.Name = "ctrlFilterLicense";
            this.Size = new System.Drawing.Size(1334, 470);
            this.pFind.ResumeLayout(false);
            this.pFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pFind;
        private System.Windows.Forms.TextBox tbLicenseIDVal;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ctrlLicenseCard ctrlLicenseCard1;
        private System.Windows.Forms.ErrorProvider epValidation;
    }
}
