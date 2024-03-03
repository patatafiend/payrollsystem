namespace payrollsystemsti
{
    partial class formDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_User_Username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.employeeContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.employee = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.employeeRegister = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.empSalary = new System.Windows.Forms.Button();
            this.employeeTransition = new System.Windows.Forms.Timer(this.components);
            this.sideBarTransition = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_useraccount = new System.Windows.Forms.Button();
            this.sideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.settings = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnLeave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.employeeContainer.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sideBar.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lb_User_Username);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 40);
            this.panel1.TabIndex = 1;
            // 
            // lb_User_Username
            // 
            this.lb_User_Username.AutoSize = true;
            this.lb_User_Username.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_User_Username.Location = new System.Drawing.Point(903, 12);
            this.lb_User_Username.Name = "lb_User_Username";
            this.lb_User_Username.Size = new System.Drawing.Size(70, 16);
            this.lb_User_Username.TabIndex = 2;
            this.lb_User_Username.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payroll Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 52);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-3, -31);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(199, 117);
            this.button1.TabIndex = 3;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.dashBoard_btn);
            // 
            // employeeContainer
            // 
            this.employeeContainer.BackColor = System.Drawing.Color.MistyRose;
            this.employeeContainer.Controls.Add(this.panel8);
            this.employeeContainer.Controls.Add(this.panel4);
            this.employeeContainer.Controls.Add(this.panel5);
            this.employeeContainer.Controls.Add(this.panel6);
            this.employeeContainer.Location = new System.Drawing.Point(0, 113);
            this.employeeContainer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.employeeContainer.Name = "employeeContainer";
            this.employeeContainer.Size = new System.Drawing.Size(185, 220);
            this.employeeContainer.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.employee);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(185, 52);
            this.panel8.TabIndex = 7;
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.Color.Gainsboro;
            this.employee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee.Image = ((System.Drawing.Image)(resources.GetObject("employee.Image")));
            this.employee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employee.Location = new System.Drawing.Point(-3, -32);
            this.employee.Name = "employee";
            this.employee.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.employee.Size = new System.Drawing.Size(199, 117);
            this.employee.TabIndex = 3;
            this.employee.Text = "Employee";
            this.employee.UseVisualStyleBackColor = false;
            this.employee.Click += new System.EventHandler(this.employee_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.employeeRegister);
            this.panel4.Location = new System.Drawing.Point(0, 52);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 52);
            this.panel4.TabIndex = 8;
            // 
            // employeeRegister
            // 
            this.employeeRegister.BackColor = System.Drawing.Color.WhiteSmoke;
            this.employeeRegister.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRegister.Image = ((System.Drawing.Image)(resources.GetObject("employeeRegister.Image")));
            this.employeeRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeeRegister.Location = new System.Drawing.Point(-3, -31);
            this.employeeRegister.Name = "employeeRegister";
            this.employeeRegister.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.employeeRegister.Size = new System.Drawing.Size(199, 117);
            this.employeeRegister.TabIndex = 3;
            this.employeeRegister.Text = "Register";
            this.employeeRegister.UseVisualStyleBackColor = false;
            this.employeeRegister.Click += new System.EventHandler(this.employee_Register);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.button3);
            this.panel5.Location = new System.Drawing.Point(0, 104);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(185, 52);
            this.panel5.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-3, -31);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(199, 117);
            this.button3.TabIndex = 3;
            this.button3.Text = "Attendance";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.empSalary);
            this.panel6.Location = new System.Drawing.Point(0, 156);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(185, 52);
            this.panel6.TabIndex = 10;
            // 
            // empSalary
            // 
            this.empSalary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.empSalary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empSalary.Image = ((System.Drawing.Image)(resources.GetObject("empSalary.Image")));
            this.empSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.empSalary.Location = new System.Drawing.Point(-3, -31);
            this.empSalary.Name = "empSalary";
            this.empSalary.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.empSalary.Size = new System.Drawing.Size(199, 117);
            this.empSalary.TabIndex = 3;
            this.empSalary.Text = "Salary";
            this.empSalary.UseVisualStyleBackColor = false;
            this.empSalary.Click += new System.EventHandler(this.employee_Salary);
            // 
            // employeeTransition
            // 
            this.employeeTransition.Interval = 10;
            this.employeeTransition.Tick += new System.EventHandler(this.employeeTransition_Tick);
            // 
            // sideBarTransition
            // 
            this.sideBarTransition.Interval = 10;
            this.sideBarTransition.Tick += new System.EventHandler(this.sideBarTransition_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btn_useraccount);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 52);
            this.panel2.TabIndex = 4;
            // 
            // btn_useraccount
            // 
            this.btn_useraccount.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_useraccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_useraccount.Image = ((System.Drawing.Image)(resources.GetObject("btn_useraccount.Image")));
            this.btn_useraccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_useraccount.Location = new System.Drawing.Point(-3, -31);
            this.btn_useraccount.Name = "btn_useraccount";
            this.btn_useraccount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_useraccount.Size = new System.Drawing.Size(199, 117);
            this.btn_useraccount.TabIndex = 3;
            this.btn_useraccount.Text = "User Account";
            this.btn_useraccount.UseVisualStyleBackColor = false;
            this.btn_useraccount.Click += new System.EventHandler(this.userAccount_btn);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.White;
            this.sideBar.Controls.Add(this.panel3);
            this.sideBar.Controls.Add(this.panel2);
            this.sideBar.Controls.Add(this.employeeContainer);
            this.sideBar.Controls.Add(this.panel9);
            this.sideBar.Controls.Add(this.panel7);
            this.sideBar.Controls.Add(this.panel10);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 40);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(187, 639);
            this.sideBar.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.settings);
            this.panel9.Location = new System.Drawing.Point(0, 336);
            this.panel9.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(185, 52);
            this.panel9.TabIndex = 6;
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Gainsboro;
            this.settings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.settings.Image = ((System.Drawing.Image)(resources.GetObject("settings.Image")));
            this.settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settings.Location = new System.Drawing.Point(-3, -31);
            this.settings.Name = "settings";
            this.settings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.settings.Size = new System.Drawing.Size(199, 117);
            this.settings.TabIndex = 3;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.button6);
            this.panel7.Location = new System.Drawing.Point(0, 391);
            this.panel7.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(185, 52);
            this.panel7.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Gainsboro;
            this.button6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-3, -31);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(199, 117);
            this.button6.TabIndex = 3;
            this.button6.Text = "Logout";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnLogout);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.btnLeave);
            this.panel10.Location = new System.Drawing.Point(0, 446);
            this.panel10.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(185, 52);
            this.panel10.TabIndex = 7;
            // 
            // btnLeave
            // 
            this.btnLeave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLeave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeave.Image = ((System.Drawing.Image)(resources.GetObject("btnLeave.Image")));
            this.btnLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeave.Location = new System.Drawing.Point(-3, -31);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLeave.Size = new System.Drawing.Size(199, 117);
            this.btnLeave.TabIndex = 3;
            this.btnLeave.Text = "Leave Application";
            this.btnLeave.UseVisualStyleBackColor = false;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // formDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1206, 679);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "formDashboard";
            this.Text = "formDashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formDashboard_FormClosing);
            this.Load += new System.EventHandler(this.dashBoard_btn);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.employeeContainer.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.sideBar.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel employeeContainer;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button employee;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button employeeRegister;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button empSalary;
        private System.Windows.Forms.Timer employeeTransition;
        private System.Windows.Forms.Timer sideBarTransition;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_useraccount;
        private System.Windows.Forms.FlowLayoutPanel sideBar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button settings;
		private System.Windows.Forms.Label lb_User_Username;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnLeave;
    }
}