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
       
        string fileName;
        public leaveApplication()
        {
            InitializeComponent();
        }

        private void leaveApplication_Load(object sender, EventArgs e)
        {
            loadLeaveCB();
        }

        private void loadLeaveCB()
        {
			using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Category]", conn))
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

				// Retrieve the EmpID of the logged-in employee
				int employeeID = GetLoggedInEmployeeID();

				using (SqlConnection sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
				{
					sqlConn.Open();

					string query = "INSERT INTO Leaves (EmployeeID, CategoryID, StartDate, EndDate, Reason, MedicalCertificate, Status, FileName) VALUES" +
						"(@EmployeeID, (SELECT CategoryID FROM LeaveCategory WHERE CatName = @CategoryName)," +
						" @StartDate, @EndDate, @Reason, @MedicalCertificate, 'Pending', @FileName)";

					using (SqlCommand cmd = new SqlCommand(query, sqlConn))
					{
						// Add parameters to prevent SQL injection
						cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
						cmd.Parameters.AddWithValue("@CategoryName", categoryName);
						cmd.Parameters.AddWithValue("@StartDate", dtStart.Value.ToString("MM/dd/yyyy"));
						cmd.Parameters.AddWithValue("@EndDate", dtEnd.Value.ToString("MM/dd/yyyy"));
						cmd.Parameters.AddWithValue("@Reason", tbReason.Text);
						cmd.Parameters.AddWithValue("@MedicalCertificate", medicalCertificate);
						cmd.Parameters.AddWithValue("@FileName", fileName);

						cmd.ExecuteNonQuery();
					}

					MessageBox.Show("Leave Application Submitted Successfully");
					ClearLeaveApplicationForm();
				}
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
        string loggedInUserName;
        public string LoggedInUserName
        {
            get { return loggedInUserName; }
            set
            {
                loggedInUserName = value;
                // Update the label with logged-in user name
                
            }
        }
        private int GetLoggedInEmployeeID()
        {

			using (SqlConnection sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=stipayrolldb; Integrated Security=True; TrustServerCertificate=True; Encrypt=false"))
			{
				sqlConn.Open();
				string query = "SELECT EmpID FROM Employee WHERE UserName = @username";

				using (SqlCommand cmd = new SqlCommand(query, sqlConn))
				{
					cmd.Parameters.AddWithValue("@username", loggedInUserName);

					object result = cmd.ExecuteScalar();
					if (result != null)
					{
						return (int)result;
					}
					return -1; // Return -1 if the EmpID is not found (handle this case appropriately in your application)
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
    }
}
