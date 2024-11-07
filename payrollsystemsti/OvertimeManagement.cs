using payrollsystemsti.AdminTabs;
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

namespace payrollsystemsti
{
    public partial class OvertimeManagement : Form
    {
        Methods m = new Methods();
        public OvertimeManagement()
        {
            InitializeComponent();
        }

        private void lbLM_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            OT_Details OTD = new OT_Details();         
            OTD.Show();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.LastName, EmployeeAccounts.FirstName" +
                ", OvertimeApplications.Status, OvertimeApplications.Date, OvertimeApplications.StartTime, OvertimeApplications.EndTime" +
                " FROM EmployeeAccounts JOIN OvertimeApplications ON EmployeeAccounts.EmployeeID = OvertimeApplications.EmployeeID";

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
                        dataGridView1.Rows[n].Cells["dgDate"].Value = row["Date"].ToString();
                        dataGridView1.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["StartTime"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["EndTime"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
