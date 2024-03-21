using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Markup;

namespace payrollsystemsti.AdminTabs
{
    public partial class leaveManagement : Form
    {
        Methods m = new Methods();
        private string employeeID;
        public leaveManagement()
        {
            InitializeComponent();
        }

        private void leaveManagement_Load(object sender, System.EventArgs e)
        {
            LoadData();
            btnUpdate.Enabled = false;
            btnView.Enabled = false;
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            leaveDetails ld = new leaveDetails();
            leaveDetails.ld.employeeID = Int32.Parse(employeeID);
            ld.Show();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.LastName, EmployeeAccounts.FirstName" +
                ", LeaveApplications.Status, LeaveApplications.CategoryName FROM EmployeeAccounts JOIN LeaveApplications" +
                " ON EmployeeAccounts.EmployeeID = LeaveApplications.EmployeeID";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgName"].Value = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
                        dataGridView1.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveType"].Value = row["CategoryName"].ToString();
                    }
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            employeeID = dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value.ToString();

            btnUpdate.Enabled = true;
            btnView.Enabled = true;
            btnApprove.Enabled = true;
            btnReject.Enabled = true;
        }
        
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if(employeeID != "0")
            {
                string query = "UPDATE LeaveApplications SET Status = @status WHERE EmployeeID = @employeeID";
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Approved");
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);

                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (employeeID != "0")
            {
                string query = "UPDATE LeaveApplications SET Status = @status WHERE EmployeeID = @employeeID";
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Rejected");
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);

                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
