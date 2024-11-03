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
        TimeSpan endTimePM = new TimeSpan(19, 00, 0);    // 6:00 PM

        TimeSpan timeOutBDYS = new TimeSpan(9, 16, 0);  // 9:16 AM
        TimeSpan timeOutBDYE = new TimeSpan(12, 59, 0);    // 12:59 PM

        TimeSpan timeOutBDYSS = new TimeSpan(13, 16, 0);  // 1:16 PM
        TimeSpan timeOutBDYEE = new TimeSpan(19, 0, 0);    // 7:00 PM

        public attendanceMonitoring()
        {
            InitializeComponent();
            AMinstance = this;
            //Timer timer = new Timer() { Interval = 60000 }; // Check every minute
            //timer.Tick += (sender, e) => CheckAndUpdateTimeouts();
            //timer.Start();
        }

        private void attendanceMonitoring_Load(object sender, EventArgs e)
        {
            ac = new ArduinoComms("COM3");
            btnTimeIN.Enabled = true;

            LoadAttendanceData(date.Value);

            //time.Enabled = false;
            //timer.Enabled = true;
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
                string currentTimeString = time.Value.ToString("HH:mm tt");
                string currentDate = date.Value.ToString("MM/dd/yyyy");

                try
                {
                    int fID = 0;
                    fID = await ac.SendTimeCommand(fID);
                    
                    if (fID > 0)
                    {
                        if (insertAttendance(currentDate, currentTime, null, fID, getEmpID(fID)))
                        {
                            insertAttedanceHistory(getEmpID(fID), currentTimeString, currentDate, status);
                            if (CheckForHoliday(Convert.ToDateTime(currentDate)))
                            {
                                InsertToHoliday(getEmpID(fID), Convert.ToDateTime(currentDate), GetHolidayID(Convert.ToDateTime(currentDate)));
                            }
                            MessageBox.Show($"Welcome {getEmpName(fID)}!!!");
                            LoadAttendanceData(date.Value);

                            if(checkIfLate(time.Value.Hour, time.Value.Minute, 0))
                            {
                                DateTime timeIn = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, time.Value.Hour,time.Value.Minute, 0);
                                DateTime lateStartTime = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, 9, 15, 0);

                                TimeSpan difference = timeIn - lateStartTime;
                                double minutesLate = difference.TotalMinutes;

                                UpdateAttendanceForLate(getEmpID(fID), currentDate, minutesLate);
                                //bool iswhat1 = UpdateAttendanceForLate(getEmpID(fID), currentDate, currentMinute);
                                MessageBox.Show("Minutes late: " + minutesLate);

                            }

                            if (checkIfLatePM(time.Value.Hour, time.Value.Minute, 0))
                            {
                                DateTime timeIn = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, time.Value.Hour, time.Value.Minute, 0);
                                DateTime lateStartTime = new DateTime(time.Value.Year, time.Value.Month, time.Value.Day, 1, 15, 0);

                                TimeSpan difference = timeIn - lateStartTime;
                                double minutesLate = difference.TotalMinutes;

                                UpdateAttendanceForLate(getEmpID(fID), currentDate, minutesLate);
                                //bool iswhat1 = UpdateAttendanceForLate(getEmpID(fID), currentDate, currentMinute);
                                MessageBox.Show("Minutes late: " + minutesLate);

                            }

                            if (checkIfEarly(time.Value.Hour, time.Value.Minute, 0))
                            {
                                UpdateAttendanceForEarly(getEmpID(fID), currentDate);
                            }
                            //bool iswhat = checkIfLate(time.Value.Hour, time.Value.Minute, 0);
                            //MessageBox.Show(iswhat.ToString());
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

        public bool CheckAttendanceRecord(int empID, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                try
                {
                    string query = "SELECT EmployeeID WHERE Date = @date";
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
            TimeSpan startTime = new TimeSpan(9, 15, 0);
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
            TimeSpan endTime = new TimeSpan(9, 14, 0);

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
            TimeSpan startTime = new TimeSpan(1, 15, 0);
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
                TimeSpan timeNow = TimeSpan.FromHours(time.Value.Hour);
                loadingIndicator.Visible = true;
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;

                string status = "Time OUT";
                float currentTime = time.Value.Hour;
                float late = time.Value.Minute;
                string currentTimeString = time.Value.ToString("hh:mm tt");
                string currentDate = date.Value.ToString("MM/dd/yyyy");

                try
                {
                    int fID = 0;
                    fID = await ac.SendTimeCommand(fID);

                    if (fID > 0)
                    {
                        if (insertAttendance(currentDate, null, currentTime, fID, getEmpID(fID)))
                        {
                            insertAttedanceHistory(getEmpID(fID), currentTimeString, currentDate, status);
                            MessageBox.Show($"check out of {getEmpName(fID)} ");
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

        public bool insertAttendance(string date, double? timeIn, double? timeOut, int fingerID, int empID)
        {
            TimeSpan timeNow = TimeSpan.FromHours(time.Value.Hour);
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query;
                
                if ((!IsTimedInAM(fingerID, date) && (timeNow >= startTimeAM && timeNow <= endTimeAM)) || (!IsTimedOutAM(fingerID, date) && (timeNow >= startTimeAM && timeNow <= endTimeAM)))
                {
                    if ((timeIn != null && timeOut == null) && !IsTimedInAM(fingerID, date))
                    {
                        TimeSpan timeInSpan = TimeSpan.FromHours(timeIn.Value);
                        string timeInString = timeInSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "INSERT INTO Attendance (Date, TimeIn_AM, fingerID, EmployeeID) VALUES (@Date, @timeInAM, @fingerID, @empID)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeInAM", timeInString);
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@empID", getEmpID(fingerID));


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
                    else if ((timeIn == null && timeOut != null) && IsTimedInAM(fingerID, date))
                    {
                        TimeSpan timeOutSpan = TimeSpan.FromHours(timeOut.Value);
                        string timeOutString = timeOutSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeOut_AM = @timeOutAM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeOutAM", timeOutString);

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
                    else if(IsTimedInAM(fingerID, date) || IsTimedOutAM(fingerID, date))
                    {
                        MessageBox.Show("Duplicated attendance");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("you dont have a time-in(AM) record yet...");
                        return false;
                    }
                }
                else if (IsTimedOutAM(fingerID, date))
                {
                    if ((timeIn != null && timeOut == null) && !IsTimedInPM(fingerID, date))
                    {
                        TimeSpan timeInSpan = TimeSpan.FromHours(timeIn.Value);
                        string timeInString = timeInSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeIn_PM = @timeInPM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeInPM", timeInString);

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
                    else if((timeIn == null && timeOut != null) && IsTimedInPM(fingerID, date) && !IsTimedOutPM(fingerID, date))
                    {
                        TimeSpan timeOutSpan = TimeSpan.FromHours(timeOut.Value);
                        string timeOutString = timeOutSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeOut_PM = @timeOutPM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeOutPM", timeOutString);

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
                    else if (IsTimedInPM(fingerID, date) || IsTimedOutPM(fingerID, date))
                    {
                        MessageBox.Show("you already have that attendance");
                        return false;
                    }
                    else if (IsTimedOutAM(fingerID, date))
                    {
                        MessageBox.Show("you already have that attendance");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("You don't have a time-in(PM) record yet");
                        return false;
                    }
                }
                else if((timeNow >= startTimePM && timeNow <= endTimePM) && !IsTimedInAM(fingerID, date))
                {
                    if((timeIn != null && timeOut == null) && !IsTimedInPM(fingerID, date))
                    {
                        TimeSpan timeInSpan = TimeSpan.FromHours(timeIn.Value);
                        string timeInString = timeInSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "INSERT INTO Attendance (Date, TimeIn_PM, fingerID) VALUES (@Date, @timeInPM, @fingerID)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeInPM", timeInString);

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
                    else if((timeIn == null && timeOut != null) && IsTimedInPM(fingerID, date))
                    {
                        TimeSpan timeOutSpan = TimeSpan.FromHours(timeOut.Value);
                        string timeOutString = timeOutSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeOut_PM = @timeOutPM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeOutPM", timeOutString);

                            try
                            {
                                int rowsAffected = cmd.ExecuteNonQuery();
                                Console.WriteLine("first time out afternoon");
                                return rowsAffected > 0;
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Error Inserting Attedance: " + ex.Message);
                                return false;
                            }
                        }
                    }
                    else if(IsTimedInPM(fingerID, date) || IsTimedOutPM(fingerID, date))
                    {
                        MessageBox.Show("You already have that attendnace");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("you dont have a time-in(PM) record");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to insert attendance...");
                    return false;
                }
            }
        }

        public bool IsTimedOutAM(int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeOut_AM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@date", date);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public bool IsTimedInAM(int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_AM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@date", date);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private bool IsTimedInPM(int fID, string currentDate)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_PM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand (query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fID);
                    cmd.Parameters.AddWithValue("@date", currentDate);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private bool IsTimedOutPM(int fID, string currentDate)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TimeOut_PM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fID);
                    cmd.Parameters.AddWithValue("@date", currentDate);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }



        public int getEmpID(int fingerID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeID FROM EmployeeAccounts WHERE fingerID = @fingerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);

                    object result = cmd.ExecuteScalar();
                    
                    if(result != null)
                    {
                        int empID = (int)result;
                        return empID;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public string getEmpName(int fingerID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM EmployeeAccounts WHERE fingerID = @fingerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@fingerID", SqlDbType.Int).Value = fingerID;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        }
                    }
                }
            }
            return "Employee Doesn't Exist";
        }

        public bool insertAttedanceHistory(int empID, string time, string date, string status)
        {

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO AttedanceHistory(EmployeeID, Date, Status, Time) " +
                    "VALUES(@empID, @date, @status, @time)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();

                    return true;
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
            time.Value = DateTime.Now;
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

        private void CheckForHolidayAndDoubleHours(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if today is a holiday
                string holidayCheckSql = @"SELECT COUNT(*) FROM Holidays WHERE HolidayDate = @today";

                using (SqlCommand holidayCheckCommand = new SqlCommand(holidayCheckSql, connection))
                {
                    holidayCheckCommand.Parameters.AddWithValue("@today", DateTime.Now.Date);
                    int holidayCount = (int)holidayCheckCommand.ExecuteScalar();

                    if (holidayCount > 0)
                    {
                        // Today is a holiday, double the total hours
                        string doubleHoursSql = @"UPDATE Attendance SET TotalHours = TotalHours * 2 
                                                  WHERE Date = @today";

                        using (SqlCommand doubleHoursCommand = new SqlCommand(doubleHoursSql, connection))
                        {
                            doubleHoursCommand.Parameters.AddWithValue("@today", DateTime.Now.Date);
                            doubleHoursCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private bool CheckForHoliday(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(m.connStr))
            {
                connection.Open();

                // Check if today is a holiday
                string holidayCheckSql = @"SELECT COUNT(*) FROM Holidays WHERE HolidayDate = @today";

                using (SqlCommand holidayCheckCommand = new SqlCommand(holidayCheckSql, connection))
                {
                    holidayCheckCommand.Parameters.AddWithValue("@today", date);
                    int holidayCount = (int)holidayCheckCommand.ExecuteScalar();

                    return holidayCount > 0;
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
    }
}
