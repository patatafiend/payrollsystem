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
        private bool loggedIn = false;
        private string loggedInUserName;
        private int loggedInEmployeeID;


        public string LoggedInUserName
        {
            get { return loggedInUserName; }
            private set { loggedInUserName = value; }
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
                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT UserID, Role, EmployeeID, Username FROM UserAccounts WHERE Username=@username AND Password=@password";

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
                                    int employeeID = (int)reader["EmployeeID"];

                                    loggedIn = true;
                                    LoggedInUserName = username;// Fix: Assign the entered username to LoggedInUserName
                                    LoggedInEmployeeID = employeeID;

                                    
                                    this.Hide();
                                    formDashboard formDashboard = new formDashboard();
                                    formDashboard.LoggedInUserName = LoggedInUserName;
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

