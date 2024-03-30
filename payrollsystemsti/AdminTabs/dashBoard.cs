using payrollsystemsti.AdminTabs;
using payrollsystemsti.EmployeeTabs;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class dashBoard : Form
    {
        Methods m = new Methods();

        
        private leaveApplication leaveApplication;
        private departmentList DepartmentList;
        public static dashBoard dashboardInstance;
        public PictureBox pbGetImageUser;
        public Label lbGetName;
        public Label lbGetDepartment;
        public Label lbEmpID;

        public static Boolean isClickable;

        public dashBoard()
        {
            InitializeComponent();
            InitializeEventHandlers();
            dashboardInstance = this;
            pbGetImageUser = pbCurrentUser;
            lbGetName = lbWelcome;
			lbGetDepartment = lb_curDepartment;
            lbEmpID = lbEmployeeID;

		}

		private void dashBoard_Load(object sender, EventArgs e)
		{
			LoadEmployeeCount();

            

		}

		public Panel GetEmployeePanel()
		{
			return pnl_Employee;
		}

		private void InitializeEventHandlers()
        {
            pnl_Employee.Click += Pnl_Employee_Click;
            pnl_Department.Click += Pnl_Department_Click;
        }

        private void Pnl_leave_Click(object sender, EventArgs e) //Leave Application
        {
            leaveApplication = new leaveApplication();
            leaveApplication.ShowDialog();
        }

        //employee list
        private void Pnl_Employee_Click(object sender, EventArgs e) 
        {
			
			if (isClickable)
            {
				
				var employeeListForm = formDashboard.Instance.PnlContainer.Controls.OfType<employeeList>().FirstOrDefault();

				if (employeeListForm == null)
				{
					employeeListForm = new employeeList()
					{
						Dock = DockStyle.Fill,
						Name = "employeeList",
						TopLevel = false,

					};
					formDashboard.Instance.PnlContainer.Controls.Add(employeeListForm);
					employeeListForm.Show();
				}

				employeeListForm.BringToFront();

            }
            
			
			
		}

		//department list

		private void Pnl_Department_Click(object sender, EventArgs e)
        {
            if (isClickable)
            {
				var departmentListForm = formDashboard.Instance.PnlContainer.Controls.OfType<departmentList>().FirstOrDefault();

				if (departmentListForm == null)
				{
					departmentListForm = new departmentList()
					{
						Dock = DockStyle.Fill,
						Name = "departmentList",
						TopLevel = false,

					};
					formDashboard.Instance.PnlContainer.Controls.Add(departmentListForm);
					departmentListForm.Show();
				}

				departmentListForm.BringToFront();
			}
			
		}

        private void DepartmentList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DepartmentList = null;
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
