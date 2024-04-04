using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class attendanceMonitoring : Form
    {
        public attendanceMonitoring()
        {
            InitializeComponent();
            serialPort1.Open();
            serialPort1.DataReceived += SerialPort_DataReceived;
        }

        private string previousStatus = "OUT"; // Initial status

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort1.ReadLine();

                
                string id = data;

                // Determine status based on previous status
                string status = (previousStatus == "IN") ? "OUT" : "IN";
                previousStatus = status; // Update previous status

                // Get the current time
                string currentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

                // Add a new row to the DataGridView
                dataGridView1.Invoke((MethodInvoker)(() =>
                {
                    dataGridView1.Rows.Add(id, currentTime, status);
                }));
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
