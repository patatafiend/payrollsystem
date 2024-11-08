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

       

        private void LoadData()
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


		}
        private void accountsArchive_Load(object sender, System.EventArgs e)
        {
            LoadData();
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
            m.activateAcc(id);
			btnActivate.Enabled = false;
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Account Archive Activated");
			LoadData();

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
                LoadData();
            }
        }

        private void btnovertime_Click(object sender, EventArgs e)
        {
            overtimeApplication overtime = new overtimeApplication();
            overtime.Show();
        }
    }
}