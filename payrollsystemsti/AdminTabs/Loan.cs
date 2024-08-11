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
    public partial class Loan : Form
    {
        Methods m = new Methods();
        int empID = 0;
        public Loan()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Loan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public bool UpdateLoan(int employeeId, int sss, int hdmf, int company)
        {
            using (SqlConnection connection = new SqlConnection(m.connStr))
            {
                connection.Open();
                string query = "UPDATE Loans SET SSS = @sss, HDMF = @hdmf, Company = @company WHERE EmployeeID = @employeeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId",employeeId);
                    command.Parameters.AddWithValue("@sss", sss);
                    command.Parameters.AddWithValue("@hdmf", hdmf);
                    command.Parameters.AddWithValue("@company", company);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string searchText = tbSearch.Text.Trim(); // Assuming txtSearchEmployee is your textbox

            string query = "SELECT l.*, e.Name FROM Loans l " +
                            "INNER JOIN EmployeeAccounts e ON l.EmployeeID = e.EmployeeID " +
                            "WHERE IsDeactivated = 0 ";

            if (!string.IsNullOrEmpty(searchText))
            {
                query += "AND (e.Name LIKE '%" + searchText + "%')";
            }

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["Name"].ToString(); // Use Name from the joined table
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["SSS"].ToString();
                        dataGridView1.Rows[n].Cells["dg4th"].Value = row["HDMF"].ToString();
                        dataGridView1.Rows[n].Cells["dg5th"].Value = row["Company"].ToString();
                    }
                }
            }
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Visible = true;

            empID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tbSSS.Text = dataGridView1.SelectedRows[0].Cells["dg3rd"].Value.ToString();
            tbHDMF.Text = dataGridView1.SelectedRows[0].Cells["dg4th"].Value.ToString();
            tbCompany.Text = dataGridView1.SelectedRows[0].Cells["dg5th"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateLoan(empID, Convert.ToInt32(tbSSS.Text), Convert.ToInt32(tbHDMF.Text), Convert.ToInt32(tbCompany.Text));
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
