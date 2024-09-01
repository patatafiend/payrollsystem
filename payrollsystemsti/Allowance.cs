using payrollsystemsti.Tabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class Allowance : Form
    {
        Methods m = new Methods();
        int titleID = 0;
        public Allowance()
        {
            InitializeComponent();
        }

        private void Allowance_Load(object sender, EventArgs e)
        {
            LoadAllowanceData();
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
                        m.updateAllowance(Convert.ToInt32(tb1.Text), Convert.ToInt32(tb2.Text), Convert.ToInt32(tb3.Text),
                                    Convert.ToInt32(tb4.Text), Convert.ToInt32(tb5.Text), titleID);
						m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Allowance edit");
						tbClear();
                        LoadAllowanceData();
                    }
                    else
                    {
                        MessageBox.Show("Please enter data");
                    }
                }
                catch(Exception ex)
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
            if(tb1.Text != null && tb2.Text != null && tb3.Text != null && tb4.Text != null && tb5.Text != null)
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
            tb2.Clear();
            tb3.Clear();
            tb4.Clear();
        }
        private void btnDeactivate_Click(object sender, EventArgs e)
        {

        }

        private void LoadAllowanceData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT EmployeeAccounts.FirstName, EmployeeAccounts.LastName, Allowance.AllowanceID, Allowance.TrainingA, " +
                "Allowance.TransportationA, Allowance.LoadA, Allowance.ProvisionTA, Allowance.OBA FROM EmployeeAccounts " +
                "INNER JOIN Allowance ON EmployeeAccounts.EmployeeID = Allowance.EmployeeID WHERE IsDeactivated = @status";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["AllowanceID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["TrainingA"].ToString();
                        dataGridView1.Rows[n].Cells["dg4th"].Value = row["TransportationA"].ToString();
                        dataGridView1.Rows[n].Cells["dg5th"].Value = row["LoadA"].ToString();
                        dataGridView1.Rows[n].Cells["dg6th"].Value = row["ProvisionTA"].ToString();
                        dataGridView1.Rows[n].Cells["dg7th"].Value = row["OBA"].ToString();
                    }
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg3rd"].Value.ToString();
            tb2.Text = dataGridView1.SelectedRows[0].Cells["dg4th"].Value.ToString();
            tb3.Text = dataGridView1.SelectedRows[0].Cells["dg5th"].Value.ToString();
            tb4.Text = dataGridView1.SelectedRows[0].Cells["dg6th"].Value.ToString();
            tb5.Text = dataGridView1.SelectedRows[0].Cells["dg7th"].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            tb1.Clear();
            tb2.Clear();
            tb3.Clear();
            tb4.Clear();
            tb5.Clear();
            
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
