namespace payrollsystemsti.AdminTabs
{
    partial class employeeRegister
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
            this.lbFileName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.empID = new System.Windows.Forms.TextBox();
            this.empNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.empSSN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.empEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.empName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.empDob = new System.Windows.Forms.DateTimePicker();
            this.empAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasicRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgImageData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePic = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empPosition = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.empBasicRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(83, 260);
            this.lbFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(69, 16);
            this.lbFileName.TabIndex = 1;
            this.lbFileName.Text = "File Name";
            this.lbFileName.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(87, 282);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employee ID:";
            // 
            // empID
            // 
            this.empID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empID.Location = new System.Drawing.Point(125, 23);
            this.empID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empID.Multiline = true;
            this.empID.Name = "empID";
            this.empID.ReadOnly = true;
            this.empID.Size = new System.Drawing.Size(133, 24);
            this.empID.TabIndex = 8;
            // 
            // empNumber
            // 
            this.empNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empNumber.Location = new System.Drawing.Point(95, 161);
            this.empNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empNumber.Multiline = true;
            this.empNumber.Name = "empNumber";
            this.empNumber.Size = new System.Drawing.Size(133, 24);
            this.empNumber.TabIndex = 10;
            this.empNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empNumber_KeyDown);
            this.empNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mobile:";
            // 
            // empSSN
            // 
            this.empSSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empSSN.Location = new System.Drawing.Point(125, 55);
            this.empSSN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empSSN.Multiline = true;
            this.empSSN.Name = "empSSN";
            this.empSSN.Size = new System.Drawing.Size(133, 24);
            this.empSSN.TabIndex = 12;
            this.empSSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empSSN_KeyDown);
            this.empSSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empSSN_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "SSN:";
            // 
            // empEmail
            // 
            this.empEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empEmail.Location = new System.Drawing.Point(95, 193);
            this.empEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empEmail.Multiline = true;
            this.empEmail.Name = "empEmail";
            this.empEmail.Size = new System.Drawing.Size(133, 24);
            this.empEmail.TabIndex = 14;
            this.empEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empEmail_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email:";
            // 
            // empName
            // 
            this.empName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empName.Location = new System.Drawing.Point(95, 31);
            this.empName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empName.Multiline = true;
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(133, 24);
            this.empName.TabIndex = 16;
            this.empName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empName_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 63);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "DoB:";
            // 
            // empDob
            // 
            this.empDob.CustomFormat = "dd/MM/yyyy";
            this.empDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.empDob.Location = new System.Drawing.Point(95, 63);
            this.empDob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empDob.Name = "empDob";
            this.empDob.Size = new System.Drawing.Size(180, 22);
            this.empDob.TabIndex = 18;
            this.empDob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empDob_KeyDown);
            // 
            // empAdd
            // 
            this.empAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empAdd.Location = new System.Drawing.Point(95, 97);
            this.empAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empAdd.Multiline = true;
            this.empAdd.Name = "empAdd";
            this.empAdd.Size = new System.Drawing.Size(181, 56);
            this.empAdd.TabIndex = 20;
            this.empAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empAdd_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Address:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(203, 282);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(804, 268);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(913, 268);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Location = new System.Drawing.Point(1021, 268);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(100, 28);
            this.btnDeactivate.TabIndex = 26;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmp,
            this.dgPosition,
            this.dgBasicRate,
            this.dgName,
            this.dgSSN,
            this.dgDoB,
            this.dgMobile,
            this.dgEmail,
            this.dgAdd,
            this.dgFileName,
            this.dgImageData,
            this.IsDeleted});
            this.dataGridView1.Location = new System.Drawing.Point(51, 346);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1107, 377);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dgEmp
            // 
            this.dgEmp.HeaderText = "Emp ID";
            this.dgEmp.Name = "dgEmp";
            this.dgEmp.ReadOnly = true;
            // 
            // dgPosition
            // 
            this.dgPosition.HeaderText = "Position";
            this.dgPosition.Name = "dgPosition";
            this.dgPosition.ReadOnly = true;
            // 
            // dgBasicRate
            // 
            this.dgBasicRate.HeaderText = "Basic Rate";
            this.dgBasicRate.Name = "dgBasicRate";
            this.dgBasicRate.ReadOnly = true;
            // 
            // dgName
            // 
            this.dgName.HeaderText = "Name";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            // 
            // dgSSN
            // 
            this.dgSSN.HeaderText = "SSN";
            this.dgSSN.Name = "dgSSN";
            this.dgSSN.ReadOnly = true;
            // 
            // dgDoB
            // 
            this.dgDoB.HeaderText = "DoB";
            this.dgDoB.Name = "dgDoB";
            this.dgDoB.ReadOnly = true;
            // 
            // dgMobile
            // 
            this.dgMobile.HeaderText = "Mobile";
            this.dgMobile.Name = "dgMobile";
            this.dgMobile.ReadOnly = true;
            // 
            // dgEmail
            // 
            this.dgEmail.HeaderText = "Email";
            this.dgEmail.Name = "dgEmail";
            this.dgEmail.ReadOnly = true;
            // 
            // dgAdd
            // 
            this.dgAdd.HeaderText = "Address";
            this.dgAdd.Name = "dgAdd";
            this.dgAdd.ReadOnly = true;
            // 
            // dgFileName
            // 
            this.dgFileName.HeaderText = "FileName";
            this.dgFileName.Name = "dgFileName";
            this.dgFileName.ReadOnly = true;
            this.dgFileName.Visible = false;
            // 
            // dgImageData
            // 
            this.dgImageData.HeaderText = "ImageData";
            this.dgImageData.Name = "dgImageData";
            this.dgImageData.ReadOnly = true;
            this.dgImageData.Visible = false;
            // 
            // IsDeleted
            // 
            this.IsDeleted.HeaderText = "dgIsDeleted";
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.ReadOnly = true;
            this.IsDeleted.Visible = false;
            // 
            // employeePic
            // 
            this.employeePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.employeePic.Location = new System.Drawing.Point(83, 52);
            this.employeePic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.employeePic.Name = "employeePic";
            this.employeePic.Size = new System.Drawing.Size(219, 182);
            this.employeePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeePic.TabIndex = 0;
            this.employeePic.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.empAdd);
            this.groupBox1.Controls.Add(this.empNumber);
            this.groupBox1.Controls.Add(this.empEmail);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.empDob);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.empName);
            this.groupBox1.Location = new System.Drawing.Point(391, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(309, 247);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 91);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "Position:";
            // 
            // empPosition
            // 
            this.empPosition.FormattingEnabled = true;
            this.empPosition.Items.AddRange(new object[] {
            "Sales Manager",
            "Purchasing supervisor",
            "Accounting regular",
            "Logistics probationary",
            "Marketing part time"});
            this.empPosition.Location = new System.Drawing.Point(125, 87);
            this.empPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empPosition.Name = "empPosition";
            this.empPosition.Size = new System.Drawing.Size(160, 24);
            this.empPosition.TabIndex = 18;
            this.empPosition.SelectedIndexChanged += new System.EventHandler(this.empPosition_SelectedIndexChanged);
            this.empPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empPosition_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.empID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.empBasicRate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.empSSN);
            this.groupBox3.Controls.Add(this.empPosition);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(788, 49);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(343, 169);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Employee Details";
            // 
            // empBasicRate
            // 
            this.empBasicRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empBasicRate.Location = new System.Drawing.Point(125, 121);
            this.empBasicRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.empBasicRate.Multiline = true;
            this.empBasicRate.Name = "empBasicRate";
            this.empBasicRate.Size = new System.Drawing.Size(133, 24);
            this.empBasicRate.TabIndex = 31;
            this.empBasicRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empBasicRate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Basic Rate:";
            // 
            // employeeRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 740);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.employeePic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "employeeRegister";
            this.Text = "employeeRegister";
            this.Load += new System.EventHandler(this.employeeRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox employeePic;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox empID;
        private System.Windows.Forms.TextBox empNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empSSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox empEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox empName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker empDob;
        private System.Windows.Forms.TextBox empAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox empPosition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox empBasicRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasicRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgImageData;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeleted;
    }
}