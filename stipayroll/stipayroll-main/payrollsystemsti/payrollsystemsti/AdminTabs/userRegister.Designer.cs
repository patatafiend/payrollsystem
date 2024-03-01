namespace payrollsystemsti.Tabs
{
    partial class userRegister
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tpBirthDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.cbRole = new System.Windows.Forms.ComboBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dgSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgDob = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(93, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name :";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(152, 68);
			this.txtName.Multiline = true;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(150, 23);
			this.txtName.TabIndex = 1;
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
			// 
			// txtUserName
			// 
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUserName.Location = new System.Drawing.Point(152, 97);
			this.txtUserName.Multiline = true;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(150, 23);
			this.txtUserName.TabIndex = 3;
			//this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(59, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "UserName :";
			// 
			// txtEmail
			// 
			this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmail.Location = new System.Drawing.Point(152, 155);
			this.txtEmail.Multiline = true;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(150, 23);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(96, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Email :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(336, 68);
			this.label5.Name = "label5";
			this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label5.Size = new System.Drawing.Size(49, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "DoB :";
			// 
			// tpBirthDate
			// 
			this.tpBirthDate.CustomFormat = "dd/MM/yyyy";
			this.tpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tpBirthDate.Location = new System.Drawing.Point(385, 68);
			this.tpBirthDate.Name = "tpBirthDate";
			this.tpBirthDate.Size = new System.Drawing.Size(150, 20);
			this.tpBirthDate.TabIndex = 9;
			this.tpBirthDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tpBirthDate_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(336, 96);
			this.label6.Name = "label6";
			this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label6.Size = new System.Drawing.Size(50, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Role :";
			// 
			// cbRole
			// 
			this.cbRole.FormattingEnabled = true;
			this.cbRole.Items.AddRange(new object[] {
            "Admin",
            "Human Resource",
            "Accountant",
            "Employee"});
			this.cbRole.Location = new System.Drawing.Point(385, 95);
			this.cbRole.Name = "cbRole";
			this.cbRole.Size = new System.Drawing.Size(150, 21);
			this.cbRole.TabIndex = 11;
			this.cbRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbRole_KeyDown);
			// 
			// txtAddress
			// 
			this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAddress.Location = new System.Drawing.Point(385, 131);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(312, 77);
			this.txtAddress.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(310, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 20);
			this.label7.TabIndex = 12;
			this.label7.Text = "Address :";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSno,
            this.dgName,
            this.dgDob,
            this.dgEmail,
            this.dgUsername,
            this.dgRole,
            this.dgAddress});
			this.dataGridView1.Location = new System.Drawing.Point(12, 385);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(742, 215);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			// 
			// dgSno
			// 
			this.dgSno.HeaderText = "S.No";
			this.dgSno.Name = "dgSno";
			this.dgSno.ReadOnly = true;
			// 
			// dgName
			// 
			this.dgName.HeaderText = "Name";
			this.dgName.Name = "dgName";
			this.dgName.ReadOnly = true;
			// 
			// dgDob
			// 
			this.dgDob.HeaderText = "DoB";
			this.dgDob.Name = "dgDob";
			this.dgDob.ReadOnly = true;
			// 
			// dgEmail
			// 
			this.dgEmail.HeaderText = "Email";
			this.dgEmail.Name = "dgEmail";
			this.dgEmail.ReadOnly = true;
			// 
			// dgUsername
			// 
			this.dgUsername.HeaderText = "UserName";
			this.dgUsername.Name = "dgUsername";
			this.dgUsername.ReadOnly = true;
			// 
			// dgRole
			// 
			this.dgRole.HeaderText = "Role";
			this.dgRole.Name = "dgRole";
			this.dgRole.ReadOnly = true;
			// 
			// dgAddress
			// 
			this.dgAddress.HeaderText = "Address";
			this.dgAddress.Name = "dgAddress";
			this.dgAddress.ReadOnly = true;
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.btnSave.Location = new System.Drawing.Point(222, 332);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 35);
			this.btnSave.TabIndex = 15;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.btnUpdate.Location = new System.Drawing.Point(326, 332);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(90, 35);
			this.btnUpdate.TabIndex = 16;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.btnDelete.Location = new System.Drawing.Point(427, 332);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(90, 35);
			this.btnDelete.TabIndex = 17;
			this.btnDelete.Text = "Deactivate";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(66, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Password :";
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Enabled = false;
			this.txtPassword.Location = new System.Drawing.Point(152, 126);
			this.txtPassword.Multiline = true;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(150, 23);
			this.txtPassword.TabIndex = 5;
			this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
			// 
			// userRegister
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 612);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cbRole);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tpBirthDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "userRegister";
			this.Text = "userRegister";
			this.Load += new System.EventHandler(this.userRegister_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker tpBirthDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDob;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label3;
	}
}