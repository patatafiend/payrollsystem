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
                    foreach(DataRow row in dt.Rows){
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.SelectedRows[n].Cells["dgEmployeeID"].Value = row["EmployeeID"].ToString();
                        dataGridView1.SelectedRows[n].Cells["dgFullName"].Value = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
                    }

                }
            }
        }
    }
}