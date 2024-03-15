using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class leaveCategoriesManagement : Form
    {
        Methods m = new Methods();
        public leaveCategoriesManagement()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO LeaveCategory (LeaveName) VALUES CatName = @catname";
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", tbLeaveName);

                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string query = "UPDATE LeaveCategory SET CatName = @catname";
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", tbLeaveName);

                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearData();
        }

        void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM LeaveCategory";
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows){
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["CatID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveName"].Value = row["CatName"].ToString();
                    }

                }
                
            }
        }

        private void leaveCategoriesManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void ClearData()
        {
            tbLeaveID.Clear();
            tbLeaveName.Clear();
        }
    }
}
