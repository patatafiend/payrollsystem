using payrollsystemsti.Tabs;
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
    public partial class Roles : Form
    {
        Methods m = new Methods();
        int titleID = 0;
        public Roles()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!m.ifRoleTitleExist(tb1.Text.ToString()))
            {
                m.insertToRoles(tb1.Text);
                LoadRoleData();
                tb1.Clear();
            }
            else if (m.ifRoleTitleExist(tb1.Text.ToString()))
            {
                MessageBox.Show("Role already exists");
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
                if (!m.ifRoleTitleExist(tb1.Text.ToString()))
                {
                    m.updateRoles(tb1.Text, titleID);
                    LoadRoleData();
                    tb1.Clear();
                }
                else if (m.ifRoleTitleExist(tb1.Text.ToString()))
                {
                    MessageBox.Show("Role already exists");
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
        }

        private void LoadRoleData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Roles WHERE IsDeactivated = 0";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["RoleID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["RoleTitle"].ToString();
                    }
                }
            }
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            LoadRoleData();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    m.deactivateRole(titleID);
                    LoadRoleData();
                    tb1.Clear();
                }
                else
                {
                    MessageBox.Show("Please select a row to deactivate", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                btnDeactivate.Enabled = false;
            }
            
        }
    }
}
