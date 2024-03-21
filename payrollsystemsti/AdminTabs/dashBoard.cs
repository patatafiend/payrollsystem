using payrollsystemsti.AdminTabs;
using payrollsystemsti.EmployeeTabs;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class dashBoard : Form
    {
        Methods m = new Methods();

        private formDashboard formDashboard;
        private leaveApplication leaveApplication;
        private employeeList EmployeeList;
        private departmentList DepartmentList;
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

		private void dashBoard_Load(object sender, EventArgs e)
		{
			LoadEmployeeCount();

		}

		private void InitializeEventHandlers()
        {
            pnl_Leave.Click += Pnl_leave_Click;
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
            if(EmployeeList == null)
            {
				EmployeeList = new employeeList();
				EmployeeList.FormClosed += EmployeeList_FormClosed;
                EmployeeList.MdiParent = formDashboard;
                EmployeeList.Dock = DockStyle.Fill;

				EmployeeList.Show();
			}
			else
            {
				EmployeeList.Activate();
			}
			


		}

        //department list

        private void Pnl_Department_Click(object sender, EventArgs e)
        {
			if(DepartmentList == null)
            {
                DepartmentList = new departmentList();
                DepartmentList.FormClosed += DepartmentList_FormClosed;
                DepartmentList.MdiParent = formDashboard;
                DepartmentList.Dock = DockStyle.Fill;
                DepartmentList.Show();

            }  
            else
            {
				DepartmentList.Activate();
			}
		}

        private void DepartmentList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DepartmentList = null;
        }

        private void EmployeeList_FormClosed(object sender, FormClosedEventArgs e)
        {
			EmployeeList = null;
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
