namespace payrollsystemsti.Tabs
{
    partial class manageEmployee
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
			this.label6 = new System.Windows.Forms.Label();
			this.cbRole = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDeactivate = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnLoadEmpAcc = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(297, 188);
			this.label6.Name = "label6";
			this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label6.Size = new System.Drawing.Size(50, 19);
			this.label6.TabIndex = 10;
			this.label6.Text = "Role :";
			// 
			// cbRole
			// 
			this.cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRole.FormattingEnabled = true;
			this.cbRole.Items.AddRange(new object[] {
            "Admin",
            "Human Resource",
            "Accountant",
            "Employee"});
			this.cbRole.Location = new System.Drawing.Point(366, 188);
			this.cbRole.Name = "cbRole";
			this.cbRole.Size = new System.Drawing.Size(218, 21);
			this.cbRole.TabIndex = 11;
			this.cbRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbRole_KeyDown);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgFullName,
            this.dgDepartment,
            this.dgPosition,
            this.dgRole,
            this.dgUserID});
			this.dataGridView1.Location = new System.Drawing.Point(25, 284);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(958, 305);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			// 
			// dgEmpID
			// 
			this.dgEmpID.HeaderText = "EmpIoyee ID";
			this.dgEmpID.Name = "dgEmpID";
			this.dgEmpID.ReadOnly = true;
			// 
			// dgFullName
			// 
			this.dgFullName.HeaderText = "Name";
			this.dgFullName.Name = "dgFullName";
			this.dgFullName.ReadOnly = true;
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
			this.dgUserID.Visible = false;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
			this.btnUpdate.Location = new System.Drawing.Point(366, 220);
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
			this.btnDeactivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeactivate.BackColor = System.Drawing.Color.Crimson;
			this.btnDeactivate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeactivate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeactivate.ForeColor = System.Drawing.SystemColors.Control;
			this.btnDeactivate.Location = new System.Drawing.Point(865, 234);
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
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Teal;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
			this.btnCancel.Location = new System.Drawing.Point(490, 220);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(118, 44);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnLoadEmpAcc
			// 
			this.btnLoadEmpAcc.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnLoadEmpAcc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLoadEmpAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadEmpAcc.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoadEmpAcc.ForeColor = System.Drawing.SystemColors.Control;
			this.btnLoadEmpAcc.Location = new System.Drawing.Point(25, 216);
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
			this.label11.Location = new System.Drawing.Point(33, 39);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(263, 32);
			this.label11.TabIndex = 33;
			this.label11.Text = "Manage Employee";
			// 
			// manageEmployee
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(1018, 624);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btnLoadEmpAcc);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnDeactivate);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.cbRole);
			this.Controls.Add(this.label6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "manageEmployee";
			this.Text = "userRegister";
			this.Load += new System.EventHandler(this.manageEmployee_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoadEmpAcc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUserID;
    }
}