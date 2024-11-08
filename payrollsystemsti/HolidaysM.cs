using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class HolidaysM : Form
    {

        Methods m = new Methods();
        int holidayID = 0;
        public HolidaysM()
        {
            InitializeComponent();
        }

        private void HolidaysM_Load(object sender, EventArgs e)
        {
            LoadHolidayData();
        }

        private void LoadHolidayData()
        {
            CultureInfo ci = new CultureInfo("en-US");
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Holidays WHERE IsDeactivated = @status";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["HolidayID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["HolidayType"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["HolidayName"].ToString();
                        dataGridView1.Rows[n].Cells["dg4th"].Value = ci.DateTimeFormat.GetMonthName(Convert.ToInt32(row["HolidayMonth"])) +", "+ row["HolidayDay"].ToString();
                        dataGridView1.Rows[n].Cells["dgMonth"].Value = row["HolidayMonth"].ToString();
                        dataGridView1.Rows[n].Cells["dgDay"].Value = row["HolidayDay"].ToString();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            m.UpdateHoliday(holidayID, cbHType.Text, tb1.Text, dtDate.Value.Month.ToString(), dtDate.Value.Day.ToString());
            LoadHolidayData();
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Holiday Edit");
			Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m.InsertHoliday(cbHType.Text, tb1.Text, dtDate.Value.Month.ToString(), dtDate.Value.Day.ToString());
            //MessageBox.Show(dtDate.Value.Date.ToString("MM/dd"));
            LoadHolidayData();
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Holiday Add");
			Clear();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            holidayID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            cbHType.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg3rd"].Value.ToString();
            int month = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgMonth"].Value);
            int day = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgDay"].Value);
            dtDate.Value = new DateTime(DateTime.Now.Year, month, day);

            btnUpdate.Enabled = true;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxLength();
        }

        void CheckTextBoxLength()
        {
            if(tb1.Text.Length >= 3)
            {
                btnAdd.Enabled = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        void HideCancel()
        {
            btnCancel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HideCancel();
        }

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !btnUpdate.Enabled;
        }

        void Clear()
        {
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Visible = false;
            tb1.Clear();
        }
    }
}
