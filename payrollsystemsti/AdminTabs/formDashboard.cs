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
        private maintenance userRegister;
        private formSettings fSettings;
        private employeeRegister empRegister;
        private employeeSalary employeeSalary;
        private leaveApplication leaveApplication;
        private leaveCategoriesManagement ltm;
        private leaveManagement lm;
        private accountsArchive aa;
        private attendanceMonitoring am;
        private enrollFingerprint ef;
        private HistoryLogForm HistoyLogForm;

        
        //draggable panel shit
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);


        // Logged-in user name property
        private string loggedInFirstName, loggedInDepartment;
        
        private int loggedInEmployeeID, loggedInLeaves, loggedInAbsents;

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

        public Button BackButton
        {
            get { return btn_back; }
            set {  btn_back = value; }
        }


		// Form constructor
		public formDashboard()
        {
            InitializeComponent();
            formDashboardInstance = this;
		}

        private void btn_back_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["dashBoard"].BringToFront();
			btn_back.Visible = false;
		}
        public string LoggedInFirstName
        {
            get { return loggedInFirstName; }
            set
            {
                loggedInFirstName = value;
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
		public int LoggedInEmployeeID
        {
            get { return loggedInEmployeeID; }
            set
            {
                loggedInEmployeeID = value;
            }
        }

		public int LoggedInLeaves
		{
			get { return loggedInLeaves; }
			set
			{
				loggedInLeaves = value;
			}
		}

        public int LoggedInAbsents
		{
			get { return loggedInAbsents; }
			set
			{
				loggedInAbsents = value;
			}
		}

		public Button GetUserAccountButton()
        {
            return btn_useraccount;
        }

        public Button GetEnrollFingerButton()
		{
			return btnEnrollFinger;
		}


        public Panel GetUserAccountPanel()
		{
			return userAccountPnl;
		}

        public Panel GetLeavePanel()
        {
            return LeaveApplicationPnl;

		}

        public Panel GetLeaveTypePanel()
        {
            return leaveTypeManagementPnl;
		}

        public Panel GetLeaveManagementPanel()
		{
			return leaveManagementPnl;
		}

        public Panel GetAccountArchivePanel()
        {
            return AccountArchivePnl;
        }

        public Panel GetEnrollFingerPanel()
        {
            return enrollFingerprintPnl;
		}

       public Panel GetEmployeePanel()
        {
            return employeePnl;
		}

        public Panel GetEmployeeRegisterPanel()
        {
            return registerPnl;
        }

        public Panel GetSalaryPanel()
        {
            return salaryPnl;
        }




		// Employee panel expand/collapse transition flags
		private bool employeeExpand = false;
        private bool sideBarExpand = true;

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
                employeePnl.Height += 10;
                if (employeePnl.Height >= 300)
                {
                    employeeTransition.Stop();
                    employeeExpand = true;
                }
            }
            else
            {
                employeePnl.Height -= 10;
                if (employeePnl.Height <= 52)
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
                sideBar.Width += 100;
                if (sideBar.Width >= 180)
                {
                    sideBarTransition.Stop();
                    sideBarExpand = true;
                }
            }
            else
            {
                sideBar.Width -= 100;
                if (sideBar.Width <= 0)
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
			panelContainerToBackOrToFront(false);
			// Show user registration form or activate if already open
			if (userRegister == null)
            {
                userRegister = new maintenance();
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
			
			panelContainerToBackOrToFront(true);

			
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
				
				dashboard.BringToFront();
				dashboard.Activate();
			}

			// Update the dashboard labels with the logged-in user details
			if (!string.IsNullOrEmpty(loggedInFirstName))
			{
				String fnameC = char.ToUpper(loggedInFirstName[0]) + loggedInFirstName.Substring(1);
				dashBoard.dashboardInstance.lbGetName.Text = "Welcome , " + fnameC;
				dashBoard.dashboardInstance.lbEmpID.Text = "EmployeeID: " + loggedInEmployeeID.ToString();
				dashBoard.dashboardInstance.lbLeaves.Text = loggedInLeaves.ToString();
				dashBoard.dashboardInstance.lbAbsents.Text = "Absents: " + loggedInAbsents.ToString();

				if (LoggedInDepartment == "HR" || LoggedInDepartment == "Accountant")
				{
					dashBoard.dashboardInstance.lbPanelName1.Text = "Total Employee";
				}
				else
				{
					dashBoard.dashboardInstance.lbPanelName1.Text = "Available Paid Leaves";
				}
			}
			else
			{
				dashBoard.dashboardInstance.lbGetName.Text = "Welcome , Tester <3";
			}

			byte[] imageData = m.RetrieveEmployeeImageData(loggedInEmployeeID);
			dashBoard.dashboardInstance.pbGetImageUser.Image = m.ConvertToImage(imageData);
			dashBoard.dashboardInstance.lbGetDepartment.Text = loggedInDepartment;

			// Ensure the dashboard is added to the panelContainer
			if (!panelContainer.Controls.Contains(dashboard))
			{
				panelContainer.Controls.Add(dashboard);
			}

			// Hide the back button when the dashboard is displayed
			btn_back.Visible = false;



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
			panelContainerToBackOrToFront(false);
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
			
            // Show settings form or activate if already open
            
        }

        // FormClosed event for settings form
        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            fSettings = null;
        }

        // Click event for employee registration button
        private void employee_Register(object sender, EventArgs e)
        {

			panelContainerToBackOrToFront(false);

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
			panelContainerToBackOrToFront(false);
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
			panelContainerToBackOrToFront(false);
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

        private void btnLTM_Click(object sender, EventArgs e)
        {
			panelContainerToBackOrToFront(false);
			if (ltm == null)
            {
                ltm = new leaveCategoriesManagement();
                ltm.FormClosed += LeaveTypeManagement_FormClosed;
                ltm.MdiParent = this;
                ltm.Dock = DockStyle.Fill;
                ltm.Show();
            }
            else
            {
                ltm.Activate();
            }
        }
        private void LeaveTypeManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            ltm = null;
        }

        private void btnLM_Click(object sender, EventArgs e)
        {
			panelContainerToBackOrToFront(false);
			if (lm == null)
            {
                lm = new leaveManagement();
                lm.FormClosed += LeaveManagement_FormClosed;
                lm.MdiParent = this;
                lm.Dock = DockStyle.Fill;
                lm.Show();
            }
            else
            {
                lm.Activate();
            }
        }

        private void LeaveManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            lm = null;
        }
        private void btnArchive_Click(object sender, EventArgs e)
        {
			panelContainerToBackOrToFront(false);

            if (aa == null)
            {
                aa = new accountsArchive();
                aa.FormClosed += AccountArchive_FormClosed;
                aa.MdiParent = this;
                aa.Dock = DockStyle.Fill;
                aa.Show();
            }
            else
            {
                aa.Activate();
            }
        }

        private void AccountArchive_FormClosed(object sender, FormClosedEventArgs e)
        {
            aa = null;
        }

        private void employeeAttendance_Click(object sender, EventArgs e)
        {

        }

        private void btnEnrollFinger_Click(object sender, EventArgs e)
        {
            panelContainerToBackOrToFront(false);
            if(am != null)
            {
                am.Close();
            }

            if (ef == null)
            {
                ef = new enrollFingerprint();
                ef.FormClosed += enrollFingerprint_FormClosed;
                ef.MdiParent = this;
                ef.Dock = DockStyle.Fill;
                ef.Show();
            }
            else
            {
                ef.Activate();
            }
        }

        private void enrollFingerprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            ef = null;
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

		private void BtnHistoryLog_Click(object sender, EventArgs e)
		{
			panelContainerToBackOrToFront(true);

			
			if (HistoyLogForm == null || HistoyLogForm.IsDisposed)
			{
				
				HistoyLogForm = new HistoryLogForm();
				HistoyLogForm.FormClosed += HistoyLogForm_FormClosed;
				HistoyLogForm.MdiParent = this;
				HistoyLogForm.Dock = DockStyle.Fill;
				panelContainer.Controls.Add(HistoyLogForm);
				HistoyLogForm.Show();
			}
			else
			{
				
				HistoyLogForm.BringToFront();
				HistoyLogForm.Activate();
		}


		}

		private void HistoyLogForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			HistoyLogForm = null;
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

        private void panelContainerToBackOrToFront(Boolean ifVisibile)
        {
			panelContainer.Visible = ifVisibile;
            if (ifVisibile)
            {
                panelContainer.BringToFront();
            }
            else
            {
                panelContainer.SendToBack();
			}
            
		}
    }
}
