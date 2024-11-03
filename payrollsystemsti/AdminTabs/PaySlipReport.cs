using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
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
    public partial class PaySlipReport : Form
    {
        Methods m = new Methods();
        public static PaySlipReport pr;

        public int empID;
        public PaySlipReport()
        {
            InitializeComponent();
            pr = this;
        }

        private void PaySlipReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            SetPayPeriodDefaults();
            DateSource();
            
        }

        private void DateSource()
        {
            List<DateTime> payPeriodEnds = new List<DateTime>();

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT DISTINCT PayPeriodEnd FROM Payroll";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("PayPeriodEnd")))
                            {
                                payPeriodEnds.Add(Convert.ToDateTime(reader["PayPeriodEnd"]));
                            }
                        }
                    }
                }
            }

            cbPayDates.DataSource = payPeriodEnds;
            cbPayDates.DisplayMember = "Date"; // Assuming payDates is a ComboBox
            cbPayDates.ValueMember = "Date";
        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadReportBatch()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Payroll.*, EmployeeAccounts.FirstName, EmployeeAccounts.LastName," +
                    " Loans.SSS AS LoanSSS, Loans.HDMF AS LoanHDMF, Loans.Company AS LoanCompany FROM Payroll " +
                    "LEFT JOIN EmployeeAccounts ON Payroll.EmployeeID = EmployeeAccounts.EmployeeID LEFT JOIN " +
                    "Loans ON Payroll.EmployeeID = Loans.EmployeeID WHERE PayPeriodEnd = @payperiodend";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payperiodend", Convert.ToDateTime(cbPayDates.Text));

                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);

                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource source = new ReportDataSource("DataSet1", dt);
                    string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string reportPath = userDirectory +@"\Source\Repos\patatafiend\payrollsystem\payrollsystemsti\AdminTabs\Report1.rdlc";
                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Add(source);
                    reportViewer1.RefreshReport();
                    MessageBox.Show(reportPath);
                }
            }
        }

        private void LoadReportSingle()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Payroll.*, EmployeeAccounts.FirstName, EmployeeAccounts.LastName," +
                    " Loans.SSS AS LoanSSS, Loans.HDMF AS LoanHDMF, Loans.Company AS LoanCompany FROM Payroll " +
                    "LEFT JOIN EmployeeAccounts ON Payroll.EmployeeID = EmployeeAccounts.EmployeeID LEFT JOIN " +
                    "Loans ON Payroll.EmployeeID = Loans.EmployeeID WHERE EmployeeAccounts.EmployeeID = @empID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", m.GetEmployeeIdByName(tbSearch.Text));
                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);

                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource source = new ReportDataSource("DataSet1", dt);
                    string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string reportPath = userDirectory + @"\Source\Repos\patatafiend\payrollsystem\payrollsystemsti\AdminTabs\Report1.rdlc";
                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Add(source);
                    reportViewer1.RefreshReport();
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

            //dtStart.Value = payPeriodStart;
            //dtEnd.Value = payPeriodEnd;
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            //DateTime startDate = dtStart.Value.Date;
            //dtEnd.Value = startDate.AddDays(14);
            //dtEnd.Value = dtEnd.Value.Date <= startDate.AddMonths(1).AddDays(-1) ? dtEnd.Value.Date : startDate.AddMonths(1).AddDays(-1);
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            //DateTime endDate = dtEnd.Value.Date;
            //dtStart.Value = endDate.AddDays(-14);
            //dtStart.Value = dtStart.Value.Date >= endDate.AddMonths(-1).AddDays(1) ? dtStart.Value.Date : endDate.AddMonths(-1).AddDays(1);
        }
        private AutoCompleteStringCollection suggest = new AutoCompleteStringCollection();

        public void SearchForName()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                // Improved query: Use OR instead of AND for searching first or last name
                string query = "SELECT FirstName, LastName FROM EmployeeAccounts WHERE FirstName LIKE @SearchTerm + '%' OR LastName LIKE @SearchTerm + '%'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm",tbSearch.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Improved readability: Use string formatting
                            suggest.Add(string.Format("{0} {1}", reader["FirstName"], reader["LastName"]));
                            //MessageBox.Show("yessssir");
                        }
                    }
                    tbSearch.AutoCompleteCustomSource = suggest;
                    
                }
            }
        }




        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchForName();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (btnSingle.Enabled)
            {
                LoadReportSingle();
            }
            else if (!btnSingle.Enabled && btnBatch.Enabled)
            {
                LoadReportBatch();
            }
            else
            {
                MessageBox.Show("No payslip to load");
            }
            
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            tbSearch.Enabled = true;
            btnLoad.Enabled = true;
            btnBatch.Enabled = false;
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            cbPayDates.Enabled = true;
            btnLoad.Enabled = true;
            btnSingle.Enabled = false;
        }

        //public void SetPaySlipInfo(int empID)
        //{
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();
        //        string query = @"SELECT ea.EmployeeID, ea.FirstName, ea.LastName, p.SemiMonthly, p.DailyRate,
        //                p.PayPeriodStart, p.PayPeriodEnd, p.PayOutDate, p.TotalHours, p.TotalHoursPay,
        //                p.OverTimePay, p.RegularH, p.SpecialH, p.OBA, p.RestDay, p.LoadA, 
        //                p.TransA, p.Adjustments, p.Incentives, p.TrainA, p.ProvTA, p.Late, 
        //                p.Savings, p.CashA, p.GrossPay, p.NetPay, p.PhilHealth, p.PagIbig, p.SSS, 
        //                p.DeductionTotal
        //                FROM EmployeeAccounts ea 
        //                INNER JOIN Payroll p ON ea.EmployeeID = p.EmployeeID 
        //                WHERE ea.EmployeeID = @empID";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@empID", empID);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    ReportParameter[] parameters = new ReportParameter[]
        //                    {
        //                        // Existing parameters (ID_NO, pName, Cp_Start, Cp_End, Total_A, Total_Netpay)
        //                        new ReportParameter("ID_NO", reader["EmployeeID"].ToString()),
        //                        new ReportParameter("pName", reader["FirstName"].ToString() + " " + reader["LastName"].ToString()),
        //                        new ReportParameter("Cp_Start", Convert.ToDateTime(reader["PayPeriodStart"]).ToString("yyyy-MM-dd")),
        //                        new ReportParameter("Cp_End", Convert.ToDateTime(reader["PayPeriodEnd"]).ToString("yyyy-MM-dd")),
        //                        new ReportParameter("Total_A", Convert.ToDecimal(reader["GrossPay"]).ToString("")),
        //                        new ReportParameter("Total_Netpay", Convert.ToDecimal(reader["NetPay"]).ToString("")),

        //                        // Added parameters based on the Payroll table
        //                        new ReportParameter("SM", reader["SemiMonthly"].ToString()),
        //                        new ReportParameter("DR", Convert.ToDecimal(reader["DailyRate"]).ToString("")),
        //                        new ReportParameter("POD", Convert.ToDateTime(reader["PayOutDate"]).ToString("yyyy-MM-dd")),
        //                        new ReportParameter("NODW", reader["TotalHours"].ToString()),
        //                        new ReportParameter("NO_OTP", reader["OverTimePay"].ToString()),
        //                        new ReportParameter("A_NODW", Convert.ToDecimal(reader["TotalHoursPay"]).ToString()), // Assuming this is what you meant by "totalHoursPay"
        //                        new ReportParameter("A_OTP", Convert.ToDecimal(reader["OverTimePay"]).ToString()),
        //                        new ReportParameter("A_LH", Convert.ToDecimal(reader["RegularH"]).ToString()),
        //                        new ReportParameter("A_SH", Convert.ToDecimal(reader["SpecialH"]).ToString()),
        //                        new ReportParameter("A_OBA", Convert.ToDecimal(reader["OBA"]).ToString()),
        //                        new ReportParameter("A_RD", Convert.ToDecimal(reader["RestDay"]).ToString()),
        //                        new ReportParameter("A_LA", Convert.ToDecimal(reader["LoadA"]).ToString()),
        //                        new ReportParameter("A_TA", Convert.ToDecimal(reader["TransA"]).ToString()),
        //                        new ReportParameter("A_ADJ", Convert.ToDecimal(reader["Adjustments"]).ToString()),
        //                        new ReportParameter("A_INC", Convert.ToDecimal(reader["Incentives"]).ToString()),
        //                        new ReportParameter("A_TRNGA", Convert.ToDecimal(reader["TrainA"]).ToString()),
        //                        new ReportParameter("A_PTA", Convert.ToDecimal(reader["ProvTA"]).ToString()),
        //                        new ReportParameter("D_LU", Convert.ToDecimal(reader["Late"]).ToString()),
        //                        new ReportParameter("D_SVNGS", Convert.ToDecimal(reader["Savings"]).ToString()),
        //                        new ReportParameter("D_CA", Convert.ToDecimal(reader["CashA"]).ToString()),
        //                        new ReportParameter("D_SSS", Convert.ToDecimal(reader["SSS"]).ToString()),
        //                        new ReportParameter("D_PHLHLTH", Convert.ToDecimal(reader["PhilHealth"]).ToString()),
        //                        new ReportParameter("D_PI", Convert.ToDecimal(reader["PagIbig"]).ToString()),
        //                        new ReportParameter("Total_D", Convert.ToDecimal(reader["DeductionTotal"]).ToString())
        //                    };

        //                    reportViewer1.LocalReport.SetParameters(parameters);
        //                    reportViewer1.RefreshReport();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No payroll data found for this employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //}


        //public void dataSource(int empID)
        //{
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();
        //        string query = "SELECT * FROM Payroll WHERE EmployeeID = @empID";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@empID", empID);

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                adapter.Fill(dt);
        //                if (dt.Rows.Count > 0) // Ensure we have data
        //                {
        //                    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
        //                    reportViewer1.LocalReport.DataSources.Clear(); // Clear any existing data sources
        //                    reportViewer1.LocalReport.DataSources.Add(rds);
        //                }
        //            }
        //        }
        //    }
        //}



        //public void SetPaySlipInfo(int empID)
        //{
        //    using (SqlConnection conn = new SqlConnection(m.connStr))
        //    {
        //        conn.Open();
        //        string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.FirstName, EmployeeAccounts.LastName, " +
        //                       "Payroll.PayPeriodStart, Payroll.PayPeriodEnd, Payroll.GrossPay, Payroll.NetPay " +
        //                       "FROM EmployeeAccounts " +
        //                       "INNER JOIN Payroll ON EmployeeAccounts.EmployeeID = Payroll.EmployeeID " +
        //                       "WHERE EmployeeAccounts.EmployeeID = @empID";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@empID", empID);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read()) 
        //                {
        //                    ReportParameter[] parameters = new ReportParameter[]
        //                    {
        //                        new ReportParameter("ID_NO", reader["EmployeeID"].ToString()),
        //                        new ReportParameter("pName", reader["FirstName"].ToString() + " " + reader["LastName"].ToString()),
        //                        new ReportParameter("Cp_Start", Convert.ToDateTime(reader["PayPeriodStart"]).ToString("yyyy-MM-dd")),
        //                        new ReportParameter("Cp_End", Convert.ToDateTime(reader["PayPeriodEnd"]).ToString("yyyy-MM-dd")),
        //                        new ReportParameter("Total_A", Convert.ToDecimal(reader["GrossPay"]).ToString("C")),
        //                        new ReportParameter("Total_Netpay", Convert.ToDecimal(reader["NetPay"]).ToString("C"))
        //                    };

        //                    reportViewer1.LocalReport.SetParameters(parameters);

        //                    reportViewer1.RefreshReport();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No payroll data found for this employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //}
    }

}
