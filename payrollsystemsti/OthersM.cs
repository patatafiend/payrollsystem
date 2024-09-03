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
    public partial class OthersM : Form
    {
        Methods m = new Methods();
        int titleID = 0;
        public OthersM()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (IsTextBoxFilled())
                    {
                        m.UpdateOtherData(Convert.ToInt32(tb1.Text), 0, 0,
                                    Convert.ToInt32(tb4.Text), titleID);
                        tbClear();
						m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Others Update");
						LoadOthersData();
                    }
                    else
                    {
                        MessageBox.Show("Please enter data");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        public bool IsTextBoxFilled()
        {
            if (tb1.Text != null && tb4.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void tbClear()
        {
            tb1.Clear();
            tb4.Clear();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    m.deactivateOthers(titleID);
                    LoadOthersData();
                    tbClear();
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

        private void LoadOthersData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT EmployeeAccounts.FirstName, EmployeeAccounts.LastName, Others.OtherID, Others.Incentives, " +
                "Others.RegularH, Others.SpecialH, Others.Adjustment FROM EmployeeAccounts " +
                "INNER JOIN Others ON EmployeeAccounts.EmployeeID = Others.EmployeeID WHERE IsDeactivated = @status";
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["OtherID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["Incentives"].ToString();
                        dataGridView1.Rows[n].Cells["dg6th"].Value = row["Adjustment"].ToString();
                    }
                }
            }
        }

        private void OthersM_Load(object sender, EventArgs e)
        {
            LoadOthersData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            tb1.Clear();
            tb4.Clear();
            btnDeactivate.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (tb1.Text.Length > 0)
            {
                btnCancel.Visible = true;
            }
            else
            {
                btnCancel.Visible = false;
            }
        }
    }
}
