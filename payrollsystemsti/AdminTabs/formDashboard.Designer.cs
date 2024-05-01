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
            this.header = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.controlBox = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnMax = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.employeePnl = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.employee = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.employeeRegister = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.employeeAttendance = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.empSalary = new System.Windows.Forms.Button();
            this.employeeTransition = new System.Windows.Forms.Timer(this.components);
            this.sideBarTransition = new System.Windows.Forms.Timer(this.components);
            this.userAccountPnl = new System.Windows.Forms.Panel();
            this.btn_useraccount = new System.Windows.Forms.Button();
            this.sideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.LeaveApplicationPnl = new System.Windows.Forms.Panel();
            this.btnLeave = new System.Windows.Forms.Button();
            this.leaveTypeManagementPnl = new System.Windows.Forms.Panel();
            this.btnLTM = new System.Windows.Forms.Button();
            this.leaveManagementPnl = new System.Windows.Forms.Panel();
            this.btnLM = new System.Windows.Forms.Button();
            this.AccountArchivePnl = new System.Windows.Forms.Panel();
            this.btnArchive = new System.Windows.Forms.Button();
            this.settingsPnl = new System.Windows.Forms.Panel();
            this.settings = new System.Windows.Forms.Button();
            this.logoutPnl = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.enrollFingerprintPnl = new System.Windows.Forms.Panel();
            this.btnEnrollFinger = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.header.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.employeePnl.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.userAccountPnl.SuspendLayout();
            this.sideBar.SuspendLayout();
            this.LeaveApplicationPnl.SuspendLayout();
            this.leaveTypeManagementPnl.SuspendLayout();
            this.leaveManagementPnl.SuspendLayout();
            this.AccountArchivePnl.SuspendLayout();
            this.settingsPnl.SuspendLayout();
            this.logoutPnl.SuspendLayout();
            this.enrollFingerprintPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.header.Controls.Add(this.btn_back);
            this.header.Controls.Add(this.controlBox);
            this.header.Controls.Add(this.label1);
            this.header.Controls.Add(this.pictureBox1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.SystemColors.Control;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1250, 70);
            this.header.TabIndex = 1;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btn_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_back.BackgroundImage")));
            this.btn_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btn_back.Location = new System.Drawing.Point(371, 6);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(65, 58);
            this.btn_back.TabIndex = 6;
            this.btn_back.UseVisualStyleBackColor = false;
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.panel17);
            this.controlBox.Controls.Add(this.panel12);
            this.controlBox.Controls.Add(this.panel16);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(1110, 0);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(140, 70);
            this.controlBox.TabIndex = 5;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.btnClose);
            this.panel17.Location = new System.Drawing.Point(93, 17);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(44, 30);
            this.panel17.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 21);
            this.btnClose.TabIndex = 30;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnMin);
            this.panel12.Location = new System.Drawing.Point(3, 17);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(44, 30);
            this.panel12.TabIndex = 0;
            // 
            // btnMin
            // 
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.Transparent;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.Location = new System.Drawing.Point(3, 3);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(36, 21);
            this.btnMin.TabIndex = 30;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnMax);
            this.panel16.Location = new System.Drawing.Point(48, 17);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(44, 30);
            this.panel16.TabIndex = 30;
            // 
            // btnMax
            // 
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.ForeColor = System.Drawing.Color.Transparent;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(3, 3);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(36, 21);
            this.btnMax.TabIndex = 30;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payroll Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 46);
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
            this.panel3.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(185, 55);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-18, -13);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(210, 80);
            this.button1.TabIndex = 3;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.dashBoard_btn);
            // 
            // employeePnl
            // 
            this.employeePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(181)))), ((int)(((byte)(202)))));
            this.employeePnl.Controls.Add(this.panel8);
            this.employeePnl.Controls.Add(this.panel4);
            this.employeePnl.Controls.Add(this.panel5);
            this.employeePnl.Controls.Add(this.panel6);
            this.employeePnl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.employeePnl.Location = new System.Drawing.Point(0, 119);
            this.employeePnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.employeePnl.Name = "employeePnl";
            this.employeePnl.Size = new System.Drawing.Size(185, 49);
            this.employeePnl.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.employee);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(185, 55);
            this.panel8.TabIndex = 7;
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.employee.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee.ForeColor = System.Drawing.SystemColors.Control;
            this.employee.Image = ((System.Drawing.Image)(resources.GetObject("employee.Image")));
            this.employee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employee.Location = new System.Drawing.Point(-17, -18);
            this.employee.Name = "employee";
            this.employee.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.employee.Size = new System.Drawing.Size(210, 80);
            this.employee.TabIndex = 3;
            this.employee.Text = "Employee";
            this.employee.UseVisualStyleBackColor = false;
            this.employee.Click += new System.EventHandler(this.employee_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.employeeRegister);
            this.panel4.Location = new System.Drawing.Point(0, 55);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 55);
            this.panel4.TabIndex = 8;
            // 
            // employeeRegister
            // 
            this.employeeRegister.BackColor = System.Drawing.Color.DarkSlateGray;
            this.employeeRegister.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRegister.ForeColor = System.Drawing.SystemColors.Control;
            this.employeeRegister.Image = ((System.Drawing.Image)(resources.GetObject("employeeRegister.Image")));
            this.employeeRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeeRegister.Location = new System.Drawing.Point(-7, -31);
            this.employeeRegister.Name = "employeeRegister";
            this.employeeRegister.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.employeeRegister.Size = new System.Drawing.Size(199, 117);
            this.employeeRegister.TabIndex = 3;
            this.employeeRegister.Text = "Register";
            this.employeeRegister.UseVisualStyleBackColor = false;
            this.employeeRegister.Click += new System.EventHandler(this.employee_Register);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.employeeAttendance);
            this.panel5.Location = new System.Drawing.Point(0, 110);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(185, 55);
            this.panel5.TabIndex = 9;
            // 
            // employeeAttendance
            // 
            this.employeeAttendance.BackColor = System.Drawing.Color.DarkSlateGray;
            this.employeeAttendance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeAttendance.ForeColor = System.Drawing.SystemColors.Control;
            this.employeeAttendance.Image = ((System.Drawing.Image)(resources.GetObject("employeeAttendance.Image")));
            this.employeeAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeeAttendance.Location = new System.Drawing.Point(-6, -42);
            this.employeeAttendance.Name = "employeeAttendance";
            this.employeeAttendance.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.employeeAttendance.Size = new System.Drawing.Size(220, 132);
            this.employeeAttendance.TabIndex = 3;
            this.employeeAttendance.Text = "Attendance";
            this.employeeAttendance.UseVisualStyleBackColor = false;
            this.employeeAttendance.Click += new System.EventHandler(this.employeeAttendance_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.empSalary);
            this.panel6.Location = new System.Drawing.Point(0, 165);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(185, 55);
            this.panel6.TabIndex = 10;
            // 
            // empSalary
            // 
            this.empSalary.BackColor = System.Drawing.Color.DarkSlateGray;
            this.empSalary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empSalary.ForeColor = System.Drawing.SystemColors.Control;
            this.empSalary.Image = ((System.Drawing.Image)(resources.GetObject("empSalary.Image")));
            this.empSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.empSalary.Location = new System.Drawing.Point(-6, -31);
            this.empSalary.Name = "empSalary";
            this.empSalary.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
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
            // userAccountPnl
            // 
            this.userAccountPnl.BackColor = System.Drawing.Color.Transparent;
            this.userAccountPnl.Controls.Add(this.btn_useraccount);
            this.userAccountPnl.Location = new System.Drawing.Point(0, 61);
            this.userAccountPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.userAccountPnl.Name = "userAccountPnl";
            this.userAccountPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.userAccountPnl.Size = new System.Drawing.Size(185, 55);
            this.userAccountPnl.TabIndex = 4;
            // 
            // btn_useraccount
            // 
            this.btn_useraccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btn_useraccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_useraccount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_useraccount.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_useraccount.Image = ((System.Drawing.Image)(resources.GetObject("btn_useraccount.Image")));
            this.btn_useraccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_useraccount.Location = new System.Drawing.Point(-17, -16);
            this.btn_useraccount.Name = "btn_useraccount";
            this.btn_useraccount.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_useraccount.Size = new System.Drawing.Size(210, 80);
            this.btn_useraccount.TabIndex = 3;
            this.btn_useraccount.Text = "User Account";
            this.btn_useraccount.UseVisualStyleBackColor = false;
            this.btn_useraccount.Click += new System.EventHandler(this.userAccount_btn);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.sideBar.Controls.Add(this.panel3);
            this.sideBar.Controls.Add(this.userAccountPnl);
            this.sideBar.Controls.Add(this.employeePnl);
            this.sideBar.Controls.Add(this.LeaveApplicationPnl);
            this.sideBar.Controls.Add(this.leaveTypeManagementPnl);
            this.sideBar.Controls.Add(this.leaveManagementPnl);
            this.sideBar.Controls.Add(this.AccountArchivePnl);
            this.sideBar.Controls.Add(this.settingsPnl);
            this.sideBar.Controls.Add(this.logoutPnl);
            this.sideBar.Controls.Add(this.enrollFingerprintPnl);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 70);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(187, 670);
            this.sideBar.TabIndex = 3;
            // 
            // LeaveApplicationPnl
            // 
            this.LeaveApplicationPnl.BackColor = System.Drawing.Color.Transparent;
            this.LeaveApplicationPnl.Controls.Add(this.btnLeave);
            this.LeaveApplicationPnl.Location = new System.Drawing.Point(0, 171);
            this.LeaveApplicationPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.LeaveApplicationPnl.Name = "LeaveApplicationPnl";
            this.LeaveApplicationPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.LeaveApplicationPnl.Size = new System.Drawing.Size(185, 55);
            this.LeaveApplicationPnl.TabIndex = 5;
            // 
            // btnLeave
            // 
            this.btnLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btnLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLeave.Image = ((System.Drawing.Image)(resources.GetObject("btnLeave.Image")));
            this.btnLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeave.Location = new System.Drawing.Point(-13, -10);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLeave.Size = new System.Drawing.Size(210, 80);
            this.btnLeave.TabIndex = 3;
            this.btnLeave.Text = "Leave \r\nApplication";
            this.btnLeave.UseVisualStyleBackColor = false;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // leaveTypeManagementPnl
            // 
            this.leaveTypeManagementPnl.BackColor = System.Drawing.Color.Transparent;
            this.leaveTypeManagementPnl.Controls.Add(this.btnLTM);
            this.leaveTypeManagementPnl.Location = new System.Drawing.Point(0, 229);
            this.leaveTypeManagementPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.leaveTypeManagementPnl.Name = "leaveTypeManagementPnl";
            this.leaveTypeManagementPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.leaveTypeManagementPnl.Size = new System.Drawing.Size(185, 55);
            this.leaveTypeManagementPnl.TabIndex = 9;
            // 
            // btnLTM
            // 
            this.btnLTM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btnLTM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLTM.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLTM.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLTM.Image = ((System.Drawing.Image)(resources.GetObject("btnLTM.Image")));
            this.btnLTM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLTM.Location = new System.Drawing.Point(-13, -16);
            this.btnLTM.Name = "btnLTM";
            this.btnLTM.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLTM.Size = new System.Drawing.Size(210, 80);
            this.btnLTM.TabIndex = 3;
            this.btnLTM.Text = "Leave Type \r\nManagement";
            this.btnLTM.UseVisualStyleBackColor = false;
            this.btnLTM.Click += new System.EventHandler(this.btnLTM_Click);
            // 
            // leaveManagementPnl
            // 
            this.leaveManagementPnl.BackColor = System.Drawing.Color.Transparent;
            this.leaveManagementPnl.Controls.Add(this.btnLM);
            this.leaveManagementPnl.Location = new System.Drawing.Point(0, 287);
            this.leaveManagementPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.leaveManagementPnl.Name = "leaveManagementPnl";
            this.leaveManagementPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.leaveManagementPnl.Size = new System.Drawing.Size(185, 55);
            this.leaveManagementPnl.TabIndex = 10;
            // 
            // btnLM
            // 
            this.btnLM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btnLM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLM.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLM.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLM.Image = ((System.Drawing.Image)(resources.GetObject("btnLM.Image")));
            this.btnLM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLM.Location = new System.Drawing.Point(-13, -16);
            this.btnLM.Name = "btnLM";
            this.btnLM.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLM.Size = new System.Drawing.Size(210, 80);
            this.btnLM.TabIndex = 3;
            this.btnLM.Text = "Leave \r\nManagement";
            this.btnLM.UseVisualStyleBackColor = false;
            this.btnLM.Click += new System.EventHandler(this.btnLM_Click);
            // 
            // AccountArchivePnl
            // 
            this.AccountArchivePnl.BackColor = System.Drawing.Color.Transparent;
            this.AccountArchivePnl.Controls.Add(this.btnArchive);
            this.AccountArchivePnl.Location = new System.Drawing.Point(0, 345);
            this.AccountArchivePnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.AccountArchivePnl.Name = "AccountArchivePnl";
            this.AccountArchivePnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.AccountArchivePnl.Size = new System.Drawing.Size(185, 55);
            this.AccountArchivePnl.TabIndex = 11;
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btnArchive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchive.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.ForeColor = System.Drawing.SystemColors.Control;
            this.btnArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnArchive.Image")));
            this.btnArchive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchive.Location = new System.Drawing.Point(-13, -20);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnArchive.Size = new System.Drawing.Size(210, 80);
            this.btnArchive.TabIndex = 3;
            this.btnArchive.Text = "Account\r\nArchive";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // settingsPnl
            // 
            this.settingsPnl.BackColor = System.Drawing.Color.Transparent;
            this.settingsPnl.Controls.Add(this.settings);
            this.settingsPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsPnl.Location = new System.Drawing.Point(0, 403);
            this.settingsPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.settingsPnl.Name = "settingsPnl";
            this.settingsPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.settingsPnl.Size = new System.Drawing.Size(185, 55);
            this.settingsPnl.TabIndex = 7;
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings.ForeColor = System.Drawing.SystemColors.Control;
            this.settings.Image = ((System.Drawing.Image)(resources.GetObject("settings.Image")));
            this.settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settings.Location = new System.Drawing.Point(-8, -15);
            this.settings.Name = "settings";
            this.settings.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.settings.Size = new System.Drawing.Size(210, 80);
            this.settings.TabIndex = 3;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // logoutPnl
            // 
            this.logoutPnl.BackColor = System.Drawing.Color.Transparent;
            this.logoutPnl.Controls.Add(this.button6);
            this.logoutPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutPnl.Location = new System.Drawing.Point(0, 461);
            this.logoutPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.logoutPnl.Name = "logoutPnl";
            this.logoutPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.logoutPnl.Size = new System.Drawing.Size(185, 55);
            this.logoutPnl.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.Control;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-8, -14);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(210, 80);
            this.button6.TabIndex = 3;
            this.button6.Text = "Logout";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnLogout);
            // 
            // enrollFingerprintPnl
            // 
            this.enrollFingerprintPnl.BackColor = System.Drawing.Color.Transparent;
            this.enrollFingerprintPnl.Controls.Add(this.btnEnrollFinger);
            this.enrollFingerprintPnl.Location = new System.Drawing.Point(0, 519);
            this.enrollFingerprintPnl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.enrollFingerprintPnl.Name = "enrollFingerprintPnl";
            this.enrollFingerprintPnl.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.enrollFingerprintPnl.Size = new System.Drawing.Size(185, 55);
            this.enrollFingerprintPnl.TabIndex = 13;
            // 
            // btnEnrollFinger
            // 
            this.btnEnrollFinger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(143)))), ((int)(((byte)(161)))));
            this.btnEnrollFinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnrollFinger.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollFinger.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnrollFinger.Image = ((System.Drawing.Image)(resources.GetObject("btnEnrollFinger.Image")));
            this.btnEnrollFinger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnrollFinger.Location = new System.Drawing.Point(-8, -12);
            this.btnEnrollFinger.Name = "btnEnrollFinger";
            this.btnEnrollFinger.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnEnrollFinger.Size = new System.Drawing.Size(210, 80);
            this.btnEnrollFinger.TabIndex = 3;
            this.btnEnrollFinger.Text = "Enroll\r\nFingerprint";
            this.btnEnrollFinger.UseVisualStyleBackColor = false;
            this.btnEnrollFinger.Click += new System.EventHandler(this.btnEnrollFinger_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(187, 70);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1063, 670);
            this.panelContainer.TabIndex = 5;
            // 
            // formDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1250, 740);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "formDashboard";
            this.Text = "formDashboard";
            this.Load += new System.EventHandler(this.dashBoard_btn);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.controlBox.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.employeePnl.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.userAccountPnl.ResumeLayout(false);
            this.sideBar.ResumeLayout(false);
            this.LeaveApplicationPnl.ResumeLayout(false);
            this.leaveTypeManagementPnl.ResumeLayout(false);
            this.leaveManagementPnl.ResumeLayout(false);
            this.AccountArchivePnl.ResumeLayout(false);
            this.settingsPnl.ResumeLayout(false);
            this.logoutPnl.ResumeLayout(false);
            this.enrollFingerprintPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel employeePnl;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button employee;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button employeeRegister;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button employeeAttendance;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button empSalary;
        private System.Windows.Forms.Timer employeeTransition;
        private System.Windows.Forms.Timer sideBarTransition;
        private System.Windows.Forms.Panel userAccountPnl;
        private System.Windows.Forms.Button btn_useraccount;
        private System.Windows.Forms.FlowLayoutPanel sideBar;
        private System.Windows.Forms.Panel LeaveApplicationPnl;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Panel settingsPnl;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Panel logoutPnl;
        private System.Windows.Forms.Panel controlBox;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel leaveTypeManagementPnl;
        private System.Windows.Forms.Button btnLTM;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel leaveManagementPnl;
        private System.Windows.Forms.Button btnLM;
        private System.Windows.Forms.Panel AccountArchivePnl;
        private System.Windows.Forms.Button btnArchive;
		private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel enrollFingerprintPnl;
        private System.Windows.Forms.Button btnEnrollFinger;
    }
}