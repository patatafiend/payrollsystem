namespace payrollsystemsti.EmployeeTabs
{
    partial class leaveApplication
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgLeaveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLeaveCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDateApplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgImageData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbLeaves = new System.Windows.Forms.ComboBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.pbMedCert = new System.Windows.Forms.PictureBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEmployeeID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedCert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgLeaveID,
            this.dgLeaveCategory,
            this.dgDateApplied,
            this.dgDateStart,
            this.dgDateEnd,
            this.dgReason,
            this.dgStatus,
            this.dgImageData,
            this.dgFileName});
            this.dataGridView1.Location = new System.Drawing.Point(50, 360);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(744, 175);
            this.dataGridView1.TabIndex = 0;
            // 
            // dgLeaveID
            // 
            this.dgLeaveID.HeaderText = "Leave ID";
            this.dgLeaveID.Name = "dgLeaveID";
            this.dgLeaveID.ReadOnly = true;
            // 
            // dgLeaveCategory
            // 
            this.dgLeaveCategory.HeaderText = "Leave Category";
            this.dgLeaveCategory.Name = "dgLeaveCategory";
            this.dgLeaveCategory.ReadOnly = true;
            // 
            // dgDateApplied
            // 
            this.dgDateApplied.HeaderText = "Date Applied";
            this.dgDateApplied.Name = "dgDateApplied";
            this.dgDateApplied.ReadOnly = true;
            // 
            // dgDateStart
            // 
            this.dgDateStart.HeaderText = "Date Start";
            this.dgDateStart.Name = "dgDateStart";
            this.dgDateStart.ReadOnly = true;
            // 
            // dgDateEnd
            // 
            this.dgDateEnd.HeaderText = "Date End";
            this.dgDateEnd.Name = "dgDateEnd";
            this.dgDateEnd.ReadOnly = true;
            // 
            // dgReason
            // 
            this.dgReason.HeaderText = "Reason";
            this.dgReason.Name = "dgReason";
            this.dgReason.ReadOnly = true;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // dgImageData
            // 
            this.dgImageData.HeaderText = "ImageData";
            this.dgImageData.Name = "dgImageData";
            this.dgImageData.ReadOnly = true;
            this.dgImageData.Visible = false;
            // 
            // dgFileName
            // 
            this.dgFileName.HeaderText = "File Name";
            this.dgFileName.Name = "dgFileName";
            this.dgFileName.ReadOnly = true;
            this.dgFileName.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(53, 309);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(148, 309);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // cbLeaves
            // 
            this.cbLeaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeaves.FormattingEnabled = true;
            this.cbLeaves.Location = new System.Drawing.Point(50, 80);
            this.cbLeaves.Name = "cbLeaves";
            this.cbLeaves.Size = new System.Drawing.Size(121, 21);
            this.cbLeaves.TabIndex = 3;
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(50, 183);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(349, 93);
            this.tbReason.TabIndex = 4;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "dd/MM/yyyy";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(50, 137);
            this.dtStart.MinDate = new System.DateTime(2024, 3, 2, 0, 0, 0, 0);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(92, 20);
            this.dtStart.TabIndex = 5;
            // 
            // pbMedCert
            // 
            this.pbMedCert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMedCert.Location = new System.Drawing.Point(621, 64);
            this.pbMedCert.Name = "pbMedCert";
            this.pbMedCert.Size = new System.Drawing.Size(183, 183);
            this.pbMedCert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedCert.TabIndex = 7;
            this.pbMedCert.TabStop = false;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "dd/MM/yyyy";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(170, 137);
            this.dtEnd.MinDate = new System.DateTime(2024, 3, 2, 0, 0, 0, 0);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(92, 20);
            this.dtEnd.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(638, 270);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(719, 270);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(638, 254);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(54, 13);
            this.lbFileName.TabIndex = 11;
            this.lbFileName.Text = "File Name";
            this.lbFileName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Choose Type of Leave";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Start";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "End";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Reason";
            this.label4.Visible = false;
            // 
            // tbEmployeeID
            // 
            this.tbEmployeeID.Location = new System.Drawing.Point(53, 26);
            this.tbEmployeeID.Name = "tbEmployeeID";
            this.tbEmployeeID.ReadOnly = true;
            this.tbEmployeeID.Size = new System.Drawing.Size(100, 20);
            this.tbEmployeeID.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Employee ID";
            this.label5.Visible = false;
            // 
            // leaveApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbEmployeeID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.pbMedCert);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.cbLeaves);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "leaveApplication";
            this.Text = "leaveApplication";
            this.Load += new System.EventHandler(this.leaveApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedCert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbLeaves;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.PictureBox pbMedCert;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeaveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeaveCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDateApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgImageData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFileName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmployeeID;
        private System.Windows.Forms.Label label5;
    }
}