using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
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
        
        public int loggedInEmpID;
        int fingerID = 0;
        bool timedIN = false;

        public attendanceMonitoring()
        {
            InitializeComponent();
            AMinstance = this;
        }

        private void attendanceMonitoring_Load(object sender, EventArgs e)
        {
            ac = new ArduinoComms("COM4");
            btnOvertime.Enabled = true;
            btnTimeIN.Enabled = true;
            btnTimeOUT.Enabled = timedIN;
        }

        private async void btnTimeIN_Click(object sender, EventArgs e)
        {
            btnTimeIN.Enabled = false;
            btnOvertime.Enabled = false;

            string status = "Time IN";
            string currentTime = dateTimePicker1.Value.ToString("dddd, MM/dd/yyyy hh:mm tt");
            if (getFingerID())
            {
                try
                {
                    bool success = await ac.SendTimeCommand(fingerID);
                    if (success)
                    {
                        dataGridView1.Rows.Add(loggedInEmpID, currentTime, status);
                        Console.WriteLine($"This is the loginID and FingerID: {loggedInEmpID}, {fingerID}");
                        timedIN = true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to display time");
                        timedIN = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    btnTimeIN.Enabled = !timedIN;
                    btnTimeOUT.Enabled = timedIN;
                    btnOvertime.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Enroll Fingerprint first.");
                btnTimeIN.Enabled = true;
                btnOvertime.Enabled = true;
            }
        }

        private bool getFingerID()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT fingerID FROM EmployeeFingerprints WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", loggedInEmpID);
                    object result = cmd.ExecuteScalar();
                    if(result != null)
                    {
                        fingerID = Convert.ToInt32(result);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Fingerprint not Enrolled");
                        return false;
                    }
                }
            }
        }

        private void attendanceMonitoring_FormClosed(object sender, FormClosedEventArgs e)
        {
            ac.closePort();
        }

        private void btnTimeOUT_Click(object sender, EventArgs e)
        {

        }
    }
}
