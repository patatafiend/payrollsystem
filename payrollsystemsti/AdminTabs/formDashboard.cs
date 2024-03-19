using payrollsystemsti.AdminTabs;
using payrollsystemsti.EmployeeTabs;
using payrollsystemsti.Tabs;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;



namespace payrollsystemsti
{
    public partial class formDashboard : Form
    {
		
        

		Methods m = new Methods();
        public static formDashboard formDashboardInstance;
        // Declare form instances
        private dashBoard dashboard;
        private manageEmployee userRegister;
        private formSettings fSettings;
        private employeeRegister empRegister;
        private employeeSalary employeeSalary;
        private leaveApplication leaveApplication;
        private leaveCategoriesManagement leaveManage;

        

        //draggable panel shit
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);


        // Logged-in user name property
        private string loggedInFirstName, loggedInDepartment;
        
        private int loggedInEmployeeID;

		static formDashboard _obj;

		public static formDashboard Instance
		{
			get
			{
				if (_obj == null)
				{
					_obj = new formDashboard();
				}
				return _obj;
			}
		}

		public Panel PnlContainer
		{
			get { return panelContainer; }
			set { panelContainer = value; }

		}



		// Form constructor
		public formDashboard()
        {
            InitializeComponent();
            formDashboardInstance = this;
			
		}

        public void formDashboard_load(object sender, EventArgs e)
        {
            _obj = this;
            dashBoard dashboard = new dashBoard();
            dashboard.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(dashboard);
        }

        

       

        public string LoggedInFirstName
        {
            get { return loggedInFirstName; }
            set
            {
                loggedInFirstName = value;
            }
        }
        public int LoggedInEmployeeID
        {
            get { return loggedInEmployeeID; }
            set
            {
                loggedInEmployeeID = value;
            }
        }

		public string LoggedInDepartment
		{
			get { return loggedInDepartment; }
			set
			{
				loggedInDepartment = value;
			}
		}



		public Button GetUserAccountButton()
        {
            return btn_useraccount;
        }


        // Employee panel expand/collapse transition flags
        private bool employeeExpand = false;
        private bool sideBarExpand = false;

        // Click event for employee button
        private void employee_Click(object sender, EventArgs e)
        {
            employeeTransition.Start();
        }

        // Employee panel expand/collapse transition
        private void employeeTransition_Tick(object sender, EventArgs e)
        {
            if (employeeExpand == false)
            {
                employeeContainer.Height += 10;
                if (employeeContainer.Height >= 300)
                {
                    employeeTransition.Stop();
                    employeeExpand = true;
                }
            }
            else
            {
                employeeContainer.Height -= 10;
                if (employeeContainer.Height <= 52)
                {
                    employeeTransition.Stop();
                    employeeExpand = false;
                }
            }
        }

        // Sidebar expand/collapse transition
        private void sideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand == false)
            {
                panel7.Width += 10;
                if (panel7.Width >= 183)
                {
                    sideBarTransition.Stop();
                    sideBarExpand = true;
                }
            }
            else
            {
                panel7.Width -= 10;
                if (panel7.Width <= 43)
                {
                    sideBarTransition.Stop();
                    sideBarExpand = false;
                }
            }
        }

        // Click event for sidebar toggle button
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();
        }

        // Click event for user account button
        private void userAccount_btn(object sender, EventArgs e)
        {
            // Show user registration form or activate if already open
            if (userRegister == null)
            {
                userRegister = new manageEmployee();
                userRegister.FormClosed += userRegister_FormClosed;
                userRegister.MdiParent = this;
                userRegister.Dock = DockStyle.Fill;
                userRegister.Show();
            }
            else
            {
                userRegister.Activate();
            }
        }

        // FormClosed event for user registration form
        private void userRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            userRegister = null;
        }

        // Click event for dashboard button
        private void dashBoard_btn(object sender, EventArgs e)
        {
            // Show dashboard form or activate if already open
            if (dashboard == null)
            {
                dashboard = new dashBoard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }
            if (!string.IsNullOrEmpty(loggedInFirstName))
            {
                String fnameC = char.ToUpper(loggedInFirstName[0]) + loggedInFirstName.Substring(1);
                dashBoard.dashboardInstance.lbGetName.Text = "Welcome , " + fnameC;
            }
            else
            {
                dashBoard.dashboardInstance.lbGetName.Text = "Welcome , Tester <3";
            }

            byte[] imageData = m.RetrieveEmployeeImageData(loggedInEmployeeID);
            dashBoard.dashboardInstance.pbGetImageUser.Image = m.ConvertToImage(imageData);

			dashBoard.dashboardInstance.lbGetDepartment.Text = loggedInDepartment;

		}

        // FormClosed event for dashboard form
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        // Click event for logout button
        private void btnLogout(object sender, EventArgs e)
        {
            this.Close();
            formLogin fm_Login = new formLogin();
            fm_Login.Show();
        }
        // Click event for settings button
        private void settings_Click(object sender, EventArgs e)
        {
            // Show settings form or activate if already open
            if (fSettings == null)
            {
                fSettings = new formSettings();
                fSettings.FormClosed += Settings_FormClosed;
                fSettings.MdiParent = this;
                fSettings.Dock = DockStyle.Fill;
                fSettings.Show();
            }
            else
            {
                fSettings.Activate();
            }
        }

        // FormClosed event for settings form
        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            fSettings = null;
        }

        // Click event for employee registration button
        private void employee_Register(object sender, EventArgs e)
        {
            // Show employee registration form or activate if already open
            if (empRegister == null)
            {
                empRegister = new employeeRegister();
                empRegister.FormClosed += EmployeeRegister_FormClosed;
                empRegister.MdiParent = this;
                empRegister.Dock = DockStyle.Fill;
                empRegister.Show();
            }
            else
            {
                empRegister.Activate();
            }
        }

        // FormClosed event for employee registration form
        private void EmployeeRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            empRegister = null;
        }

        // Click event for employee salary button
        private void employee_Salary(object sender, EventArgs e)
        {
            // Show employee salary form or activate if already open
            if (employeeSalary == null)
            {
                employeeSalary = new employeeSalary();
                employeeSalary.FormClosed += EmployeeSalary_FormClosed;
                employeeSalary.MdiParent = this;
                employeeSalary.Dock = DockStyle.Fill;
                employeeSalary.Show();
            }
            else
            {
                employeeSalary.Activate();
            }
        }

        // FormClosed event for employee salary form
        private void EmployeeSalary_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeSalary = null;
        }
        private void btnLeave_Click(object sender, EventArgs e)
        {
            if (leaveApplication == null)
            {
                leaveApplication = new leaveApplication();
                leaveApplication.FormClosed += LeaveApplication_FormClosed;
                leaveApplication.MdiParent = this;
                leaveApplication.Dock = DockStyle.Fill;
                leaveApplication.Show();
            }
            else
            {
                leaveApplication.Activate();
            }
            leaveApplication.leaveApplicationInstance.LoggedInEmpID = loggedInEmployeeID;
        }
        private void LeaveApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            leaveApplication = null;
        }

        private void btnLeaveM_Click(object sender, EventArgs e)
        {
            if (leaveManage == null)
            {
                leaveManage = new leaveCategoriesManagement();
                leaveManage.FormClosed += LeaveManagement_FormClosed;
                leaveManage.MdiParent = this;
                leaveManage.Dock = DockStyle.Fill;
                leaveManage.Show();
            }
            else
            {
                leaveManage.Activate();
            }

        }
        private void LeaveManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            leaveManage = null;
        }
        //when left mouse is clicked on the header panel this executes
        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        
    }
}
