using payrollsystemsti.AdminTabs;
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

namespace payrollsystemsti
{
    public partial class DepartmentMain : Form
    {
        Methods m = new Methods();
        int titleID = 0;
        public DepartmentMain()
        {
            InitializeComponent();
        }

        private void LoadDepartmentData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Departments WHERE IsDeactivated = 0";
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
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["DepartmentID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["DepartmentName"].ToString();
                    }
                }
            }
        }

        private void DepartmentMain_Load(object sender, EventArgs e)
        {
            LoadDepartmentData();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!m.ifDepartmentNameExist(tb1.Text.ToString()))
            {
                m.insertToDepartments(tb1.Text);
				m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Department Add");
				LoadDepartmentData();
                tb1.Clear();
            }
            else if (m.ifDepartmentNameExist(tb1.Text.ToString()))
            {
                MessageBox.Show("Department Name already exists");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!m.ifDepartmentNameExist(tb1.Text.ToString()))
                {
                    m.updateDepartments(tb1.Text, titleID);
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Department edit");
					LoadDepartmentData();
                    tb1.Clear();
                }
                else if (m.ifDepartmentNameExist(tb1.Text.ToString()))
                {
                    MessageBox.Show("Department Name already exists");
                }
                else
                {
                    MessageBox.Show("Unknown Error");
                }
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (m.checkDepartmentCount(titleID))
            {
                Transfer transfer = new Transfer();
                Transfer.trans.DepartmentID = titleID;
                transfer.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    m.deactivateDepartment(titleID);
                    LoadDepartmentData();
                    tb1.Clear();
                }
                else
                {
                    btnDeactivate.Enabled = false;
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
            btnDeactivate.Enabled = true;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            tb1.Clear();
            btnAdd.Enabled = false;
            btnDeactivate.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (tb1.Text.Length > 0)
            {
                btnCancel.Visible = true;
                if(tb1.Text.Length > 3 && !btnUpdate.Enabled)
                {
                    btnAdd.Enabled = true;
                }
            }
            else
            {
                btnCancel.Visible = false;
            }
        }
    }
}
