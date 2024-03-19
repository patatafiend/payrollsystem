namespace payrollsystemsti
{
    partial class employeeList
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lb_DashBoard = new System.Windows.Forms.Label();
			this.dgv_EmployeeList = new System.Windows.Forms.DataGridView();
			this.btnExit = new System.Windows.Forms.Button();
			this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeList)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
			this.panel2.Controls.Add(this.lb_DashBoard);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1047, 45);
			this.panel2.TabIndex = 6;
			// 
			// lb_DashBoard
			// 
			this.lb_DashBoard.AutoSize = true;
			this.lb_DashBoard.BackColor = System.Drawing.Color.Transparent;
			this.lb_DashBoard.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb_DashBoard.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lb_DashBoard.Location = new System.Drawing.Point(3, 11);
			this.lb_DashBoard.Name = "lb_DashBoard";
			this.lb_DashBoard.Size = new System.Drawing.Size(130, 23);
			this.lb_DashBoard.TabIndex = 0;
			this.lb_DashBoard.Text = "EmployeeList";
			// 
			// dgv_EmployeeList
			// 
			this.dgv_EmployeeList.AllowUserToAddRows = false;
			this.dgv_EmployeeList.AllowUserToDeleteRows = false;
			this.dgv_EmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_EmployeeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dgv_EmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_EmployeeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgLastName,
            this.dgDepartment,
            this.dgStatus});
			this.dgv_EmployeeList.Location = new System.Drawing.Point(104, 214);
			this.dgv_EmployeeList.Margin = new System.Windows.Forms.Padding(4);
			this.dgv_EmployeeList.Name = "dgv_EmployeeList";
			this.dgv_EmployeeList.ReadOnly = true;
			this.dgv_EmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_EmployeeList.Size = new System.Drawing.Size(833, 408);
			this.dgv_EmployeeList.TabIndex = 7;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Crimson;
			this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
			this.btnExit.Location = new System.Drawing.Point(819, 163);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(118, 44);
			this.btnExit.TabIndex = 28;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// dgEmpID
			// 
			this.dgEmpID.DataPropertyName = "EmployeeID";
			this.dgEmpID.HeaderText = "Employee ID";
			this.dgEmpID.Name = "dgEmpID";
			this.dgEmpID.ReadOnly = true;
			// 
			// dgLastName
			// 
			this.dgLastName.DataPropertyName = "LastName";
			this.dgLastName.HeaderText = "Last Name";
			this.dgLastName.Name = "dgLastName";
			this.dgLastName.ReadOnly = true;
			// 
			// dgDepartment
			// 
			this.dgDepartment.DataPropertyName = "Department";
			this.dgDepartment.HeaderText = "Department";
			this.dgDepartment.Name = "dgDepartment";
			this.dgDepartment.ReadOnly = true;
			// 
			// dgStatus
			// 
			this.dgStatus.DataPropertyName = "Position";
			this.dgStatus.HeaderText = "Status";
			this.dgStatus.Name = "dgStatus";
			this.dgStatus.ReadOnly = true;
			// 
			// employeeList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(1047, 654);
			this.ControlBox = false;
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.dgv_EmployeeList);
			this.Controls.Add(this.panel2);
			this.Name = "employeeList";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeList)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lb_DashBoard;
		private System.Windows.Forms.DataGridView dgv_EmployeeList;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgLastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgDepartment;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
	}
}