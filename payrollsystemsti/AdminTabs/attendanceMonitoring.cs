using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
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
        }

        private async void btnTimeIN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Time IN?", "Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;
                btnOvertime.Enabled = false;
                

                string status = "Time IN";
                string currentTime = dateTimePicker1.Value.ToString("dddd, MM/dd/yyyy hh:mm tt");

                try
                {
                    int fID = 0;
                    fID = await ac.SendTimeCommand(fID);

                    if (fID > 0)
                    {
                        dataGridView1.Rows.Add(fID, currentTime, status);
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
                }
            }else if(DialogResult == DialogResult.No)
            {
                btnTimeIN.Enabled = true;
                btnTimeOUT.Enabled = true;
                btnOvertime.Enabled = true;
            }
            
        }

        //private bool getFingerID()
        //{
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();
        //        string query = "SELECT fingerID FROM EmployeeFingerprints WHERE EmployeeID = @empID";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@empID", loggedInEmpID);
        //            object result = cmd.ExecuteScalar();
        //            if(result != null)
        //            {
        //                fingerID = Convert.ToInt32(result);
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Fingerprint not Enrolled");
        //                return false;
        //            }
        //        }
        //    }
        //}

        private void attendanceMonitoring_FormClosed(object sender, FormClosedEventArgs e)
        {
            ac.closePort();
        }

        private async void btnTimeOUT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Time OUT?", "Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                btnTimeIN.Enabled = false;
                btnTimeOUT.Enabled = false;
                btnOvertime.Enabled = false;

                string status = "Time OUT";
                string currentTime = dateTimePicker1.Value.ToString("dddd, MM/dd/yyyy hh:mm tt");

                try
                {
                    //await ac.SendTimeCommand();
                    string id = await ac.ReadLineAsync();
                    if (id != "0")
                    {
                        dataGridView1.Rows.Add(id, currentTime, status);
                        Console.WriteLine($"This is the FingerID: {id}");
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
                }
            }
            else if (DialogResult == DialogResult.No)
            {
                btnTimeIN.Enabled = true;
                btnTimeOUT.Enabled = true;
                btnOvertime.Enabled = true;
            }
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
    }
}
