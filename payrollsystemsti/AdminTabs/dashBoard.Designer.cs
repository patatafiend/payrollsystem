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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCurrentUser = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEmployeeID = new System.Windows.Forms.Label();
            this.lb_User_Username = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_Employee.SuspendLayout();
            this.pnl_Department.SuspendLayout();
            this.pnl_Leave.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_DashBoard
            // 
            this.lb_DashBoard.AutoSize = true;
            this.lb_DashBoard.BackColor = System.Drawing.Color.Transparent;
            this.lb_DashBoard.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DashBoard.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_DashBoard.Location = new System.Drawing.Point(26, 30);
            this.lb_DashBoard.Name = "lb_DashBoard";
            this.lb_DashBoard.Size = new System.Drawing.Size(186, 38);
            this.lb_DashBoard.TabIndex = 0;
            this.lb_DashBoard.Text = "Dashboard";
            this.lb_DashBoard.Click += new System.EventHandler(this.lb_DashBoard_Click);
            // 
            // pnl_Employee
            // 
            this.pnl_Employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.pnl_Employee.Controls.Add(this.lb_EmployeeNum);
            this.pnl_Employee.Controls.Add(this.lb_Employee);
            this.pnl_Employee.Location = new System.Drawing.Point(35, 194);
            this.pnl_Employee.Name = "pnl_Employee";
            this.pnl_Employee.Size = new System.Drawing.Size(274, 135);
            this.pnl_Employee.TabIndex = 1;
            this.pnl_Employee.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Employee_Paint);
            // 
            // lb_EmployeeNum
            // 
            this.lb_EmployeeNum.AutoSize = true;
            this.lb_EmployeeNum.BackColor = System.Drawing.Color.Transparent;
            this.lb_EmployeeNum.Location = new System.Drawing.Point(13, 63);
            this.lb_EmployeeNum.Name = "lb_EmployeeNum";
            this.lb_EmployeeNum.Size = new System.Drawing.Size(113, 13);
            this.lb_EmployeeNum.TabIndex = 1;
            this.lb_EmployeeNum.Text = "Number of Employees:";
            this.lb_EmployeeNum.Click += new System.EventHandler(this.lb_EmployeeNum_Click);
            // 
            // lb_Employee
            // 
            this.lb_Employee.AutoSize = true;
            this.lb_Employee.BackColor = System.Drawing.Color.Transparent;
            this.lb_Employee.Font = new System.Drawing.Font("Century Gothic", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Employee.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Employee.Location = new System.Drawing.Point(59, 9);
            this.lb_Employee.Name = "lb_Employee";
            this.lb_Employee.Size = new System.Drawing.Size(151, 34);
            this.lb_Employee.TabIndex = 0;
            this.lb_Employee.Text = "Employee";
            // 
            // pnl_Department
            // 
            this.pnl_Department.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.pnl_Department.Controls.Add(this.lb_Department);
            this.pnl_Department.Location = new System.Drawing.Point(359, 194);
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
            this.pnl_Leave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.pnl_Leave.Controls.Add(this.lb_Leave);
            this.pnl_Leave.Location = new System.Drawing.Point(35, 354);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(35, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 68);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(22, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Have a nice day!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(20, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Welcome, Renz";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pbCurrentUser
            // 
            this.pbCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCurrentUser.Image = global::payrollsystemsti.Properties.Resources.renz;
            this.pbCurrentUser.Location = new System.Drawing.Point(75, 58);
            this.pbCurrentUser.Name = "pbCurrentUser";
            this.pbCurrentUser.Size = new System.Drawing.Size(152, 147);
            this.pbCurrentUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentUser.TabIndex = 3;
            this.pbCurrentUser.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lb_User_Username);
            this.panel1.Controls.Add(this.lbEmployeeID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pbCurrentUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(813, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 673);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "My Profile";
            // 
            // lbEmployeeID
            // 
            this.lbEmployeeID.AutoSize = true;
            this.lbEmployeeID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbEmployeeID.Location = new System.Drawing.Point(15, 245);
            this.lbEmployeeID.Name = "lbEmployeeID";
            this.lbEmployeeID.Size = new System.Drawing.Size(79, 16);
            this.lbEmployeeID.TabIndex = 4;
            this.lbEmployeeID.Text = "EmployeeID:";
            // 
            // lb_User_Username
            // 
            this.lb_User_Username.AutoSize = true;
            this.lb_User_Username.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_User_Username.Location = new System.Drawing.Point(15, 268);
            this.lb_User_Username.Name = "lb_User_Username";
            this.lb_User_Username.Size = new System.Drawing.Size(70, 16);
            this.lb_User_Username.TabIndex = 5;
            this.lb_User_Username.Text = "Username:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(359, 354);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 135);
            this.panel3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(59, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Department";
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1098, 673);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
		private System.Windows.Forms.Label lb_EmployeeNum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCurrentUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEmployeeID;
        private System.Windows.Forms.Label lb_User_Username;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
    }
}