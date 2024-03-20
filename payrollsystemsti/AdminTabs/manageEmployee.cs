using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.Tabs
{
    public partial class manageEmployee : Form
    {

        Methods m = new Methods();

        public manageEmployee()
        {
            InitializeComponent();
        }
        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string userID = dataGridView1.SelectedRows[0].Cells["dgUserID"].Value.ToString();

                    string query = "UPDATE UserAccounts SET IsDeleted = @deactivate WHERE UserID = @userId";
                    using (SqlConnection conn = new SqlConnection(m.connStr))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@deactivate", '1');
                            cmd.Parameters.AddWithValue("@userId", userID);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("User Deactivated", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please select a row to deactivate", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadData();
            ClearData();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "UPDATE UserAccounts SET Username =@Username, Role =@Role" +
                               " WHERE UserID = @UserID";
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", cbRole.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Update Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnUpdate.Enabled = false;
                btnDeactivate.Enabled = false;
            }

            ClearData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            btnUpdate.Enabled = false;
        }
        private void ClearData()
        {
            cbRole.SelectedIndex = -1;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT UserAccounts.UserID, UserAccounts.Role," +
                           " EmployeeAccounts.EmployeeID, EmployeeAccounts.Department, EmployeeAccounts.Position," +
                           " EmployeeAccounts.FirstName, EmployeeAccounts.LastName FROM UserAccounts JOIN EmployeeAccounts" +
                           " ON UserAccounts.EmployeeID = EmployeeAccounts.EmployeeID;";

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
                        dataGridView1.Rows[n].Cells["dgUserID"].Value = row["UserID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = (row["FirstName"].ToString()) + " " + (row["LastName"].ToString());
                        dataGridView1.Rows[n].Cells["dgDepartment"].Value = row["Department"].ToString();
                        dataGridView1.Rows[n].Cells["dgPosition"].Value = row["Position"].ToString();
                        dataGridView1.Rows[n].Cells["dgRole"].Value = row["Role"].ToString();
                        dataGridView1.Rows[n].Cells["dgEmpID"].Value = row["EmployeeID"].ToString();
                    }
                }
            }
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cbRole.Text = dataGridView1.SelectedRows[0].Cells["dgRole"].Value.ToString();
            btnUpdate.Enabled = true;
            btnDeactivate.Enabled = true;
        }
        private void cbRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdate.Focus();
            }
        }
        //first load of form, it focuses on Name txtbox
        private void manageEmployee_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbRole;
            btnDeactivate.Enabled = false;
            btnUpdate.Enabled = false;
            LoadData();
        }

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled;
        }

        private void LoadUserData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM UserAccounts WHERE EmployeeID IS NULL";
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
                        dataGridView1.Rows[n].Cells["dgUserID"].Value = row["UserID"].ToString();
                        dataGridView1.Rows[n].Cells["dgUserName"].Value = row["UserName"].ToString();
                        dataGridView1.Rows[n].Cells["dgRole"].Value = row["Role"].ToString();
                    }
                }
            }
        }

        private void btnLoadEmpAcc_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}