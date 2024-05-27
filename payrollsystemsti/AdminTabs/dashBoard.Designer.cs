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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashBoard));
            this.lb_DashBoard = new System.Windows.Forms.Label();
            this.pnl_Employee = new System.Windows.Forms.Panel();
            this.lb_Total = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_EmployeeNum = new System.Windows.Forms.Label();
            this.lb_Employee = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_absents = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbEmployeeID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbCurrentUser = new System.Windows.Forms.PictureBox();
            this.pnl_Department = new System.Windows.Forms.Panel();
            this.lb_curDepartment = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.notifContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnl_Employee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).BeginInit();
            this.pnl_Department.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_DashBoard
            // 
            this.lb_DashBoard.AutoSize = true;
            this.lb_DashBoard.BackColor = System.Drawing.Color.Transparent;
            this.lb_DashBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DashBoard.ForeColor = System.Drawing.Color.Crimson;
            this.lb_DashBoard.Location = new System.Drawing.Point(12, 70);
            this.lb_DashBoard.Name = "lb_DashBoard";
            this.lb_DashBoard.Size = new System.Drawing.Size(156, 31);
            this.lb_DashBoard.TabIndex = 0;
            this.lb_DashBoard.Text = "Dashboard";
            this.lb_DashBoard.Click += new System.EventHandler(this.lb_DashBoard_Click);
            // 
            // pnl_Employee
            // 
            this.pnl_Employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.pnl_Employee.Controls.Add(this.lb_Total);
            this.pnl_Employee.Controls.Add(this.pictureBox1);
            this.pnl_Employee.Controls.Add(this.lb_EmployeeNum);
            this.pnl_Employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_Employee.Location = new System.Drawing.Point(38, 140);
            this.pnl_Employee.Name = "pnl_Employee";
            this.pnl_Employee.Size = new System.Drawing.Size(310, 125);
            this.pnl_Employee.TabIndex = 1;
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.BackColor = System.Drawing.Color.Transparent;
            this.lb_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Total.Location = new System.Drawing.Point(130, 13);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(156, 24);
            this.lb_Total.TabIndex = 3;
            this.lb_Total.Text = "Total Employee";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::payrollsystemsti.Properties.Resources.people;
            this.pictureBox1.Location = new System.Drawing.Point(24, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lb_EmployeeNum
            // 
            this.lb_EmployeeNum.AutoSize = true;
            this.lb_EmployeeNum.BackColor = System.Drawing.Color.Transparent;
            this.lb_EmployeeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_EmployeeNum.Location = new System.Drawing.Point(164, 44);
            this.lb_EmployeeNum.Name = "lb_EmployeeNum";
            this.lb_EmployeeNum.Size = new System.Drawing.Size(74, 39);
            this.lb_EmployeeNum.TabIndex = 1;
            this.lb_EmployeeNum.Text = "169";
            // 
            // lb_Employee
            // 
            this.lb_Employee.AutoSize = true;
            this.lb_Employee.BackColor = System.Drawing.Color.Transparent;
            this.lb_Employee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Employee.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Employee.Location = new System.Drawing.Point(34, 113);
            this.lb_Employee.Name = "lb_Employee";
            this.lb_Employee.Size = new System.Drawing.Size(104, 24);
            this.lb_Employee.TabIndex = 0;
            this.lb_Employee.Text = "Employee";
            this.lb_Employee.Click += new System.EventHandler(this.lb_Employee_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbWelcome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1063, 45);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(381, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Have a nice day!";
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.SystemColors.Control;
            this.lbWelcome.Location = new System.Drawing.Point(12, 9);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(150, 31);
            this.lbWelcome.TabIndex = 6;
            this.lbWelcome.Text = "Welcome !";
            this.lbWelcome.Click += new System.EventHandler(this.lbWelcome_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lb_absents);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lbEmployeeID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pbCurrentUser);
            this.panel1.Location = new System.Drawing.Point(784, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 670);
            this.panel1.TabIndex = 4;
            // 
            // lb_absents
            // 
            this.lb_absents.AutoSize = true;
            this.lb_absents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_absents.Location = new System.Drawing.Point(22, 377);
            this.lb_absents.Name = "lb_absents";
            this.lb_absents.Size = new System.Drawing.Size(45, 13);
            this.lb_absents.TabIndex = 7;
            this.lb_absents.Text = "absent";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(23, 402);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 304);
            this.panel3.TabIndex = 6;
            // 
            // lbEmployeeID
            // 
            this.lbEmployeeID.AutoSize = true;
            this.lbEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbEmployeeID.Location = new System.Drawing.Point(20, 326);
            this.lbEmployeeID.Name = "lbEmployeeID";
            this.lbEmployeeID.Size = new System.Drawing.Size(78, 13);
            this.lbEmployeeID.TabIndex = 4;
            this.lbEmployeeID.Text = "EmployeeID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "My Profile";
            // 
            // pbCurrentUser
            // 
            this.pbCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCurrentUser.Image = global::payrollsystemsti.Properties.Resources.renz;
            this.pbCurrentUser.Location = new System.Drawing.Point(68, 87);
            this.pbCurrentUser.Name = "pbCurrentUser";
            this.pbCurrentUser.Size = new System.Drawing.Size(152, 147);
            this.pbCurrentUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentUser.TabIndex = 3;
            this.pbCurrentUser.TabStop = false;
            // 
            // pnl_Department
            // 
            this.pnl_Department.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Department.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.pnl_Department.Controls.Add(this.lb_curDepartment);
            this.pnl_Department.Controls.Add(this.pictureBox2);
            this.pnl_Department.Controls.Add(this.label5);
            this.pnl_Department.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_Department.Location = new System.Drawing.Point(406, 140);
            this.pnl_Department.Name = "pnl_Department";
            this.pnl_Department.Size = new System.Drawing.Size(310, 125);
            this.pnl_Department.TabIndex = 4;
            // 
            // lb_curDepartment
            // 
            this.lb_curDepartment.AutoSize = true;
            this.lb_curDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lb_curDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_curDepartment.Location = new System.Drawing.Point(105, 44);
            this.lb_curDepartment.Name = "lb_curDepartment";
            this.lb_curDepartment.Size = new System.Drawing.Size(175, 29);
            this.lb_curDepartment.TabIndex = 1;
            this.lb_curDepartment.Text = "My Department";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(97, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Current Department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(402, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Department";
            // 
            // notifContainer
            // 
            this.notifContainer.Location = new System.Drawing.Point(34, 302);
            this.notifContainer.Name = "notifContainer";
            this.notifContainer.Size = new System.Drawing.Size(671, 356);
            this.notifContainer.TabIndex = 6;
            this.notifContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.notifContainer_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phone No. :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email address :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Position :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1063, 670);
            this.Controls.Add(this.notifContainer);
            this.Controls.Add(this.lb_DashBoard);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_Department);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_Employee);
            this.Controls.Add(this.pnl_Employee);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(187, 70);
            this.Name = "dashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dashBoard";
            this.Load += new System.EventHandler(this.dashBoard_Load);
            this.pnl_Employee.ResumeLayout(false);
            this.pnl_Employee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).EndInit();
            this.pnl_Department.ResumeLayout(false);
            this.pnl_Department.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label lb_DashBoard;
		private System.Windows.Forms.Panel pnl_Employee;
		private System.Windows.Forms.Label lb_Employee;
		private System.Windows.Forms.Label lb_EmployeeNum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.PictureBox pbCurrentUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEmployeeID;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lb_Total;
		private System.Windows.Forms.Panel pnl_Department;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lb_curDepartment;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel notifContainer;
        private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lb_absents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
    }
}