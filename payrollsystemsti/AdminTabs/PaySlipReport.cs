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
            dataSource(empID);
            SetPaySlipInfo(empID);
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        public void SetPaySlipInfo(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeAccounts.EmployeeID, EmployeeAccounts.FirstName, EmployeeAccounts.LastName, " +
                               "Payroll.PayPeriodStart, Payroll.PayPeriodEnd, Payroll.GrossPay, Payroll.NetPay " +
                               "FROM EmployeeAccounts " +
                               "INNER JOIN Payroll ON EmployeeAccounts.EmployeeID = Payroll.EmployeeID " +
                               "WHERE EmployeeAccounts.EmployeeID = @empID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            ReportParameter[] parameters = new ReportParameter[]
                            {
                                new ReportParameter("ID_NO", reader["EmployeeID"].ToString()),
                                new ReportParameter("pName", reader["FirstName"].ToString() + " " + reader["LastName"].ToString()),
                                new ReportParameter("Cp_Start", Convert.ToDateTime(reader["PayPeriodStart"]).ToString("yyyy-MM-dd")),
                                new ReportParameter("Cp_End", Convert.ToDateTime(reader["PayPeriodEnd"]).ToString("yyyy-MM-dd")),
                                new ReportParameter("Total_A", Convert.ToDecimal(reader["GrossPay"]).ToString("C")),
                                new ReportParameter("Total_Netpay", Convert.ToDecimal(reader["NetPay"]).ToString("C"))
                            };

                            reportViewer1.LocalReport.SetParameters(parameters);

                            reportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("No payroll data found for this employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public void dataSource(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Payroll WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0) // Ensure we have data
                        {
                            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                            reportViewer1.LocalReport.DataSources.Clear(); // Clear any existing data sources
                            reportViewer1.LocalReport.DataSources.Add(rds);
                        }
                    }
                }
            }
        }
    }
}
