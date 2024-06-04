using payrollsystemsti.AdminTabs;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace payrollsystemsti
{
    public partial class formLogin : Form
    {
        Methods m = new Methods();
        formDashboard formDashboard = new formDashboard();
        public static formLogin formLoginInstance;
        dashBoard dashBoard = new dashBoard();
        attendanceMonitoring attedanceMonitoring = new attendanceMonitoring();

		//draggable panel shit
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
			if(LogInTester(tbUserName.Text, tbPassword.Text))
			{
                this.Hide();
                formDashboard.Show();
                formDashboard.formDashboardInstance.LoggedInLeaves = m.GetTotalEmployeeCount();
                dashBoard.isClickable = true;

                LogLoginTime(0, "Tester", "User", 0, 0, 0); // Assuming 0 or dummy values for tester
            }
		}
        private bool LogInTester(string user, string password)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Username, Password FROM UserAccounts WHERE Username = @user AND Password = @pass";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", "tester");
                    cmd.Parameters.AddWithValue("@pass", "tester");

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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
                                int userID = (int)reader["UserID"];
                                int employeeID = (int)reader["EmployeeID"];
                                int numLeaves = (int)reader["Leaves"];
                                int numAbsents = (int)reader["Absents"];
                                int totalEmployee = m.GetTotalEmployeeCount();

                                int roleID = (int)reader["RoleID"];
                                string departmentName = m.getDepartmentName((int)reader["DepartmentID"]);
                                int departmentID = (int)reader["DepartmentID"];

                                


                                string username = reader["Username"].ToString();
                                string fname = reader["FirstName"].ToString();
                                string lname = reader["LastName"].ToString();  // LastName added


                                // Log the login time
                                LogLoginTime(employeeID, fname, lname, 0, numLeaves, numAbsents);

                                this.Hide();
                                formDashboard.formDashboardInstance.LoggedInEmployeeID = employeeID;
                                formDashboard.formDashboardInstance.LoggedInFirstName = fname;
                                formDashboard.formDashboardInstance.LoggedInDepartment = departmentName;
                                formDashboard.formDashboardInstance.LoggedInAbsents = numAbsents;

                                // Disable function based on role/department
                                if (roleID == 4)
                                {
                                    
                                    if (departmentID == 2)
                                    {
                                        formDashboard.GetEnrollFingerPanel().Hide();
                                        formDashboard.formDashboardInstance.LoggedInLeaves = totalEmployee;
                                        dashBoard.isClickable = true;
                                    }
                                    else if (departmentID == 4)
                                    {
                                        formDashboard.GetUserAccountPanel().Hide();
                                        formDashboard.GetEnrollFingerPanel().Hide();
                                        formDashboard.GetLeaveTypePanel().Hide();
                                        formDashboard.GetLeaveManagementPanel().Hide();
                                        formDashboard.GetAccountArchivePanel().Hide();
                                        formDashboard.formDashboardInstance.LoggedInLeaves = totalEmployee;
                                        dashBoard.isClickable = true;
                                    }
                                    else if(departmentID == 1)
                                    {
                                        formDashboard.GetUserAccountPanel().Hide();
                                        formDashboard.GetLeaveTypePanel().Hide();
                                        formDashboard.GetLeaveManagementPanel().Hide();
                                        formDashboard.GetAccountArchivePanel().Hide();
                                        formDashboard.GetEnrollFingerPanel().Hide();
                                        formDashboard.GetEmployeeRegisterPanel().Hide();
                                        formDashboard.GetSalaryPanel().Hide();
                                        formDashboard.formDashboardInstance.LoggedInLeaves = numLeaves;
                                        dashBoard.isClickable = false;
                                    }
                                }
                                else // Admin
                                {
                                    Console.WriteLine("fdSfsdfsdfsdf" + departmentID);
                                    formDashboard.formDashboardInstance.LoggedInLeaves = totalEmployee;
                                    dashBoard.isClickable = true;
                                }
                                MessageBox.Show("ssadasdssdsasadAASDASDASDASDASD " + departmentID);
                                Console.WriteLine("fdSfsdfsdfsdf" + departmentID);
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
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if(tbUserName.Text.Length > 0)
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

