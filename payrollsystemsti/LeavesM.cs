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
    public partial class LeavesM : Form
    {
        Methods m = new Methods();
        int titleID = 0;
        public LeavesM()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddLeave();
        }

        private void AddLeave()
        {
            if (!m.ifLeaveCategoryExist(tb1.Text.ToString()))
            {
				AddNewLeaveColumn(tb1.Text);


				int numofLeaves = Int32.Parse(tb_numofLeaves.Text.ToString());
				m.insertToLeaves(tb1.Text, checkBox(), numofLeaves);
				m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Leave Added");
				LoadLeaveCategoryData();
				tb1.Clear();

                
                
                
            }
            else if (m.ifLeaveCategoryExist(tb1.Text.ToString()))
            {
                MessageBox.Show("Leave already exists");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
        }

		private void AddNewLeaveColumn(string columnName)
		{
			string query = $"ALTER TABLE LeaveTypeAvailable ADD [{columnName}] INT DEFAULT 0";
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.ExecuteNonQuery();
				}
			}
		}


		private void UpdateLeave()
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!m.ifLeaveCategoryExist(tb1.Text.ToString()))
                {
                    m.updateLeaves(tb1.Text, checkBox(), titleID);
                    LoadLeaveCategoryData();
                    tb1.Clear();
                    cbPicture.Checked = false;
                }
                else if (m.ifLeaveCategoryExist(tb1.Text.ToString()))
                {
                    MessageBox.Show("Leave already exists");
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

        private void DeactivateLeave()
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    m.deactivateDeduction(titleID);
                    LoadLeaveCategoryData();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
			m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "Leave edit");
			UpdateLeave();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
        }

        private void LoadLeaveCategoryData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM LeaveCategory WHERE IsDeactivated = 0";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["CategoryID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["CategoryName"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = hasProof(row["hasProof"].ToString());
                    }
                }
            }
        }

        public bool checkBox()
        {
            switch (cbPicture.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
                default:
                    return false;
            }
        }

        public string hasProof(string yesno)
        {
            switch (yesno)
            {
                case "True":
                    return "Yes";
                default:
                    return "No";
            }
        }
        public void passProof(string yesno)
        {
            switch (yesno)
            {
                case "Yes":
                    cbPicture.Checked = true;
                    break;
                default:
                    cbPicture.Checked = false;
                    break;
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

        private void LeavesM_Load(object sender, EventArgs e)
        {
            LoadLeaveCategoryData();
        }
    }
}
