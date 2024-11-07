using Microsoft.Reporting.Map.WebForms.VirtualEarth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using MessageBox = System.Windows.Forms.MessageBox;

namespace payrollsystemsti.AdminTabs
{
    public partial class overtimeApplication : Form
    {
        Methods m = new Methods();
        private int empID = 0;
        public overtimeApplication()
        {
            InitializeComponent();
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(tbReason.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbReason, "Please provide a reason..");
            }
            else if (checkOvertimePending())
            {
                errorProvider1.Clear();
                errorProvider1.SetError(btnSubmit, "Please wait for approval of pending leave");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private bool checkOvertimePending()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM OvertimeApplications WHERE EmployeeID = @empID AND Status = @status";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@status", "Pending");

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                InsertToOvertimeApplications(empID);
            }
            
        }

        public void InsertToOvertimeApplications(int empID)
        {
            try
            {
                TimeSpan datetimestart = time.Value.TimeOfDay;
                TimeSpan datetimeout = timeout.Value.TimeOfDay;
                string justification = tbReason.Text.ToString();

                TimeSpan totalHours = timeout.Value.TimeOfDay - time.Value.TimeOfDay;

                string query = "INSERT INTO OvertimeApplications (EmployeeID, AppliedDate, StartTime, EndTime , Justification, Status , Date)" +
                    " VALUES (@empID,  @AppliedDate, @StartTime, @EndTime, @Justification, @status, @date)";

                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@AppliedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@StartTime", datetimestart);
                        cmd.Parameters.AddWithValue("@EndTime", datetimeout);
                        cmd.Parameters.AddWithValue("@Justification", justification);
                        cmd.Parameters.AddWithValue("@status", "Pending");
                        cmd.Parameters.AddWithValue("@date", dtDate.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();

                MessageBox.Show("Overtime application submitted successfully.");

                m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Overtime Submitted by " + Methods.CurrentUser.LastName + ", " + Methods.CurrentUser.FirstName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadData()
        {
            overtimegrid.Rows.Clear();
            string query = "SELECT * FROM OvertimeApplications WHERE EmployeeID = @empID";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("empID", empID);
                   

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = overtimegrid.Rows.Add();
                        overtimegrid.Rows[n].Cells["dgOvertimeID"].Value = row["OvertimeID"].ToString();
                        overtimegrid.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"]).ToString("MM/dd/yyyy");
                        overtimegrid.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["StartTime"].ToString()).ToString("hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["EndTime"].ToString()).ToString("hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgReason"].Value = row["Justification"].ToString();
                        overtimegrid.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                        overtimegrid.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(row["Date"]).ToString("MM/dd/yyyy");
                    }
                }
            }
        }

		private void btnUpdate_Click_1(object sender, EventArgs e)
		{
            UpdateOvertime(empID);
            btnUpdate.Enabled = false;
		}

        public void UpdateOvertime(int empID)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TimeSpan time = this.time.Value.TimeOfDay;
                TimeSpan timeout = this.timeout.Value.TimeOfDay;

                if (UpdateOvertimeTable(empID, time, timeout, tbReason.Text, dtDate.Value))
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Overtime Edited by " + Methods.CurrentUser.LastName + ", " + Methods.CurrentUser.FirstName);
                }
                btnSubmit.Enabled = true;
                btnUpdate.Enabled = false;

            }
            else
            {
                btnSubmit.Enabled = true;
                btnUpdate.Enabled = false;
            }

            LoadData();
        }
		private bool UpdateOvertimeTable(int empID, TimeSpan starttm, TimeSpan endtm, string reason, DateTime date)
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				string query = "UPDATE OvertimeApplications SET StartTime = @starttime, EndTime = @endtime, Justification = @justification, Date = @date WHERE EmployeeID = @empID";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@starttime", starttm);
					cmd.Parameters.AddWithValue("@endtime", endtm);
					cmd.Parameters.AddWithValue("@justification", reason);
					cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);

                    try
					{
						int rowsAffected = cmd.ExecuteNonQuery();
						return rowsAffected > 0;
					}
					catch (SqlException ex)
					{
						MessageBox.Show("Error Updating Overtime Application: " + ex.Message);
						return false;
					}
				}
			}

		}

        

		private void btnCancel_Click(object sender, EventArgs e)
		{
            
            if(btnSubmit.Enabled == false)
			{
				btnSubmit.Enabled = true;
				btnUpdate.Enabled = false;
			}
			else
			{
				MessageBox.Show("No row selected to cancel.");
			}

		}

        private void overtimegrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbReason.Text = overtimegrid.SelectedRows[0].Cells["dgReason"].Value.ToString();
            time.Text = overtimegrid.SelectedRows[0].Cells["dgStart"].Value.ToString();
            timeout.Text = overtimegrid.SelectedRows[0].Cells["dgEnd"].Value.ToString();
            btnUpdate.Enabled = true;
        }

        private void overtimeApplication_Load(object sender, EventArgs e)
        {
            empID = Methods.CurrentUser.UserID;
            LoadData();
        }
    }
}