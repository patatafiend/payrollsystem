using payrollsystemsti.EmployeeTabs;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti
{
	public partial class dashBoard : Form
	{
		private leaveApplication leaveApplication;
		public static dashBoard dashboardInstance;
		public PictureBox pbGetImageUser;
		public Label lbGetLabel;

		public dashBoard()
		{
			InitializeComponent();
			InitializeEventHandlers();
			dashboardInstance = this;
			pbGetImageUser = pbCurrentUser;
			lbGetLabel = lbWelcome;
		}

		private void InitializeEventHandlers()
		{
			pnl_Leave.Click += Pnl_leave_Click;
		}

		private void Pnl_leave_Click(object sender, EventArgs e)
		{
			leaveApplication = new leaveApplication();
			leaveApplication.ShowDialog();
		}

		private void dashBoard_Load(object sender, EventArgs e)
		{
			
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True;";

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(connectionString))
				{
					
					sqlConn.Open();

					// Create a SqlCommand to count the number of employees
					string query = "SELECT COUNT(*) FROM EmployeeAccounts";
					using (SqlCommand cmd = new SqlCommand(query, sqlConn))
					{
						// ExecuteScalar returns the first column of the first row
						int numberOfEmployees = Convert.ToInt32(cmd.ExecuteScalar());

						// Display the number of employees in a label
						lb_EmployeeNum.Text = $"Number of Employees: {numberOfEmployees}";
					}
				}
			}
			catch (Exception ex)
			{
				// Handle the exception
				MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void lb_DashBoard_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lb_EmployeeNum_Click(object sender, EventArgs e)
        {

        }

        private void pnl_Employee_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
