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
    public partial class Deduction : Form
    {

        Methods m = new Methods();
        int titleID = 0;
        public Deduction()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Insert();
        }

        public void insertDeductionC()
        {
            if (!m.ifDeductionExist(tb1.Text.ToString()))
            {
                m.insertToDeductions(tb1.Text, Convert.ToInt32(tb2.Text), cbPeriod.Text);
                m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Deduction Add");
                LoadContributionData();
                tb1.Clear();
                tb2.Clear();
            }
            else if (m.ifDeductionExist(tb1.Text.ToString()))
            {
                MessageBox.Show("Deduction already exists");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
        }

        public void insertDeductionT()
        {
            if (!m.ifDeductionExist(tb1.Text.ToString()))
            {
                m.insertToDeductionsT(tb1.Text, Convert.ToInt32(tb2.Text), Convert.ToDecimal(tbAdd.Text));
                m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Deduction Add");
                LoadContributionData();
                tb1.Clear();
                tb2.Clear();
            }
            else if (m.ifDeductionExist(tb1.Text.ToString()))
            {
                MessageBox.Show("Deduction already exists");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
        }
        public void Insert()
        {
            switch (cbDeduct.Text)
            {
                case "Contributions":
                    insertDeductionC();
                    break;
                case "Tax":
                    insertDeductionT();
                    break;
                default:
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void Update()
        {
            switch (cbDeduct.Text)
            {
                case "Contributions":
                    updateDeductionC();
                    break;
                case "Tax":
                    updateDeductionT();
                    break;
                default:
                    break;
            }
        }

        public void updateDeductionC()
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("yes");
                m.updateDeductions(tb1.Text, Convert.ToInt32(tb2.Text), titleID, cbPeriod.Text);
                m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Deduction Edit");
                LoadContributionData();
                tb1.Clear();
                tb2.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        public void updateDeductionT()
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                m.updateDeductionsT(tb1.Text, Convert.ToInt32(tb2.Text), Convert.ToDecimal(tbAdd.Text), titleID);
                m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Deduction Edit");
                LoadContributionData();
                tb1.Clear();
                tb2.Clear();
                tbAdd.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    m.deactivateDeduction(titleID);
                    LoadContributionData();
                    tb1.Clear();
                    tb2.Clear();
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Deduction Deactivate");
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
            btnDeactivate.Enabled = true;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
            tb2.Text = dataGridView1.SelectedRows[0].Cells["dg3rd"].Value.ToString();
            if (cbDeduct.Text == "Tax")
            {
                tbAdd.Text = dataGridView1.SelectedRows[0].Cells["dgAdd"].Value.ToString();
            }
            
        }

        private void LoadContributionData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Deductions WHERE Additional IS NULL AND IsDeactivated = 0";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["DeductionID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["DeductionType"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["Amount"].ToString();
                        dataGridView1.Rows[n].Cells["dgPeriod"].Value = row["Period"].ToString();
                    }
                }
            }
        }

        private void LoadTaxData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Deductions WHERE Additional = 0 AND IsDeactivated = 0";
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
                        dataGridView1.Rows[n].Cells["dg1st"].Value = row["DeductionID"].ToString();
                        dataGridView1.Rows[n].Cells["dg2nd"].Value = row["DeductionType"].ToString();
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = row["Amount"].ToString();
                        dataGridView1.Rows[n].Cells["dgAdd"].Value = row["Additional"].ToString();
                    }
                }
            }
        }

        private void Deduction_Load(object sender, EventArgs e)
        {
            LoadContributionData();
            cbDeduct.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            tb1.Clear();
            tb2.Clear();
            tbAdd.Clear();
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

        private void btnLoan_Click(object sender, EventArgs e)
        {
            OpenLoanForm();
        }

        private void OpenLoanForm()
        {
            Loan loan = new Loan();
            loan.Show();
        }

        private void cbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDeduct.Text)
            {
                case "Contributions":
                    LoadContributionData();
                    interfaceOne();
                    break;
                case "Tax":
                    LoadTaxData();
                    interfaceTwo();
                    break;
                default:
                    LoadContributionData();
                    interfaceOne();
                    break;
            }
        }

        void interfaceOne()
        {
            tbAdd.Visible = false;
            lbAdd.Visible = false;
            lbPeriod.Visible = true;
            cbPeriod.Visible = true;
            dataGridView1.Columns["dgAdd"].Visible = false;
            dataGridView1.Columns["dgPeriod"].Visible = true;
        }
        void interfaceTwo()
        {
            tbAdd.Visible = true;
            lbAdd.Visible = true;
            lbPeriod.Visible = false;
            cbPeriod.Visible = false;
            dataGridView1.Columns["dgAdd"].Visible = true;
            dataGridView1.Columns["dgPeriod"].Visible = false;
        }
    }
}
