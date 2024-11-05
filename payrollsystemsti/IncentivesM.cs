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

namespace payrollsystemsti
{
    public partial class IncentivesM : Form
    {
        Methods m = new Methods();
        int IncentiveID = 0;
        int empID = 0;
        public IncentivesM()
        {
            InitializeComponent();
        }

        private void IncentivesM_Load(object sender, EventArgs e)
        {
            LoadIncentivesData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (IsTextBoxFilled())
                    {
                        UpdateAllIncentives();
                        m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Others Update");
                        LoadIncentivesData();
                    }
                    else
                    {
                        MessageBox.Show("Please enter data");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                btnBatch.Enabled = false;
            }
        }

        private bool UpdateAllIncentives()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Others SET Incentives = @incentives";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@incentives", Convert.ToDouble(tb1.Text));

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error updating Others: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        public bool IsTextBoxFilled()
        {
            if (tb1.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void tbClear()
        {
            tb1.Clear();
        }

        private void LoadIncentivesData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT EmployeeAccounts.FirstName, EmployeeAccounts.LastName, Others.OtherID, " +
                "Others.Incentives, Others.ITremarks FROM EmployeeAccounts INNER JOIN Others ON EmployeeAccounts.EmployeeID = Others.EmployeeID " +
                "WHERE IsDeactivated = @status";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["OtherID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["Incentives"].ToString();
                        dataGridView1.Rows[n].Cells["dgRemarks"].Value = row["ITremarks"].ToString();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void Reset()
        {
            tb1.Clear();
            btnBatch.Enabled = false;
            btnCancel.Visible = false;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (tb1.Text.Length > 0)
            {
                btnBatch.Enabled = true;
                btnSingle.Enabled = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnBatch.Enabled = false;
                btnSingle.Enabled = false;
                btnCancel.Visible = false;
            }
        }

        private void tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            empID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tbRemarks.Text = dataGridView1.SelectedRows[0].Cells["dgRemarks"].Value.ToString();
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (IsTextBoxFilled())
                    {
                        m.UpdateIncentivesData(empID, Convert.ToInt32(tb1.Text), tbRemarks.Text);
                        m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Incentives Update");
                        LoadIncentivesData();
                    }
                    else
                    {
                        MessageBox.Show("Please enter data");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                btnBatch.Enabled = false;
            }
        }

        private void SearchByName()
        {
            dataGridView1.Rows.Clear();
            string searchText = tbSearch.Text.Trim(); // Assuming txtSearchEmployee is your textbox

            string query = "SELECT EmployeeAccounts.FirstName, EmployeeAccounts.LastName, Others.OtherID, " +
                "Others.Incentives, Others.ITremarks FROM EmployeeAccounts INNER JOIN Others ON EmployeeAccounts.EmployeeID = Others.EmployeeID " +
                "WHERE IsDeactivated = 0";

            if (!string.IsNullOrEmpty(searchText))
            {
                query += " AND (FirstName LIKE '%" + searchText + "%')";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["OtherID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["Incentives"].ToString();
                        dataGridView1.Rows[n].Cells["dgRemarks"].Value = row["ITremarks"].ToString();
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchByName();
        }
    }
}
