using payrollsystemsti.AdminTabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace payrollsystemsti.EmployeeTabs
{
    public partial class leaveApplication : Form
    {
        public static leaveApplication leaveApplicationInstance;
        public TextBox tbEmployee;
        Methods m = new Methods();
        string fileName;
        
        public leaveApplication()
        {
            InitializeComponent();
            leaveApplicationInstance = this;
            tbEmployee = tbEmployeeID;
        }

        private void leaveApplication_Load(object sender, EventArgs e)
        {
            loadLeaveCB();
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
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
			// Retrieve the selected leave category from the combo box
			string categoryName = cbLeaves.Text;

			// Validate input fields
			if (Validation())
			{
				// Convert medical certificate image to binary
				byte[] medicalCertificate = ConvertImageToBinary(pbMedCert.Image);

				using (SqlConnection sqlConn = new SqlConnection(m.connStr))
				{
					sqlConn.Open();

					string query = "INSERT INTO LeaveApplication (CategoryID, StartDate, EndDate, Reason, MedicalCertificate, Status, FileName, DateApplied, EmployeeID) VALUES" +
						"(@CategoryName," +
						" @StartDate, @EndDate, @Reason, @MedicalCertificate, @Status, @FileName, @DateApplied, EmployeeID)";

					using (SqlCommand cmd = new SqlCommand(query, sqlConn))
					{
						// Add parameters to prevent SQL injection
						cmd.Parameters.AddWithValue("@EmployeeID", tbEmployeeID.Text);
						cmd.Parameters.AddWithValue("@CategoryName", categoryName);
						cmd.Parameters.AddWithValue("@StartDate", dtStart.Value.ToString("MM/dd/yyyy"));
						cmd.Parameters.AddWithValue("@EndDate", dtEnd.Value.ToString("MM/dd/yyyy"));
						cmd.Parameters.AddWithValue("@Reason", tbReason.Text);
						cmd.Parameters.AddWithValue("@MedicalCertificate", medicalCertificate);
						cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@Status", "Pending");

                        cmd.ExecuteNonQuery();
					}

					MessageBox.Show("Leave Application Submitted Successfully");
					ClearLeaveApplicationForm();
				}
                LoadData();
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
            else if (pbMedCert.Image == null)
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
            string query = "SELECT LeaveAccounts.StartDate, LeaveAccounts.EndDate,LeaveAccounts.Reason," +
                "LeaveAccounts.EndDate, LeaveAccounts.Reason, LeaveAccounts.FileName,LeaveAccounts.ImageData," +
                " Category.CategoryId, Category.CategoryName FROM LeaveApplication JOIN Category ON" +
                " LeaveApplication.CategoryId = Category.CategoryId";

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
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["LeaveId"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveCategory"].Value = row["CategoryId"].ToString();
                        dataGridView1.Rows[n].Cells["dgStartDate"].Value = Convert.ToDateTime(row["StartDate"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgEndDate"].Value = Convert.ToDateTime(row["EndDate"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells["dgReason"].Value = row["Reason"].ToString();
                        dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                        dataGridView1.Rows[n].Cells["dgImageData"].Value = row["ImageData"].ToString();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void lbFileName_Click(object sender, EventArgs e)
        {

        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
