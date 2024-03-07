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
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLoadEmpAcc = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserID:";
            // 
            // tbUserID
            // 
            this.tbUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserID.Location = new System.Drawing.Point(127, 105);
            this.tbUserID.Multiline = true;
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.ReadOnly = true;
            this.tbUserID.Size = new System.Drawing.Size(218, 31);
            this.tbUserID.TabIndex = 1;
            // 
            // tbUserName
            // 
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserName.Location = new System.Drawing.Point(127, 153);
            this.tbUserName.Multiline = true;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(218, 31);
            this.tbUserName.TabIndex = 3;
            this.tbUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "UserName :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 248);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Role :";
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Admin",
            "Human Resource",
            "Accountant",
            "Employee"});
            this.cbRole.Location = new System.Drawing.Point(127, 248);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(218, 21);
            this.cbRole.TabIndex = 11;
            this.cbRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbRole_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgUsername,
            this.dgDepartment,
            this.dgPosition,
            this.dgRole,
            this.dgUserID});
            this.dataGridView1.Location = new System.Drawing.Point(440, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(543, 502);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "EmpIoyee ID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
            // 
            // dgUsername
            // 
            this.dgUsername.HeaderText = "UserName";
            this.dgUsername.Name = "dgUsername";
            this.dgUsername.ReadOnly = true;
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
            // dgRole
            // 
            this.dgRole.HeaderText = "Role";
            this.dgRole.Name = "dgRole";
            this.dgRole.ReadOnly = true;
            // 
            // dgUserID
            // 
            this.dgUserID.HeaderText = "UserID";
            this.dgUserID.Name = "dgUserID";
            this.dgUserID.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(44, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 44);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(168, 307);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 44);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.EnabledChanged += new System.EventHandler(this.btnUpdate_EnabledChanged);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.Color.Crimson;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeactivate.Location = new System.Drawing.Point(168, 357);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(118, 44);
            this.btnDeactivate.TabIndex = 17;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password :";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(127, 200);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(218, 31);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Teal;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(292, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 44);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Teal;
            this.btnLoad.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoad.Location = new System.Drawing.Point(440, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(132, 56);
            this.btnLoad.TabIndex = 19;
            this.btnLoad.Text = "Load User Accounts";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLoadEmpAcc
            // 
            this.btnLoadEmpAcc.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnLoadEmpAcc.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadEmpAcc.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoadEmpAcc.Location = new System.Drawing.Point(578, 25);
            this.btnLoadEmpAcc.Name = "btnLoadEmpAcc";
            this.btnLoadEmpAcc.Size = new System.Drawing.Size(132, 56);
            this.btnLoadEmpAcc.TabIndex = 20;
            this.btnLoadEmpAcc.Text = "Load Employee Accounts";
            this.btnLoadEmpAcc.UseVisualStyleBackColor = false;
            this.btnLoadEmpAcc.Click += new System.EventHandler(this.btnLoadEmpAcc_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(19, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(255, 32);
            this.label11.TabIndex = 33;
            this.label11.Text = "Employee Register";
            // 
            // userRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1018, 624);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnLoadEmpAcc);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUserID);
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
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUserID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoadEmpAcc;
        private System.Windows.Forms.Label label11;
    }
}