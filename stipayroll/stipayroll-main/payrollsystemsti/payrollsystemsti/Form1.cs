using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti
{
	public partial class fm_login : Form
	{
		private bool isClosing; 
		private bool loggedIn = false;
		private string loggedInUserName;

		public string LoggedInUserName
		{
			get { return loggedInUserName; }
			private set { loggedInUserName = value; }
		}

		public fm_login()
		{
			InitializeComponent();
		}

		private void bt_login_Click(object sender, EventArgs e)
		{
			using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
			{
				try
				{
					conn.Open();
					string query = "SELECT Role, Name FROM users WHERE Username=@username AND Password=@password";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@username", tb_username.Text);
						cmd.Parameters.AddWithValue("@password", tb_password.Text);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								string role = reader["Role"].ToString();
								string userName = reader["Name"].ToString();

								loggedIn = true;
								LoggedInUserName = userName;
								this.Hide();
								formDashboard dashboard = new formDashboard();
								dashboard.LoggedInUserName = LoggedInUserName;
								dashboard.Show();

								if (role != "Admin") //disable function if not admin
								{
									Button userAccountButton = dashboard.GetUserAccountButton();
									userAccountButton.Hide();
									userAccountButton.Enabled = false;
								}
							}
							else
							{
								MessageBox.Show("Login Failed!", "Error");
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

		public bool IsLoggedIn()
		{
			return loggedIn;
		}

		public string GetLoggedInUserName()
		{
			return LoggedInUserName;
		}

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
			this.ActiveControl = tb_username;
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			
		}

		private void tb_username_TextChanged(object sender, EventArgs e)
		{
			
		}

		private bool close;
	}
}
