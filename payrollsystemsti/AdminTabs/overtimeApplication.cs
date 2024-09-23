using Microsoft.Reporting.Map.WebForms.VirtualEarth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using MessageBox = System.Windows.Forms.MessageBox;

namespace payrollsystemsti.AdminTabs
{
    public partial class overtimeApplication : Form
    {
        Methods m = new Methods();
        private int selectedOvertimeID;
        public overtimeApplication()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan datetimestart = time.Value.TimeOfDay;
                TimeSpan datetimeout = timeout.Value.TimeOfDay;
                string justification = tbReason.Text.ToString();
                int overtimeid = GetOvertimeID();

                TimeSpan totalHours = timeout.Value.TimeOfDay - time.Value.TimeOfDay;

                string query = "INSERT INTO OvertimeApplications (AppliedDate, StartTime, EndTime , Justification) VALUES ( @AppliedDate, @StartTime, @EndTime, @Justification)";
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@AppliedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@StartTime", datetimestart);
                        cmd.Parameters.AddWithValue("@EndTime", datetimeout);
                        cmd.Parameters.AddWithValue("@Justification", justification);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();

                MessageBox.Show("Overtime application submitted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private int GetOvertimeID()
        {

            return 1;
        }
        private void LoadData()
        {
            overtimegrid.Rows.Clear();
            string query = "SELECT * FROM OvertimeApplications";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = overtimegrid.Rows.Add();
                        overtimegrid.Rows[n].Cells["dgOvertimeID"].Value = row["OvertimeID"].ToString();
                        overtimegrid.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"].ToString()).ToString("MM/dd/yyyy");
                        overtimegrid.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["StartTime"].ToString()).ToString("hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["EndTime"].ToString()).ToString("hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgReason"].Value = row["Justification"].ToString();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TimeSpan time = this.time.Value.TimeOfDay;
                TimeSpan timeout = this.timeout.Value.TimeOfDay;

                if (UpdateOvertimeTable(selectedOvertimeID, time, timeout, tbReason.Text))
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                btnSubmit.Enabled = true;
            }

        }

        private void overtimegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.overtimegrid.Rows[e.RowIndex];
                tbReason.Text = row.Cells["dgReason"].Value.ToString();
                time.Text = row.Cells["dgStart"].Value.ToString();
                timeout.Text = row.Cells["dgEnd"].Value.ToString();

                // Retrieve and store the OvertimeID
                selectedOvertimeID = Convert.ToInt32(row.Cells["dgOvertimeID"].Value);
            }
            btnUpdate.Enabled = true;
            btnSubmit.Enabled = false;
        }

        private bool UpdateOvertimeTable(int overtimeID, TimeSpan starttm, TimeSpan endtm, string reason)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE OvertimeApplications SET StartTime = @starttime, EndTime = @endtime, Justification = @justification WHERE OvertimeID = @OvertimeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@starttime", starttm);
                    cmd.Parameters.AddWithValue("@endtime", endtm);
                    cmd.Parameters.AddWithValue("@justification", reason);
                    cmd.Parameters.AddWithValue("@OvertimeID", overtimeID);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Updating Overtime Application: " + ex.Message);
                        return false;
                    }
                }
            }
        }


    }
}