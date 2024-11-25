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
        private decimal basicRate = 0;
        private decimal totalHoursW = 0;
        private decimal totalOvertime = 0;
        private decimal totalLate = 0;
        private decimal totalAbsent = 0;

        private decimal basicSalary = 0;
        private decimal overtimePay = 0;
        private decimal gross = 0;

        private int taxID = 0;
        private decimal tax = 0;

        private int empID = 0;
        public employeeSalary()
        {
            InitializeComponent();
        }

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
                                "ISNULL(SUM(CASE WHEN a.TotalHours >= 0 THEN a.TotalHours ELSE 0 END), 0) AS TotalHours, " + // Filter negative TotalHours
                                "ISNULL(SUM(a.TotalOvertime), 0) AS TotalOvertime, " +
                                "ISNULL(SUM(a.Late), 0) AS TotalLate " +
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
                        dataGridView1.Rows[n].Cells["dgTHW"].Value = row["TotalHours"].ToString();  // Assuming "dgTHW" refers to TotalHours
                        dataGridView1.Rows[n].Cells["dgOT"].Value = row["TotalOvertime"].ToString();
                        dataGridView1.Rows[n].Cells["dgLate"].Value = row["TotalLate"].ToString();
                        dataGridView1.Rows[n].Cells["dgAbsent"].Value = m.GetAbsents(dateStart, dateEnd, (int)row["EmployeeID"]).ToString();
                    }
                }
            }
        }

        //public void LoadPayrollData()
        //{
        //    DateTime dateStart = Convert.ToDateTime(dtStart.Value);
        //    DateTime dateEnd = Convert.ToDateTime(dtEnd.Value);

        //    dataGridView1.Rows.Clear();
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();

        //        string query = "SELECT ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate, " +
        //                       "SUM(CASE WHEN a.IsOvertime THEN a.TotalHours ELSE 0 END) AS TotalOvertime, " +
        //                       "SUM(a.TotalHours) AS TotalHours, " +
        //                       "(ea.BasicRate * SUM(a.TotalHours)) AS NetPay " +  // Include additional calculations
        //                       "FROM EmployeeAccounts ea " +
        //                       "LEFT JOIN Attendance a ON ea.EmployeeID = a.EmployeeID " +
        //                       "WHERE a.Date BETWEEN @dateStart AND @dateEnd " +
        //                       "GROUP BY ea.EmployeeID, ea.FirstName, ea.LastName, ea.BasicRate";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@dateStart", dateStart);
        //            cmd.Parameters.AddWithValue("@dateEnd", dateEnd);

        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);

        //                foreach (DataRow row in dt.AsEnumerable())
        //                {
        //                    int n = dataGridView1.Rows.Add();
        //                    dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"];
        //                    dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"] + " " + row["LastName"];
        //                    dataGridView1.Rows[n].Cells["dgBasic"].Value = row["BasicRate"];
        //                    dataGridView1.Rows[n].Cells["dgTHW"].Value = row["TotalHours"];
        //                    dataGridView1.Rows[n].Cells["dgOT"].Value = row["TotalOvertime"];
        //                    dataGridView1.Rows[n].Cells["dgNetPay"].Value = row["NetPay"];
        //                    // Add additional cells for calculations like Net Pay
        //                }
        //            }
        //        }
        //    }
        //}

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
                                "ISNULL(SUM(a.TotalHours), 0) AS TotalHours, " +
                                "ISNULL(SUM(a.Late), 0) AS TotalLate " +
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
                        dataGridView1.Rows[n].Cells["dgTHW"].Value = row["TotalHours"].ToString();
                        dataGridView1.Rows[n].Cells["dgOT"].Value = row["TotalOvertime"].ToString();
                        dataGridView1.Rows[n].Cells["dgLate"].Value = row["TotalLate"].ToString();
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
            basicRate = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["dgBasic"].Value.ToString());
            totalHoursW = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["dgTHW"].Value.ToString());
            totalOvertime = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["dgOT"].Value.ToString());
            totalLate = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["dgLate"].Value.ToString());
            totalAbsent = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["dgAbsent"].Value.ToString());

            
            
            //setOthers(empID);
            
            
            btnCompute.Enabled = true;

            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePayroll();
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Salary Saved");
		}
        
        

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime endDate = dtEnd.Value.Date;
            //m.GetPayStart() value is 12
            //m.GetPayEnd() value is 28

            if (dtEnd.Value.Day != m.GetPayStart() && dtEnd.Value.Day != m.GetPayEnd())
            {
                MessageBox.Show("Only days" + m.GetPayStart() + " and " + m.GetPayEnd() + " are allowed.");
                dtEnd.Value = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, m.GetPayStart());
            }

            if (endDate.Day == m.GetPayStart())
            {
                dtStart.Value = new DateTime(endDate.Year, endDate.Month - 1, m.GetPayEnd() + 1);
            }
            else if (endDate.Day == m.GetPayEnd())
            {
                
                dtStart.Value = new DateTime(endDate.Year, endDate.Month, m.GetPayStart() + 1);
            }

            LoadPayrollData();
        }


        private void btnCompute_Click(object sender, EventArgs e)
        {
            ComputePayroll();
        }

        private void ComputePayroll()
        {
            decimal workdays = CalculateWorkdays(dtStart.Value, dtEnd.Value);
            if(m.GetEmployeeType(empID).ToString() == "Regular" || m.GetEmployeeType(empID).ToString() == "Probationary")
            {
                basicSalary = basicRate * workdays;
            }

            if (m.GetEmployeeType(empID).ToString() == "Part-Time")
            {
                basicSalary = calBasicSalary(basicRate, totalHoursW);
            }
            
            overtimePay = calOvertimePay(totalOvertime, basicRate);

            tbBasic.Text = basicSalary.ToString();
            tbOT.Text = overtimePay.ToString();
            tbLate.Text = Math.Round(calLate(totalLate, basicRate), 2).ToString();
            tbAbsent.Text = (CountAbsences(dtStart.Value, dtEnd.Value, empID) * basicRate).ToString();
            //MessageBox.Show(Math.Round((calLate(totalLate) * (basicRate / 8)), 2).ToString());

            tbIncentives.Text = GetIncentives(empID).ToString();
            tbAdjustment.Text = GetAdjustment(empID).ToString();

            decimal thwRH = GetHolidayRegularData(empID, dtStart.Value, dtEnd.Value);
            decimal thwSH = GetHolidaySpecialData(empID, dtStart.Value, dtEnd.Value);

            tbRegularH.Text = Math.Round(calBasicSalary(basicRate, thwRH), 2).ToString();
            tbSpecialH.Text = Math.Round(calSpecialH(basicRate, thwSH), 2).ToString();

            setAllowance(empID);

            //basicSalary = basicSalary - Convert.ToDecimal(tbLate.Text);

            gross = grossPay(Convert.ToDecimal(tbBasic.Text), Convert.ToDecimal(tbIncentives.Text), Convert.ToDecimal(tbTA.Text),
                Convert.ToDecimal(tbTransA.Text), Convert.ToDecimal(tbLoadA.Text), Convert.ToDecimal(tbPTA.Text),
                overtimePay, Convert.ToDecimal(tbRegularH.Text), Convert.ToDecimal(tbSpecialH.Text),
                Convert.ToDecimal(tbAdjustment.Text), Convert.ToDecimal(tbOBA.Text));

            tbGross.Text = gross.ToString();
            tbSSS.Text = "0";
            tbPagibig.Text = "0";
            tbPH.Text = "0";

            if(getPeriod(1) == "1st" && dtEnd.Value.Day == m.GetPayStart())
            {
                tbPH.Text = calPH(setDeductions(1), (decimal)Convert.ToDouble(tbBasic.Text)).ToString();
            }

            if (getPeriod(2) == "1st" && dtEnd.Value.Day == m.GetPayStart())
            {
                tbSSS.Text = calSSS(setDeductions(2), (decimal)gross).ToString();
            }

            if (getPeriod(3) == "1st" && dtEnd.Value.Day == m.GetPayStart())
            {
                MessageBox.Show(calPH(setDeductions(3), Convert.ToDecimal(tbBasic.Text)).ToString());
                tbPagibig.Text = calPagIbig(setDeductions(3)).ToString();
            }

            if (getPeriod(1) == "2nd" && dtEnd.Value.Day == m.GetPayEnd())
            {
                tbPH.Text = calPH(setDeductions(1), (decimal)Convert.ToDouble(tbBasic.Text)).ToString();
            }

            if (getPeriod(2) == "2nd" && dtEnd.Value.Day == m.GetPayEnd())
            {
                tbSSS.Text = calSSS(setDeductions(2), (decimal)gross).ToString();
            }

            if (getPeriod(3) == "2nd" && dtEnd.Value.Day == m.GetPayEnd())
            {
                tbPagibig.Text = calPagIbig(setDeductions(3)).ToString();
            }

            taxID = isTaxID((decimal)basicSalary);
            tax = calWithholdingTax(GetWTaxAmount(taxID), GetWTaxAdditional(taxID), gross);


            tbTax.Text = tax.ToString();

            MessageBox.Show((gross).ToString());
            //gross = basicSalary - tax;

            

            btnCompute.Enabled = false;
            btnSave.Enabled = true;
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Salary Computed");
		}

        public int CalculateWorkdays(DateTime startDate, DateTime endDate)
        {
            int totalDays = (endDate - startDate).Days + 1;

            // Calculate Sundays between the dates
            int sundays = totalDays / 7;

            // Adjust for partial weeks at the beginning and end
            if (startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sundays--;
            }
            if (endDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sundays--;
            }

            return totalDays - sundays;
        }

        public decimal CountAbsences(DateTime startDate, DateTime endDate, int employeeId)
        {
            // Calculate the total number of days between the two dates, including both endpoints
            int totalDays = (endDate - startDate).Days + 1;

            // Calculate the number of Sundays between the two dates
            int sundays = totalDays / 7;

            // Adjust for partial weeks at the beginning and end
            if (startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sundays--;
            }
            if (endDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sundays--;
            }

            // Calculate the expected number of workdays
            int expectedWorkdays = totalDays - sundays;

            // Get the actual number of workdays from the database
            int actualWorkdays = GetActualWorkdays(startDate, endDate, employeeId);

            // Calculate the number of absences
            int absences = expectedWorkdays - actualWorkdays;

            return absences;
        }

        private int GetActualWorkdays(DateTime startDate, DateTime endDate, int employeeId)
        {
            // SQL query to count workdays
            string query = "SELECT COUNT(*) FROM Attendance WHERE EmployeeID = @employeeId AND Date BETWEEN @startDate AND @endDate AND TotalHours != 0";

            using (SqlConnection conn = new SqlConnection(m.connStr))

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeId",
         employeeId);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);


                    int actualWorkdays = (int)cmd.ExecuteScalar();
                    return actualWorkdays;
                }
            }
        }


        public string getPeriod(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Period FROM Deductions WHERE DeductionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Period"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
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
        }

        public bool InsertIntoPayroll(int empID, decimal semiP, decimal dailyR, DateTime payStart, DateTime payEnd, DateTime payOut,
                              decimal totalH, decimal ot, decimal regh, decimal specialh, decimal oba, decimal rest, decimal loadA,
                              decimal transA, decimal adj, decimal incentives, decimal trainA, decimal provTA, decimal late, decimal savings,
                              decimal cashA, decimal gross, decimal netPay, decimal philHealth, decimal pagIbig, decimal sss,
                              decimal dtotal, decimal thp)
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
            decimal incentives = Convert.ToDecimal(tbIncentives.Text);
            decimal regH = Convert.ToDecimal(tbRegularH.Text);
            decimal specialH = Convert.ToDecimal(tbSpecialH.Text);
            decimal adj = Convert.ToDecimal(tbAdjustment.Text);
            decimal lateA = Convert.ToDecimal(tbAbsent.Text) + Convert.ToDecimal(tbLate.Text); ;

            decimal trainA = Convert.ToDecimal(tbTA.Text);
            decimal transA = Convert.ToDecimal(tbTransA.Text);
            decimal loadA = Convert.ToDecimal(tbLoadA.Text);
            decimal provA = Convert.ToDecimal(tbPTA.Text);
            decimal obA = Convert.ToDecimal(tbOBA.Text);

            decimal phil = Convert.ToDecimal(tbPH.Text);
            decimal pagibig = Convert.ToDecimal(tbPagibig.Text);
            decimal sss = Convert.ToDecimal(tbSSS.Text);

            decimal deductionT = phil + pagibig + sss;
            decimal grossPay = gross - tax;
            decimal netpay = grossPay - (deductionT + lateA);
            decimal totalHP = ((decimal)totalHoursW / 8) * basicRate;
            decimal semiM = Convert.ToDecimal(tbBasic.Text);


            DateTime dateStart = Convert.ToDateTime(dtStart.Value);
            DateTime dateEnd = Convert.ToDateTime(dtEnd.Value);


            if (!IfPaySlipExist(empID, dateStart, dateEnd))
            {
                InsertIntoPayroll(empID, semiM, basicRate, dateStart, dateEnd, dateEnd.AddDays(2), totalHoursW,
                totalOvertime, regH, specialH, obA, 0, loadA, transA, adj, incentives, trainA, provA, lateA,
                0, 0, grossPay, netpay, phil, pagibig, sss, deductionT, totalHP);

                MessageBox.Show("Payslip Recorded!");
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("payslip already exist");
                btnSave.Enabled = false;
            }
        }
        
        

        public int isTaxID(decimal salary)
        {
            if (salary <= 10417)
            {
                return 1006;
            }
            else if (salary >= 10417 && salary <= 16666)
            {
                return 4;
            }
            else if (salary >= 16666 && salary <= 33332)
            {
                return 5;
            }
            else if (salary >= 33333 && salary <= 83332)
            {
                return 6;
            }
            else if (salary >= 83333 && salary <= 333332)
            {
                return 7;
            }
            else if (salary >= 333333)
            {
                return 1005;
            }
            else
            {
                return 0;
            }
        }

        public decimal IfNegative(decimal thw, decimal value)
        {
            if (thw < 0)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        

        public int GetWTaxAmount(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Amount FROM Deductions WHERE DeductionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["Amount"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public decimal GetWTaxAdditional(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Additional FROM Deductions WHERE DeductionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Convert.ToDecimal(reader["Additional"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetIncentives(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Incentives FROM Others WHERE EmployeeID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Convert.ToDecimal(reader["Incentives"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetAdjustment(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Adjustment FROM Others WHERE EmployeeID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Convert.ToDecimal(reader["Adjustment"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private decimal calWithholdingTax(decimal percent, decimal adds, decimal gross)
        {
            return (gross * (percent / 100)) + adds;
        }

        private decimal calBasicSalary(decimal basicRate, decimal tHW)
        {
            return (basicRate / 8) * tHW;
        }

        private decimal calOvertimePay(decimal overtime, decimal basic)
        {
            decimal OvertimeRate = (basic / 8m) * 1.25m;
            return OvertimeRate * overtime;
        }

        private decimal calPH(decimal ph, decimal basicSalary)
        {
            return (ph / 100) * basicSalary;
        }

        private decimal calSSS(decimal sss, decimal gross)
        {
            return (sss / 100) * gross;
        }

        private decimal calPagIbig(decimal pagibig)
        {
            return pagibig;
        }

        private decimal calSpecialH(decimal basicRate, decimal thW)
        {
            return ((basicRate / 8) * thW) * 0.30m;
        }

        private decimal calLate(decimal late, decimal basicRate)
        {
            return (basicRate / 8) * (late / 60);
        }

        private decimal grossPay(decimal basicSalary, decimal incentives, decimal trainA, decimal transA, decimal loadA, decimal provA, decimal ot, decimal regH, decimal slH, decimal adj ,decimal ob)
        {
            return basicSalary + incentives + trainA + transA + loadA + provA + ot + regH + slH + adj + ob;
        }

        public decimal setDeductions(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Amount FROM Deductions WHERE DeductionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id ", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            return Convert.ToDecimal(reader["Amount"]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
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

            if (today.Day <= m.GetPayStart())
            {
                payPeriodEnd = new DateTime(today.Year, today.Month, m.GetPayStart());
            }
            else
            {
                payPeriodEnd = new DateTime(today.Year, today.Month, m.GetPayEnd());
            }

            dtEnd.Value = payPeriodEnd;
        }

        public bool IfPaySlipExist(int employeeID, DateTime dateFrom, DateTime dateTo)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Payroll " +
                               "WHERE EmployeeID = @employeeID AND PayPeriodStart = @dateFrom AND PayPeriodEnd = @dateTo";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                    cmd.Parameters.AddWithValue("@dateTo", dateTo);

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

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void btnEditPeriod_Click(object sender, EventArgs e)
        {
            PayPeriod pay = new PayPeriod();
            pay.Show();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            tbPagibig.Text = "0";
            tbPH.Text = "0";
            tbSSS.Text = "0";
        }
    }
}
