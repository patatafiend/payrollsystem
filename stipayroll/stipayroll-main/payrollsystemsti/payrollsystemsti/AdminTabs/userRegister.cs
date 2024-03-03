using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Globalization;
using System.Security.Cryptography;
using payrollsystemsti.AdminTabs;

namespace payrollsystemsti.Tabs
{
	public partial class userRegister : Form
	{
		private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
		private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string Digits = "0123456789";
		private const string SpecialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?";
		//I'll lipat nalang to sa ibang class para mas malinis dito na muna eksdi :)

		public userRegister()
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
                    using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false"))
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

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (Validation())
			{
				if (ifUserNameExists(tbUserName.Text))
				{
					MessageBox.Show("User Name Already Exists");
				}
				else
				{
					string randomPass = passwordGenerator(); //Generate randomPassword
					string query = "INSERT INTO UserAccounts (Username, Password, Role) VALUES (@Username, @Password, @Role)";
					using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false"))
					{
						conn.Open();
						using(SqlCommand cmd = new SqlCommand(query, conn))
						{
							cmd.Parameters.AddWithValue("@Username", tbUserName.Text);
                            cmd.Parameters.AddWithValue("@Password", randomPass);
                            cmd.Parameters.AddWithValue("@Username", cbRole.Text);
                        }
					}
					MessageBox.Show("User password = " + randomPass + " Record Saved Successfully.... ");
					ClearData();
					LoadData();
				}
			}
		}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
				string query = "UPDATE UserAccounts SET Username =@Username, Role =@Role," +
					           "WHERE UserID = @UserID";
                using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt = false"))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", tbUserName.Text);
                        cmd.Parameters.AddWithValue("@Role", cbRole.Text);
                        cmd.Parameters.AddWithValue("@Username", tbUserID.Text);
                    }
                }
                MessageBox.Show("Update Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDeactivate.Enabled = false;
            }
            ClearData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        private bool ifUserNameExists(string userName)
        {
            string query = "SELECT 1 FROM UserAccounts WHERE Username = @Username";
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt = false"))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            } 
        }
        private void ClearData()
        {
            tbUserID.Clear();
            tbUserName.Clear();
            cbRole.SelectedIndex = -1;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
            btnSave.Enabled = true;
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
			string query = "SELECT UserAccounts.UserID, UserAccounts.UserName, UserAccounts.Role," +
                           " EmployeeAccounts.EmployeeID, EmployeeAccounts.Department, EmployeeAccounts.Position FROM UserAccounts JOIN EmployeeAccounts" +
				           " ON UserAccounts.EmployeeID = EmployeeAccounts.EmployeeID;";
			using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false"))
			{
				conn.Open();
				using(SqlCommand cmd = new SqlCommand(query, conn))
				{
					SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgUserID"].Value = row["UserID"].ToString();
                        dataGridView1.Rows[n].Cells["dgUserName"].Value = row["UserName"].ToString();
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
            tbUserID.Text = dataGridView1.SelectedRows[0].Cells["dgUserID"].Value.ToString();
            tbUserName.Text = dataGridView1.SelectedRows[0].Cells["dgUsername"].Value.ToString();
            cbRole.Text = dataGridView1.SelectedRows[0].Cells["dgRole"].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDeactivate.Enabled = true;
        }
        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbUserName.Text.Length > 0)
                {
                    tbPassword.Focus();
                }
                else
                {
                    tbUserName.Focus();
                }
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbPassword.Text.Length > 0)
                {
                    cbRole.Focus();
                }
                else
                {
                    tbPassword.Focus();
                }
            }
        }
        private void cbRole_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                btnSave.Focus();
			}
		}
		
		//first load of form, it focuses on Name txtbox
		private void userRegister_Load(object sender, EventArgs e)
		{
			this.ActiveControl = tbUserID;
			btnDeactivate.Enabled = false;
			btnUpdate.Enabled = false;
			LoadData();
		}

		private bool Validation()
		{
			bool result = false;
			if (string.IsNullOrEmpty(cbRole.Text))
			{
				errorProvider1.Clear();
				errorProvider1.SetError(cbRole, "Please select Role");
			}
			else if (string.IsNullOrEmpty(tbUserName.Text))
			{
				errorProvider1.Clear();
				errorProvider1.SetError(tbUserName, "Please enter UserName");
			}
			else
			{
				errorProvider1.Clear();
				result = true;
			}
			return result;
		}
		public string passwordGenerator(int passlength = 12)
		{
			string validChars = LowerCase + UpperCase + Digits + SpecialChars;
			Random random = new Random();

			// Ensure the password has at least one character of each type
			string mandatoryChars =
				LowerCase[random.Next(LowerCase.Length)].ToString() +
				UpperCase[random.Next(UpperCase.Length)].ToString() +
				Digits[random.Next(Digits.Length)].ToString() +
				SpecialChars[random.Next(SpecialChars.Length)].ToString();

			// Fill the rest of the password length with random characters from the combined set
			string remainingChars = new string(Enumerable.Repeat(validChars, passlength - mandatoryChars.Length)
				.Select(s => s[random.Next(s.Length)]).ToArray());

			// Combine and shuffle mandatory and remaining characters to ensure randomness
			string unshuffledPassword = mandatoryChars + remainingChars;

			// Shuffle the resultant password to ensure mandatory characters are randomly distributed
			string shuffledPassword = new string(unshuffledPassword.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());

			// Escape single quotes to prevent SQL injection issues
			string sqlSafePassword = shuffledPassword.Replace("'", "''");

			return sqlSafePassword;
		}

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled;
        }
    }
}