using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class accountsArchive : Form
    {

        Methods m = new Methods();
        public accountsArchive()
        {
            InitializeComponent();
        }

        private void accountsArchive_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
			string query = "SELECT * FROM EmployeeAccounts WHERE isDeleted = 1";

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

		private void btnActivate_Click(object sender, System.EventArgs e)
		{

		}
		 private void searchfunction()
		{
			string query = "SELECT * FROM EmployeeAccounts WHERE isDeleted = 1 AND LastName LIKE '%" + searchbox.Text + "%' OR FirstName LIKE '%" + searchbox.Text + "%'";

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
						archives.SelectedRows[n].Cells["dgEmployeeID"].Value = row["EmployeeID"].ToString();
						archives.SelectedRows[n].Cells["dgFullName"].Value = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
					}

				}
			}
		}

		private void tbSearch_TextChanged(object sender, System.EventArgs e)
		{
			archives.Rows.Clear();
			searchfunction();
		}

		private void btEnter_Click(object sender, System.EventArgs e)
		{
			searchfunction();
		}
	}
}