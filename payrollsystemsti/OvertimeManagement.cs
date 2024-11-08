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
        leaveManagement lm = new leaveManagement();
        int empID = 0;
        string date, timein, timeout;
        public OvertimeManagement()
        {
            InitializeComponent();
        }

        private void lbLM_Click(object sender, EventArgs e)
        {

        }


        private void btnView_Click(object sender, EventArgs e)
        {
            OT_Details OTD = new OT_Details();
            OT_Details.ot.employeeID = empID;
            OT_Details.ot.AppDate = date;
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
                        dataGridView1.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(row["Date"]).ToString("MM/dd/yyyy");
                        dataGridView1.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["StartTime"].ToString()).ToString("hh:mm tt");
                        dataGridView1.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["EndTime"].ToString()).ToString("hh:mm tt");
                    }
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            empID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value);
            date = dataGridView1.SelectedRows[0].Cells["dgDate"].Value.ToString();
            timein = dataGridView1.SelectedRows[0].Cells["dgStart"].Value.ToString();
            timeout = dataGridView1.SelectedRows[0].Cells["dgEnd"].Value.ToString();
            btnApprove.Enabled = true;
            btnReject.Enabled = true;
            btnView.Enabled = true;

            string status = dataGridView1.SelectedRows[0].Cells["dgStatus"].Value.ToString();

            if (status == "Approved" || status == "Rejected")
            {
                btnView.Enabled = true;
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
            else
            {
                btnView.Enabled = true;
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
        }

        private void OvertimeManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Approve this application?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Action("Approved", empID);
                if (UpdateOvertimeTime(date, timein, timeout, empID))
                {
                    MessageBox.Show("Record Updated");
                }
                else
                {
                    Action("Pending", empID);
                    MessageBox.Show("You dont have a record for this date.");
                }
                m.Add_Notification_AcceptedOrRejected(empID.ToString(), "Overtime Application", "Approved");
				LoadData();
            }
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
            btnView.Enabled = false;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Approve this application?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Action("Rejected", empID);
                MessageBox.Show("Application Rejected");
                m.Add_Notification_AcceptedOrRejected(empID.ToString(), "Overtime Application", "Rejected");
                
                LoadData();
            }
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
            btnView.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public bool Action(string action, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE OvertimeApplications SET Status = @status WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", action);
                    cmd.Parameters.AddWithValue("@empID", empID);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateOvertimeTime(string date, string start, string end, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET OverTime_TimeIn = @timein, OverTime_TimeOut = @timeout" +
                    " WHERE EmployeeID = @empID AND Date = @Date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@timein", start);
                    cmd.Parameters.AddWithValue("@timeout", end);
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Time record updated for OT");
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Inserting Attedance: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
