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
        int fingerID = 0;
        TimeSpan startTimeAM = new TimeSpan(9, 0, 0);  // 9:00 AM
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
        }

        private void attendanceMonitoring_Load(object sender, EventArgs e)
        {
            ac = new ArduinoComms("COM3");
            btnOvertime.Enabled = true;
            btnTimeIN.Enabled = true;

            //LoadAtttendanceData(date.Text);

        }

        private async void btnTimeIN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Time IN?", "Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loadingIndicator.Visible = true;
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;
                btnOvertime.Enabled = false;


                string status = "Time IN";
                int currentTime = time.Value.Hour;
                string currentDate = date.Value.ToString("MM/dd/yyyy");

                try
                {
                    int fID = 0;
                    fID = await ac.SendTimeCommand(fID);

                    if (fID > 0)
                    {
                        if(!IsTimedInAM(fID, currentDate))
                        {
                            insertAttendance(currentDate, currentTime, null, fID);
                            MessageBox.Show($"Welcome {getEmpName(fID)}!!!");
                            dataGridView1.Rows.Add(getEmpID(fID), currentTime, currentDate, status);
                        }
                        else if(IsTimedInAM(fID, currentDate))
                        {
                            insertAttendance(currentDate, currentTime, null, fID);
                        }
                        else
                        {
                            MessageBox.Show("You already have a record for the morning hours..");
                        }

                        Console.WriteLine($"This is the FingerID: {fID}");
                    }
                    else
                    {
                        MessageBox.Show("Failed to display time");
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
                    btnOvertime.Enabled = true;
                    loadingIndicator.Visible = false;
                }
            }
            else if (DialogResult == DialogResult.No)
            {
                btnTimeIN.Enabled = true;
                btnTimeOUT.Enabled = true;
                btnOvertime.Enabled = true;
                loadingIndicator.Visible = false;
            }
        }
        private async void btnTimeOUT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Time OUT?", "Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loadingIndicator.Visible = true;
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;
                btnOvertime.Enabled = false;

                string status = "Time OUT";
                int currentTime = time.Value.Hour;
                string currentDate = date.Value.ToString("MM/dd/yyyy");

                try
                {
                    //await ac.SendTimeCommand();
                    fingerID = await ac.SendTimeCommand(fingerID);

                    if (fingerID != 0)
                    {

                        insertAttendance(currentDate, null, currentTime, fingerID);
                        dataGridView1.Rows.Add(getEmpID(fingerID), currentTime, currentDate, status);
                        Console.WriteLine($"This is the FingerID: {fingerID}");
                    }
                    else
                    {
                        MessageBox.Show("Failed to display time");
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
                    btnOvertime.Enabled = true;
                    loadingIndicator.Visible = false;
                }
            }
            else if (DialogResult == DialogResult.No)
            {
                btnTimeIN.Enabled = true;
                btnTimeOUT.Enabled = true;
                btnOvertime.Enabled = true;
                loadingIndicator.Visible = false;
            }
        }

        public void insertAttendance(string date, int? timeIn, int? timeOut, int fingerID)
        {
            TimeSpan timeNow = TimeSpan.FromHours(time.Value.Hour);
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query;
                
                if (!IsTimedInAM(fingerID, date) && (TimeSpan.FromHours(time.Value.Hour) >= startTimeAM && TimeSpan.FromHours(time.Value.Hour) <= endTimeAM) )
                {
                    if (timeIn != null && timeOut == null)
                    {
                        TimeSpan timeInSpan = TimeSpan.FromHours(timeIn.Value);
                        string timeInString = timeInSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "INSERT INTO Attendance (Date, TimeIn_AM, fingerID) VALUES (@Date, @timeInAM, @fingerID)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeInAM", timeInString);
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if(!IsTimedOutAM(fingerID, date) && (timeNow >= startTimeAM && timeNow <= endTimeAM))
                {
                    if (timeIn == null && timeOut != null)
                    {
                        TimeSpan timeOutSpan = TimeSpan.FromHours(timeOut.Value);
                        string timeOutString = timeOutSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeOut_AM = @timeOutAM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeOutAM", timeOutString);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (IsTimedOutAM(fingerID, date))
                {
                    if (timeIn != null && timeOut == null)
                    {
                        TimeSpan timeInSpan = TimeSpan.FromHours(timeIn.Value);
                        string timeInString = timeInSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeIn_PM = @timeInPM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeInPM", timeInString);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if(timeIn == null && timeOut != null)
                    {
                        TimeSpan timeOutSpan = TimeSpan.FromHours(timeOut.Value);
                        string timeOutString = timeOutSpan.ToString(@"hh\:mm\:ss\.fffffff");
                        query = "UPDATE Attendance SET TimeOut_PM = @timeOutPM WHERE fingerID = @fingerID AND Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@fingerID", fingerID);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@timeOutPM", timeOutString);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if(timeNow >= startTimePM && timeNow <= endTimePM)
                {

                }
                else
                {
                    MessageBox.Show("Failed to insert attendance...");
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
                    if(result == null)
                    {
                        return false;
                    }
                    else if(result.ToString() == "00:00:00")
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
                string query = "SELECT TimeIn_AM FROM Attendance WHERE fingerID = @fingerID AND Date = @date AND TimeIn_AM IS NOT NULL";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@date", date);

                    object result = cmd.ExecuteScalar();
                    if(result != null)
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

        public int getEmpID(int fingerID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeID FROM EmployeeFingerprints WHERE fingerID = @fingerID";

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
                string query = "SELECT FirstName,LastName FROM EmployeeAccounts WHERE fingerID = @fingerID";
                using (SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    object result = cmd.ExecuteScalar();

                    if(result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return "Employee Doesn't Exist";
                    }
                }
            }
        }

        //public void LoadAtttendanceData(string date)
        //{
        //    dataGridView1.Rows.Clear();
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();
        //        string query = "SELECT * FROM Attedance WHERE Date = @date";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();

        //            cmd.Parameters.AddWithValue("@date", date);

        //            sda.Fill(dt);
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                int n = dataGridView1.Rows.Add();

        //                dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["fingerID"].ToString();
        //                dataGridView1.Rows[n].Cells["dgTime"].Value = row["fingerID"].ToString();
        //                dataGridView1.Rows[n].Cells["dgDate"].Value = row["Date"].ToString();


        //            }
        //        }
        //    }
        //}

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
            this.Close();
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
    }
}
