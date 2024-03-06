namespace payrollsystemsti
{
    partial class dashBoard
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
            this.lb_DashBoard = new System.Windows.Forms.Label();
            this.pnl_Employee = new System.Windows.Forms.Panel();
            this.lb_EmployeeNum = new System.Windows.Forms.Label();
            this.lb_Employee = new System.Windows.Forms.Label();
            this.pnl_Department = new System.Windows.Forms.Panel();
            this.lb_Department = new System.Windows.Forms.Label();
            this.pnl_Leave = new System.Windows.Forms.Panel();
            this.lb_Leave = new System.Windows.Forms.Label();
            this.pbCurrentUser = new System.Windows.Forms.PictureBox();
            this.pnl_Employee.SuspendLayout();
            this.pnl_Department.SuspendLayout();
            this.pnl_Leave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_DashBoard
            // 
            this.lb_DashBoard.AutoSize = true;
            this.lb_DashBoard.BackColor = System.Drawing.Color.Transparent;
            this.lb_DashBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DashBoard.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_DashBoard.Location = new System.Drawing.Point(3, 9);
            this.lb_DashBoard.Name = "lb_DashBoard";
            this.lb_DashBoard.Size = new System.Drawing.Size(254, 51);
            this.lb_DashBoard.TabIndex = 0;
            this.lb_DashBoard.Text = "Jezhan Inc.";
            // 
            // pnl_Employee
            // 
            this.pnl_Employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnl_Employee.Controls.Add(this.lb_EmployeeNum);
            this.pnl_Employee.Controls.Add(this.lb_Employee);
            this.pnl_Employee.Location = new System.Drawing.Point(12, 82);
            this.pnl_Employee.Name = "pnl_Employee";
            this.pnl_Employee.Size = new System.Drawing.Size(274, 135);
            this.pnl_Employee.TabIndex = 1;
            // 
            // lb_EmployeeNum
            // 
            this.lb_EmployeeNum.AutoSize = true;
            this.lb_EmployeeNum.BackColor = System.Drawing.Color.Transparent;
            this.lb_EmployeeNum.Location = new System.Drawing.Point(14, 74);
            this.lb_EmployeeNum.Name = "lb_EmployeeNum";
            this.lb_EmployeeNum.Size = new System.Drawing.Size(113, 13);
            this.lb_EmployeeNum.TabIndex = 1;
            this.lb_EmployeeNum.Text = "Number of Employees:";
            // 
            // lb_Employee
            // 
            this.lb_Employee.AutoSize = true;
            this.lb_Employee.BackColor = System.Drawing.Color.Transparent;
            this.lb_Employee.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Employee.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Employee.Location = new System.Drawing.Point(59, 9);
            this.lb_Employee.Name = "lb_Employee";
            this.lb_Employee.Size = new System.Drawing.Size(141, 32);
            this.lb_Employee.TabIndex = 0;
            this.lb_Employee.Text = "Employee";
            // 
            // pnl_Department
            // 
            this.pnl_Department.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnl_Department.Controls.Add(this.lb_Department);
            this.pnl_Department.Location = new System.Drawing.Point(336, 82);
            this.pnl_Department.Name = "pnl_Department";
            this.pnl_Department.Size = new System.Drawing.Size(274, 135);
            this.pnl_Department.TabIndex = 2;
            // 
            // lb_Department
            // 
            this.lb_Department.AutoSize = true;
            this.lb_Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Department.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Department.Location = new System.Drawing.Point(59, 9);
            this.lb_Department.Name = "lb_Department";
            this.lb_Department.Size = new System.Drawing.Size(162, 32);
            this.lb_Department.TabIndex = 0;
            this.lb_Department.Text = "Department";
            // 
            // pnl_Leave
            // 
            this.pnl_Leave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnl_Leave.Controls.Add(this.lb_Leave);
            this.pnl_Leave.Location = new System.Drawing.Point(12, 242);
            this.pnl_Leave.Name = "pnl_Leave";
            this.pnl_Leave.Size = new System.Drawing.Size(274, 135);
            this.pnl_Leave.TabIndex = 2;
            // 
            // lb_Leave
            // 
            this.lb_Leave.AutoSize = true;
            this.lb_Leave.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Leave.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Leave.Location = new System.Drawing.Point(82, 9);
            this.lb_Leave.Name = "lb_Leave";
            this.lb_Leave.Size = new System.Drawing.Size(92, 32);
            this.lb_Leave.TabIndex = 0;
            this.lb_Leave.Text = "Leave";
            // 
            // pbCurrentUser
            // 
            this.pbCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCurrentUser.Location = new System.Drawing.Point(728, 12);
            this.pbCurrentUser.Name = "pbCurrentUser";
            this.pbCurrentUser.Size = new System.Drawing.Size(171, 157);
            this.pbCurrentUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentUser.TabIndex = 3;
            this.pbCurrentUser.TabStop = false;
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.pbCurrentUser);
            this.Controls.Add(this.pnl_Leave);
            this.Controls.Add(this.pnl_Department);
            this.Controls.Add(this.pnl_Employee);
            this.Controls.Add(this.lb_DashBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dashBoard";
            this.Load += new System.EventHandler(this.dashBoard_Load);
            this.pnl_Employee.ResumeLayout(false);
            this.pnl_Employee.PerformLayout();
            this.pnl_Department.ResumeLayout(false);
            this.pnl_Department.PerformLayout();
            this.pnl_Leave.ResumeLayout(false);
            this.pnl_Leave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label lb_DashBoard;
		private System.Windows.Forms.Panel pnl_Employee;
		private System.Windows.Forms.Label lb_Employee;
		private System.Windows.Forms.Panel pnl_Department;
		private System.Windows.Forms.Label lb_Department;
		private System.Windows.Forms.Panel pnl_Leave;
		private System.Windows.Forms.Label lb_Leave;
        private System.Windows.Forms.PictureBox pbCurrentUser;
		private System.Windows.Forms.Label lb_EmployeeNum;
	}
}