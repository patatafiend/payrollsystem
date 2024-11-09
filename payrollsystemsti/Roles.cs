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
                m.insertToRoles(tb1.Text, checkBox1(), checkBox2(), checkBox3(), checkBox4(), checkBox5(), checkBox6(), checkBox7());
				m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Role Added");
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
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Role Edited");
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
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["Maintenance"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["ViewHistory"].ToString();
                        dataGridView1.Rows[n].Cells["dg4th"].Value = row["LeaveManagement"].ToString();
                        dataGridView1.Rows[n].Cells["dg5th"].Value = row["AccountArchive"].ToString();
                        dataGridView1.Rows[n].Cells["dg6th"].Value = row["BackupRestore"].ToString();
                        dataGridView1.Rows[n].Cells["dg7th"].Value = row["EmployeeManagement"].ToString();
                        dataGridView1.Rows[n].Cells["dg8th"].Value = row["Attendance"].ToString();
                    }
                }
            }
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            LoadRoleData();
        }

        public bool checkBox1()
        {
            switch (mBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }
        public bool checkBox2()
        {
            switch (vhBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }
        public bool checkBox3()
        {
            switch (lmBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }

        public bool checkBox4()
        {
            switch (aaBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }

        public bool checkBox5()
        {
            switch (brBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }

        public bool checkBox6()
        {
            switch (emBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }

        public bool checkBox7()
        {
            switch (aBox.CheckState)
            {
                case CheckState.Checked:
                    return true;
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
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
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Role Deactivated");
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
                if (tb1.Text.Length > 3 && !btnUpdate.Enabled)
                {
                    btnAdd.Enabled = true;
                }
            }
            else
            {
                btnCancel.Visible = false;
            }
        }

        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
        }
    }
}
