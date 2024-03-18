using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace payrollsystemsti.EmployeeTabs
{
    public partial class leaveApplication : Form
    {
        public static leaveApplication leaveApplicationInstance;
        Methods m = new Methods();
        string fileName;

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
            LoadData();
        }

        private void loadLeaveCB()
        {
            string query = "SELECT * FROM LeaveCategory";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
        private void ClearLeaveApplicationForm()
        {
            cbLeaves.SelectedIndex = -1;
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            tbReason.Clear();
            pbMedCert.Image = null;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (Validation())
            {
                // Convert medical certificate image to binary
                byte[] medicalCertificate = m.ConvertImageToBinary(pbMedCert.Image);

                using (SqlConnection sqlConn = new SqlConnection(m.connStr))
                {
                    sqlConn.Open();

                    string query = "INSERT INTO LeaveApplications (CategoryName, DateStart, DateEnd, AppliedDate, Status, Reason, MedicalCert, FileName, EmployeeID) VALUES" +
                        "(@CategoryName, @DateStart, @DateEnd, @AppliedDate, @Status, @Reason, @MedicalCert, @FileName, @EmployeeID)";

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
                        if(medicalCertificate != null)
                        {
                            cmd.Parameters.AddWithValue("@MedicalCert", medicalCertificate);
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                        }
                        else
                        {
                            cmd.Parameters.Add("@MedicalCert", SqlDbType.Image).Value = DBNull.Value;
                            cmd.Parameters.AddWithValue("@FileName", DBNull.Value);
                        }
                        
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Leave Application Submitted Successfully");
                    ClearLeaveApplicationForm();
                }
                LoadData();
                ClearData();
            }
        }
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(tbReason.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbReason, "Please provide a reason..");
            }
            else if (pbMedCert.Visible == true)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(pbMedCert, "Please provide a Medical Certificate");
            }
            else if (cbLeaves.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbLeaves, "Please Select a Leave Category");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
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
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["LID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveCategory"].Value = row["CategoryName"].ToString();
                        dataGridView1.Rows[n].Cells["dgStart"].Value = Convert.ToDateTime(row["DateStart"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEnd"].Value = Convert.ToDateTime(row["DateEnd"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgAppliedDate"].Value = Convert.ToDateTime(row["AppliedDate"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgStatus"].Value = row["Status"].ToString();
                        dataGridView1.Rows[n].Cells["dgReason"].Value = row["Reason"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["MedicalCert"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                    }
                }
            }
        }

        private void ClearData()
        {
            cbLeaves.Items.Clear();
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            tbReason.Clear();
            pbMedCert = null;
            lbFileName.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void cbLeaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLeaves.Text.Equals("Sick Leave"))
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                cbLeaves.Text = dataGridView1.SelectedRows[0].Cells["dgLeaveCategory"].Value.ToString();
                tbReason.Text = dataGridView1.SelectedRows[0].Cells["dgReason"].Value.ToString();

                if (!dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.Equals(null))
                {
                    pbMedCert.Image = Image.FromFile(dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString());
                }
                

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
    }
}
