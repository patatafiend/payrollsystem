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
        private ViewAttendance viewA;
        private DepartmentMain DepartmentMain;
        private Position Position;
        private Roles Roles;
        private LeavesM LeavesM;
        private Deduction Deduction;
        private Allowance Allowance;
        private OthersM OthersM;
        private IncentivesM Incentives;
        private HolidaysM holidays;
        private BackupRestore BRestore;




        //draggable panel shit
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


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

        

        public Button BackButton
        {
            get { return btn_back; }
            set { btn_back = value; }
        }


        // Form constructor
        public formDashboard()
        {
            InitializeComponent();
            formDashboardInstance = this;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            
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

        public Panel GetHistoryPanel()
        {
            return HIstoryLogPnl;
        }

        public Panel GetMaintenancePanel()
		{
			return maintinanceC;
		}

        public Panel GetBackupAndRestorePanel()
        {
            return panel15;

		}






        // Employee panel expand/collapse transition flags
        private bool employeeExpand = false;
        private bool sideBarExpand = true;
        private bool maintinanceExpand = false;

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
            mtransition.Start();
            
            // Show user registration form or activate if already open
            //if (userRegister == null)
            //         {
            //             userRegister = new maintenance();
            //             userRegister.FormClosed += userRegister_FormClosed;
            //             userRegister.MdiParent = this;
            //             userRegister.Dock = DockStyle.Fill;
            //             userRegister.Show();
            //         }
            //         else
            //         {
            //             userRegister.Activate();
            //         }

        }





        // FormClosed event for user registration form
        private void userRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            userRegister = null;
        }

        // Click event for dashboard button
        private void dashBoard_btn(object sender, EventArgs e)
        {

            


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
                dashBoard.dashboardInstance.lbEmpName.Text = "Name: " + fnameC;

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
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + ", " + Methods.CurrentUser.FirstName + "Logged out.");
			fm_Login.Show();
        }
        // Click event for settings button
        private void settings_Click(object sender, EventArgs e)
        {
            
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
                leaveApplication.leaveApplicationInstance.LoggedInEmpID = loggedInEmployeeID;
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
            
            if (viewA == null)
            {
                viewA = new ViewAttendance();
                viewA.FormClosed += ViewAttedance_FormClosed;
                viewA.MdiParent = this;
                viewA.Dock = DockStyle.Fill;
                ViewAttendance.va.employeeID = loggedInEmployeeID;
                viewA.Show();
            }
            else
            {
                viewA.Activate();
            }

        }

        private void ViewAttedance_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewA = null;
        }

        private void btnEnrollFinger_Click(object sender, EventArgs e)
        {
            
            if (am != null)
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
				m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + ", " + Methods.CurrentUser.FirstName + "Logged out.");


			}
        }

		private void BtnHistoryLog_Click(object sender, EventArgs e)
		{
			

			if (HistoyLogForm == null)
			{
				HistoyLogForm = new HistoryLogForm();
				HistoyLogForm.FormClosed += HistoyLogForm_FormClosed;
				HistoyLogForm.MdiParent = this;
				HistoyLogForm.Dock = DockStyle.Fill;
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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void employeePnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (DepartmentMain == null)
            {
                DepartmentMain = new DepartmentMain();
                DepartmentMain.FormClosed += Department_FormClosed;
                DepartmentMain.MdiParent = this;
                DepartmentMain.Dock = DockStyle.Fill;
                DepartmentMain.Show();
            }
            else
            {
                DepartmentMain.Activate();

            }
        }
        private void Department_FormClosed(object sender, FormClosedEventArgs e)
        {
            DepartmentMain = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mtransition_Tick(object sender, EventArgs e)
        {
            if (maintinanceExpand == false)
            {
                maintinanceC.Height += 10;
                if (maintinanceC.Height >= 600)
                {
                    mtransition.Stop();
                    maintinanceExpand = true;
                }
            }
            else
            {
                maintinanceC.Height -= 10;
                if (maintinanceC.Height <= 52)
                {
                    mtransition.Stop();
                    maintinanceExpand = false;
                }
            }
        }

        private void maintinanceC_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            if (OthersM == null)
            {
                OthersM = new OthersM();
                OthersM.FormClosed += OthersM_FormClosed;
                OthersM.MdiParent = this;
                OthersM.Dock = DockStyle.Fill;
                OthersM.Show();
            }
            else
            {
                OthersM.Activate();

            }
        }
        private void OthersM_FormClosed(object sender, FormClosedEventArgs e)
        {
            OthersM = null;
        }

    

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            

            if (Position == null)
            {
                Position = new Position();
                Position.FormClosed += Position_FormClosed;
                Position.MdiParent = this;
                Position.Dock = DockStyle.Fill;
                Position.Show();
            }
            else
            {
                Position.Activate();

            }
        }
        private void Position_FormClosed(object sender, FormClosedEventArgs e)
        {
            Position = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            if (Roles == null)
            {
                Roles  = new Roles();
                Roles.FormClosed += Roles_FormClosed;
                Roles.MdiParent = this;
                Roles.Dock = DockStyle.Fill;
                Roles.Show();
            }
            else
            {
                Roles.Activate();

            }
        } 
    
        private void Roles_FormClosed(object sender, FormClosedEventArgs e)
        {
            Roles = null;
        
    }

        private void button5_Click(object sender, EventArgs e)
        {

            if (LeavesM == null)
            {
                LeavesM = new LeavesM();
                LeavesM.FormClosed += LeavesM_FormClosed;
                LeavesM.MdiParent = this;
                LeavesM.Dock = DockStyle.Fill;
                LeavesM.Show();
            }
            else
            {
                LeavesM.Activate();

            }
        }
        private void LeavesM_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeavesM = null;
        
    }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (Deduction == null)
            {
                Deduction = new Deduction();
                Deduction.FormClosed += Deduction_FormClosed;
                Deduction.MdiParent = this;
                Deduction.Dock = DockStyle.Fill;
                Deduction.Show();
            }
            else
            {
                Deduction.Activate();

            }
        }
        private void Deduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            Deduction = null;

        
    }

        private void button7_Click(object sender, EventArgs e)
        {

            if (Allowance == null)
            {
                
                Allowance = new Allowance();
                Allowance.FormClosed += Allowance_FormClosed;
                Allowance.MdiParent = this;
                Allowance.Dock = DockStyle.Fill;
                Allowance.Show();



            }
            else
            {
                Allowance.Activate();
            }
        }
        private void Allowance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Allowance = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            

            if (holidays == null)
            {
                holidays = new HolidaysM();
                holidays.FormClosed += HolidaysM_FormClosed;
                holidays.MdiParent = this;
                holidays.Dock = DockStyle.Fill;
                holidays.Show();
            }
            else
            {
                holidays.Activate();
            }
        }
        private void HolidaysM_FormClosed(object sender, FormClosedEventArgs e)
        {
            holidays = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            

            if (Incentives == null)
            {
                Incentives = new IncentivesM();
                Incentives.FormClosed += IncentivesM_FormClosed;
                Incentives.MdiParent = this;
                Incentives.Dock = DockStyle.Fill;
                Incentives.Show();
            }
            else
            {
                Incentives.Activate();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (BRestore == null)
            {
                BRestore = new BackupRestore();
                BRestore.FormClosed += BackupRestore_FormClosed;
                BRestore.MdiParent = this;
                BRestore.Dock = DockStyle.Fill;
                BRestore.Show();
            }
            else
            {
                BRestore.BringToFront();
                BRestore.Activate();
            }

        }
        private void BackupRestore_FormClosed(object sender, FormClosedEventArgs e)
        {
            BRestore = null;
        }

            private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IncentivesM_FormClosed(object sender, FormClosedEventArgs e)
        {
            Incentives = null;
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
