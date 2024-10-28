using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class AddAttendance : Form
    {
        Methods m = new Methods();
        public static AddAttendance add;
        public int empID = 0;

        TimeSpan startTimeAM = new TimeSpan(9, 0, 0);  // 9:00 AM
        TimeSpan endTimeAM = new TimeSpan(12, 0, 0);    // 12:00 PM

        TimeSpan startTimePM = new TimeSpan(13, 0, 0);  // 1:00 PM
        TimeSpan endTimePM = new TimeSpan(18, 00, 0);    // 6:00 PM
        public AddAttendance()
        {
            InitializeComponent();
            add = this;
        }

        public int EmployeeID
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

        private bool InsertAttendance(int empID, int fingerID, DateTime timeInAM, DateTime timeOutAM, DateTime timeInPM, DateTime timeOutPM, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Attendancee(EmployeeID, FingerID, TimeIn_AM, TimeOut_AM, TimeIn_PM, TimeOut_PM, Date) " +
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
                bool success = InsertAttendance(Convert.ToInt32(empID), m.GetFingerID(Convert.ToInt32(empID)),Convert.ToDateTime(startTimeAM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(endTimeAM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(startTimePM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(endTimePM.ToString("hh\\:mm\\:ss")), currentDate);
                if (!success)
                {
                    // Handle insertion failure (e.g., show error message)
                    MessageBox.Show("Error inserting attendance record for " + currentDate);
                    break;
                }
                else if(success && i == (days - 1))
                {
                    MessageBox.Show("Leave application approved and attendance records created successfully!");
                }
            }

            // Show success message after successful insertion for all days
            //MessageBox.Show("Leave application approved and attendance records created successfully!");
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            InsertApprovedLeaveDates();
            //InsertAttendance(Convert.ToInt32(empID), m.GetFingerID(Convert.ToInt32(empID)),Convert.ToDateTime(startTimeAM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(endTimeAM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(startTimePM.ToString("hh\\:mm\\:ss")), Convert.ToDateTime(endTimePM.ToString("hh\\:mm\\:ss")), dtStart.Value);
            //MessageBox.Show(startTimeAM.ToString("hh\\:mm\\:ss"));
        }

        private void AddAttendance_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(empID.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAttendance(1, 8);
        }

        private bool UpdateAttendance(int empID, int totalHours)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendancee SET TotalHours = @totalhours WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@totalhours", totalHours);


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
    }
}
