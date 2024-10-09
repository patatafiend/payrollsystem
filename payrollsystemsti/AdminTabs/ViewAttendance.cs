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

       /* private void LoadAttedance(int empID)
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
                        dataGridView1.Rows[n].Cells["dgNDW"].Value = totalWD.ToString();
                        dataGridView1.Rows[n].Cells["dgLates"].Value = m.GetTotalLateMin((int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgAbsents"].Value = m.GetAbsents((int)row["EmployeeID"]).ToString();
                    }
                }
            }
        }*/

        private void LoadAttendance(int empID)
        {
            
            using (SqlConnection sqlCon = new SqlConnection(m.connStr))
            {
                sqlCon.Open();
				SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM HistoryTable WHERE Historyfrom = 'Login'", sqlCon);
				DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtbl;
            }

        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            // gets all active employees in the database
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string queryActive = "SELECT * FROM Attendance WHERE EmployeeID = @empID AND MONTH(Date) = @date AND YEAR(Date) = @date1";

                using (SqlCommand cmd = new SqlCommand(queryActive, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", dtDate.Value.Month);
                    cmd.Parameters.AddWithValue("date1", dtDate.Value.Year);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        //dataGridView1.Rows[n].Cells["dgFirstName"].Value = m.GetEmpName(Convert.ToInt32(row["EmployeeID"].ToString()));
                        //dataGridView1.Rows[n].Cells["dgAbsents"].Value = row["Absents"].ToString();
                        dataGridView1.Rows[n].Cells["dgTimeIn"].Value = row["TimeIn_AM"].ToString();
                        dataGridView1.Rows[n].Cells["dgTimeOut"].Value = row["TimeOut_AM"].ToString();
                        dataGridView1.Rows[n].Cells["dgTimeInPm"].Value = row["TimeIn_PM"].ToString();
                        dataGridView1.Rows[n].Cells["dgTimeOutPM"].Value = row["TimeOut_PM"].ToString();
                        dataGridView1.Rows[n].Cells["dgLate"].Value = row["Late"].ToString();
                        dataGridView1.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(row["Date"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
            }

        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
			// TODO: This line of code loads data into the 'stipayrolldbDataSet3.HistoryTable' table. You can move, or remove it, as needed.
			//this.historyTableTableAdapter2.Fill(this.stipayrolldbDataSet3.HistoryTable);
			
            LoadData();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
