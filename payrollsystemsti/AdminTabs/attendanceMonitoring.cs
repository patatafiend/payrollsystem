using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace payrollsystemsti.AdminTabs
{
    public partial class attendanceMonitoring : Form
    {
        ArduinoComms ac;
        public static attendanceMonitoring AMinstance;
        Methods m = new Methods();

        //draggable panel shit
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public int loggedInEmpID;

        TimeSpan startTimeAM = new TimeSpan(6, 0, 0);  // 9:00 AM
        TimeSpan endTimeAM = new TimeSpan(12, 0, 0);    // 12:00 PM

        TimeSpan startTimePM = new TimeSpan(13, 0, 0);  // 1:00 PM
        TimeSpan endTimePM = new TimeSpan(23, 00, 0);    // 11:00 PM

        TimeSpan timeOutBDYS = new TimeSpan(9, 16, 0);  // 9:16 AM
        TimeSpan timeOutBDYE = new TimeSpan(12, 59, 0);    // 12:59 PM

        TimeSpan timeOutBDYSS = new TimeSpan(13, 16, 0);  // 1:16 PM
        TimeSpan timeOutBDYEE = new TimeSpan(18, 0, 0);  // 6 :00 PM

        public attendanceMonitoring()
        {
            InitializeComponent();
            AMinstance = this;
            //Timer timer = new Timer() { Interval = 60000 }; // Check every minute
            //timer.Tick += (sender, e) => CheckAndUpdateTimeouts();
            timer.Start();
        }

        private void attendanceMonitoring_Load(object sender, EventArgs e)
        {
            ac = new ArduinoComms("COM3");
            btnTimeIN.Enabled = true;

            LoadAttendanceData(date.Value);
            //sfDateTimeEdit1.

            //time.Enabled = false;
            //
            
        }

        private async void btnTimeIN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Time IN?", "Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TimeSpan timeNow = TimeSpan.FromHours(time.Value.Hour);
                loadingIndicator.Visible = true;
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;

                string status = "Time IN";
                double currentTime = time.Value.Hour;
                double currentMinute = time.Value.Minute;
                string currentTimeString = time.Value.ToString("hh:mm tt");
                string currentDate = date.Value.ToString("MM/dd/yyyy");
                bool holiday = false;

                try
                {
                    int fID = 0;
                    fID = await ac.SendTimeCommand(fID);
                    
                    if (isFingerIdExist(fID))
                    {
                        if (InsertAttendance(currentDate, fID))
                        {
                            m.insertAttedanceHistory(m.getEmpID(fID), currentTimeString, currentDate, status);
                            //MessageBox.Show(date.Value.Month+" "+ date.Value.Day);

                            //if (CheckForHoliday(time.Value.Month, time.Value.Day))
                            //{
                            //    InsertToHoliday(getEmpID(fID), Convert.ToDateTime(currentDate), GetHolidayID(Convert.ToDateTime(currentDate)));
                            //}
                            pbEmployee.Image = m.ConvertToImage(m.GetEmpPicture(m.getEmpID(fID)));
                            lbStatus.Text = "Time IN";
                            lbTime.Text = currentTimeString;
                            MessageBox.Show($"Welcome {m.getEmpName(fID)}!!!");
                            pbEmployee.Image = null;
                            lbStatus.Text = "Status";
                            lbTime.Text = "";

                            LoadAttendanceData(date.Value);

                            if(checkIfLate(time.Value.Hour, time.Value.Minute, 0))
                            {
                                DateTime timeIn = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, time.Value.Hour,time.Value.Minute, 0);
                                DateTime lateStartTime = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, 9, 0, 0);

                                TimeSpan difference = timeIn - lateStartTime;
                                double minutesLate = difference.TotalMinutes;

                                UpdateAttendanceForLate(m.getEmpID(fID), currentDate, minutesLate);
                                //bool iswhat1 = UpdateAttendanceForLate(getEmpID(fID), currentDate, currentMinute);
                                MessageBox.Show("Minutes late: " + minutesLate);

                            }

                            //if (checkIfLatePM(time.Value.Hour, time.Value.Minute, 0))
                            //{
                            //    DateTime timeIn = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, time.Value.Hour, time.Value.Minute, 0);
                            //    DateTime lateStartTime = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, 1, 0, 1);

                            //    TimeSpan difference = timeIn - lateStartTime;
                            //    double minutesLate = difference.TotalMinutes;

                            //    UpdateAttendanceForLate(m.getEmpID(fID), currentDate, minutesLate);
                            //    //bool iswhat1 = UpdateAttendanceForLate(getEmpID(fID), currentDate, currentMinute);
                            //    MessageBox.Show("Minutes late: " + minutesLate);

                            //}

                            if (checkIfEarly(time.Value.Hour, time.Value.Minute, 0))
                            {
                                UpdateAttendanceForEarly(m.getEmpID(fID), currentDate);
                            }
                            //bool iswhat = checkIfLate(time.Value.Hour, time.Value.Minute, 0);
                            //MessageBox.Show(iswhat.ToString());

                            if (CheckForHoliday(date.Value.Month, date.Value.Day))
                            {
                                holiday = true;
                                string holidayType = GetHolidayType(date.Value.Month, date.Value.Day);

                                UpdateHoliday(m.getEmpID(fID), date.Value, holiday, holidayType);
                                //MessageBox.Show("is this even printing");
                            }
                            //bool isTrue = CheckForHoliday(date.Value.Month, date.Value.Day);
                            //MessageBox.Show(isTrue.ToString());
                        }
                    }
                    else
                    {
                        fID = 0;
                        MessageBox.Show("Failed to Time-In");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    btnTimeIN.Enabled = true;
                    btnTimeOUT.Enabled = true;
                    loadingIndicator.Visible = false;
                }
            }
            else if (DialogResult == DialogResult.No)
            {
                btnTimeIN.Enabled = true;
                btnTimeOUT.Enabled = true;
                loadingIndicator.Visible = false;
            }
            LoadAttendanceData(date.Value);
        }

        public bool isFingerIdExist(int fID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM EmployeeAccounts WHERE fingerID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", fID);
                    try
                    {
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateAttendanceForLate(int empID, string date, double minutes)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                try
                {
                    string query = "UPDATE Attendance SET Late = @minutes WHERE EmployeeID = @empID AND Date = @date";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@minutes", minutes);
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@date", date);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating attendance: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateAttendanceForEarly(int empID, string date)
        {
            TimeSpan timeStart = new TimeSpan(9, 0, 0);
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                try
                {
                    string query = "UPDATE Attendance SET TimeIn_AM = @timein WHERE EmployeeID = @empID AND Date = @date";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@timein", timeStart);
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@date", date);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating attendance: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateHoliday(int empID, DateTime date, bool isHoliday, string holidayType)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                try
                {
                    string query = "UPDATE Attendance SET IsHoliday = @ih , HolidayType = @ht WHERE EmployeeID = @empID AND Date = @date";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@ih", isHoliday);
                        cmd.Parameters.AddWithValue("@ht", holidayType);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating attendance: " + ex.Message);
                    return false;
                }
            }
        }

        public bool CheckAttendanceRecord(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                try
                {
                    string query = "SELECT EmployeeID FROM Attendance WHERE Date = @date";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating attendance: " + ex.Message);
                    return false;
                }
            }
        }

        private bool checkIfLate(int hour, int minute, int second)
        {
            TimeSpan currentTime = new TimeSpan(hour, minute, second);
            TimeSpan startTime = new TimeSpan(9, 0, 1);
            TimeSpan endTime = new TimeSpan(11, 59, 0);

            if (currentTime >= startTime && currentTime <= endTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkIfEarly(int hour, int minute, int second)
        {
            TimeSpan currentTime = new TimeSpan(hour, minute, second);
            TimeSpan startTime = new TimeSpan(6, 0, 0);
            TimeSpan endTime = new TimeSpan(9, 0, 0);

            if (currentTime >= startTime && currentTime <= endTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkIfLatePM(int hour, int minute, int second)
        {
            TimeSpan currentTime = new TimeSpan(hour, minute, second);
            TimeSpan startTime = new TimeSpan(1, 0, 1);
            TimeSpan endTime = new TimeSpan(5, 59, 0);

            if (currentTime >= startTime && currentTime <= endTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async void btnTimeOUT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Time OUT?", "Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TimeSpan timeNow = new TimeSpan(time.Value.Hour, time.Value.Minute, 0);
                loadingIndicator.Visible = true;
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;

                string status = "Time OUT";
                float currentTime = time.Value.Hour;
                float late = time.Value.Minute;
                string currentTimeString = time.Value.ToString("hh:mm tt");
                string currentDate = date.Value.ToString("MM/dd/yyyy");
                decimal totalH;

                try
                {
                    int fID = 0;
                    fID = await ac.SendTimeCommand(fID);

                    if (isFingerIdExist(fID))
                    {
                        if (UpdateAttendance(currentDate, fID))
                        {
                            m.insertAttedanceHistory(m.getEmpID(fID), currentTimeString, currentDate, status);
                            m.ConvertToImage(m.GetEmpPicture(m.getEmpID(fID)));
                            lbStatus.Text = "Time OUT";
                            lbTime.Text = currentTimeString;

                            MessageBox.Show($"check out of {m.getEmpName(fID)} ");
                            totalH = GetTotalHours(m.getEmpID(fID), currentDate);

                            //MessageBox.Show(totalH.ToString());

                            if (m.IsTimedOutAM(fID, currentDate) && (totalH == 0) && (timeNow >= startTimeAM && timeNow <= endTimeAM))
                            {
                                //MessageBox.Show(GetTimeInAM(m.getEmpID(fID), currentDate).ToString());
                                //MessageBox.Show(timeNow.ToString());
                                //MessageBox.Show(TotalHoursWorkedAM(m.getEmpID(fID), currentDate).ToString());
                                //MessageBox.Show("1");

                                UpdateTotalHours(m.getEmpID(fID), currentDate, GetTimeInAM(m.getEmpID(fID), currentDate), timeNow.ToString(), totalH);

                            }
                            else if ((totalH >= 0 && totalH <= 8) && (timeNow >= startTimePM && timeNow <= endTimePM) && m.IsTimedInPM(fID, currentDate))
                            {
                                //MessageBox.Show("2");
                                UpdateTotalHours(m.getEmpID(fID), currentDate, GetTimeInPM(m.getEmpID(fID), currentDate), timeNow.ToString(), totalH);
                                totalH = GetTotalHours(m.getEmpID(fID), currentDate);
                                if (totalH > 8)
                                {
                                    //MessageBox.Show((totalH % 8).ToString());
                                    totalH = totalH - 8;
                                    UpdateTotalHours(m.getEmpID(fID), currentDate, 8);
                                    InsertOvertimeApp(m.getEmpID(fID), currentDate, totalH);
                                }
                            }
                            else if ((totalH >= 0 && totalH <= 8) && (timeNow >= startTimePM && timeNow <= endTimePM) && !m.IsTimedInPM(fID, currentDate))
                            {
                                //MessageBox.Show("3");
                                UpdateTotalHours(m.getEmpID(fID), currentDate, GetTimeInAM(m.getEmpID(fID), currentDate), timeNow.ToString(), totalH);
                                totalH = GetTotalHours(m.getEmpID(fID), currentDate);
                                if (totalH > 8)
                                {
                                    //MessageBox.Show((totalH % 8).ToString());
                                    totalH = totalH - 8;
                                    UpdateTotalHours(m.getEmpID(fID), currentDate, 8);
                                    InsertOvertimeApp(m.getEmpID(fID), currentDate, totalH);
                                }
                            }
                            
                            

                            CalculateAndUpdateUndertime(m.getEmpID(fID), currentDate);
                            

                        }
                        else
                        {
                            MessageBox.Show($"nothing ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to Time-Out");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    btnTimeIN.Enabled = true;
                    btnTimeOUT.Enabled = true;
                    loadingIndicator.Visible = false;
                }
            }
            else if (DialogResult == DialogResult.No)
            {
                btnTimeIN.Enabled = true;
                btnTimeOUT.Enabled = true;
                loadingIndicator.Visible = false;
            }
            LoadAttendanceData(date.Value);
        }

        public bool InsertOvertimeApp(int empID, string date, decimal overtimeT)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO OvertimeApplications(EmployeeID, Date, OvertimeHours, Submitted) VALUES (@empID, @date, @hours, @sub)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@hours", overtimeT);
                    cmd.Parameters.AddWithValue("@sub", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if insert was successful
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception (e.g., log, display error message)
                        MessageBox.Show($"Error inserting into OT: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        public class Attendance
        {
            public int AttendanceID { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan TimeInAM { get; set; }
            public TimeSpan TimeOutAM { get; set; }
            public TimeSpan TimeInPM { get; set; }
            public TimeSpan TimeOutPM { get; set; }
            public decimal TotalHours { get; set; }
            public int EmployeeID { get; set; }
            public decimal Late { get; set; }
            public decimal TotalOvertime { get; set; }
            public bool IsHoliday { get; set; }
            public string HolidayType { get; set; }
        }

        public void CalculateAndUpdateUndertime(int employeeId, string date)
        {
            var attendanceRecord = GetAttendanceRecord(employeeId, date);

            Console.WriteLine(attendanceRecord);

            if (attendanceRecord == null)
            {
                return;
            }

            
            TimeSpan totalHours = TimeSpan.Zero;
            if (attendanceRecord.TimeInAM != default && attendanceRecord.TimeOutAM != default)
            {
                totalHours += attendanceRecord.TimeOutAM - attendanceRecord.TimeInAM;
            }
            if (attendanceRecord.TimeInPM != default && attendanceRecord.TimeOutPM != default)
            {
                totalHours += attendanceRecord.TimeOutPM - attendanceRecord.TimeInPM;
            }

            TimeSpan undertime = TimeSpan.FromHours(8) - totalHours;

            if (undertime > TimeSpan.Zero)
            {
                UpdateUndertime(attendanceRecord.AttendanceID, (decimal)undertime.TotalHours);
            }
        }

        private Attendance GetAttendanceRecord(int employeeId, string date)
        {
            using (SqlConnection connection = new SqlConnection(m.connStr))
            {
                connection.Open();
                string query = "SELECT * FROM Attendance WHERE EmployeeID = @employeeId AND Date = @date";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    command.Parameters.AddWithValue("@date", date);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Attendance attendanceRecord = new Attendance();
                            attendanceRecord.AttendanceID = (int)reader["AttendanceID"];
                            attendanceRecord.TimeInAM = (TimeSpan)reader["TimeIn_AM"];
                            attendanceRecord.TimeOutAM = (TimeSpan)reader["TimeOut_AM"];
                            attendanceRecord.TimeInPM = (TimeSpan)reader["TimeIn_PM"];
                            attendanceRecord.TimeOutPM = (TimeSpan)reader["TimeOut_PM"];

                            return attendanceRecord;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        private void UpdateUndertime(int attendanceId, decimal undertimeHours)
        {
            using (SqlConnection connection = new SqlConnection(m.connStr))
            {
                connection.Open();
                string query = "UPDATE Attendance SET Late = @undertime WHERE AttendanceID = @attendanceId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@undertime", undertimeHours);
                    command.Parameters.AddWithValue("@attendanceId", attendanceId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public decimal GetTotalHours(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TotalHours FROM Attendance WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Convert.ToDecimal(reader["TotalHours"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public string GetTimeInAM(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_AM FROM Attendance WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["TimeIn_AM"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }

        public string GetTimeInPM(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_PM FROM Attendance WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["TimeIn_PM"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }

        public bool UpdateTotalHours(int empID, string date, string startT, string endT, decimal currentH)
        {
            TimeSpan totalHours = TimeSpan.Parse(endT) - TimeSpan.Parse(startT);
            decimal totalHoursDecimal = (decimal)totalHours.TotalHours + currentH;

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET TotalHours = @thours WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@thours", totalHoursDecimal);  // Assign calculated total hours

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception message
                        Console.Error.WriteLine($"Error updating total hours: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public bool UpdateTotalHours(int empID, string date, decimal currentH)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET TotalHours = @thours WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@thours", 8);  // Assign calculated total hours

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception message
                        Console.Error.WriteLine($"Error updating total hours: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public void LoadAttendanceData(DateTime date)
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM AttedanceHistory WHERE Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    cmd.Parameters.AddWithValue("@date", date);

                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();

                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgTime"].Value = Convert.ToDateTime(row["Time"].ToString()).ToString("hh:mm tt");
                        dataGridView1.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(row["Date"].ToString()).ToString("MM/dd/yyyy");
                        dataGridView1.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                    }
                }
            }
        }

        private void attendanceMonitoring_FormClosed(object sender, FormClosedEventArgs e)
        {
            ac.closePort();
        }

        private void attendanceHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ac.closePort();
            this.Hide();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time.Value = time.Value.AddSeconds(1);
        }

        private void btnOvertime_Click(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            LoadAttendanceData(date.Value);
        }

        private void time_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckAndUpdateTimeouts()
        {
            if (DateTime.Now.Hour == 12 || DateTime.Now.Hour == 18)
            {
                UpdateTimedOutEmployees(DateTime.Now);
            }
        }

        private void UpdateTimedOutEmployees(DateTime currentTime)
        {
            using (SqlConnection connection = new SqlConnection(m.connStr))
            {
                connection.Open();

                string sql = @"UPDATE Attendance SET TimeOut_AM = @currentTime WHERE TimeIn_AM != '00:00:00' AND
                               TimeOut_AM = '00:00:00' AND Date = @date UNION ALL 
                               UPDATE Attendance SET 
                               TimeOut_PM = @currentTime WHERE TimeIn_PM != '00:00:00' AND 
                               TimeOut_PM = '00:00:00' AND Date = @date";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@currentTime", currentTime.TimeOfDay);
                    command.Parameters.AddWithValue("@date", currentTime.Date);
                    command.ExecuteNonQuery();
                }
            }
        }

       

        public bool CheckForHoliday(int month, int day)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                // Check if today is a holiday
                string query = @"SELECT COUNT(*) FROM Holidays WHERE HolidayMonth = @month AND HolidayDay = @day";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@day", day);
                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                    
                }
            }
        }

        public string GetHolidayType(int month, int day)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = @"SELECT HolidayType FROM Holidays WHERE HolidayMonth = @month AND HolidayDay = @day";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@day", day);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        return reader["HolidayType"].ToString();
                    }
                    else
                    {
                        return "None";
                    }
                }
            }
        }

        public int GetHolidayID(DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                // Check if today is a holiday
                string query = @"SELECT HolidayID FROM Holidays WHERE HolidayDate = @today";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@today", date);
                    
                    try
                    {
                        int holidayCount = (int)cmd.ExecuteScalar();
                        return holidayCount;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Departments: " + ex.Message);
                        return 0;
                    }
                }
            }
        }

        private bool InsertToHoliday(int empID, DateTime date, int holiday)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = @"INSERT INTO HolidayAttendance(EmployeeID, Date, HolidayID) VALUES (@empID, @date, @holiday)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@holiday", holiday);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into holiday attendance: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool InsertAttendance(string date, int fingerID)
        {
            

            TimeSpan timeNow = new TimeSpan(time.Value.Hour, time.Value.Minute, time.Value.Second);

            if ((!m.IsTimedInAM(fingerID, date) && (timeNow >= startTimeAM && timeNow <= endTimeAM)))
            {
                if (!CheckAttendanceRecord(m.getEmpID(fingerID), date))
                {
                    return insertTimeInAM(timeNow.ToString(), fingerID, date);
                }
                else
                {
                    MessageBox.Show("Duplicated attendance");
                    return false;
                }
            }
            else if ((timeNow >= startTimePM && timeNow <= endTimePM) && !m.IsTimedInAM(fingerID, date))
            {
                if (!CheckAttendanceRecord(m.getEmpID(fingerID), date))
                {
                    return insertTimeInPM(timeNow.ToString(), fingerID, date);
                }
                else
                {
                    MessageBox.Show("Duplicated attendance");
                    return false;
                }
                
            }
            else if ((timeNow >= startTimePM && timeNow <= endTimePM) && m.IsTimedInAM(fingerID, date))
            {
                return updateTimeInPM(timeNow.ToString(), fingerID, date);
            }
            else
            {
                MessageBox.Show("Failed to insert attendance...");
                return false;
            }

        }

        public bool UpdateAttendance(string date, int fingerID)
        {
            TimeSpan timeNow = new TimeSpan(time.Value.Hour, time.Value.Minute, time.Value.Second);

            if ((m.IsTimedInAM(fingerID, date) && (timeNow >= startTimeAM && timeNow <= endTimeAM)))
            {
                return updateTimeOutAM(timeNow.ToString(), fingerID, date);
            }
            else if ((timeNow >= startTimePM && timeNow <= endTimePM) && m.IsTimedInAM(fingerID, date))
            {
                return updateTimeOutPM(timeNow.ToString(), fingerID, date);
            }
            else if ((timeNow >= startTimePM && timeNow <= endTimePM) && (m.IsTimedInAM(fingerID, date) || m.IsTimedInPM(fingerID, date)))
            {
                return updateTimeOutPM(timeNow.ToString(), fingerID, date);
            }
            else
            {
                MessageBox.Show("Failed to update attendance...");
                return false;
            }
        }

        public bool insertTimeInAM(string timeIn, int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                
                string query = "INSERT INTO Attendance (Date, TimeIn_AM, fingerID, EmployeeID) VALUES (@Date, @timeInAM, @fingerID, @empID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@timeInAM", timeIn);
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@empID", m.getEmpID(fingerID));

                    

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
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
        public bool insertTimeInPM(string timeIn, int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                
                string query = "INSERT INTO Attendance (Date, TimeIn_PM, fingerID, EmployeeID) VALUES (@Date, @timeInPM, @fingerID, @empID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@timeInPM", timeIn);
                    cmd.Parameters.AddWithValue("@empID", m.getEmpID(fingerID));

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("First Time in afternoon");
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

        public bool updateTimeOutAM(string timeOut, int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET TimeOut_AM = @timeOutAM WHERE fingerID = @fingerID AND Date = @Date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@timeOutAM", timeOut);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
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

        public bool updateTimeInPM(string timeIn, int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET TimeIn_PM = @timeInPM WHERE fingerID = @fingerID AND Date = @Date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@timeInPM", timeIn);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
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

        public bool updateTimeOutPM(string timeOut, int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET TimeOut_PM = @timeOutPM WHERE fingerID = @fingerID AND Date = @Date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@timeOutPM", timeOut);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
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

        public decimal TotalHoursWorked(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_AM, TimeOut_AM, TimeIn_PM, TimeOut_PM FROM Attendance WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TimeSpan totalHours = TimeSpan.Zero;

                        // Check for TimeOut_AM
                        if (reader["TimeOut_AM"] != null)
                        {
                            totalHours = TimeSpan.Parse((string)reader["TimeIn_AM"]) - TimeSpan.Parse((string)reader["TimeOut_AM"]);
                        }
                        else if (reader["TimeOut_PM"] != null)
                        {
                            // Handle lunch break logic here (optional)
                            totalHours = TimeSpan.Parse((string)reader["TimeIn_AM"]) - TimeSpan.Parse((string)reader["TimeOut_PM"]);
                        }
                        else
                        {
                            return 0;
                        }

                        return (decimal)totalHours.TotalHours;
                    }
                    else
                    {
                        return 0; // No attendance record found
                    }
                }
            }
        }

        public decimal TotalHoursWorkedAM(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_AM, TimeOut_AM FROM Attendance WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TimeSpan timeInAM = (TimeSpan)reader["TimeIn_AM"];
                        TimeSpan timeOutAM = (TimeSpan)reader["TimeOut_AM"];

                        TimeSpan totalHours = timeOutAM - timeInAM;

                        return (decimal)totalHours.TotalHours;
                    }
                    else
                    {
                        return 0; // No attendance record found
                    }
                }
            }
        }

        public bool UpdateOvertimeTimeOut(string date, double? timeOut, int fingerID, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Attendance SET OverTime_TimeOut = @timeout WHERE fingerID = @fingerID AND Date = @Date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@timeout", timeOut);
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("time out OT");
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

        public bool CheckIfAllowed(string fingerID, string empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT OvertimeApplications WHERE Status = @status AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@status", "Approved");
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("time out OT");
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
