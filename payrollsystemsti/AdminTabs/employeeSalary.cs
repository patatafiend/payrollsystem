using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class employeeSalary : Form
    {
        Methods m = new Methods();
        private int basicRate = 0;
        private int totalHoursW = 0;
        private int totalOvertime = 0;
        public employeeSalary()
        {
            InitializeComponent();
        }

        public void LoadPayrollData()
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate, " +
                    "SUM(a.TotalOvertime) AS TotalOvertime, " +
                    "SUM(a.TotalHours) AS TotalHours FROM EmployeeAccounts ea " +
                    "INNER JOIN Attendance a ON ea.EmployeeID = a.EmployeeID " +
                    "GROUP BY ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgBasic"].Value = row["BasicRate"].ToString();
                        dataGridView1.Rows[n].Cells["dgTHW"].Value = row["TotalHours"].ToString();
                        dataGridView1.Rows[n].Cells["dgOT"].Value = row["TotalOvertime"].ToString();
                    }
                }
            }
        }

        private void employeeSalary_Load(object sender, System.EventArgs e)
        {
            LoadPayrollData();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            basicRate = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgBasic"].Value.ToString());
            totalHoursW = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgTHW"].Value.ToString());
            totalOvertime = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgOT"].Value.ToString());

            tbBasic.Text = calBasicSalary(basicRate, totalHoursW).ToString();
            tbOT.Text = calOvertimePay(totalOvertime, basicRate).ToString();
            tbPH.Text = calPH(setDeductions(1), Convert.ToDouble(tbBasic.Text)).ToString();
            tbSSS.Text = calSSS(setDeductions(2), 0).ToString();
            tbPagibig.Text = calPagIbig(setDeductions(3), Convert.ToDouble(tbBasic.Text)).ToString();
        }

        private double calBasicSalary(double basicRate, double tHW)
        {
            return (basicRate / 8) * tHW;
        }

        private double calOvertimePay(double overtime, double basic)
        {
            double OvertimeRate = (basic / 8) * 1.25;
            return OvertimeRate * overtime;
        }

        private double calPH(double ph, double basicSalary)
        {
           return (ph / 100) * basicSalary;
        }

        private double calSSS(double sss, double gross)
        {
            return (sss / 100) * gross;
        }

        private double calPagIbig(double pag, double basicSalary)
        {
            return basicSalary - pag;
        }

        public double setDeductions(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Amount FROM Deductions WHERE DeductionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id ", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return (double)reader["Amount"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
