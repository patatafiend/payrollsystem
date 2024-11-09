using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class accountsArchive : Form
    {

        Methods m = new Methods();

		int id = 0;
        public accountsArchive()
        {
            InitializeComponent();
        }

       

        private void LoadDataEmployee()
        {
			archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM EmployeeAccounts WHERE IsDeleted = 1";

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
						int n = archives.Rows.Add();
						archives.Rows[n].Cells["dgEmployeeID"].Value = row["EmployeeID"].ToString();
						archives.Rows[n].Cells["dgFullName"].Value = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
					}

				}
			}
            archives.Columns["dgEmployeeID"].HeaderText = "EmployeeID";
		}

        private void LoadDataDeduction()
        {
            archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM Deductions WHERE IsDeactivated = 1";

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
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["DeductionID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["DeductionType"].ToString() + ", " + row["Amount"].ToString();
                    }

                }
            }
            archives.Columns["dgEmployeeID"].HeaderText = "Deduction ID";
        }

        private void LoadDataDepartment()
        {
            archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM Departments WHERE IsDeactivated = 1";

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
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["DepartmentID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["DepartmentName"].ToString();
                    }

                }
            }
            archives.Columns["dgEmployeeID"].HeaderText = "Department ID";
        }

        private void LoadDataHolidays()
        {
            archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM Holidays WHERE IsDeactivated = 1";

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
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["HolidayID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["HolidayName"].ToString() + ", " + row["HolidayType"].ToString();
                    }

                }
            }
            archives.Columns["dgEmployeeID"].HeaderText = "Holiday ID";
        }

        private void LoadDataLeaves()
        {
            archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM LeaveCategory WHERE IsDeactivated= 1";

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
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["CategoryID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["CategoryName"].ToString();
                    }

                }
            }
            archives.Columns["dgEmployeeID"].HeaderText = "Leave ID";
        }

        private void LoadDataRoles()
        {
            archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM Roles WHERE IsDeactivated = 1";

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
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["RoleID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["RoleTitle"].ToString();
                    }

                }
            }
        }

        private void LoadDataPosition()
        {
            archives.Rows.Clear();
            string searchText = searchbox.Text.Trim();
            string query = "SELECT * FROM Positions WHERE IsDeactivated = 1";

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
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["PositionID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["PositionTitle"].ToString();
                    }
                }
            }
            archives.Columns["dgEmployeeID"].HeaderText = "Position ID";
        }
        private void accountsArchive_Load(object sender, System.EventArgs e)
        {
            LoadDataEmployee();
        }

        private void searchfunction()
        {
            archives.Rows.Clear();

            string searchText = searchbox.Text.Trim(); // Assuming txtSearchEmployee is your textbox

            // Use parameterized query to prevent SQL injection
            string query = "SELECT * FROM EmployeeAccounts WHERE IsDeleted = 1 AND FirstName LIKE @searchText";

            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%"); // Add parameterized search text

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int n = archives.Rows.Add();
                        archives.Rows[n].Cells["dgEmployeeID"].Value = row["EmployeeID"].ToString();
                        archives.Rows[n].Cells["dgFullName"].Value = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
                    }
                }
            }
        }


        private void btnActivate_Click_1(object sender, EventArgs e)
        {
            
        }

        void activate()
        {
            switch (cbPosition.Text)
            {
                case "Employee Accounts":
                    activateE();
                    break;
                case "Deduction":
                    activateD();
                    break;
                case "Department":
                    activateDep();
                    break;
                case "Holidays":
                    activateHol();
                    break;
                case "Leaves":
                    activateLeave();
                    break;
                case "Roles":
                    activateRole();
                    break;
                case "Positon":
                    activatePosition();
                    break;
                default:
                    activateE();
                    break;
            }
        }

        void activateE()
        {
            m.activateAcc(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        void activateD()
        {
            m.activateDeduc(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        void activateDep()
        {
            m.activateDepartment(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        void activateHol()
        {
            m.activateHoliday(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        void activateLeave()
        {
            m.activateLeave(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        void activateRole()
        {
            m.activateRoles(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        void activatePosition()
        {
            m.activatePosition(id);
            btnActivate.Enabled = false;
            m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
            LoadDataEmployee();
        }

        private void archives_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnActivate.Enabled = true;


            id = Convert.ToInt32(archives.SelectedRows[0].Cells["dgEmployeeID"].Value.ToString());
        }


        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (searchbox.Text.Length > 0)
            {
                searchfunction();
            }
            else
            {
                LoadDataEmployee();
            }
        }

        private void btnovertime_Click(object sender, EventArgs e)
        {
            overtimeApplication overtime = new overtimeApplication();
            overtime.Show();
        }

        private void cbPosition_TextChanged(object sender, EventArgs e)
        {
            switch (cbPosition.Text)
            {
                case "Employee Accounts":
                    LoadDataEmployee();
                    break;
                case "Deduction":
                    LoadDataDeduction();
                    break;
                case "Department":
                    LoadDataDepartment();
                    break;
                case "Holidays":
                    LoadDataHolidays();
                    break;
                case "Leaves":
                    LoadDataLeaves();
                    break;
                case "Roles":
                    LoadDataRoles();
                    break;
                case "Position":
                    LoadDataPosition();
                    break;
            }
        }

    }
}