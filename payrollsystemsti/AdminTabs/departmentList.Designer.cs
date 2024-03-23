namespace payrollsystemsti.AdminTabs
{
	partial class departmentList
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
			this.btnExit = new System.Windows.Forms.Button();
			this.dgv_DepartmentList = new System.Windows.Forms.DataGridView();
			this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lb_DepartmentList = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_DepartmentList)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Crimson;
			this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
			this.btnExit.Location = new System.Drawing.Point(819, 163);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(118, 44);
			this.btnExit.TabIndex = 31;
			this.btnExit.Text = "Back";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btn_back);
			// 
			// dgv_DepartmentList
			// 
			this.dgv_DepartmentList.AllowUserToAddRows = false;
			this.dgv_DepartmentList.AllowUserToDeleteRows = false;
			this.dgv_DepartmentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_DepartmentList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dgv_DepartmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_DepartmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgDepartment});
			this.dgv_DepartmentList.Location = new System.Drawing.Point(104, 214);
			this.dgv_DepartmentList.Margin = new System.Windows.Forms.Padding(4);
			this.dgv_DepartmentList.Name = "dgv_DepartmentList";
			this.dgv_DepartmentList.ReadOnly = true;
			this.dgv_DepartmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_DepartmentList.Size = new System.Drawing.Size(833, 408);
			this.dgv_DepartmentList.TabIndex = 30;
			// 
			// dgEmpID
			// 
			this.dgEmpID.DataPropertyName = "EmployeeID";
			this.dgEmpID.HeaderText = "Employee ID";
			this.dgEmpID.Name = "dgEmpID";
			this.dgEmpID.ReadOnly = true;
			// 
			// dgDepartment
			// 
			this.dgDepartment.DataPropertyName = "Department";
			this.dgDepartment.HeaderText = "Department";
			this.dgDepartment.Name = "dgDepartment";
			this.dgDepartment.ReadOnly = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
			this.panel2.Controls.Add(this.lb_DepartmentList);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1047, 45);
			this.panel2.TabIndex = 29;
			// 
			// lb_DepartmentList
			// 
			this.lb_DepartmentList.AutoSize = true;
			this.lb_DepartmentList.BackColor = System.Drawing.Color.Transparent;
			this.lb_DepartmentList.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb_DepartmentList.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lb_DepartmentList.Location = new System.Drawing.Point(3, 11);
			this.lb_DepartmentList.Name = "lb_DepartmentList";
			this.lb_DepartmentList.Size = new System.Drawing.Size(147, 23);
			this.lb_DepartmentList.TabIndex = 0;
			this.lb_DepartmentList.Text = "DepartmentList";
			// 
			// departmentList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(1047, 654);
			this.ControlBox = false;
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.dgv_DepartmentList);
			this.Controls.Add(this.panel2);
			this.Name = "departmentList";
			this.Load += new System.EventHandler(this.departmentList_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.dgv_DepartmentList)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGridView dgv_DepartmentList;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lb_DepartmentList;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgDepartment;
	}
}