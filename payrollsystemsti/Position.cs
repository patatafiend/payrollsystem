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
    public partial class Position : Form
    {
        Methods m = new Methods();
        int titleID = 0;
        public Position()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPosition();
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePostion();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DeactivatePositon();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
        }

        private void Position_Load(object sender, EventArgs e)
        {
            LoadPositionData();
        }

        private void LoadPositionData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Positions WHERE IsDeactivated = 0";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["PositionID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["PositionTitle"].ToString();
                    }
                }
            }
        }

        private void AddPosition()
        {
            if (!m.ifPositionTitleExist(tb1.Text.ToString()))
            {
                m.insertToPositions(tb1.Text);
                LoadPositionData();
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

        private void UpdatePostion()
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!m.ifPositionTitleExist(tb1.Text.ToString()))
                {
                    m.updatePositions(tb1.Text, titleID);
                    LoadPositionData();
                    tb1.Clear();
                }
                else if (m.ifPositionTitleExist(tb1.Text.ToString()))
                {
                    MessageBox.Show("Position already exists");
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

        private void DeactivatePositon()
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    m.deactivatePosition(titleID);
                    LoadPositionData();
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
    }
}
