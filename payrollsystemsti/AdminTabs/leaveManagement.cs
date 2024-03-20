using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class leaveManagement : Form
    {
        Methods m = new Methods();
        private int employeeID;
        public leaveManagement()
        {
            InitializeComponent();
        }

        private void leaveManagement_Load(object sender, System.EventArgs e)
        {
            LoadData();
            btnUpdate.Enabled = false;
            btnView.Enabled = false;
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            leaveDetails ld = new leaveDetails();
            ld.Show();
            leaveDetails.ld.employeeID = employeeID;
            
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

                    string catQuery = "SELECT CategoryName";
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
            employeeID = (int)dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value;
        }
    }
}
