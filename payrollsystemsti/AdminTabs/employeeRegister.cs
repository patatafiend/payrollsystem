using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class employeeRegister : Form
    {
        Methods m = new Methods();
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
            LoadDepartments();
            LoadPositions();
            LoadRoles();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
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
            else if (tbSSN.Text.Length < 10)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbSSN, "Invalid Number");
            }
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
            else if (!m.ValidateEmail(tbEmail.Text)) // email format validation
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbEmail, "Invalid email format");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }
        
        //saves inputed data in the textbox
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (m.ifEmployeeExists(tbFirstName.Text, tbLastName.Text))
                {
                    MessageBox.Show("User Aready Exists", "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (m.ifSSNExists(tbSSN.Text))
                {
                    MessageBox.Show("SSN Aready Exists", "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(m.connStr))
                    {
                        conn.Open();
                        string query = "INSERT INTO EmployeeAccounts (FirstName, LastName, " +
                                   "Department, Position, SSN, Email, Address, Dob, BasicRate, FileName, " +
                                   "ImageData, Mobile, IsDeleted, Leaves, Absents) " +
                                   "OUTPUT INSERTED.EmployeeID VALUES(@FirstName, @LastName, " +
                                   "@Department, @Position, @SSN, @Email, @Address, @Dob, @BasicRate, " +
                                   "@FileName, @ImageData, @Mobile, @IsDeleted, @Leaves, @Absents )";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                            cmd.Parameters.AddWithValue("@LastName", tbLastName.Text);
                            cmd.Parameters.AddWithValue("@Departments", getDepartmentID(cbDeparment.Text));
                            cmd.Parameters.AddWithValue("@Positions", getPositionID(cbPosition.Text));
                            cmd.Parameters.AddWithValue("@SSN", tbSSN.Text);
                            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                            cmd.Parameters.AddWithValue("@Address", tbAddress.Text);
                            cmd.Parameters.AddWithValue("@Dob", dtDob.Value.ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@BasicRate", tbBasicRate.Text);
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                            cmd.Parameters.AddWithValue("@ImageData", m.ConvertImageToBinary(pbEmployee.Image));
                            cmd.Parameters.AddWithValue("@Mobile", tbMob.Text);
                            cmd.Parameters.AddWithValue("@IsDeleted", '0');
							cmd.Parameters.AddWithValue("@Leaves", 5);
							cmd.Parameters.AddWithValue("@Absents", 0);

                            cmd.ExecuteNonQuery();
                        }
                    }

                }

            }
            ClearData();
            LoadData();
            LoadDepartments();
            LoadPositions();
            LoadRoles();

        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(m.connStr))
                {
                    conn.Open();
                    string query = "UPDATE EmployeeAccounts SET FirstName = @FirstName, LastName = @LastName," +
                           "DepartmentID = @Department, PositionID = @Position, SSN = @SSN, Email = @Email, " +
                           "Address = @Address, Dob = @Dob, BasicRate = @BasicRate, ImageData = @ImageData, " +
                           "Mobile = @Mobile, RoleID = @role";

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        query += ", FileName = @FileName ";
                    }

                    query += " WHERE EmployeeID = @employeeId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", tbLastName.Text);
                        cmd.Parameters.AddWithValue("@Department", getDepartmentID(cbDeparment.Text));
                        cmd.Parameters.AddWithValue("@Position", getPositionID(cbPosition.Text));
                        cmd.Parameters.AddWithValue("@role", getRoleID(cbRole.Text));
                        cmd.Parameters.AddWithValue("@SSN", tbSSN.Text);
                        cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                        cmd.Parameters.AddWithValue("@Address", tbAddress.Text);
                        cmd.Parameters.AddWithValue("@Dob", dtDob.Value.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@BasicRate", tbBasicRate.Text);
                        cmd.Parameters.AddWithValue("@ImageData", m.ConvertImageToBinary(pbEmployee.Image));
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
                LoadDepartments();
                LoadPositions();
                LoadRoles();
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
                    using (SqlConnection conn = new SqlConnection(m.connStr))
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
                    LoadDepartments();
                    LoadPositions();
                    LoadRoles();
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
            cbDeparment.SelectedIndex = -1;
            tbBasicRate.Clear();
        }
        //loads data
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            // gets all active employees in the database
            using (SqlConnection conn = new SqlConnection(m.connStr))
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
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgSSN"].Value = row["SSN"].ToString();
                        dataGridView1.Rows[n].Cells["dgMobile"].Value = row["Mobile"].ToString();
                        dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["Dob"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                        dataGridView1.Rows[n].Cells["dgAdd"].Value = row["Address"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["ImageData"].ToString();
                        dataGridView1.Rows[n].Cells["dgDepartment"].Value = getDepartmentName(Convert.ToInt32(row["DepartmentID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgPosition"].Value = getPositionTitle(Convert.ToInt32(row["PositionID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgRole"].Value = getRoleTitle(Convert.ToInt32(row["RoleID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgBasicRate"].Value = row["BasicRate"].ToString();
                    }
                }

            }

        }
        // if double click on the data in datagridview, it goes to the textboxes
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string fullName = dataGridView1.SelectedRows[0].Cells["dgFullName"].Value.ToString();
            string firstName = fullName.Split(' ')[0];
            string lastName = fullName.Split(' ')[1];
            tbFirstName.Text = firstName;
            tbLastName.Text = lastName;

            empID.Text = dataGridView1.SelectedRows[0].Cells["dgEmp"].Value.ToString();
            tbMob.Text = dataGridView1.SelectedRows[0].Cells["dgMobile"].Value.ToString();
            tbEmail.Text = dataGridView1.SelectedRows[0].Cells["dgEmail"].Value.ToString();
            tbSSN.Text = dataGridView1.SelectedRows[0].Cells["dgSSN"].Value.ToString();
            tbAddress.Text = dataGridView1.SelectedRows[0].Cells["dgAdd"].Value.ToString();
            lbFileName.Text = dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString();
            cbPosition.Text = dataGridView1.SelectedRows[0].Cells["dgPosition"].Value.ToString();
            cbDeparment.Text = dataGridView1.SelectedRows[0].Cells["dgDepartment"].Value.ToString();
            cbRole.Text = dataGridView1.SelectedRows[0].Cells["dgRole"].Value.ToString();
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
        //gets the value in the combo box role
        private void empPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPosition.SelectedIndex != -1)
            {
                tbBasicRate.Text = m.setItem(cbPosition.Text);
            }
        }

        public int getDepartmentID(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentID FROM Departments WHERE DepartmentName = @title";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    int id = (int)cmd.ExecuteScalar();
                    return id;
                }
            }
        }

        public int getPositionID(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT PositionID FROM Positions WHERE PositionTitle = @title";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    int id = (int)cmd.ExecuteScalar();
                    return id;
                }
            }
        }

        public int getRoleID(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT RoleID FROM Roles WHERE RoleTitle = @title";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    int id = (int)cmd.ExecuteScalar();
                    return id;
                }
            }
        }

        public string getDepartmentName(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentName FROM Departments WHERE DepartmentID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string name = (string)cmd.ExecuteScalar();
                    return name;
                }
            }
        }

        public string getPositionTitle(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT PositionTitle FROM Positions WHERE PositionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string name = (string)cmd.ExecuteScalar();
                    return name;
                }
            }
        }

        public string getRoleTitle(int id)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT RoleTitle FROM Roles WHERE RoleID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string name = (string)cmd.ExecuteScalar();
                    return name;
                }
            }
        }


        private void LoadDepartments()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentName FROM Departments WHERE IsDeactivated = @status";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);

                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        cbDeparment.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string departmentName = row[0].ToString();
                            cbDeparment.Items.Add(departmentName);
                        }
                    }
                }
            }
        }
        private void LoadPositions()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT PositionTitle FROM Positions WHERE IsDeactivated = @status";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);

                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        cbPosition.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string positions = row[0].ToString();
                            cbPosition.Items.Add(positions);
                        }
                    }
                }
            }
        }
        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT RoleTitle FROM Roles WHERE IsDeactivated = @status";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);

                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        cbRole.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string roleTitle = row[0].ToString();
                            cbRole.Items.Add(roleTitle);
                        }
                    }
                }
            }
        }
        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled;
        }
        //when enter is pressed and textbox has value, it goes to the next textbox 
        private void tbFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbFirstName.Text.Length > 0)
                {
                    tbLastName.Focus();
                }
                else
                {
                    tbFirstName.Focus();
                }
            }
        }
        private void tbLastName_KeyDown(object sender, KeyEventArgs e)
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
        private void dtDob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAddress.Focus();
            }
        }
        private void tbAdd_KeyDown(object sender, KeyEventArgs e)
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
        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
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

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbEmail.Text.Length > 0)
                {
                    cbDeparment.Focus();
                }
                else
                {
                    tbEmail.Focus();
                }
            }
        }

        private void cbDeparment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbEmail.Text.Length > 0)
                {
                    cbPosition.Focus();
                }
                else
                {
                    cbDeparment.Focus();
                }
            }
        }

        private void cbPosition_KeyDown(object sender, KeyEventArgs e)
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
        private void tbBasicRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbBasicRate.Text.Length > 1)
                {
                    tbSSN.Focus();
                }
                else
                {
                    tbBasicRate.Focus();
                }
            }
        }
        private void tbSSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbSSN.Text.Length > 1)
                {
                    btnSave.Focus();
                }
                else
                {
                    tbSSN.Focus();
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
    }
}
