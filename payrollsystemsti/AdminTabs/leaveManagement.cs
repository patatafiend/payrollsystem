using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Markup;

namespace payrollsystemsti.AdminTabs
{
	public partial class leaveManagement : Form
	{
		Methods m = new Methods();
		private string employeeID;
        private string leaveID;
        private string date;

        TimeSpan startTimeAM = new TimeSpan(9, 0, 0);  // 9:00 AM
        TimeSpan endTimeAM = new TimeSpan(12, 0, 0);    // 12:00 PM

        TimeSpan startTimePM = new TimeSpan(13, 0, 0);  // 1:00 PM
        TimeSpan endTimePM = new TimeSpan(18, 00, 0);
        public leaveManagement()
		{
			InitializeComponent();
		}

		private void leaveManagement_Load(object sender, System.EventArgs e)
		{
			LoadData();
			btnView.Enabled = false;
			btnApprove.Enabled = false;
			btnReject.Enabled = false;
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			LeaveDetails ld = new LeaveDetails();
			LeaveDetails.ld.employeeID = Int32.Parse(employeeID);
            LeaveDetails.ld.LeaveID = Int32.Parse(leaveID);
            LeaveDetails.ld.AppDate = date;
			ld.Show();

		}

        private void LoadData()
        {
            dataGridView1.Rows.Clear();

            int selectedMonth = dtDate.Value.Month;
            int selectedYear = dtDate.Value.Year;

            string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.LastName, EmployeeAccounts.FirstName, " +
                           "LeaveApplications.Status, LeaveApplications.LeaveID, LeaveApplications.CategoryName, " +
                           "LeaveApplications.DateStart, LeaveApplications.DateEnd, LeaveApplications.AppliedDate " +
                           "FROM EmployeeAccounts " +
                           "JOIN LeaveApplications ON EmployeeAccounts.EmployeeID = LeaveApplications.EmployeeID " +
                           "WHERE MONTH(LeaveApplications.DateStart) = @selectedMonth AND YEAR(LeaveApplications.DateStart) = @selectedYear";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@selectedMonth", selectedMonth);
                    cmd.Parameters.AddWithValue("@selectedYear", selectedYear);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["LeaveID"].ToString();
                        dataGridView1.Rows[n].Cells["dgName"].Value = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
                        dataGridView1.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveType"].Value = row["CategoryName"].ToString();
                        dataGridView1.Rows[n].Cells["dgDateStart"].Value = Convert.ToDateTime(row["DateStart"].ToString()).ToString("MM/dd/yyyy");
                        dataGridView1.Rows[n].Cells["dgDateEnd"].Value = Convert.ToDateTime(row["DateEnd"].ToString()).ToString("MM/dd/yyyy");
                        dataGridView1.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"].ToString()).ToString("MM/dd/yyyy");
                    }
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			employeeID = dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value.ToString();
            leaveID = dataGridView1.SelectedRows[0].Cells["dgLeaveID"].Value.ToString();
            date = dataGridView1.SelectedRows[0].Cells["dgAppliedDate"].Value.ToString();

            string status = dataGridView1.SelectedRows[0].Cells["dgStatus"].Value.ToString();

            if(status == "Approved" || status == "Rejected")
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

