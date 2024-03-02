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

namespace payrollsystemsti.Tabs
{
	public partial class userRegister : Form
	{
		private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
		private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string Digits = "0123456789";
		private const string SpecialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?";
		//I'll lipat nalang to sa ibang class para mas malinis dito na muna eksdi :)
		private Connection con = new Connection();

		public userRegister()
		{
			InitializeComponent();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{


			DialogResult dialogResult = MessageBox.Show("Delete this row?", "Delete", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				con.DataSend("DELETE FROM Users WHERE Username = '" + txtUserName.Text + "'");
			}
			LoadData();
			ClearData();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (Validation())
			{
				if (ifUserNameExists(txtUserName.Text))
				{
					MessageBox.Show("User Name Already Exists");
				}
				else
				{
					string newpassword = passwordGenerator(); //Generate randomPassword
					con.DataSend("INSERT INTO [Users] (Username, Password, Name, Email, Role, Dob, Address)VALUES('" + txtUserName.Text +
						"','" + newpassword + "','" + txtName.Text + "','" + txtEmail.Text + "'," +
						"'" + cbRole.Text + "','" + tpBirthDate.Value.ToString("MM/dd/yyyy") + "','" + txtAddress.Text + "')");
					MessageBox.Show("User password = " + newpassword + " Record Saved Successfully.... ");
					ClearData();
					LoadData();
				}
			}
		}
		//method to register employees in the users database
        public string UserRegistration(string name, string email, string role, DateTime dob, string address, string empid)
        {
            //string username = GenerateUniqueUsername(name); // You need to implement a method to generate a unique username based on the user's name.
            string password = passwordGenerator(); // Generate a random password
			string username = GenerateUniqueUsername(name);
            // Assuming you have a Users table with columns: Username, Password, Name, Email, Role, Dob, Address
            con.DataSend($"INSERT INTO Users (Username, Password, Name, Email, Role, Dob, Address) VALUES ('{username}', '{password}', '{name}', '{email}', '{role}', '{dob.ToString("MM/dd/yyyy")}', '{address}')");

            return "";
        }

        private string GenerateUniqueUsername(string name)
        {
			Random ran = new Random();
			int randomNum = ran.Next(1000);
			string randomName = name + randomNum;
			while (ifNameExists(randomName).Equals(true))
			{
				GenerateUniqueUsername(randomName);
			}
            return randomName;
        }

        private void ClearData()
        {
            txtName.Clear();
            txtUserName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cbRole.SelectedIndex = -1;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            tpBirthDate.Value = DateTime.Now;
        }
        private bool ifNameExists(string name)
        {
            con.DataGet("SELECT 1 FROM [Users] WHERE [Name]= '" + name + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private bool ifUserNameExists(string userName)
        {
            con.DataGet("SELECT 1 FROM [Users] WHERE [Username]= '" + userName + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            con.DataGet("SELECT * FROM [Users]");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["dgUserID"].Value = row["UserID"].ToString();
                dataGridView1.Rows[n].Cells["dgName"].Value = row["Name"].ToString();
                try
                {
                    dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["Dob"].ToString()).ToString("dd/MM/yyyy");
                }
                catch (Exception e)
                {

                }

                dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                dataGridView1.Rows[n].Cells["dgUsername"].Value = row["UserName"].ToString();
                dataGridView1.Rows[n].Cells["dgRole"].Value = row["Role"].ToString();
                dataGridView1.Rows[n].Cells["dgAddress"].Value = row["Address"].ToString();
            }
        }

        private void cbRole_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				txtAddress.Focus();
			}
		}

		
		private void tpBirthDate_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbRole.Focus();
			}
		}
		private void txtEmail_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (txtEmail.Text.Length > 0)
				{
					tpBirthDate.Focus();
				}
				else
				{
					txtEmail.Focus();
				}
			}
		}
		//Keydown(when user enters data it goes to the nxt txtbox)
		private void txtName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (txtName.Text.Length > 0)
				{
					txtUserName.Focus();
				}
				else
				{
					txtName.Focus();
				}
			}
		}
		private void txtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (txtPassword.Text.Length > 0)
				{
					txtEmail.Focus();
				}
				else
				{
					txtPassword.Focus();
				}
			}
		}
		//private void txtUserName_KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.KeyCode == Keys.Enter)
		//	{
		//		e.SuppressKeyPress = true;
		//		if (txtUserName.Text.Length > 0)
		//		{
		//			txtPassword.Focus();
		//		}
		//		else
		//		{
		//			txtUserName.Focus();
		//		}
		//	}
		//}

		//first load of form, it focuses on Name txtbox
		private void userRegister_Load(object sender, EventArgs e)
		{
			this.ActiveControl = txtName;
			btnDelete.Enabled = false;
			btnUpdate.Enabled = false;
			LoadData();
		}

		private bool Validation()
		{
			bool result = false;
			if (string.IsNullOrEmpty(txtName.Text))
			{
				errorProvider1.Clear();
				errorProvider1.SetError(txtName, "Please enter Name");
			}
			else if (string.IsNullOrEmpty(txtUserName.Text))
			{
				errorProvider1.Clear();
				errorProvider1.SetError(txtUserName, "Please enter UserName");
			}
			//else if (string.IsNullOrEmpty(txtEmail.Text))
			//{
			//	errorProvider1.Clear();
			//	errorProvider1.SetError(txtPassword, "Please enter Email");
			//}
			//else if (cbRole.SelectedIndex == -1)
			//{
			//	errorProvider1.Clear();
			//	errorProvider1.SetError(txtPassword, "Please Select Role");
			//}
			else
			{
				errorProvider1.Clear();
				result = true;
			}
			return result;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				con.DataSend("UPDATE Users SET Username ='" + txtName.Text + "', Email ='" + txtEmail.Text + "', Role ='" + cbRole.Text + "'," +
					" Dob ='" + tpBirthDate.Value.ToString("MM/dd/yyyy") + "', Address ='" + txtAddress.Text + "'" +
					" Where Username = '" + txtUserName.Text + "'");
				MessageBox.Show("Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadData();
				btnSave.Enabled = true;
				btnUpdate.Enabled = false;
				btnDelete.Enabled = false;
			}
			ClearData();
		}

		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			txtName.Text = dataGridView1.SelectedRows[0].Cells["dgName"].Value.ToString();
			txtUserName.Text = dataGridView1.SelectedRows[0].Cells["dgUsername"].Value.ToString();
			txtEmail.Text = dataGridView1.SelectedRows[0].Cells["dgEmail"].Value.ToString();
			txtAddress.Text = dataGridView1.SelectedRows[0].Cells["dgAddress"].Value.ToString();

			string dobCellValue = dataGridView1.SelectedRows[0].Cells["dgDob"].Value.ToString();
			DateTime dob;

			if (DateTime.TryParseExact(dobCellValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
			{
				tpBirthDate.Value = dob;
			}
			else
			{
				MessageBox.Show("Invalid date format");
			}

			cbRole.Text = dataGridView1.SelectedRows[0].Cells["dgRole"].Value.ToString();
			btnSave.Enabled = false;
			btnUpdate.Enabled = true;
			btnDelete.Enabled = true;
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

        
    }
}