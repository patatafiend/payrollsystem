using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class leaveCategoriesManagement : Form
    {
        Methods m = new Methods();
        public leaveCategoriesManagement()
        {
            InitializeComponent();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO LeaveCategory (CategoryName) VALUES (@catname)";
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", tbLeaveName.Text);

                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
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
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgLeaveID"].Value = row["CategoryID"].ToString();
                        dataGridView1.Rows[n].Cells["dgLeaveName"].Value = row["CategoryName"].ToString();
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbLeaveID.Text = dataGridView1.SelectedRows[0].Cells["dgLeaveID"].Value.ToString();
            tbLeaveName.Text = dataGridView1.SelectedRows[0].Cells["dgLeaveName"].Value.ToString();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            ClearData();
        }
    }
}
