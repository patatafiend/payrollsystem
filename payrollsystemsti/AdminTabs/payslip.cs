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
    public partial class payslip : Form

    {

        Methods m = new Methods();

        public payslip()
        {
            InitializeComponent();
        }

        public void getEmployeeName(int empid)
        {
            using (SqlConnection con = new SqlConnection(m.connStr))
            {
                con.Open();
                string query = "SELECT FirstName, LastName  FROM EmployeeAccounts WHERE EmployeeID = @empID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        label8.Text = row["FirstName"].ToString() + row["LastName"].ToString();
                    }
                }
            }
        }


        public void getDailyRate(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT BasicRate FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label6.Text = "0";
                    }

                }
            }
        }

        public void getSemiMonthly(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT BasicSalary FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label6.Text = "0";
                    }

                }
            }
        }


        public void getSavings(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Savings FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label40.Text = "0";
                    }

                }
            }
        }

        public void getCashAdvance(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT CashAdvance FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label41.Text = "0";
                    }

                }
            }
        }

        public void getLateUndertime(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Late FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label34.Text = "0";
                    }

                }
            }
        }

        public void getLegalHolidays(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT RegularH FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label43.Text = "0";
                    }

                }
            }
        }

        public void getSpecialHolidays(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT SpecialH FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label44.Text = "0";
                    }

                }
            }
        }

        public void getOBAllowance(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT OBA FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label47.Text = "0";
                    }

                }
            }
        }

        public void getRestDay(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Restday FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label47.Text = "0";
                    }

                }
            }
        }

        public void getLoadA(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT LoadA FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label45.Text = "0";
                    }

                }
            }
        }

        public void getTransporatationA(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TransportationA FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label46.Text = "0";
                    }

                }
            }
        }

        public void getAdjustment(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Adjustment FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label46.Text = "0";
                    }

                }
            }
        }

        public void getIncentives(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Incentives FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label49.Text = "0";
                    }

                }
            }
        }

        public void getTrianingAllowance(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TrainingA FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label54.Text = "0";
                    }

                }
            }
        }


        public void getPTA(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TPTAFROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label55.Text = "0";
                    }

                }
            }
        }


        public void getProvitionTA(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT TPTA FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label55.Text = "0";
                    }

                }
            }
        }

        public void getSSS(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT SSS FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label61.Text = "0";
                    }

                }
            }
        }

        public void getPhilHealth(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT PhilHealth FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label60.Text = "0";
                    }

                }
            }
        }

        public void getPagibig(int empid)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Pagibig FROM EmployeeSalary WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empid);

                    object result = cmd.ExecuteScalar();

                    label6.Text = result.ToString();

                    if (result == null)
                    {
                        label59.Text = "0";
                    }

                }
            }
        }

    }
}
