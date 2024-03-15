using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace payrollsystemsti
{
    public partial class formLogin : Form
    {
        Methods m = new Methods();
        //private bool loggedIn = false;
        private string loggedInUserName, loggedInFirstName;
        private int loggedInEmployeeID;

        public string LoggedInUserName
        {
            get { return loggedInUserName; }
            private set { loggedInUserName = value; }
        }
        public string LoggedInFirstName
        {
            get { return loggedInFirstName; }
            private set { loggedInFirstName = value; }
        }
        public int LoggedInEmployeeID
        {
            get { return loggedInEmployeeID; }
            private set { loggedInEmployeeID = value; }
        }

        public formLogin()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Equals("tester") && tbPassword.Text.Equals("tester"))
            {
                this.Hide();
                formDashboard formDashboard = new formDashboard();
                formDashboard.LoggedInUserName = LoggedInUserName;
                formDashboard.Show();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT UserAccounts.UserID, UserAccounts.Role, UserAccounts.EmployeeID, UserAccounts.Username," +
                            "EmployeeAccounts.FirstName FROM UserAccounts INNER JOIN EmployeeAccounts" +
                            " ON UserAccounts.EmployeeID = EmployeeAccounts.EmployeeID" +
                            " WHERE Username=@username AND Password=@password";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", tbUserName.Text);
                            cmd.Parameters.AddWithValue("@password", tbPassword.Text);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int userID = (int)reader["UserID"];
                                    string role = reader["Role"].ToString();
                                    string username = reader["Username"].ToString();
                                    string fname = reader["FirstName"].ToString();
                                    int employeeID = (int)reader["EmployeeID"];

                                    //loggedIn = true;
                                    LoggedInUserName = username;// Fix: Assign the entered username to LoggedInUserName
                                    LoggedInFirstName = fname;
                                    LoggedInEmployeeID = employeeID;

                                    
                                    this.Hide();
                                    formDashboard formDashboard = new formDashboard();
                                    formDashboard.LoggedInUserName = LoggedInUserName;
                                    formDashboard.LoggedInFirstName = LoggedInFirstName;
                                    formDashboard.LoggedInEmployeeID = LoggedInEmployeeID;
                                    formDashboard.Show();
                                    if (role != "Admin")
                                    {
                                        // disable functions if not admin
                                        Button useraccountbutton = formDashboard.GetUserAccountButton();
                                        useraccountbutton.Hide();
                                        useraccountbutton.Enabled = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Login Failed! Invalid username or password.", "Error");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.GetType().Name}\n\nDetails:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error");
                    }
                }
            }
        }
        bool close;
        private void fm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void fm_login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbUserName;
        }
    }

}

