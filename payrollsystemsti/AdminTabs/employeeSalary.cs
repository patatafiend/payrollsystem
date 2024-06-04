using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class employeeSalary : Form
    {
        Methods m = new Methods();
        public static employeeSalary es;
        private double basicRate = 0;
        private double totalHoursW = 0;
        private double totalOvertime = 0;
        private double totalLate = 0;
        private double totalAbsent = 0;

        private double basicSalary = 0;
        private double overtimePay = 0;
        private double gross = 0;

        private int empID = 0;
        public employeeSalary()
        {
            InitializeComponent();
        }

        public void LoadPayrollData()
        {
            DateTime dateStart = Convert.ToDateTime(dtStart.Value.ToString("MM/dd/yyyy"));
            DateTime dateEnd = Convert.ToDateTime(dtEnd.Value.ToString("MM/dd/yyyy"));

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
                        dataGridView1.Rows[n].Cells["dgTHW"].Value = GetTotalHours(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgOT"].Value = GetTotalHoursOT(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgLate"].Value = GetTotalLateMin(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgAbsent"].Value = GetAbsents(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                    }
                }
            }
        }

        public void LoadComputedPayrollData()
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeID FROM Payroll";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = getEmpName((int)row["EmployeeID"]);
                    }
                }
            }
        }

        public string getEmpName(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["FirstName"].ToString()+ " " + reader["LastName"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }


        private void employeeSalary_Load(object sender, System.EventArgs e)
        {
            LoadPayrollData();
            firsInterface();
            SetPayPeriodDefaults();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(cbPayroll.Text == "Printing")
            {
                empID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value.ToString());
            }
            else
            {
                //

                empID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value.ToString());
                basicRate = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgBasic"].Value.ToString());
                totalHoursW = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgTHW"].Value.ToString());
                totalOvertime = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgOT"].Value.ToString());
                totalLate = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgLate"].Value.ToString());
                totalAbsent = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgAbsent"].Value.ToString());

                tbBasic.Text = basicSalary.ToString();
                tbOT.Text = overtimePay.ToString();
                tbPH.Text = calPH(setDeductions(1), Convert.ToDouble(tbBasic.Text)).ToString();

                basicSalary = calBasicSalary(basicRate, totalHoursW);
                overtimePay = calOvertimePay(totalOvertime, basicRate);

                tbPagibig.Text = calPagIbig().ToString();
                tbLate.Text = totalLate.ToString();
                tbAbsent.Text = totalAbsent.ToString();



                setAllowance(empID);
                setOthers(empID);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dateStart = Convert.ToDateTime(dtStart.Value.ToString("MM/dd/yyyy"));
            DateTime dateEnd = Convert.ToDateTime(dtEnd.Value.ToString("MM/dd/yyyy"));

            insertToPayroll(empID, dateStart, dateEnd, gross, 0, gross);
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

        private double calPagIbig()
        {
            return 100;
        }

        private double grossPay(double basicSalary, double incentives, double trainA, double transA, double loadA, double provA, double ot, double regH, double slH, double adj)
        {
            return basicSalary + incentives + trainA + transA + loadA + provA + ot + regH + slH + adj;
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
                        return Convert.ToDouble((int)reader["Amount"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private void SetPayPeriodDefaults()
        {
            DateTime today = DateTime.Today;
            DateTime payPeriodStart, payPeriodEnd;

            if (today.Day <= 15)
            {
                payPeriodStart = new DateTime(today.Year, today.Month, 1);
                payPeriodEnd = new DateTime(today.Year, today.Month, 15);
            }
            else
            {
                payPeriodStart = new DateTime(today.Year, today.Month, 16);
                payPeriodEnd = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            }

            dtStart.Value = payPeriodStart;
            dtEnd.Value = payPeriodEnd;
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            LoadPayrollData();
            DateTime startDate = dtStart.Value.Date;
            dtEnd.Value = startDate.AddDays(14);
            dtEnd.Value = dtEnd.Value.Date <= startDate.AddMonths(1).AddDays(-1) ? dtEnd.Value.Date : startDate.AddMonths(1).AddDays(-1);
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime endDate = dtEnd.Value.Date;
            dtStart.Value = endDate.AddDays(-14);
            dtStart.Value = dtStart.Value.Date >= endDate.AddMonths(-1).AddDays(1) ? dtStart.Value.Date : endDate.AddMonths(-1).AddDays(1);
        }

        private decimal GetTotalHours(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT SUM(TotalHours) AS TotalHours " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        private decimal GetTotalHoursOT(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT SUM(TotalOvertime) AS TotalOvertime " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private decimal GetTotalLateMin(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT SUM(Late) AS Late " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private decimal GetAbsents(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID AND TotalHours = @thw";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@thw", 0);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private void setAllowance(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Allowance WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tbTA.Text = reader["TrainingA"].ToString();
                        tbTransA.Text = reader["TransportationA"].ToString();
                        tbLoadA.Text = reader["LoadA"].ToString();
                        tbPTA.Text = reader["ProvisionTA"].ToString();
                        tbOBA.Text = reader["OBA"].ToString();
                    }
                }
            }
        }
        private void setOthers(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Others WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tbIncentives.Text = reader["Incentives"].ToString();
                        tbRegularH.Text = reader["RegularH"].ToString();
                        tbSpecialH.Text = reader["SpecialH"].ToString();
                        tbAdjustment.Text = reader["Adjustment"].ToString();
                    }
                }
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            gross = grossPay(basicSalary, Convert.ToDouble(tbIncentives.Text), Convert.ToDouble(tbTA.Text),
                Convert.ToDouble(tbTransA.Text), Convert.ToDouble(tbLoadA.Text), Convert.ToDouble(tbPTA.Text),
                overtimePay, Convert.ToDouble(tbRegularH.Text), Convert.ToDouble(tbSpecialH.Text),
                Convert.ToDouble(tbAdjustment.Text));

            tbSSS.Text = calSSS(setDeductions(2), gross).ToString();
        }

        

        private void btnPayslip_Click(object sender, EventArgs e)
        {
            PaySlipReport ps = new PaySlipReport();
            PaySlipReport.pr.empID = empID;
            ps.Show();
        }

        private void cbPayroll_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbPayroll.Text)
            {
                case "Payroll Computation":
                    LoadPayrollData();
                    firsInterface();
                    break;
                case "Printing":
                    LoadComputedPayrollData();
                    // Resize the combo box
                    cbPayroll.Width = 200;
                    cbPayroll.Height = 80;
                    cbPayroll.Top = 100;
                    cbPayroll.Left = 750;


                    dataGridView1.Top = 150;
                    dataGridView1.Height = 500;
                    

                    // Relocate the print button
                    btnPayslip.Left = 30;
                    btnPayslip.Top = 80;
                    hidePayrollComputation();               
                    break;
                default:
                    firsInterface();
                    break;
            }
        }

      


        public void hidePayrollComputation()
        {
            lbStart.Visible = false;
            lbEnd.Visible = false;

            dtStart.Visible = false;
            dtEnd.Visible = false;

            gb1.Visible = false;
            gb2.Visible = false;
            gb3.Visible = false;
            gb4.Visible = false;

            btnCompute.Visible = false;
            btnSave.Visible = false;
            btnPayslip.Visible = true;
        }
        public void firsInterface()
        {
            
            lbStart.Visible = true;
            lbEnd.Visible = true;

            dtStart.Visible = true;
            dtEnd.Visible = true;

            gb1.Visible = true;
            gb2.Visible = true;
            gb3.Visible = true;
            gb4.Visible = true;

            btnCompute.Visible = true;
            btnSave.Visible = true;
            btnPayslip.Visible = false;

            // Resize the combo box
           
            cbPayroll.Top = 415;
            cbPayroll.Left = 780;
            cbPayroll.Width = 160;

            dataGridView1.Location =  new System.Drawing.Point(24, 450);

            btnCompute.Location = new System.Drawing.Point(768, 34);
            btnSave.Location = new System.Drawing.Point(906, 35);

           

        }

     


            public bool insertToPayroll(int empID, DateTime payStart, DateTime payEnd, double gross, double deductionID, double netPay)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Payroll(EmployeeID, PayPeriodStart, PayPeriodEnd, GrossPay, DeductionID, NetPay) " +
                    "VALUES(@empID, @payStart, @payEnd, @gross, @deductionID, @netpay)";
                using (SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@gross", gross);
                    cmd.Parameters.AddWithValue("@deductionID", deductionID);
                    cmd.Parameters.AddWithValue("@netpay", netPay);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Payroll: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            // Set the size of the form
            this.Width = 800; // Width in pixels
            this.Height = 600; // Height in pixels

            // Set the location of the form on the screen
            this.Left = 100; // Distance from left edge of the screen
            this.Top = 50;  // Distance from top edge of the screen
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set the size of the form
            this.Width = 800; // Width in pixels
            this.Height = 600; // Height in pixels

            // Set the location of the form on the screen
            this.Left = 100; // Distance from left edge of the screen
            this.Top = 50;  // Distance from top edge of the screen
        }
    }
}
