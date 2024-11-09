using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace payrollsystemsti.EmployeeTabs
{
    public partial class leaveApplication : Form
    {
        public static leaveApplication leaveApplicationInstance;
        Methods m = new Methods();
        string fileName;
        int leaveID = 0;
        byte[] medicalCertificate;

        private int loggedInID;

        public leaveApplication()
        {
            InitializeComponent();
            leaveApplicationInstance = this;
        }

        public int LoggedInEmpID
        {
            set
            {
                loggedInID = value;
            }
            get
            {
                return loggedInID;
            }
        }

        private void leaveApplication_Load(object sender, EventArgs e)
        {
            loadLeaveCB();
            cbLeaves.SelectedIndex = 0;
            LoadData(loggedInID);
            if(cbLeaves.Text == "Sick Leave" || cbLeaves.Text == "Emergency Leave")
            {
                dtStart.MinDate = DateTime.Now.AddDays(1);
            }
            else
            {
                dtStart.MinDate = DateTime.Now.AddDays(14);
            }
            
            //LoadData();
            
        }

        private void loadLeaveCBmale()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM LeaveCategory WHERE CategoryName != @catName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catName", "Maternity Leave");
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        // Clear existing items before adding new ones
                        cbLeaves.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            // gets data in the 2nd Column of Category database
                            string categoryName = row[1].ToString();
                            cbLeaves.Items.Add(categoryName);
                        }
                    }
                }
            }
        }

        private void loadLeaveCBfemale()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM LeaveCategory WHERE CategoryName != @catName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catName", "Paternity Leave");
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        // Clear existing items before adding new ones
                        cbLeaves.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            // gets data in the 2nd Column of Category database
                            string categoryName = row[1].ToString();
                            cbLeaves.Items.Add(categoryName);
                        }
                    }
                }
            }
        }

        private void loadLeaveCB()
        {
            string gender = m.GetGender(loggedInID);
            if(gender == "Male")
            {
                loadLeaveCBmale();
            }
            else
            {
                loadLeaveCBfemale();
            }
        }
        private void ClearLeaveApplicationForm()
        {
			/*cbLeaves.SelectedIndex = -1;
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            tbReason.Clear();
            pbMedCert.Image = null;*/

			cbLeaves.SelectedIndex = -1;

			// Ensure MinDate and MaxDate can accommodate today's date
			dtStart.MinDate = DateTimePicker.MinimumDateTime;
			dtStart.MaxDate = DateTimePicker.MaximumDateTime;
			dtStart.Value = DateTime.Now;

			dtEnd.MinDate = DateTimePicker.MinimumDateTime;
			dtEnd.MaxDate = DateTimePicker.MaximumDateTime;
			dtEnd.Value = DateTime.Now;

			tbReason.Clear();
			pbMedCert.Image = null;
		}
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                medicalCertificate = m.ConvertImageToBinary(pbMedCert.Image);

                using (SqlConnection sqlConn = new SqlConnection(m.connStr))
                {
                    sqlConn.Open();

					string query = "INSERT INTO LeaveApplications (CategoryName, DateStart, DateEnd, AppliedDate, Status, Reason, MedicalCert, EmployeeID) VALUES (@CategoryName, @DateStart, @DateEnd, @AppliedDate, @Status, @Reason, @MedicalCert, @EmployeeID)";

					using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@EmployeeID", loggedInID);
                        cmd.Parameters.AddWithValue("@CategoryName", cbLeaves.Text);
                        cmd.Parameters.AddWithValue("@DateStart", dtStart.Value.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@DateEnd", dtEnd.Value.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@AppliedDate", DateTime.Now.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@Status", "Pending");
                        cmd.Parameters.AddWithValue("@Reason", tbReason.Text);
                        cmd.Parameters.AddWithValue("@MedicalCert", medicalCertificate);


                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                             if (rowsAffected > 0)
                             {
                                 
                                 Add_Notification(); // Call to store the notification
                             }
                        }
                        catch (SqlException ex)
                        {
                            
                            MessageBox.Show($"Error inserting into Others: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    MessageBox.Show("Leave Application Submitted Successfully");
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Leave Application Submitted");
					ClearLeaveApplicationForm();
                }
                LoadData(loggedInID);
                ClearData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            medicalCertificate = m.ConvertImageToBinary(pbMedCert.Image);
            
            string query = "UPDATE LeaveApplications SET CategoryName = @categoryName, DateStart = @dateStart, DateEnd = @dateEnd" +
                ", Reason = @reason, MedicalCert = @medcert WHERE EmployeeID = @empID";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryName", cbLeaves.Text);
                    cmd.Parameters.AddWithValue("@dateStart", dtStart.Value.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@dateEnd", dtEnd.Value.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@reason", tbReason.Text);
                    cmd.Parameters.AddWithValue("@empID", loggedInID);
                    cmd.Parameters.AddWithValue("@medcert", medicalCertificate);
                    cmd.ExecuteNonQuery();
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Leave Edited");
				}
            }
            LoadData(loggedInID);
            loadLeaveCB();
            ClearData();
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(tbReason.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbReason, "Please provide a reason..");
            }
            else if (pbMedCert.Image == null && pbMedCert.Visible)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(pbMedCert, "Please provide a Medical Certificate");
            }
            else if (cbLeaves.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbLeaves, "Please Select a Leave Category");
            }
            else if (checkLeavePending())
            {
				errorProvider1.Clear();
				errorProvider1.SetError(cbLeaves, "Please wait for approval of pending leave");
			}
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private bool checkLeavePending()
        {
            
            using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				string query = "SELECT * FROM LeaveApplications WHERE EmployeeID = @empID AND Status = 'Pending'";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@empID", loggedInID);
					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.HasRows)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    lbFileName.Text = fileName;
                    pbMedCert.Image = Image.FromFile(fileName);
                }
            }
        }

        private void LoadData(int empID)
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM LeaveApplications WHERE EmployeeID = @empID";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["LeaveID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveCategory"].Value = row["CategoryName"].ToString();
                        dataGridView1.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["DateStart"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["DateEnd"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                        dataGridView1.Rows[n].Cells["dgReason"].Value = row["Reason"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["MedicalCert"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                        dataGridView1.Rows[n].Cells["dgImage"].Value = row["MedicalCert"];
                    }
                }
            }
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM LeaveApplications";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["LeaveID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveCategory"].Value = row["CategoryName"].ToString();
                        dataGridView1.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["DateStart"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["DateEnd"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                        dataGridView1.Rows[n].Cells["dgReason"].Value = row["Reason"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["MedicalCert"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                        dataGridView1.Rows[n].Cells["dgImage"].Value = row["MedicalCert"];
                    }
                }
            }
        }

        private void ClearData()
        {
            cbLeaves.SelectedIndex = -1;
            dtStart.Value = DateTime.Now;
			if (DateTime.Now >= dtEnd.MinDate && DateTime.Now <= dtEnd.MaxDate)
			{
				dtEnd.Value = DateTime.Now;
			}
			else
			{
				dtEnd.Value = dtEnd.MinDate;
			}
			tbReason.Clear();
            pbMedCert.Image = null;
            lbFileName.Text = string.Empty;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                cbLeaves.Text = dataGridView1.SelectedRows[0].Cells["dgLeaveCategory"].Value.ToString();
                tbReason.Text = dataGridView1.SelectedRows[0].Cells["dgReason"].Value.ToString();
                pbMedCert.Image = m.ConvertToImage((byte[])dataGridView1.SelectedRows[0].Cells["dgImage"].Value);



                string startCellValue = dataGridView1.SelectedRows[0].Cells["dgStart"].Value.ToString();
                string endCellValue = dataGridView1.SelectedRows[0].Cells["dgEnd"].Value.ToString();
                DateTime start, end;

                if (DateTime.TryParseExact(startCellValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
                {
                    dtStart.Value = start;
                }
                else
                {
                    MessageBox.Show("Invalid date format");
                }

                if (DateTime.TryParseExact(endCellValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out end))
                {
                    dtEnd.Value = end;
                }
                else
                {
                    MessageBox.Show("Invalid date format");
                }

                btnSubmit.Enabled = false;
                btnUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetLeaveName(int leaveID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT CategoryName FROM LeaveCategory WHERE CategoryID = @catID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catID", leaveID);
                    object name = cmd.ExecuteScalar();
                    return name.ToString();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            pbMedCert.Image = null;
        }

        private void cbLeaves_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cbLeaves.Text)
            {
                case "Sick Leave":
                    dtStart.MinDate = DateTime.Now.AddDays(1);
                    break;
                case "Emergency Leave":
                    dtStart.MinDate = DateTime.Now.AddDays(1);
                    break;
                default:
                    dtStart.MinDate = DateTime.Now.AddDays(14);
                    break;
            }

            if(hasProof(cbLeaves.Text) == true)
            {
                pbMedCert.Visible = true;
                btnAdd.Visible = true;
                btnRemove.Visible = true;
            }
            else
            {
                pbMedCert.Visible = false;
                btnAdd.Visible = false;
                btnRemove.Visible = false;
            }
        }
        
        private bool hasProof(string category)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT hasProof FROM LeaveCategory WHERE CategoryName = @category";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    try
                    {
						/*bool result = (bool)cmd.ExecuteScalar();
                        return result;*/

						object result = cmd.ExecuteScalar();

						// Check if the result is null
						if (result != null && result != DBNull.Value)
						{
							return (bool)result;
						}
						else
						{
							// Handle the case where no result was found
							//MessageBox.Show("Category not found or hasProof is null.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return false;
						}
					}
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                    
                }
            }
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            dtEnd.MinDate = dtStart.Value.AddDays(1);
        }

		private void Add_Notification()
		{
			
			string notificationMessage = "Leave Application Submitted Successfully";
			DateTime notificationDate = DateTime.Now;

			using (SqlConnection sqlConn = new SqlConnection(m.connStr))
			{
				sqlConn.Open();

				
				string query = "INSERT INTO Notifications (NotificationMessage, Date, EmployeeID) " +
							   "VALUES (@NotificationMessage, @Date, @EmployeeID)";

				using (SqlCommand cmd = new SqlCommand(query, sqlConn))
				{
					
					cmd.Parameters.AddWithValue("@NotificationMessage", notificationMessage);
					cmd.Parameters.AddWithValue("@Date", notificationDate);
					cmd.Parameters.AddWithValue("@EmployeeID", loggedInID);

					try
					{
						
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show("Notification Added Successfully");
						}
						else
						{
							MessageBox.Show("Failed to Add Notification");
						}
					}
					catch (SqlException ex)
					{
						MessageBox.Show($"Error inserting into Notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
	}
}
