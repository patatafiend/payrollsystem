﻿namespace payrollsystemsti
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
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lb_DashBoard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 654);
            this.panel2.TabIndex = 6;
            // 
            // lb_DashBoard
            // 
            this.lb_DashBoard.AutoSize = true;
            this.lb_DashBoard.BackColor = System.Drawing.Color.Transparent;
            this.lb_DashBoard.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DashBoard.ForeColor = System.Drawing.Color.Crimson;
            this.lb_DashBoard.Location = new System.Drawing.Point(28, 25);
            this.lb_DashBoard.Name = "lb_DashBoard";
            this.lb_DashBoard.Size = new System.Drawing.Size(182, 32);
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
            this.dgStatus});
            this.dgv_EmployeeList.Location = new System.Drawing.Point(18, 32);
            this.dgv_EmployeeList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_EmployeeList.Name = "dgv_EmployeeList";
            this.dgv_EmployeeList.ReadOnly = true;
            this.dgv_EmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeList.Size = new System.Drawing.Size(875, 451);
            this.dgv_EmployeeList.TabIndex = 7;
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
            // dgStatus
            // 
            this.dgStatus.DataPropertyName = "Position";
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(868, 598);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 44);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Back";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_EmployeeList);
            this.groupBox1.Location = new System.Drawing.Point(74, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 512);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details:";
            // 
            // employeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1047, 654);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Name = "employeeList";
            this.Load += new System.EventHandler(this.employeeList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lb_DashBoard;
		private System.Windows.Forms.DataGridView dgv_EmployeeList;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgLastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}