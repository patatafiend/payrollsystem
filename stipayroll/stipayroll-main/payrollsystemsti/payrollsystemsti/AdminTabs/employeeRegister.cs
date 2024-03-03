using payrollsystemsti.Tabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace payrollsystemsti.AdminTabs
{
    public partial class employeeRegister : Form
    {

        //Connection conn = new Connection();
        userRegister user = new userRegister();
        private string fileName;
        public employeeRegister()
        {
            InitializeComponent();
        }

        // adds image
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    lbFileName.Text = fileName;
                    pbEmployee.Image = Image.FromFile(fileName);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            pbEmployee.Image = null;
        }

        private void employeeRegister_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbFirstName;
            LoadData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
        }

        //when enter is pressed and textbox has value, it goes to the next textbox 
        private void empName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbFirstName.Text.Length > 0)
                {
                    dtDob.Focus();
                }
                else
                {
                    tbFirstName.Focus();
                }
            }
        }
        private void empNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbMob.Text.Length > 1)
                {
                    tbEmail.Focus();
                }
                else
                {
                    tbMob.Focus();
                }
            }
        }
        private void empSSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbSSN.Text.Length > 1)
                {
                    cbPosition.Focus();
                }
                else
                {
                    tbSSN.Focus();
                }
            }
        }

        private void empEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbEmail.Text.Length > 0)
                {
                    tbSSN.Focus();
                }
                else
                {
                    tbEmail.Focus();
                }
            }
        }

        private void empAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbAddress.Text.Length > 1)
                {
                    tbMob.Focus();
                }
                else
                {
                    tbAddress.Focus();
                }
            }
        }

        private void empDob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAddress.Focus();
            }
        }
        private void empPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPosition.SelectedIndex > -1)
                {
                    tbBasicRate.Focus();
                }
                else
                {
                    cbPosition.Focus();
                }

            }
        }
        private void empBasicRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbBasicRate.Text.Length > 1)
                {
                    btnSave.Focus();
                }
                else
                {
                    tbBasicRate.Focus();
                }
            }
        }

        private void empNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void empSSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        // checks if textboxes are filled
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(tbFirstName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbFirstName, "Please enter Name");
            }
            else if (string.IsNullOrEmpty(tbMob.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbMob, "Please enter UserName");
            }
            else if (string.IsNullOrEmpty(tbSSN.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbSSN, "Please enter Social Security Number");
            }
            //else if (empSSN.Text.Length < 10)
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(empSSN, "Invalid SSN");
            //}
            //else if (empSSN.Text.Length < 11)
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(empSSN, "Invalid Number");
            //}
            else if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbEmail, "Please enter Email");
            }
            else if (string.IsNullOrEmpty(tbAddress.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbAddress, "Please enter Address");
            }
            else if (string.IsNullOrEmpty(tbAddress.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbAddress, "Please enter Address");
            }
            else if (pbEmployee.Image == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(pbEmployee, "Please Choose Image");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        // checks if the database have a combination of firstname and lastname
        private bool ifEmployeeExists(string fname, string lname)
        {
            string query = "SELECT 1 FROM EmployeeAccounts WHERE FirstName = @FirstName AND LastName = @LastName";

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", fname);
                    cmd.Parameters.AddWithValue("@LastName", lname);

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }
        // checks if the database already has ssn
        private bool ifSSNExists(string ssn)
        {
            string query = "SELECT 1 FROM EmployeeAccounts WHERE SSN = @SSN";

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SSN", ssn);

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }
        // converts image to binary
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        //saves inputed data in the textbox
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (ifEmployeeExists(tbFirstName.Text, tbLastName.Text))
                {
                    MessageBox.Show("User Aready Exists", "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if (ifSSNExists(tbSSN.Text))
                {
                    MessageBox.Show("SSN Aready Exists", "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //inserts employee accounts
                    //OUTPUT INSERTED.EmployeeID gets the value of the newly inserted data
                    string query = "INSERT INTO EmployeeAccounts (FirstName, LastName, Department, Position, SSN, Email, Address, Dob, BasicRate, FileName, ImageData, Mobile, IsDeleted) " +
                                   "OUTPUT INSERTED.EmployeeID VALUES(@FirstName, @LastName, @Department, @Position, @SSN, @Email, @Address, @Dob, @BasicRate, @FileName, @ImageData, @Mobile, @IsDeleted)";


                    using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                            cmd.Parameters.AddWithValue("@LastName", tbLastName.Text);
                            cmd.Parameters.AddWithValue("@Department", tbDepart.Text);
                            cmd.Parameters.AddWithValue("@Position", cbPosition.Text);
                            cmd.Parameters.AddWithValue("@SSN", tbSSN.Text);
                            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                            cmd.Parameters.AddWithValue("@Address", tbAddress.Text);
                            cmd.Parameters.AddWithValue("@Dob", dtDob.Value.ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@BasicRate", tbBasicRate.Text);
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                            cmd.Parameters.AddWithValue("@ImageData", ConvertImageToBinary(pbEmployee.Image));
                            cmd.Parameters.AddWithValue("@Mobile", tbMob.Text);
                            cmd.Parameters.AddWithValue("@IsDeleted", '0');
                            int employeeId = Convert.ToInt32(cmd.ExecuteScalar());


                            if (employeeId != 0)
                            {
                                string userQuery = "INSERT INTO UserAccounts (Username, Password, Role, EmployeeID) " +
                                                   "VALUES (@Username, @Password, @Role, @EmployeeID)";

                                string generatedUsername = $"{tbFirstName.Text.ToLower()}{employeeId}";

                                using (SqlCommand userCmd = new SqlCommand(userQuery, conn))
                                {
                                    userCmd.Parameters.AddWithValue("@Username", generatedUsername);
                                    userCmd.Parameters.AddWithValue("@Password", user.passwordGenerator());
                                    userCmd.Parameters.AddWithValue("@Role", "Employee");
                                    userCmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                                    userCmd.ExecuteNonQuery();
                                }
                                MessageBox.Show("User Account Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to create user account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    
                }
                
            }
            //ClearData();
            LoadData();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "UPDATE EmployeeAccounts SET FirstName = @FirstName, LastName = @LastName," +
                           "Department = @Department, Position = @Position, SSN = @SSN, Email = @Email, Address = @Address, Dob = @Dob, " +
                           "BasicRate = @BasicRate, ImageData = @ImageData, Mobile = @Mobile";

                if (!string.IsNullOrEmpty(fileName))
                {
                    query += ", FileName = @FileName ";
                }

                query += " WHERE EmployeeID = @employeeId";

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", tbLastName.Text);
                        cmd.Parameters.AddWithValue("@Department", tbDepart.Text);
                        cmd.Parameters.AddWithValue("@Position", cbPosition.Text);
                        cmd.Parameters.AddWithValue("@SSN", tbSSN.Text);
                        cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                        cmd.Parameters.AddWithValue("@Address", tbAddress.Text);
                        cmd.Parameters.AddWithValue("@Dob", dtDob.Value.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@BasicRate", tbBasicRate.Text);
                        cmd.Parameters.AddWithValue("@ImageData", ConvertImageToBinary(pbEmployee.Image));
                        cmd.Parameters.AddWithValue("@Mobile", tbMob.Text);
                        cmd.Parameters.AddWithValue("@employeeId", empID.Text);

                        if (!string.IsNullOrEmpty(fileName))
                        {
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                LoadData();
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string empID = dataGridView1.SelectedRows[0].Cells["dgEmp"].Value.ToString();

                    string query = "UPDATE EmployeeAccounts SET IsDeleted = @deactivate WHERE EmployeeID = @employeeId";
                    using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@deactivate", '1');
                            cmd.Parameters.AddWithValue("@employeeId", empID);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Employee Deactivated", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please select a row to deactivate", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        // clears data inside textboxes
        private void ClearData()
        {
            empID.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            tbDepart.Clear();
            tbMob.Clear();
            tbSSN.Clear();
            tbEmail.Clear();
            tbAddress.Clear();
            dtDob.Value = DateTime.Now;
            pbEmployee.Image = null;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
            cbPosition.SelectedIndex = -1;
            tbBasicRate.Clear();
        }

        //loads data
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            // gets all active employees in the database
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt = false"))
            {
                conn.Open();
                string queryActive = "SELECT * FROM EmployeeAccounts WHERE IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(queryActive, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmp"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFirstName"].Value = row["FirstName"].ToString();
                        dataGridView1.Rows[n].Cells["dgLastName"].Value = row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgDepartment"].Value = row["Department"].ToString();
                        dataGridView1.Rows[n].Cells["dgSSN"].Value = row["SSN"].ToString();
                        dataGridView1.Rows[n].Cells["dgMobile"].Value = row["Mobile"].ToString();
                        dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["Dob"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                        dataGridView1.Rows[n].Cells["dgAdd"].Value = row["Address"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["ImageData"].ToString();
                        dataGridView1.Rows[n].Cells["dgPosition"].Value = row["Position"].ToString();
                        dataGridView1.Rows[n].Cells["dgBasicRate"].Value = row["BasicRate"].ToString();
                    }
                }

            }
            
        }

        // if double click on the data in datagridview, it goes to the textboxes
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool isDeleted = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["dgIsDeleted"].Value);
            if (isDeleted)
            {
                MessageBox.Show("This employee is deactivated.", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                empID.Text = dataGridView1.SelectedRows[0].Cells["dgEmp"].Value.ToString();
                tbFirstName.Text = dataGridView1.SelectedRows[0].Cells["dgFirstName"].Value.ToString();
                tbLastName.Text = dataGridView1.SelectedRows[0].Cells["dgLastName"].Value.ToString();
                tbDepart.Text = dataGridView1.SelectedRows[0].Cells["dgDepartment"].Value.ToString();
                tbMob.Text = dataGridView1.SelectedRows[0].Cells["dgMobile"].Value.ToString();
                tbEmail.Text = dataGridView1.SelectedRows[0].Cells["dgEmail"].Value.ToString();
                tbSSN.Text = dataGridView1.SelectedRows[0].Cells["dgSSN"].Value.ToString();
                tbAddress.Text = dataGridView1.SelectedRows[0].Cells["dgAdd"].Value.ToString();
                lbFileName.Text = dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString();
                cbPosition.Text = dataGridView1.SelectedRows[0].Cells["dgPosition"].Value.ToString();
                tbBasicRate.Text = dataGridView1.SelectedRows[0].Cells["dgBasicRate"].Value.ToString();
                pbEmployee.Image = Image.FromFile(dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString());

                string dobCellValue = dataGridView1.SelectedRows[0].Cells["dgDob"].Value.ToString();
                DateTime dob;

                if (DateTime.TryParseExact(dobCellValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    dtDob.Value = dob;
                }
                else
                {
                    MessageBox.Show("Invalid date format");
                }

                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDeactivate.Enabled = false;
            }
        }
        //gets the value in the combo box role
        private void empPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPosition.SelectedItem != null)
            {
                string p = cbPosition.SelectedItem.ToString();
                tbBasicRate.Text = setItem(p);
            }
        }
        //sets the value of textbox basicrate
        private string setItem(string p)
        {
            switch (p)
            {
                case "Sales Manager":
                    return "1000";
                case "Purchasing supervisor":
                    return "850";
                default:
                    return "610";
            }
        }

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled;
        }
    }
}
