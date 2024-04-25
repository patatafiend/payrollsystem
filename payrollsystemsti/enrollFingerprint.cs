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

namespace payrollsystemsti
{
    public partial class enrollFingerprint : Form
    {
        Methods m = new Methods();
        ArduinoComms ac;
        int empID = 0;
        int fingerID = 0;
        public enrollFingerprint()
        {
            InitializeComponent();
            
        }

        private void enrollFingerprint_Load(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            btnEnrollFinger.Enabled = false;
            cbFilterID.SelectedIndex = 1;
            //LoadData();

            ac = new ArduinoComms("COM4");
        }

        private bool updateFID(int fingerID, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                string query = "UPDATE EmployeeFingerprints SET FingerID = @fingerID, EmployeeID = @empID";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            
        }

        private bool insertFID(int fingerID, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                string query = "INSERT INTO EmployeeFingerprints(fingerID, EmployeeID) VALUES(@fingerID, @empID)";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }

        }

        private async void btnEnrollFinger_Click(object sender, EventArgs e)
        {
            fingerID = Int32.Parse(tbFingerID.Text.ToString());
            btnEnrollFinger.Enabled = false;
            MessageBox.Show("Enrollment in progress...");

            try
            {
                bool success = await ac.SendEnrollCommand(fingerID);

                if (success)
                {
                    bool insert = insertFID(fingerID, empID);
                    if (insert)
                    {
                        LoadData();
                        MessageBox.Show("Enrollment Success");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enrollment failed. See log for details");
                Console.WriteLine($"Enrollment Error: {ex.Message}");
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRemove.Enabled = true;
            
            if (!string.IsNullOrEmpty(tbFingerID.Text))
            {
                btnRemove.Enabled = true;
                btnEnrollFinger.Enabled = true;

                string fingerID = dataGridView1.SelectedRows[0].Cells["dgFingerID"].Value.ToString();
                empID = Int32.Parse(dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value.ToString());
            }
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeID, FirstName, LastName FROM EmployeeAccounts WHERE" +
                    " EmployeeID NOT IN (SELECT EmployeeID FROM EmployeeFingerprints) AND isDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLastName"].Value = row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgFirstName"].Value = row["FirstName"].ToString();
                        dataGridView1.Rows[n].Cells["dgFingerID"].Value = "No ID";
                    }
                }
            }
        }
        private void LoadDataFingerID()
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.FirstName, EmployeeAccounts.LastName" +
                    ", EmployeeFingerprints.FingerID FROM EmployeeAccounts JOIN EmployeeFingerprints ON" +
                    " EmployeeAccounts.EmployeeID = EmployeeFingerprints.EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLastName"].Value = row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgFirstName"].Value = row["FirstName"].ToString();
                        dataGridView1.Rows[n].Cells["dgFingerID"].Value = row["fingerID"].ToString();
                    }
                }
            }
        }

        private void cbFilterID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cbFilterID.SelectedIndex)
                {
                    case 0:
                        LoadDataFingerID();
                        break;
                    case 1:
                        LoadData();
                        break;
                    default:
                        LoadData();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void enrollFingerprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            ac.closePort();
        }
    }
}
