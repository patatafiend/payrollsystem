using Microsoft.Reporting.WinForms;
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
    public partial class EmployeeReport : Form
    {
        Methods m = new Methods();
        public EmployeeReport()
        {
            InitializeComponent();
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

            cbDates.DataSource = payPeriodEnds;
            cbDates.DisplayMember = "Date"; // Assuming payDates is a ComboBox
            cbDates.ValueMember = "Date";
        }

        private void EmployeeReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            DateSource();
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
                    cmd.Parameters.AddWithValue("@payperiodend", Convert.ToDateTime(cbDates.Text));

                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);

                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource source = new ReportDataSource("EmployeeReports", dt);
                    string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string reportPath = userDirectory + @"\Source\Repos\patatafiend\payrollsystem\payrollsystemsti\AdminTabs\Report2.rdlc";
                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Add(source);
                    reportViewer1.RefreshReport();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadReportBatch();
        }

        private void cbDates_TextChanged(object sender, EventArgs e)
        {
            if (cbDates.SelectedIndex >= 0)
            {
                btnLoad.Enabled = true;
            }
        }
    }
}
