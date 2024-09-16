using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class overtimeApplication : Form
    {
		Methods m = new Methods();
		public overtimeApplication()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values
                TimeSpan datetimestart = time.Value.TimeOfDay;
                TimeSpan datetimeout = timeout.Value.TimeOfDay;
                string justification = tbReason.Text;
                int employeeid = 0;


                // Insert data into database
                string query = "INSERT INTO OvertimeApplications (EmployeeID, AppliedDate, StartTime, EndTime, TotalHours, Justification) VALUES (@EmployeeID, @AppliedDate, @StartTime, @EndTime, @TotalHours, @Justification)";
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeid);
                        cmd.Parameters.AddWithValue("@AppliedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@StartTime", datetimestart);
                        cmd.Parameters.AddWithValue("@EndTime", datetimeout);
                        cmd.Parameters.AddWithValue("@Justification", justification);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();
            }
            catch (Exception ex)
            {
              
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Implement logic for editing an existing overtime application
            // ...
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
                        overtimegrid.Rows[n].Cells["dgEmployeeID"].Value = row["EmployeeID"].ToString();
                        overtimegrid.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"].ToString()).ToString("dd/MM/yyyy");
                        overtimegrid.Rows[n].Cells["dgStartTime"].Value = Convert.ToDateTime(row["StartTime"].ToString()).ToString("dd/MM/yyyy hh:mm tt"); 
                        overtimegrid.Rows[n].Cells["dgEndTime"].Value = Convert.ToDateTime(row["EndTime"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgTotalHours"].Value = Convert.ToDateTime(row["TotalHours"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                        overtimegrid.Rows[n].Cells["dgJustification"].Value = row["Justification"].ToString();
                    }

                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
