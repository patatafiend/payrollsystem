﻿using payrollsystemsti.AdminTabs;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace payrollsystemsti
{
	public partial class formLogin : Form
	{
		Methods m = new Methods();
		formDashboard formDashboard = new formDashboard();
		public static formLogin formLoginInstance;
		dashBoard dashBoard = new dashBoard();
		attendanceMonitoring attedanceMonitoring = new attendanceMonitoring();

		// Draggable panel code
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HTCAPTION = 0x2;
		[DllImport("User32.dll")]
		public static extern bool ReleaseCapture();
		[DllImport("User32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		public formLogin()
		{
			InitializeComponent();
			formLoginInstance = this;
		}

		private void bt_login_Click(object sender, EventArgs e)
		{
			if (LogIN(tbUserName.Text, tbPassword.Text))
			{
				MessageBox.Show("Login Successful");
			}
			else
			{
				MessageBox.Show("Login Failed");
			}
		}

		private bool LogIN(string user, string pass)
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				try
				{
					conn.Open();
					string query = "SELECT UserAccounts.UserID, UserAccounts.Username, UserAccounts.EmployeeID, " +
						"EmployeeAccounts.FirstName, EmployeeAccounts.LastName, EmployeeAccounts.DepartmentID, " +
						"EmployeeAccounts.Leaves, EmployeeAccounts.Absents, EmployeeAccounts.RoleID FROM UserAccounts " +
						"INNER JOIN EmployeeAccounts ON UserAccounts.EmployeeID = EmployeeAccounts.EmployeeID WHERE " +
						"Username=@username AND Password=@password AND IsDeactivated = @status";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@username", user);
						cmd.Parameters.AddWithValue("@password", pass);
						cmd.Parameters.AddWithValue("@status", 0);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								// Set CurrentUser properties
								Methods.CurrentUser.UserID = (int)reader["UserID"];
								Methods.CurrentUser.Username = reader["Username"].ToString();
								Methods.CurrentUser.FirstName = reader["FirstName"].ToString();
								Methods.CurrentUser.LastName = reader["LastName"].ToString();

								int employeeID = (int)reader["EmployeeID"];
								int numLeaves = (int)reader["Leaves"];
								int numAbsents = (int)reader["Absents"];
								int totalEmployee = m.GetTotalEmployeeCount();

								int roleID = (int)reader["RoleID"];
								string departmentName = m.getDepartmentName((int)reader["DepartmentID"]);
								int departmentID = (int)reader["DepartmentID"];

								// Log the login time
								LogLoginTime(employeeID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, departmentID, numLeaves, numAbsents);

								this.Hide();
								formDashboard.formDashboardInstance.LoggedInEmployeeID = employeeID;
								formDashboard.formDashboardInstance.LoggedInFirstName = Methods.CurrentUser.FirstName;
								formDashboard.formDashboardInstance.LoggedInDepartment = departmentName;
								formDashboard.formDashboardInstance.LoggedInAbsents = numAbsents;

								// Disable function based on role/department
								if (roleID == 4)
								{
									if (departmentID == 2) // HR
									{
										formDashboard.GetEnrollFingerPanel().Hide();
										formDashboard.formDashboardInstance.LoggedInLeaves = totalEmployee;
										dashBoard.isClickable = true;
									}
									else if (departmentID == 4) // Accounting
									{
										formDashboard.GetUserAccountPanel().Hide();
										formDashboard.GetEnrollFingerPanel().Hide();
										formDashboard.GetLeaveManagementPanel().Hide();
										formDashboard.GetAccountArchivePanel().Hide();
										formDashboard.GetHistoryPanel().Hide();
										formDashboard.formDashboardInstance.LoggedInLeaves = numLeaves;
										dashBoard.isClickable = true;
									}
									else if (departmentID == 1) // Sales
									{
										formDashboard.GetUserAccountPanel().Hide();
										formDashboard.GetLeaveManagementPanel().Hide();
										formDashboard.GetAccountArchivePanel().Hide();
										formDashboard.GetEnrollFingerPanel().Hide();
										formDashboard.GetEmployeeRegisterPanel().Hide();
										formDashboard.GetSalaryPanel().Hide();
										formDashboard.GetHistoryPanel().Hide();
										formDashboard.formDashboardInstance.LoggedInLeaves = numLeaves;
										dashBoard.isClickable = false;
									}
									else if (departmentID == 3) // Logistics
									{
										formDashboard.GetEnrollFingerPanel().Hide();
										formDashboard.formDashboardInstance.LoggedInLeaves = numLeaves;
										dashBoard.isClickable = true;
									}
									else if (departmentID == 5) // Another Department
									{
										formDashboard.GetEnrollFingerPanel().Hide();
										formDashboard.formDashboardInstance.LoggedInLeaves = numLeaves;
										dashBoard.isClickable = true;
									}
									else if (departmentID == 6) // Another Department
									{
										formDashboard.GetEnrollFingerPanel().Hide();
										formDashboard.formDashboardInstance.LoggedInLeaves = numLeaves;
										dashBoard.isClickable = true;
									}
								}
								else // Admin
								{
									formDashboard.formDashboardInstance.LoggedInLeaves = totalEmployee;
									dashBoard.isClickable = true;
								}
								formDashboard.Show();
								return true;
							}
							else
							{
								MessageBox.Show("Login Failed! Invalid username or password.", "Error");
								return false;
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"An error occurred: {ex.GetType().Name}\n\nDetails:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error");
					return false;
				}
			}
		}

		private void loginForm_Load(object sender, EventArgs e)
		{
			this.ActiveControl = tbUserName;
			tbPassword.PasswordChar = '*';
		}

		private void tbUserName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (tbUserName.Text.Length > 0)
				{
					tbPassword.Focus();
				}
				else
				{
					tbUserName.Focus();
				}
			}
		}

		private void tbPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (tbPassword.Text.Length > 0)
				{
					btnLogin.Focus();
				}
				else
				{
					tbPassword.Focus();
				}
			}
		}

		private void btnMin_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void btnMax_Click(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Maximized)
			{
				WindowState = FormWindowState.Normal;
			}
			else
			{
				WindowState = FormWindowState.Maximized;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void loginHeader_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
			}
		}

		private void btnCheckIn_Click(object sender, EventArgs e)
		{
			attedanceMonitoring.Show();
		}

		private void LogLoginTime(int employeeID, string firstName, string lastName, int department, int leaves, int absents)
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				try
				{
					conn.Open();
					string insertQuery = "INSERT INTO HistoryTable (EmployeeID, FirstName, LastName, Department, Leaves, Absents, LoginTime) " +
										 "VALUES (@employeeID, @firstName, @lastName, @department, @leaves, @absents, @loginTime)";
					using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
					{
						cmd.Parameters.AddWithValue("@employeeID", employeeID);
						cmd.Parameters.AddWithValue("@firstName", firstName);
						cmd.Parameters.AddWithValue("@lastName", lastName);
						cmd.Parameters.AddWithValue("@department", department);
						cmd.Parameters.AddWithValue("@leaves", leaves);
						cmd.Parameters.AddWithValue("@absents", absents);
						cmd.Parameters.AddWithValue("@loginTime", DateTime.Now);
						cmd.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"An error occurred while logging the login time: {ex.GetType().Name}\n\nDetails:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error");
				}
			}
		}
	}
}
