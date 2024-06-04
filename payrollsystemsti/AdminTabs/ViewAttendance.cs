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

namespace payrollsystemsti.AdminTabs
{
    public partial class ViewAttendance : Form
    {

        Methods m = new Methods();
        public static ViewAttendance va;
        public static int empID;
        public ViewAttendance()
        {
            InitializeComponent();
            va = this;
        }

        public int employeeID
        {
            set
            {
                empID = value;
            }
            get
            {
                return empID;
            }
        }

        private void LoadAttedance(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Attendance WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add(row);
                        double totalWD = ((double)m.GetTotalHours((int)row["EmployeeID"])) / 24;
                        dataGridView1.Rows[n].Cells["dgNWD"].Value = totalWD.ToString();
                        dataGridView1.Rows[n].Cells["dgLates"].Value = m.GetTotalLateMin((int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgAbsents"].Value = m.GetAbsents((int)row["EmployeeID"]).ToString();
                    }
                }
            }
        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
            LoadAttedance(empID);
        }
    }
}
