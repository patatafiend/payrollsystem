using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["HolidayName"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["HolidayDate"].ToString();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            m.UpdateHoliday(holidayID, tb1.Text, dtDate.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m.InsertHoliday(tb1.Text, Convert.ToDateTime(dtDate.Value.ToString("MM/dd/yyyy")));
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            holidayID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["HolidayID"].Value);
            tb1.Text = dataGridView1.SelectedRows[0].Cells["HolidayName"].ToString();
            dtDate.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["HolidayDate"].Value);
        }
    }
}
