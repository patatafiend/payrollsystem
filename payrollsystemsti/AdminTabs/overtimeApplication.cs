﻿using Microsoft.Reporting.Map.WebForms.VirtualEarth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
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
        public int empID = 0;
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
                UpdateOvertimeTime(dtDate.Value.ToString("MM/dd/yyyy"), empID);
                MessageBox.Show("Application submitted!");
            }
            
        }

        public bool UpdateOvertimeTime(string date, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE OvertimeApplications SET Status = @status, Submitted = @sub" +
                    " WHERE EmployeeID = @empID AND Date = @Date";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    cmd.Parameters.AddWithValue("@sub", 1);
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

        public void InsertToOvertimeApplications(int empID)
        {
            try
            {
                TimeSpan datetimestart = time.Value.TimeOfDay;
                TimeSpan datetimeout = timeout.Value.TimeOfDay;
                string justification = tbReason.Text.ToString();

                TimeSpan totalHours = timeout.Value.TimeOfDay - time.Value.TimeOfDay;

                string query = "INSERT INTO OvertimeApplications (EmployeeID, AppliedDate, StartTime, EndTime, Justification, Status , Date)" +
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

				m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Overtime Submitted");
                m.Add_Notification_AcceptedOrRejected(empID.ToString(), " Overtime Application ", "Pending");
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

                        // Handle null values and format dates and times
                        overtimegrid.Rows[n].Cells["dgOvertimeID"].Value = row["OvertimeID"] ?? DBNull.Value;
                        overtimegrid.Rows[n].Cells["dgAppliedDate"].Value = row["AppliedDate"] != DBNull.Value ? Convert.ToDateTime(row["AppliedDate"]).ToString("MM/dd/yyyy") : string.Empty;
                        overtimegrid.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["StartTime"].ToString()).ToString("hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["EndTime"].ToString()).ToString("hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgReason"].Value = row["Justification"] ?? string.Empty;
                        overtimegrid.Rows[n].Cells["dgStatus"].Value = row["Status"] ?? string.Empty;
                        overtimegrid.Rows[n].Cells["dgDate"].Value = row["Date"] != DBNull.Value ? Convert.ToDateTime(row["Date"]).ToString("MM/dd/yyyy") : string.Empty;
                        overtimegrid.Rows[n].Cells["dgHours"].Value = row["OvertimeHours"] ?? DBNull.Value;

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

                if (UpdateOvertimeTable(empID, tbReason.Text, dtDate.Value.ToString("MM/dd/yyyy")))
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Overtime Edited");
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
		private bool UpdateOvertimeTable(int empID, string reason, string date)
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				string query = "UPDATE OvertimeApplications SET Justification = @justification WHERE EmployeeID = @empID AND Date = @date";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
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

        private bool UpdateOvertimeTable(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE OvertimeApplications SET Submitted = @sub, Date = @date WHERE EmployeeID = @empID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@sub", 1);

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
            //dtDate.Value = Convert.ToDateTime(overtimegrid.SelectedRows[0].Cells["dgDate"].Value).ToString("MM/dd/yyyy");

            string dobCellValue = overtimegrid.SelectedRows[0].Cells["dgDate"].Value.ToString();
            DateTime dob;

            if (DateTime.TryParseExact(dobCellValue, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                dtDate.Value = dob;
            }
            else
            {
                MessageBox.Show("Invalid date format");
            }
            btnUpdate.Enabled = true;
        }

        private void overtimeApplication_Load(object sender, EventArgs e)
        {
            empID = Methods.CurrentUser.EmployeeID;
            LoadData();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timeout_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}