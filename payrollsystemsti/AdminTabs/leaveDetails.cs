using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class leaveDetails : Form
    {
        Methods m = new Methods();
        public static leaveDetails ld;
        public leaveDetails()
        {
            InitializeComponent();
            ld = this;
        }
        private int empID;
        public int employeeID
        {
            set
            {
                empID = value;
            }
            get
            {
                return empID;
            }
        }

        private void leaveDetails_Load(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.FirstName, EmployeeAccounts.LastName," +
                " EmployeeAccounts.DepartmentID, EmployeeAccounts.PositionID, LeaveApplications.DateStart, LeaveApplications.DateEnd" +
                ", LeaveApplications.CategoryName, LeaveApplications.Reason FROM EmployeeAccounts JOIN LeaveApplications" +
                " ON EmployeeAccounts.EmployeeID = LeaveApplications.EmployeeID";
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbEmpID.Text = reader["EmployeeID"].ToString();
                            lbFullName.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                            lbDepartment.Text = reader["DepartmentID"].ToString();
                            lbPosition.Text = reader["PositionID"].ToString();
                            lbDateRange.Text = "Starting from " + reader["DateStart"].ToString() + " to " + reader["DateEnd"].ToString();
                            lbLeaveType.Text = reader["CategoryName"].ToString();
                            lbReason.Text = reader["Reason"].ToString();
                        }
                    }
                }
            }
        }
    }
}
