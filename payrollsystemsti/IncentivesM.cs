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
    public partial class IncentivesM : Form
    {
        Methods m = new Methods();
        int IncentiveID = 0;
        public IncentivesM()
        {
            InitializeComponent();
        }

        private void IncentivesM_Load(object sender, EventArgs e)
        {
            LoadIncentivesData();
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
                        m.UpdateIncentivesData(IncentiveID, Convert.ToInt32(tb1.Text));
                        tbClear();
                        m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Others Update");
                        LoadIncentivesData();
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
            if (tb1.Text != null)
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
        }

        private void LoadIncentivesData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT EmployeeAccounts.FirstName, EmployeeAccounts.LastName, Others.OtherID, " +
                "Others.Incentives FROM EmployeeAccounts INNER JOIN Others ON EmployeeAccounts.EmployeeID = Others.EmployeeID " +
                "WHERE IsDeactivated = @status";
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
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void Reset()
        {
            tb1.Clear();
            btnUpdate.Enabled = false;
            btnCancel.Visible = false;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (tb1.Text.Length > 0)
            {
                btnUpdate.Enabled = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnCancel.Visible = false;
            }
        }
    }
}