		private void btnApprove_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(employeeID))
			{
				using (SqlConnection conn = new SqlConnection(m.connStr))
				{
					conn.Open();
					SqlTransaction transaction = conn.BeginTransaction();

					try
					{
						// Update LeaveApplications table
						string leaveQuery = "UPDATE LeaveApplications SET Status = @status WHERE EmployeeID = @employeeID";
						using (SqlCommand leaveCmd = new SqlCommand(leaveQuery, conn, transaction))
						{
							leaveCmd.Parameters.AddWithValue("@status", "Approved");
							leaveCmd.Parameters.AddWithValue("@employeeID", employeeID);

							leaveCmd.ExecuteNonQuery();
						}

						InsertApprovedLeaveDates();

						UpdateLeaveTypeAvailableTable(dataGridView1.SelectedRows[0].Cells["dgLeaveType"].Value.ToString(), Int32.Parse(employeeID));


						// Commit the transaction if both updates are successful
						transaction.Commit();

						// Add notification
						m.Add_Notification_AcceptedOrRejected(employeeID, "approved", "Leave");

						MessageBox.Show("Leave approved successfully.", "Success");

						//add history log leave acceptance
						m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Leave approved");





					}
					catch (Exception ex)
					{
						// Roll back the transaction if there's an error and the transaction is still active
						if (transaction != null && transaction.Connection != null)
						{
							try
							{
								transaction.Rollback();
							}
							catch (Exception rollbackEx)
							{
								MessageBox.Show($"Error during rollback: {rollbackEx.Message}", "Rollback Error");
							}
						}
						MessageBox.Show($"Error updating tables: {ex.Message}", "Error");
					}
				}
				LoadData(); // Reload data after updates
			}
			else
			{
				MessageBox.Show("EmployeeID is invalid.", "Error");
			}
		}

        private bool InsertAttendance(int empID, int fingerID, DateTime timeInAM, DateTime timeOutAM, DateTime timeInPM, DateTime timeOutPM, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Attendance(EmployeeID, FingerID, TimeIn_AM, TimeOut_AM, TimeIn_PM, TimeOut_PM, Date) " +
                    "VALUES  (@empID, @fingerID, @timeinAM , @timeoutAM , @timeinPM, @timeoutPM, @date)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@timeinAM", timeInAM);
                    cmd.Parameters.AddWithValue("@timeoutAM", timeOutAM);
                    cmd.Parameters.AddWithValue("@timeinPM", timeInPM);
                    cmd.Parameters.AddWithValue("@timeoutPM", timeOutPM);
                    cmd.Parameters.AddWithValue("@date", date);

                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                        return false;
                    }
                }
            }
        }

        private void InsertApprovedLeaveDates()
        {


            // Get leave application details (assuming you have access to them)
            DateTime startDate = dtStart.Value;
            DateTime endDate = dtEnd.Value;

            // Calculate the number of days
            int days = (endDate - startDate).Days + 2;

            for (int i = 0; i < days; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                bool success = InsertAttendance(Convert.ToInt32(employeeID), m.GetFingerID(Convert.ToInt32(employeeID)), Convert.ToDateTime(startTimeAM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(endTimeAM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(startTimePM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(endTimePM.ToString("hh\\:mm\\:ss")), currentDate);
                if (!success)
                {
                    // Handle insertion failure (e.g., show error message)
                    MessageBox.Show("Error inserting attendance record for " + currentDate);
                    break;
                }
                else if (success && i == (days - 1))
                {
                    MessageBox.Show("Leave application approved and attendance records created successfully!");
                }
            }

            // Show success message after successful insertion for all days
            //MessageBox.Show("Leave application approved and attendance records created successfully!");
        }

        private void btnReject_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(employeeID))
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

				// Add notification
				m.Add_Notification_AcceptedOrRejected(employeeID, "rejected", "Leave");



				m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Leave Rejected");

				LoadData();
			}
			else
			{
				MessageBox.Show("EmployeeID is invalid.", "Error");
			}
		}

		private void btnReload_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		

		

		private void btnUpdate_Click(object sender, EventArgs e)
		{

		}

		private void UpdateLeaveTypeAvailableTable(string leavecategory, int employeeid)
		{
			using(SqlConnection conn = new SqlConnection(m.connStr))
			{
				try
				{
				conn.Open();
				string query = $"UPDATE LeaveTypeAvailable SET [{leavecategory}] = [{leavecategory}] - 1 WHERE [Employee ID] = @employeeID";
				using(SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@employeeID", employeeID);
					cmd.ExecuteNonQuery();
				}
				}catch(Exception ex)
				{
					MessageBox.Show($"Error updating LeaveTypeAvailable table: {ex.Message}", "Error");
				}
			}
		}

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
			LoadData();
        }
    }
}
