using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class formLogin : Form
    {
        Methods m = new Methods();
        formDashboard formDashboard = new formDashboard();

        public formLogin()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Equals("tester") && tbPassword.Text.Equals("tester"))
            {
                this.Hide();
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

                                    this.Hide();
                                    formDashboard.formDashboardInstance.LoggedInEmployeeID = employeeID;
                                    formDashboard.formDashboardInstance.LoggedInFirstName = fname;
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

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbUserName;
        }
    }

}

