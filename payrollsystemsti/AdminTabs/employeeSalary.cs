using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
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

        //public void LoadPayrollData()
        //{
        //    DateTime dateStart = Convert.ToDateTime(dtStart.Value.ToString("MM/dd/yyyy"));
        //    DateTime dateEnd = Convert.ToDateTime(dtEnd.Value.ToString("MM/dd/yyyy"));

        //    dataGridView1.Rows.Clear();
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();
        //        string query = "SELECT ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate, " +
        //            "SUM(a.TotalOvertime) AS TotalOvertime, " +
        //            "SUM(a.TotalHours) AS TotalHours FROM EmployeeAccounts ea " +
        //            "INNER JOIN Attendance a ON ea.EmployeeID = a.EmployeeID " +
        //            "GROUP BY ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();

        //            sda.Fill(dt);
        //            foreach(DataRow row in dt.Rows)
        //            {
        //                int n = dataGridView1.Rows.Add();
        //                dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
        //                dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
        //                dataGridView1.Rows[n].Cells["dgBasic"].Value = row["BasicRate"].ToString();
        //                dataGridView1.Rows[n].Cells["dgTHW"].Value = m.GetTotalHours(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
        //                dataGridView1.Rows[n].Cells["dgOT"].Value = m.GetTotalHoursOT(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
        //                dataGridView1.Rows[n].Cells["dgLate"].Value = m.GetTotalLateMin(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
        //                dataGridView1.Rows[n].Cells["dgAbsent"].Value = m.GetAbsents(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
        //            }
        //        }
        //    }
        //}

        public void LoadPayrollData()
        {
            DateTime dateStart = Convert.ToDateTime(dtStart.Value);
            DateTime dateEnd = Convert.ToDateTime(dtEnd.Value);

            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                // Use LEFT JOIN instead of INNER JOIN to include all employees
                string query = "SELECT ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate, " +
                                "ISNULL(SUM(a.TotalOvertime), 0) AS TotalOvertime, " +
                                "ISNULL(SUM(a.TotalHours), 0) AS TotalHours " +
                                "FROM EmployeeAccounts ea " +
                                "LEFT JOIN Attendance a ON ea.EmployeeID = a.EmployeeID " +
                                "WHERE a.Date BETWEEN @dateStart AND @dateEnd " + // Filter by date range
                                "GROUP BY ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dateStart", dateStart);
                    cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
                    cmd.Parameters.AddWithValue("@holiday", false);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgBasic"].Value = row["BasicRate"].ToString();
                        dataGridView1.Rows[n].Cells["dgTHW"].Value = m.GetTotalHours(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgOT"].Value = m.GetTotalHoursOT(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgLate"].Value = m.GetTotalLateMin(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgAbsent"].Value = m.GetAbsents(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                    }
                }
            }
        }

        public decimal GetHolidayRegularData(int empID, DateTime dateStart, DateTime dateEnd)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                // Use LEFT JOIN instead of INNER JOIN to include all employees
                string query = "SELECT ISNULL(SUM(TotalOvertime), 0) AS TotalOvertime, " +
                                "ISNULL(SUM(TotalHours), 0) AS TotalHours " +
                                "FROM Attendance WHERE Date BETWEEN @dateStart AND @dateEnd AND EmployeeID = @empID AND" +
                                " IsHoliday = @holiday AND HolidayType = @type ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dateStart", dateStart);
                    cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
                    cmd.Parameters.AddWithValue("@holiday", true);
                    cmd.Parameters.AddWithValue("@type", "Regular");
                    cmd.Parameters.AddWithValue("@empID", empID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Convert.ToDecimal(reader["TotalHours"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetHolidaySpecialData(int empID, DateTime dateStart, DateTime dateEnd)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                // Use LEFT JOIN instead of INNER JOIN to include all employees
                string query = "SELECT ISNULL(SUM(TotalOvertime), 0) AS TotalOvertime, " +
                                "ISNULL(SUM(TotalHours), 0) AS TotalHours " +
                                "FROM Attendance WHERE Date BETWEEN @dateStart AND @dateEnd AND EmployeeID = @empID AND" +
                                " IsHoliday = @holiday AND HolidayType = @type ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dateStart", dateStart);
                    cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
                    cmd.Parameters.AddWithValue("@holiday", true);
                    cmd.Parameters.AddWithValue("@type", "Special");
                    cmd.Parameters.AddWithValue("@empID", empID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Convert.ToDecimal(reader["TotalHours"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }


        private void SearchByName()
        {
            DateTime dateStart = Convert.ToDateTime(dtStart.Value.ToString("MM/dd/yyyy"));
            DateTime dateEnd = Convert.ToDateTime(dtEnd.Value.ToString("MM/dd/yyyy"));

            dataGridView1.Rows.Clear();
            string searchText = tbSearch.Text.Trim(); // Assuming txtSearchEmployee is your textbox

            string query = "SELECT ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate, " +
                                "ISNULL(SUM(a.TotalOvertime), 0) AS TotalOvertime, " +
                                "ISNULL(SUM(a.TotalHours), 0) AS TotalHours " +
                                "FROM EmployeeAccounts ea " +
                                "LEFT JOIN Attendance a ON ea.EmployeeID = a.EmployeeID " +
                                "WHERE a.Date BETWEEN @dateStart AND @dateEnd AND (ea.FirstName LIKE '%" + searchText + "%') " + // Filter by date range
                                "GROUP BY ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate";

            

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dateStart", dateStart);
                    cmd.Parameters.AddWithValue("@dateEnd", dateEnd);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgBasic"].Value = row["BasicRate"].ToString();
                        dataGridView1.Rows[n].Cells["dgTHW"].Value = m.GetTotalHours(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgOT"].Value = m.GetTotalHoursOT(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgLate"].Value = m.GetTotalLateMin(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                        dataGridView1.Rows[n].Cells["dgAbsent"].Value = m.GetAbsents(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
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
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = m.GetEmpName((int)row["EmployeeID"]);
                    }
                }
            }
        }

        


        private void employeeSalary_Load(object sender, System.EventArgs e)
        {
            btnCompute.Enabled = false;
            btnSave.Enabled = false;
            LoadPayrollData();
            SetPayPeriodDefaults();
            //SetDateTimePickerDates();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            empID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgEmpID"].Value.ToString());
            basicRate = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgBasic"].Value.ToString());
            totalHoursW = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgTHW"].Value.ToString());
            totalOvertime = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgOT"].Value.ToString());
            totalLate = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgLate"].Value.ToString());
            totalAbsent = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["dgAbsent"].Value.ToString());

            tbBasic.Text = basicRate.ToString();
            basicSalary = calBasicSalary(basicRate, totalHoursW);
            overtimePay = calOvertimePay(totalOvertime, basicRate);

            tbBasic.Text = basicSalary.ToString();
            tbOT.Text = overtimePay.ToString();
            tbPH.Text = calPH(setDeductions(1), Convert.ToDouble(tbBasic.Text)).ToString();
            
            tbIncentives.Text = "0";
            tbAdjustment.Text = "0";
            tbRegularH.Text = GetHolidayRegularData(empID, dtStart.Value, dtEnd.Value).ToString();
            tbSpecialH.Text = GetHolidaySpecialData(empID, dtStart.Value, dtEnd.Value).ToString();
            tbSSS.Text = "0";
            
            setAllowance(empID);
            //setOthers(empID);
            
            
            btnCompute.Enabled = true;

            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePayroll();
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Payroll Saved");
		}
        
        

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            LoadPayrollData();
            DateTime startDate = dtStart.Value.Date;
            dtEnd.Value = startDate.AddDays(15);
            dtEnd.Value = dtEnd.Value.Date <= startDate.AddMonths(1).AddDays(-1) ? dtEnd.Value.Date : startDate.AddMonths(1).AddDays(-1);
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadPayrollData();
            DateTime endDate = dtEnd.Value.Date;
            dtStart.Value = endDate.AddDays(-15);
            dtStart.Value = dtStart.Value.Date >= endDate.AddMonths(-1).AddDays(1) ? dtStart.Value.Date : endDate.AddMonths(-1).AddDays(1);
            //if (dtEnd.Value.Day != 12 && dtEnd.Value.Day != 28)
            //{
            //    MessageBox.Show("Only the 12th and 28th are allowed.");
            //    dtEnd.Value = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, 12); // Set default to 12

            //}
        }


        private void btnCompute_Click(object sender, EventArgs e)
        {
            ComputePayroll();
        }

        private void ComputePayroll()
        {
            gross = grossPay(basicSalary, Convert.ToDouble(tbIncentives.Text), Convert.ToDouble(tbTA.Text),
                Convert.ToDouble(tbTransA.Text), Convert.ToDouble(tbLoadA.Text), Convert.ToDouble(tbPTA.Text),
                overtimePay, Convert.ToDouble(tbRegularH.Text), Convert.ToDouble(tbSpecialH.Text),
                Convert.ToDouble(tbAdjustment.Text));

            if (dtEnd.Value.Day == 12)
            {
                tbSSS.Text = "0";
            }
            else
            {
                tbSSS.Text = calSSS(setDeductions(2), gross).ToString();
            }

            btnCompute.Enabled = false;
            btnSave.Enabled = true;
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Payroll Computed");
		}

        

        private void btnPayslip_Click_1(object sender, EventArgs e)
        {
            PaySlipReport pr = new PaySlipReport();
            pr.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            EmployeeReport er = new EmployeeReport();
            er.Show();
        }

        private void tbBasic_TextChanged(object sender, EventArgs e)
        {
            setAllowance(empID);
            //setOthers(empID);
            tbPagibig.Text = calPagIbig().ToString();
            tbLate.Text = totalLate.ToString();
            tbAbsent.Text = totalAbsent.ToString();
        }

        public bool InsertIntoPayroll(int empID, double semiP, double dailyR, DateTime payStart, DateTime payEnd, DateTime payOut,
                              double totalH, double ot, double regh, double specialh, double oba, double rest, double loadA,
                              double transA, double adj, double incentives, double trainA, double provTA, double late, double savings,
                              double cashA, double gross, double netPay, double philHealth, double pagIbig, double sss,
                              double dtotal, double thp)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Payroll (EmployeeID, SemiMonthly, DailyRate, PayPeriodStart, 
                    PayPeriodEnd, PayOutDate, TotalHours, OverTimePay, RegularH, SpecialH, OBA, RestDay, LoadA, TransA, 
                    Adjustments, Incentives, TrainA, ProvTA, Late, Savings, CashA, GrossPay, NetPay, PhilHealth, PagIbig, 
                    SSS, DeductionTotal, TotalHoursPay, SSSLoan, PagIbigLoan, CompanyLoan) VALUES (@EmployeeID, @SemiMonthly,
                    @DailyRate, @PayPeriodStart, @PayPeriodEnd, @PayOutDate,@TotalHours, @OverTimePay, @RegularH, @SpecialH, 
                    @OBA, @RestDay, @LoadA, @TransA, @Adjustments, @Incentives, @TrainA, @ProvTA, @Late, @Savings, @CashA, 
                    @GrossPay, @NetPay, @PhilHealth, @PagIbig, @SSS, @dtotal, @thp, @sssl, @pagibigl, @companyl)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parameterized Query for All Columns
                        cmd.Parameters.AddWithValue("@EmployeeID", empID);
                        cmd.Parameters.AddWithValue("@SemiMonthly", semiP);
                        cmd.Parameters.AddWithValue("@DailyRate", dailyR);
                        cmd.Parameters.AddWithValue("@PayPeriodStart", payStart);
                        cmd.Parameters.AddWithValue("@PayPeriodEnd", payEnd);
                        cmd.Parameters.AddWithValue("@PayOutDate", payOut);
                        cmd.Parameters.AddWithValue("@TotalHours", totalH);
                        cmd.Parameters.AddWithValue("@OverTimePay", ot);
                        cmd.Parameters.AddWithValue("@RegularH", regh);
                        cmd.Parameters.AddWithValue("@SpecialH", specialh);
                        cmd.Parameters.AddWithValue("@OBA", oba);
                        cmd.Parameters.AddWithValue("@RestDay", rest);
                        cmd.Parameters.AddWithValue("@LoadA", loadA);
                        cmd.Parameters.AddWithValue("@TransA", transA);
                        cmd.Parameters.AddWithValue("@Adjustments", adj);
                        cmd.Parameters.AddWithValue("@Incentives", incentives);
                        cmd.Parameters.AddWithValue("@TrainA", trainA);
                        cmd.Parameters.AddWithValue("@ProvTA", provTA);
                        cmd.Parameters.AddWithValue("@Late", late);
                        cmd.Parameters.AddWithValue("@Savings", savings);
                        cmd.Parameters.AddWithValue("@CashA", cashA);
                        cmd.Parameters.AddWithValue("@GrossPay", gross);
                        cmd.Parameters.AddWithValue("@NetPay", netPay);
                        cmd.Parameters.AddWithValue("@PhilHealth", philHealth);
                        cmd.Parameters.AddWithValue("@PagIbig", pagIbig);
                        cmd.Parameters.AddWithValue("@SSS", sss);
                        cmd.Parameters.AddWithValue("@dtotal", dtotal);
                        cmd.Parameters.AddWithValue("@thp", thp);
                        cmd.Parameters.AddWithValue("@sssl", m.GetSSSLoan(empID));
                        cmd.Parameters.AddWithValue("@pagibigl", m.GetHDMFLoan(empID));
                        cmd.Parameters.AddWithValue("@companyl", m.GetCompanyLoan(empID));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting into Payroll: " + ex.Message);
                    return false;
                }
            }
        }

        private void SavePayroll()
        {
            double incentives = Convert.ToDouble(tbIncentives.Text);
            double regH = Convert.ToDouble(tbIncentives.Text);
            double specialH = Convert.ToDouble(tbIncentives.Text);
            double adj = Convert.ToDouble(tbIncentives.Text);

            double trainA = Convert.ToDouble(tbTA.Text);
            double transA = Convert.ToDouble(tbTransA.Text);
            double loadA = Convert.ToDouble(tbLoadA.Text);
            double provA = Convert.ToDouble(tbPTA.Text);
            double obA = Convert.ToDouble(tbOBA.Text);

            double phil = Convert.ToDouble(tbPH.Text);
            double pagibig = Convert.ToDouble(tbPagibig.Text);
            double sss = Convert.ToDouble(tbSSS.Text);

            double deductionT = phil + pagibig + sss;
            double netpay = gross - deductionT;
            double totalHP = (totalHoursW / 8) * basicRate;
            double semiM = basicRate * 15;

            DateTime dateStart = Convert.ToDateTime(dtStart.Value);
            DateTime dateEnd = Convert.ToDateTime(dtEnd.Value);


            if (!IfPaySlipExist(empID))
            {
                InsertIntoPayroll(empID, semiM, basicRate, dateStart, dateEnd, dateEnd.AddDays(2), totalHoursW,
                totalOvertime, regH, specialH, obA, 0, loadA, transA, adj, incentives, trainA, provA, totalLate,
                0, 0, gross, netpay, phil, pagibig, sss, deductionT, totalHP);

                MessageBox.Show("Payslip Recorded!");
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("payslip already exist");
                btnSave.Enabled = false;
            }
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

            if (today.Day <= 12)
            {
                payPeriodStart = new DateTime(today.Year, today.Month, 1);
                payPeriodEnd = new DateTime(today.Year, today.Month, 12);
            }
            else
            {
                payPeriodStart = new DateTime(today.Year, today.Month, 13);
                payPeriodEnd = new DateTime(today.Year, today.Month, 28);
            }

            dtStart.Value = payPeriodStart;
            dtEnd.Value = payPeriodEnd;
        }

        public bool IfPaySlipExist(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Payroll WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
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

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length != 0)
            {
                SearchByName();
            }
            else
            {
                LoadPayrollData();
            }
        }

        //private void SetDateTimePickerDates()
        //{
        //    // Get the current year
        //    int currentYear = DateTime.Now.Year;

        //    // Set the minimum and maximum dates for each month
        //    for (int month = 1; month <= 12; month++)
        //    {
        //        // Calculate the 12th day of the month
        //        DateTime twelfthDay = new DateTime(currentYear, month, 12);

        //        // Set the minimum and maximum dates for the DateTimePicker
        //        dtEnd.MaxDate = twelfthDay;

        //        // Break the loop if the current month is reached
        //        if (month == DateTime.Now.Month)
        //        {
        //            break;
        //        }
        //    }
        //}
    }
}
