namespace DVLD_Presentation_Layer
{
    partial class ctrlFilterPerson
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
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.lbFindBy = new System.Windows.Forms.Label();
            this.tbFindByVal = new System.Windows.Forms.TextBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.epValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonInfo1 = new DVLD_Presentation_Layer.ctrlPersonInfo();
            this.pFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // pFind
            // 
            this.pFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFind.Controls.Add(this.btnAddPerson);
            this.pFind.Controls.Add(this.btnFind);
            this.pFind.Controls.Add(this.lbFindBy);
            this.pFind.Controls.Add(this.tbFindByVal);
            this.pFind.Controls.Add(this.cbFindBy);
            this.pFind.Location = new System.Drawing.Point(5, 19);
            this.pFind.Name = "pFind";
            this.pFind.Size = new System.Drawing.Size(1065, 78);
            this.pFind.TabIndex = 3;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLD_Presentation_Layer.Properties.Resources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(961, 7);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(65, 60);
            this.btnAddPerson.TabIndex = 4;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::DVLD_Presentation_Layer.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(877, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 60);
            this.btnFind.TabIndex = 3;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lbFindBy
            // 
            this.lbFindBy.AutoSize = true;
            this.lbFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lbFindBy.Location = new System.Drawing.Point(113, 21);
            this.lbFindBy.Name = "lbFindBy";
            this.lbFindBy.Size = new System.Drawing.Size(126, 32);
            this.lbFindBy.TabIndex = 2;
            this.lbFindBy.Text = "Find By:";
            // 
            // tbFindByVal
            // 
            this.tbFindByVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindByVal.Location = new System.Drawing.Point(546, 24);
            this.tbFindByVal.Name = "tbFindByVal";
            this.tbFindByVal.Size = new System.Drawing.Size(280, 30);
            this.tbFindByVal.TabIndex = 1;
            this.tbFindByVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFindByVal_KeyPress);
            this.tbFindByVal.Validating += new System.ComponentModel.CancelEventHandler(this.tbFindByVal_Validating);
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cbFindBy.Location = new System.Drawing.Point(249, 23);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(280, 33);
            this.cbFindBy.TabIndex = 0;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(34, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInfo1.LabelLinkEnable = true;
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(-5, 101);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.NationalNo = "";
            this.ctrlPersonInfo1.PersonID = -1;
            this.ctrlPersonInfo1.PersonInfo = null;
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(1403, 326);
            this.ctrlPersonInfo1.TabIndex = 4;
            // 
            // ctrlFilterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Controls.Add(this.pFind);
            this.Name = "ctrlFilterPerson";
            this.Size = new System.Drawing.Size(1394, 423);
            this.Load += new System.EventHandler(this.ctrlFilterPerson_Load);
            this.pFind.ResumeLayout(false);
            this.pFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ctrlPersonInfo ctrlPersonInfo;
        private System.Windows.Forms.Panel pFind;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lbFindBy;
        private System.Windows.Forms.TextBox tbFindByVal;
        private System.Windows.Forms.ComboBox cbFindBy;
        private ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.ErrorProvider epValidation;
        private System.Windows.Forms.Label label1;
    }
}
