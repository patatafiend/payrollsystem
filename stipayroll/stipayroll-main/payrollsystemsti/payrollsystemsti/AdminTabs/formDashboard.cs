using payrollsystemsti.AdminTabs;
using payrollsystemsti.EmployeeTabs;
using payrollsystemsti.Tabs;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace payrollsystemsti
{
	public partial class formDashboard : Form
	{
		// Declare form instances
		private dashBoard dashboard;
		private userRegister userRegister;
		private formSettings fSettings;
		private employeeRegister empRegister;
		private employeeSalary employeeSalary;
		private leaveApplication leaveApplication;

		private bool logout = false;
		private bool closedForm = true;
		private bool isClosing = false;


		// Logged-in user name property
		private string loggedInUserName;
        private int loggedInEmployeeID;
        private byte[] RetrieveEmployeeImageData(int employeeID)
        {
            // Implement your logic to fetch ImageData from EmployeeAccounts table based on EmployeeID
            byte[] imageData = null;
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
            {
				conn.Open();
                string imageQuery = "SELECT ImageData FROM EmployeeAccounts WHERE EmployeeID = @employeeID";

                using (SqlCommand imageCmd = new SqlCommand(imageQuery, conn))
                {
                    imageCmd.Parameters.AddWithValue("@employeeID", employeeID);

                    using (SqlDataReader imageReader = imageCmd.ExecuteReader())
                    {
                        if (imageReader.Read())
                        {
                            if (!(imageReader["ImageData"] is DBNull))
                            {
                                imageData = (byte[])imageReader["ImageData"];
                            }
                        }
                    }
                }
            }
            return imageData;
        }
        public static Image ConvertToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
            }
        }

        public string LoggedInUserName
		{
			get { return loggedInUserName; }
			set
			{
				loggedInUserName = value;
				// Update the label with logged-in user name
				lb_User_Username.Text = "Name: " + loggedInUserName;
            }
		}
        public int LoggedInEmployeeID
		{
			get { return loggedInEmployeeID;}
			set
			{
				loggedInEmployeeID = value;
				lbEmployeeID.Text = loggedInEmployeeID.ToString();
			}
		}

        
        // Get user account button
        public Button GetUserAccountButton()
        {
            return btn_useraccount;
        }
		

        // Employee panel expand/collapse transition flags
        private bool employeeExpand = false;
		private bool sideBarExpand = false;

		// Form constructor
		public formDashboard()
		{
			InitializeComponent();
		}

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
				userRegister = new userRegister();
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
            byte[] imageData = RetrieveEmployeeImageData(loggedInEmployeeID);
            dashBoard.dashboardInstance.pbGetImageUser.Image = ConvertToImage(imageData);
        }

        // FormClosed event for dashboard form
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
		{
			dashboard = null;
		}

		// Click event for logout button
		private void btnLogout(object sender, EventArgs e)
		{
			logout = true;
			this.Close();
		}

		// FormClosing event for the dashboard form
		private void formDashboard_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (closedForm && logout == false)
			{
				if (!isClosing)
				{
					DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						isClosing = true;
						Application.Exit();
					}
					else
					{
						e.Cancel = true;
					}
				}
			}
			else if (logout)
			{
				DialogResult result = MessageBox.Show("Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					formLogin fm_Login = new formLogin();
					fm_Login.Show();
				}
				else
				{
					e.Cancel = true;
				}
			}
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
        }

        private void LeaveApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            leaveApplication = null;
        }
    }
}
