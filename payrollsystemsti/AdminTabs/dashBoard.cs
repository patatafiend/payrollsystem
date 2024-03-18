using payrollsystemsti.EmployeeTabs;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class dashBoard : Form
    {
        Methods m = new Methods();
        private leaveApplication leaveApplication;
        public static dashBoard dashboardInstance;
        public PictureBox pbGetImageUser;
        public Label lbGetName;
        public Label lbGetDepartment;


        public dashBoard()
        {
            InitializeComponent();
            InitializeEventHandlers();
            dashboardInstance = this;
            pbGetImageUser = pbCurrentUser;
            lbGetName = lbWelcome;
			lbGetDepartment = lb_curDepartment;

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
            LoadEmployeeCount();

        }
        void LoadEmployeeCount()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();

                    // Create a SqlCommand to count the number of employees
                    string query = "SELECT COUNT(*) FROM EmployeeAccounts";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ExecuteScalar returns the first column of the first row
                        int numberOfEmployees = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the number of employees in a label
                        lb_EmployeeNum.Text = $"{numberOfEmployees}";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
	}

}
