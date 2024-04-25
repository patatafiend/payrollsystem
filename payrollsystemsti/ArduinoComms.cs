using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace payrollsystemsti
{
    internal class ArduinoComms
    {
        private SerialPort _serialport;

        public ArduinoComms(string portName)
        {
            _serialport = new SerialPort(portName, 9600);
            _serialport.Open();
        }
        public Task<string> ReadLineAsync()
        {
            try
            {
                var tcs = new TaskCompletionSource<string>();


                void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
                {
                    try
                    {
                        string line = _serialport.ReadLine();
                        tcs.SetResult(line);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }

                _serialport.DataReceived += DataReceivedHandler;
                return tcs.Task;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public void closePort()
        {
            _serialport.Close();
        }

        public async Task<bool> SendEnrollCommand(int fingerId)
        {
            string command = $"Enroll {fingerId}";
            _serialport.Write(command);

            try
            {
                string response = await ReadLineAsync();

                if (response.Trim() == "Success")
                {
                    return true;
                }
                else if (response.StartsWith("ERROR:"))
                {
                    string errorMessage = response.Substring("ERROR:".Length);

                    MessageBox.Show($"Enrollment failed: {errorMessage}");
                    return false;
                }
                else
                {
                    MessageBox.Show("Unexpected response from the device");
                    return false;
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Communication timeout. Enrollment failed");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error during communication : {e.Message}");
                MessageBox.Show("An error occured while communicating with the device.");
                return false;
            }
        }

        public async Task<bool> SendTimeCommand(int fingerID)
        {
            string command = $"Time {fingerID}";
            _serialport.Write(command);

            try
            {
                string response = await ReadLineAsync();
                if (response.Trim() == "Success")
                {
                    MessageBox.Show("Time in Success");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public async Task<bool> SendDeleteCommand(int fingerID)
        {
            string command = $"Delete {fingerID}";
            _serialport.Write(command);
            try
            {
                string response = await ReadLineAsync();
                if (response.Trim() == "Success")
                {
                    MessageBox.Show($"Deleted, Employee Fingerprint with ID: {fingerID}");
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to delete fingerprint");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
