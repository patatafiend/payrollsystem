using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

                    // Load the image asynchronously to avoid blocking the UI thread
                    Task.Run(() =>
                    {
                        try
                        {
                            // Resize the image to a suitable size
                            Bitmap resizedImage = ResizeImage(Image.FromFile(fileName), 300, 300); // Adjust the dimensions as needed

                            // Update the PictureBox on the UI thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                pbEmployee.Image = resizedImage;
                            });
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions, e.g., log the error or display an error message
                            MessageBox.Show("Error loading image: " + ex.Message);
                        }
                    });
                }
            }
        }

        private Bitmap ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics graphic = Graphics.FromImage(bmp))
            {
                graphic.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
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
            dataGridView1.Font = new Font("Arial", 15);
            dataGridView1.Columns["dgDepartment"].Width = 250;
        }

        public int GenerateEmployeeId()
        {
            int lastUsedId = GetLastUsedEmployeeId();
            int nextId = lastUsedId + 1;

            string employeeId = nextId.ToString().PadLeft(4, '0');

            if (!UpdateLastUsedEmployeeId(nextId))
            {
                // Handle error updating last used ID (log or display message)
                Console.WriteLine("Error updating last used employee ID");
            }

            return Convert.ToInt32(employeeId);
        }

        private int GetLastUsedEmployeeId()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT MAX(EmployeeID) FROM EmployeeAccounts";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        // No records found in the table, return a starting value
                        return 1;
                    }
                }
            }
        }

        private bool UpdateLastUsedEmployeeId(int newId)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE EmployeeIdSettings SET LastUsedId = @newId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newId", newId);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception and return false
                        Console.Error.WriteLine($"Error updating LastUsedId: {ex.Message}");
                        return false;
                    }
                }
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
					bool isInserted = InsertToEmployeeAccounts(GenerateEmployeeId(),
						tbFirstName.Text, tbLastName.Text, getDepartmentID(cbDeparment.Text),
						getPositionID(cbPosition.Text), getRoleID(cbRole.Text), tbSSN.Text, tbEmail.Text, tbAddress.Text,
						dtDob.Value, tbBasicRate.Text, lbFileName.Text, m.ConvertImageToBinary(pbEmployee.Image),
						tbMob.Text, 0, defaultAvailableTotalLeaves(), 0, DateTime.Now, cbGender.Text, cbCivil.Text, dtStartDate.Value, cbType.Text);

					if (isInserted)
					{
						m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Registered");
						StoreUserLeaveTypeData();


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
		private (string, int) GetCategoryNameAndLeaveDays(string tableName)
		{
			string categoryName = string.Empty;
			int defaultAvailableLeaveDays = 0;

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				
				string query = $"SELECT TOP 1 CategoryName, defaultAvailableLeaveDays FROM {tableName}";
				SqlCommand cmd = new SqlCommand(query, conn);
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					categoryName = reader["CategoryName"].ToString();
					defaultAvailableLeaveDays = Convert.ToInt32(reader["defaultAvailableLeaveDays"]);
				}

				reader.Close();
			}

			return (categoryName, defaultAvailableLeaveDays);
		}

		private List<string> GetTableColumns(string tableName)
		{
			List<string> columns = new List<string>();

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				
				string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
				SqlCommand cmd = new SqlCommand(query, conn);
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					columns.Add(reader["COLUMN_NAME"].ToString());
				}

				reader.Close();
			}

			return columns;
		}

		private int GetLatestAddedEmployeeId()
		{
			int latestEmployeeId = -1;

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				
				string query = "SELECT TOP 1 EmployeeID FROM EmployeeAccounts ORDER BY EmployeeID DESC";
				SqlCommand cmd = new SqlCommand(query, conn);
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					latestEmployeeId = Convert.ToInt32(reader["EmployeeID"]);
				}

				reader.Close();
			}

			return latestEmployeeId;
		}

        private void StoreLeaveCategoryData()
        {
            List<(string CategoryName, int DefaultAvailableLeaveDays)> leaveCategoryData = new List<(string, int)>();

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                
                string query = "SELECT CategoryName, defaultAvailableLeaveDays FROM LeaveCategory";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string categoryName = reader["CategoryName"].ToString();
                    int defaultAvailableLeaveDays = Convert.ToInt32(reader["defaultAvailableLeaveDays"]);
                    leaveCategoryData.Add((categoryName, defaultAvailableLeaveDays));
                }

                reader.Close();
            }
        }

		
		private List<(string CategoryName, int DefaultAvailableLeaveDays)> GetLeaveCategoryData()
		{
			List<(string CategoryName, int DefaultAvailableLeaveDays)> leaveCategoryData = new List<(string, int)>();

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				
				string query = "SELECT CategoryName, defaultAvailableLeaveDays FROM LeaveCategory";
				SqlCommand cmd = new SqlCommand(query, conn);
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					string categoryName = reader["CategoryName"].ToString();
					int defaultAvailableLeaveDays = Convert.ToInt32(reader["defaultAvailableLeaveDays"]);
					leaveCategoryData.Add((categoryName, defaultAvailableLeaveDays));
				}

				reader.Close();
			}

			return leaveCategoryData;
		}

		private List<string> StoreLeaveTypeAvailableColumn(string tableName)
		{
			List<string> columns = new List<string>();

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				
				string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
				SqlCommand cmd = new SqlCommand(query, conn);
				SqlDataReader reader = cmd.ExecuteReader();

				int columnIndex = 0;
				while (reader.Read())
				{
					if (columnIndex < 2)
					{
						
						columnIndex++;
						continue;
					}
					columns.Add(reader["COLUMN_NAME"].ToString());
					columnIndex++;
				}

				reader.Close();
			}

			return columns;
		}

		private void StoreUserLeaveTypeData()
		{
			int employeeId = GetLatestAddedEmployeeId();
			if (employeeId == -1)
			{
				MessageBox.Show("Error retrieving the latest employee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			List<(string CategoryName, int DefaultAvailableLeaveDays)> leaveCategoryData = GetLeaveCategoryData();
			List<string> leaveTypeColumns = GetTableColumns("LeaveTypeAvailable");

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				
				

				StringBuilder queryBuilder = new StringBuilder("INSERT INTO LeaveTypeAvailable ([Employee ID]");
				foreach (var column in leaveTypeColumns)
				{
					if (column != "Employee ID" && column != "Id") 
					{
						queryBuilder.Append($", [{column}]");
					}
				}
				queryBuilder.Append(") VALUES (@EmployeeID");

				foreach (var column in leaveTypeColumns)
				{
					if (column != "Employee ID" && column != "Id") 
					{
						queryBuilder.Append($", @{column.Replace(" ", "_")}");
					}
				}
				queryBuilder.Append(")");

				SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn);
				cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

				foreach (var column in leaveTypeColumns)
				{
					if (column != "Employee ID" && column != "Id") 
					{
						var leaveCategory = leaveCategoryData.FirstOrDefault(l => l.CategoryName == column);
						int leaveDays = leaveCategory != default ? leaveCategory.DefaultAvailableLeaveDays : 0;
						cmd.Parameters.AddWithValue($"@{column.Replace(" ", "_")}", leaveDays);
					}
				}
				cmd.ExecuteNonQuery();


			}
		}

        private bool InsertToEmployeeAccounts(int empID, string firstName, string lastName, int department, int position, int role, string ssn, string email, string address, DateTime dob, string basic, string fileName, byte[] imageData, string mobile, byte isDeleted, int leaves, int absents, DateTime hdate, string gender, string civil, DateTime sdate, string type)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO EmployeeAccounts (EmployeeID, FirstName, LastName, " +
                           "DepartmentID, PositionID, RoleID, SSN, Email, Address, Dob, BasicRate, FileName, " +
                           "ImageData, Mobile, IsDeleted, Leaves, Absents, HiredDate, Gender, CivilStatus, StartDate, Type) " +
                           "OUTPUT INSERTED.EmployeeID VALUES(@empID, @FirstName, @LastName, " +
                           "@Department, @Position, @Role, @SSN, @Email, @Address, @Dob, @BasicRate, " +
                           "@FileName, @ImageData, @Mobile, @IsDeleted, @Leaves, @Absents, @hireddate, @gender, @civil, @startdate, @type)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
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
                    cmd.Parameters.AddWithValue("@civil", civil);
                    cmd.Parameters.AddWithValue("@startdate", sdate);
                    cmd.Parameters.AddWithValue("@type", type);



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
		private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (UpdateEmployeeAccounts(tbFirstName.Text, tbLastName.Text, getDepartmentID(cbDeparment.Text),
                        getPositionID(cbPosition.Text), getRoleID(cbRole.Text), tbSSN.Text, tbEmail.Text, tbAddress.Text,
                        dtDob.Value.ToString("MM/dd/yyyy"), tbBasicRate.Text, lbFileName.Text, m.ConvertImageToBinary(pbEmployee.Image),
                        tbMob.Text, Convert.ToInt32(empID.Text), cbGender.Text, cbCivil.Text, cbType.Text));
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Register Edit");
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

        private bool UpdateEmployeeAccounts(string firstName, string lastName, int department, int position, int role, string ssn, string email, string address, string dob, string basic, string fileName, byte[] imageData, string mobile, int empID, string gender, string civil, string type)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE EmployeeAccounts SET FirstName = @firstName, LastName = @lastName," +
                       "DepartmentID = @department, PositionID = @position, RoleID = @role, SSN = @ssn, Email = @email, " +
                       "Address = @address, Dob = @dob, BasicRate = @basicRate, ImageData = @imageData, " +
                       "Mobile = @mobile, FileName = @fileName, Gender = @gender, CivilStatus = @civil WHERE EmployeeID = @employeeId";


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
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@civil", civil);
                    cmd.Parameters.AddWithValue("@type", type);

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
                    m.InsertAdjustmentData(Convert.ToInt32(id), 0, "");
                    m.InsertIncentivesData(Convert.ToInt32(id), 0, "");
                    m.InsertLoan(Convert.ToInt32(id), 0, 0, 0);
                    updateLeaveTypeAvailableIfFemaleOrMale(NempID);


					MessageBox.Show("Created User Succesfully");
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Registered Account created");
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
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Registered Deactivated");
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

		private int defaultAvailableTotalLeaves()
		{
            int totaldefaultleave = 0;
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT defaultAvailableLeaveDays FROM LeaveCategory";
                using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						totaldefaultleave += Convert.ToInt32(reader["defaultAvailableLeaveDays"]);
					}
				}
            }

            return totaldefaultleave;
		}

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

		private void updateLeaveTypeAvailableIfFemaleOrMale(int empid)
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				string query = "SELECT [Maternity Leave], [Paternity Leave] FROM LeaveTypeAvailable WHERE [Employee ID] = @empID";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@empID", empid);

				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					reader.Close();

					if (m.GetEmpGender(empid).Equals("Male"))
					{
						// Update MaternityLeave to 0 for male employees
						string updateQuery = "UPDATE LeaveTypeAvailable SET [Maternity Leave] = 0 WHERE [Employee ID] = @empID";
						SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
						updateCmd.Parameters.AddWithValue("@empID", empid);
						updateCmd.ExecuteNonQuery();
					}
					else if (m.GetEmpGender(empid).Equals("Female"))
					{
						// Update PaternityLeave to 0 for female employees
						string updateQuery = "UPDATE LeaveTypeAvailable SET [Paternity Leave] = 0 WHERE [Employee ID] = @empID";
						SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
						updateCmd.Parameters.AddWithValue("@empID", empid);
						updateCmd.ExecuteNonQuery();
					}
				}
			}
		}

	}
}
