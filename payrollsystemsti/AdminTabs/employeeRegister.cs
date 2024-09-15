using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static payrollsystemsti.Methods;

namespace payrollsystemsti.AdminTabs
{
    public partial class employeeRegister : Form
    {
        Methods m = new Methods();
        private string fileName;
        enrollFingerprint ef = new enrollFingerprint();

        int fingeID = 0;
        DateTime dateNow = DateTime.Now;
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
            lbFileName.Text = "";
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
            btnCreate.Enabled = false;
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
					MessageBox.Show("User Already Exists", "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (m.ifSSNExists(tbSSN.Text))
				{
					MessageBox.Show("SSN Already Exists", "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					bool isInserted = InsertToEmployeeAccounts(
						tbFirstName.Text, tbLastName.Text, getDepartmentID(cbDeparment.Text),
						getPositionID(cbPosition.Text), getRoleID(cbRole.Text), tbSSN.Text, tbEmail.Text, tbAddress.Text,
						dtDob.Value.ToString("MM/dd/yyyy"), tbBasicRate.Text, lbFileName.Text, m.ConvertImageToBinary(pbEmployee.Image),
						tbMob.Text, 0, 5, 0, dateNow, cbGender.Text);

					if (isInserted)
					{
						//RegisterHistory(
						//	cbDeparment.Text, cbPosition.Text, cbRole.Text, CurrentUser.Username, CurrentUser.UserID,
						//	$"{tbFirstName.Text} {tbLastName.Text}", 0);

                        m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Employee Register Added");
                        

                        ClearData();
						LoadData();
						LoadDepartments();
						LoadPositions();
						LoadRoles();
					}
					else
					{
						MessageBox.Show("Error inserting data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}



		private bool InsertToEmployeeAccounts(string firstName, string lastName, int department, int position, int role, string ssn, string email, string address, string dob, string basic, string fileName, byte[] imageData, string mobile, byte isDeleted, int leaves, int absents, DateTime hdate, string gender)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO EmployeeAccounts (FirstName, LastName, " +
                           "DepartmentID, PositionID, RoleID, SSN, Email, Address, Dob, BasicRate, FileName, " +
                           "ImageData, Mobile, IsDeleted, Leaves, Absents, HiredDate, Gender) " +
                           "OUTPUT INSERTED.EmployeeID VALUES(@FirstName, @LastName, " +
                           "@Department, @Position, @Role, @SSN, @Email, @Address, @Dob, @BasicRate, " +
                           "@FileName, @ImageData, @Mobile, @IsDeleted, @Leaves, @Absents, @hireddate, @gender )";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Department", department);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@SSN", ssn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@BasicRate", basic);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    cmd.Parameters.AddWithValue("@ImageData", imageData);
                    cmd.Parameters.AddWithValue("@Mobile", mobile);
                    cmd.Parameters.AddWithValue("@IsDeleted", isDeleted);
                    cmd.Parameters.AddWithValue("@Leaves", leaves);
                    cmd.Parameters.AddWithValue("@Absents", absents);
                    cmd.Parameters.AddWithValue("@hireddate", hdate);
                    cmd.Parameters.AddWithValue("@gender", gender);
					


					try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Employee Accounts: " + ex.Message);
                        return false;
                    }
                }
            }
        }

		//private void RegisterHistory(string department, string position, string role, string adder, int adderID, string addedName, int addedID)
		//{
		//	using (SqlConnection conn = new SqlConnection(m.connStr))
		//	{
		//		conn.Open();
		//		string query = "INSERT INTO RegisterHistory (Department, Position, Role, Addedby, AdderID, EmployeeName, EmployeeID, time) " +
		//					   "VALUES(@department, @position, @role, @adder, @adderID, @addedName, @addedID, @dateAdded)";

		//		using (SqlCommand cmd = new SqlCommand(query, conn))
		//		{
		//			cmd.Parameters.AddWithValue("@department", department);
		//			cmd.Parameters.AddWithValue("@position", position);
		//			cmd.Parameters.AddWithValue("@role", role);
		//			cmd.Parameters.AddWithValue("@adder", adder);
		//			cmd.Parameters.AddWithValue("@adderID", adderID);
		//			cmd.Parameters.AddWithValue("@addedName", addedName);
		//			cmd.Parameters.AddWithValue("@addedID", addedID); 
		//			cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);

		//			try
		//			{
		//				cmd.ExecuteNonQuery();
		//			}
		//			catch (SqlException ex)
		//			{
		//				MessageBox.Show("Error inserting into Register History: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//			}
		//		}
		//	}
		//}
		private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (UpdateEmployeeAccounts(tbFirstName.Text, tbLastName.Text, getDepartmentID(cbDeparment.Text),
                        getPositionID(cbPosition.Text), getRoleID(cbRole.Text), tbSSN.Text, tbEmail.Text, tbAddress.Text,
                        dtDob.Value.ToString("MM/dd/yyyy"), tbBasicRate.Text, lbFileName.Text, m.ConvertImageToBinary(pbEmployee.Image),
                        tbMob.Text, Convert.ToInt32(empID.Text)))
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadData();
                    LoadDepartments();
                    LoadPositions();
                    LoadRoles();
                }
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDeactivate.Enabled = false;
            }
        }

        private bool UpdateEmployeeAccounts(string firstName, string lastName, int department, int position, int role, string ssn, string email, string address, string dob, string basic, string fileName, byte[] imageData, string mobile, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE EmployeeAccounts SET FirstName = @firstName, LastName = @lastName," +
                       "DepartmentID = @department, PositionID = @position, RoleID = @role, SSN = @ssn, Email = @email, " +
                       "Address = @address, Dob = @dob, BasicRate = @basicRate, ImageData = @imageData, " +
                       "Mobile = @mobile, @FileName = @fileName WHERE EmployeeID = @employeeId";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@ssn", ssn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@basicRate", basic);
                    cmd.Parameters.AddWithValue("@fileName", fileName);
                    cmd.Parameters.AddWithValue("@imageData", imageData);
                    cmd.Parameters.AddWithValue("@mobile", mobile);
                    cmd.Parameters.AddWithValue("@employeeId", empID);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Updating Employee: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int NempID = Convert.ToInt32(empID.Text);
            if (!ifUserAlreadyExist(NempID))
            {
                string info = GetEmployeeInfo(NempID);
                string email = info.Split(' ')[2];
                string password = info.Split(' ')[0] + info.Split(' ')[1];
                string id = info.Split(' ')[1];

                if(CreateUser(email, password.ToLower(), Convert.ToInt32(id)))
                {
                    m.insertToAllowances(Convert.ToInt32(id),0,0,0,0,0);
                    m.InsertAdjustmentData(Convert.ToInt32(id), 0);
                    m.InsertIncentivesData(Convert.ToInt32(id), 0);
                    m.InsertLoan(Convert.ToInt32(id), 0, 0, 0);
                    
                    MessageBox.Show("Created User Succesfully");
                }

                btnCreate.Enabled = false;

            }
            else if(ifUserAlreadyExist(NempID))
            {
                MessageBox.Show("User account already exist");
            }
        }

        public bool ifUserHasFID(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT fingerID FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    object result = cmd.ExecuteScalar();

                    if(result != DBNull.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool ifUserAlreadyExist(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM UserAccounts WHERE EmployeeID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", empID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool CreateUser(string user, string password, int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO UserAccounts(Username, Password, EmployeeID) " +
                    "VALUES(@username, @password, @empID)";

                using (SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@username", user);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@empID", empID);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Creating Employee: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private string GetEmployeeInfo(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT FirstName, Email, EmployeeID FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fname = reader["FirstName"].ToString();
                            string email = reader["Email"].ToString();
                            int employeeID = (int)reader["EmployeeID"];

                            string info = fname + " " + employeeID + " " + email;
                            return info;
                        }
                        else
                        {
                            MessageBox.Show("Employee doesn't exist");
                            return " ";
                        }
                    }
                }
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
                        dataGridView1.Rows[n].Cells["dgDepartment"].Value = m.getDepartmentName(Convert.ToInt32(row["DepartmentID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgPosition"].Value = m.getPositionTitle(Convert.ToInt32(row["PositionID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgRole"].Value = m.getRoleTitle(Convert.ToInt32(row["RoleID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgBasicRate"].Value = row["BasicRate"].ToString();
                        dataGridView1.Rows[n].Cells["dgFID"].Value = row["fingerID"].ToString();
                        dataGridView1.Rows[n].Cells["dgImage"].Value = row["ImageData"];
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
            pbEmployee.Image = m.ConvertToImage((byte[])dataGridView1.SelectedRows[0].Cells["dgImage"].Value);


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

            if (ifUserHasFID(Convert.ToInt32(empID.Text)))
            {
                btnCreate.Enabled = true;
                MessageBox.Show("this printed");
            }
            else
            {
                btnCreate.Enabled = false;
            }

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

        private void SearchByName()
        {
            dataGridView1.Rows.Clear();
            string searchText = tbSearch.Text.Trim(); // Assuming txtSearchEmployee is your textbox

            string query = "SELECT * FROM EmployeeAccounts WHERE IsDeleted = 0";

            if (!string.IsNullOrEmpty(searchText))
            {
                query += "AND (FirstName LIKE '%" + searchText + "%')";
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
                        dataGridView1.Rows[n].Cells["dgEmp"].Value = row["EmployeeID"].ToString();
                        dataGridView1.Rows[n].Cells["dgFullName"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dgSSN"].Value = row["SSN"].ToString();
                        dataGridView1.Rows[n].Cells["dgMobile"].Value = row["Mobile"].ToString();
                        dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["Dob"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                        dataGridView1.Rows[n].Cells["dgAdd"].Value = row["Address"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["ImageData"].ToString();
                        dataGridView1.Rows[n].Cells["dgDepartment"].Value = m.getDepartmentName(Convert.ToInt32(row["DepartmentID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgPosition"].Value = m.getPositionTitle(Convert.ToInt32(row["PositionID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgRole"].Value = m.getRoleTitle(Convert.ToInt32(row["RoleID"].ToString()));
                        dataGridView1.Rows[n].Cells["dgBasicRate"].Value = row["BasicRate"].ToString();
                        dataGridView1.Rows[n].Cells["dgFID"].Value = row["fingerID"].ToString();
                        dataGridView1.Rows[n].Cells["dgImage"].Value = row["ImageData"];
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

        private void btnEnrollFinger_Click(object sender, EventArgs e)
        {
            ef.Show();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(tbSearch.Text.Length != 0)
            {
                SearchByName();
            }
            else
            {
                LoadData();
            }
        }
    }
}
