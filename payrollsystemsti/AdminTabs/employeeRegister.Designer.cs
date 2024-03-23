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
			this.tbMob = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbSSN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbFirstName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dtDob = new System.Windows.Forms.DateTimePicker();
			this.tbAddress = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDeactivate = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dgEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgBasicRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgDoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgSSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgImageData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pbEmployee = new System.Windows.Forms.PictureBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cbPosition = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbDepart = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbBasicRate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbFileName
			// 
			this.lbFileName.AutoSize = true;
			this.lbFileName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFileName.Location = new System.Drawing.Point(53, 257);
			this.lbFileName.Name = "lbFileName";
			this.lbFileName.Size = new System.Drawing.Size(92, 19);
			this.lbFileName.TabIndex = 1;
			this.lbFileName.Text = "File Name:";
			this.lbFileName.Visible = false;
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.Teal;
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.ForeColor = System.Drawing.SystemColors.Control;
			this.btnAdd.Location = new System.Drawing.Point(54, 292);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(118, 44);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "Employee ID:";
			// 
			// empID
			// 
			this.empID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.empID.Location = new System.Drawing.Point(137, 29);
			this.empID.Multiline = true;
			this.empID.Name = "empID";
			this.empID.ReadOnly = true;
			this.empID.Size = new System.Drawing.Size(172, 28);
			this.empID.TabIndex = 8;
			// 
			// tbMob
			// 
			this.tbMob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbMob.Location = new System.Drawing.Point(129, 188);
			this.tbMob.Multiline = true;
			this.tbMob.Name = "tbMob";
			this.tbMob.Size = new System.Drawing.Size(172, 28);
			this.tbMob.TabIndex = 10;
			this.tbMob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumber_KeyDown);
			this.tbMob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empNumber_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "Mobile:";
			// 
			// tbSSN
			// 
			this.tbSSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSSN.Location = new System.Drawing.Point(137, 187);
			this.tbSSN.Multiline = true;
			this.tbSSN.Name = "tbSSN";
			this.tbSSN.Size = new System.Drawing.Size(172, 28);
			this.tbSSN.TabIndex = 12;
			this.tbSSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSSN_KeyDown);
			this.tbSSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empSSN_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 19);
			this.label4.TabIndex = 11;
			this.label4.Text = "SSN:";
			// 
			// tbEmail
			// 
			this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEmail.Location = new System.Drawing.Point(129, 226);
			this.tbEmail.Multiline = true;
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(172, 28);
			this.tbEmail.TabIndex = 14;
			this.tbEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmail_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(30, 226);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 19);
			this.label5.TabIndex = 13;
			this.label5.Text = "Email:";
			// 
			// tbFirstName
			// 
			this.tbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbFirstName.Location = new System.Drawing.Point(129, 26);
			this.tbFirstName.Multiline = true;
			this.tbFirstName.Name = "tbFirstName";
			this.tbFirstName.Size = new System.Drawing.Size(172, 28);
			this.tbFirstName.TabIndex = 16;
			this.tbFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFirstName_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(30, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(93, 19);
			this.label6.TabIndex = 15;
			this.label6.Text = "First Name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(30, 98);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 19);
			this.label7.TabIndex = 17;
			this.label7.Text = "DoB:";
			// 
			// dtDob
			// 
			this.dtDob.CustomFormat = "dd/MM/yyyy";
			this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtDob.Location = new System.Drawing.Point(129, 98);
			this.dtDob.Name = "dtDob";
			this.dtDob.Size = new System.Drawing.Size(172, 27);
			this.dtDob.TabIndex = 18;
			this.dtDob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDob_KeyDown);
			// 
			// tbAddress
			// 
			this.tbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbAddress.Location = new System.Drawing.Point(129, 136);
			this.tbAddress.Multiline = true;
			this.tbAddress.Name = "tbAddress";
			this.tbAddress.Size = new System.Drawing.Size(172, 46);
			this.tbAddress.TabIndex = 20;
			this.tbAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAdd_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(30, 136);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(74, 19);
			this.label8.TabIndex = 19;
			this.label8.Text = "Address:";
			// 
			// btnRemove
			// 
			this.btnRemove.BackColor = System.Drawing.Color.Crimson;
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRemove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRemove.ForeColor = System.Drawing.SystemColors.Control;
			this.btnRemove.Location = new System.Drawing.Point(178, 292);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(118, 44);
			this.btnRemove.TabIndex = 23;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.BackColor = System.Drawing.Color.Teal;
			this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
			this.btnSave.Location = new System.Drawing.Point(616, 363);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(118, 44);
			this.btnSave.TabIndex = 24;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
			this.btnUpdate.Location = new System.Drawing.Point(739, 363);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(118, 44);
			this.btnUpdate.TabIndex = 25;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.EnabledChanged += new System.EventHandler(this.btnUpdate_EnabledChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDeactivate
			// 
			this.btnDeactivate.BackColor = System.Drawing.Color.Crimson;
			this.btnDeactivate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeactivate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeactivate.ForeColor = System.Drawing.SystemColors.Control;
			this.btnDeactivate.Location = new System.Drawing.Point(54, 363);
			this.btnDeactivate.Name = "btnDeactivate";
			this.btnDeactivate.Size = new System.Drawing.Size(118, 44);
			this.btnDeactivate.TabIndex = 26;
			this.btnDeactivate.Text = "Deactivate";
			this.btnDeactivate.UseVisualStyleBackColor = false;
			this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmp,
            this.dgLastName,
            this.dgFirstName,
            this.dgDepartment,
            this.dgPosition,
            this.dgBasicRate,
            this.dgDoB,
            this.dgMobile,
            this.dgEmail,
            this.dgAdd,
            this.dgSSN,
            this.dgFileName,
            this.dgImageData,
            this.dgIsDeleted});
			this.dataGridView1.Location = new System.Drawing.Point(54, 429);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(927, 219);
			this.dataGridView1.TabIndex = 27;
			this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			// 
			// dgEmp
			// 
			this.dgEmp.HeaderText = "Emp ID";
			this.dgEmp.Name = "dgEmp";
			this.dgEmp.ReadOnly = true;
			// 
			// dgLastName
			// 
			this.dgLastName.HeaderText = "LastName";
			this.dgLastName.Name = "dgLastName";
			this.dgLastName.ReadOnly = true;
			// 
			// dgFirstName
			// 
			this.dgFirstName.HeaderText = "FirstName";
			this.dgFirstName.Name = "dgFirstName";
			this.dgFirstName.ReadOnly = true;
			// 
			// dgDepartment
			// 
			this.dgDepartment.HeaderText = "Department";
			this.dgDepartment.Name = "dgDepartment";
			this.dgDepartment.ReadOnly = true;
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
			// dgSSN
			// 
			this.dgSSN.HeaderText = "SSN";
			this.dgSSN.Name = "dgSSN";
			this.dgSSN.ReadOnly = true;
			this.dgSSN.Visible = false;
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
			// dgIsDeleted
			// 
			this.dgIsDeleted.HeaderText = "IsDeleted";
			this.dgIsDeleted.Name = "dgIsDeleted";
			this.dgIsDeleted.ReadOnly = true;
			this.dgIsDeleted.Visible = false;
			// 
			// pbEmployee
			// 
			this.pbEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbEmployee.Location = new System.Drawing.Point(57, 90);
			this.pbEmployee.Name = "pbEmployee";
			this.pbEmployee.Size = new System.Drawing.Size(177, 160);
			this.pbEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbEmployee.TabIndex = 0;
			this.pbEmployee.TabStop = false;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tbLastName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbAddress);
			this.groupBox1.Controls.Add(this.tbMob);
			this.groupBox1.Controls.Add(this.tbEmail);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.dtDob);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tbFirstName);
			this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(321, 77);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(319, 269);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Personal Information";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(30, 60);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(94, 19);
			this.label10.TabIndex = 21;
			this.label10.Text = "Last Name:";
			// 
			// tbLastName
			// 
			this.tbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbLastName.Location = new System.Drawing.Point(129, 60);
			this.tbLastName.Multiline = true;
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(172, 28);
			this.tbLastName.TabIndex = 22;
			this.tbLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLastName_KeyDown);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(21, 110);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(70, 19);
			this.label13.TabIndex = 15;
			this.label13.Text = "Position:";
			// 
			// cbPosition
			// 
			this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPosition.FormattingEnabled = true;
			this.cbPosition.Items.AddRange(new object[] {
            "Sales Manager",
            "Purchasing supervisor",
            "Accounting regular",
            "Logistics probationary",
            "Marketing part time"});
			this.cbPosition.Location = new System.Drawing.Point(137, 110);
			this.cbPosition.Name = "cbPosition";
			this.cbPosition.Size = new System.Drawing.Size(172, 27);
			this.cbPosition.TabIndex = 18;
			this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.empPosition_SelectedIndexChanged);
			this.cbPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPosition_KeyDown);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.tbDepart);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.empID);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.tbBasicRate);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.tbSSN);
			this.groupBox3.Controls.Add(this.cbPosition);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(662, 77);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(319, 269);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Employee Details";
			// 
			// tbDepart
			// 
			this.tbDepart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDepart.Location = new System.Drawing.Point(137, 67);
			this.tbDepart.Multiline = true;
			this.tbDepart.Name = "tbDepart";
			this.tbDepart.Size = new System.Drawing.Size(172, 28);
			this.tbDepart.TabIndex = 33;
			this.tbDepart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDepart_KeyDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(21, 67);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(105, 19);
			this.label9.TabIndex = 32;
			this.label9.Text = "Department:";
			// 
			// tbBasicRate
			// 
			this.tbBasicRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbBasicRate.Location = new System.Drawing.Point(137, 149);
			this.tbBasicRate.Multiline = true;
			this.tbBasicRate.Name = "tbBasicRate";
			this.tbBasicRate.Size = new System.Drawing.Size(172, 28);
			this.tbBasicRate.TabIndex = 31;
			this.tbBasicRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBasicRate_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 149);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 19);
			this.label1.TabIndex = 19;
			this.label1.Text = "Basic Rate:";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Teal;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
			this.btnCancel.Location = new System.Drawing.Point(863, 363);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(118, 44);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Crimson;
			this.label11.Location = new System.Drawing.Point(59, 22);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(255, 32);
			this.label11.TabIndex = 32;
			this.label11.Text = "Employee Register";
			// 
			// employeeRegister
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(1018, 660);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnDeactivate);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbFileName);
			this.Controls.Add(this.pbEmployee);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "employeeRegister";
			this.Text = "employeeRegister";
			this.Load += new System.EventHandler(this.employeeRegister_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEmployee;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox empID;
        private System.Windows.Forms.TextBox tbMob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBasicRate;
        private System.Windows.Forms.TextBox tbDepart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasicRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgImageData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIsDeleted;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
    }
}