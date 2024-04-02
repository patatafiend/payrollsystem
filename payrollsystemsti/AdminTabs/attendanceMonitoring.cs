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

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadLine();

            UpdateLabel(data);
        }

        private void UpdateLabel(string text)
        {
            if (label1.InvokeRequired)
            {
                BeginInvoke((MethodInvoker)(() => UpdateLabel(text)));
            }
            else
            {
                label1.Text = text;
            }
        }

        private void attendanceMonitoring_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }
    }
}
