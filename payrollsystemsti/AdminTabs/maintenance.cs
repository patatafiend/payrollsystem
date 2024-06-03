using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.Tabs
{
    public partial class maintenance : Form
    {

        Methods m = new Methods();
        int titleID = 0;

        public maintenance()
        {
            InitializeComponent();
        }

        private void ClearData()
        {
            tb1.Clear();
            tb2.Clear();
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
        }

        //first load of form, it focuses on Name txtbox
        private void manageEmployee_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbMaintenance;
            btnDeactivate.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
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

        private void LoadDeductionData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM Deductions WHERE IsDeactivated = 0";
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
                    }
                }
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!m.ifDepartmentNameExist(tb1.Text.ToString()) && !m.ifRoleTitleExist(tb1.Text.ToString()) && !m.ifPositionTitleExist(tb1.Text.ToString()))
            {
                switch (cbMaintenance.Text.ToString())
                {
                    case "Departments":
                        m.insertToDepartments(tb1.Text);
                        LoadDepartmentData();
                        break;
                    case "Positions":
                        m.insertToPositions(tb1.Text);
                        LoadPositionData();
                        break;
                    case "Roles":
                        m.insertToRoles(tb1.Text);
                        LoadRoleData();
                        break;
                    case "Leaves":
                        m.insertToLeaves(tb1.Text, checkBox());
                        LoadLeaveCategoryData();
                        break;
                    case "Deductions":
                        m.insertToDeductions(tb1.Text, Convert.ToInt32(tb2.Text));
                        tbClear();
                        LoadDeductionData();
                        break;
                }
            }
            else if (m.ifDepartmentNameExist(tb1.Text.ToString()) || m.ifRoleTitleExist(tb1.Text.ToString()) || m.ifPositionTitleExist(tb1.Text.ToString()))
            {
                MessageBox.Show("Title already exists");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
            tb1.Clear();
        }

        public void tbClear()
        {
            tb2.Clear();
            tb3.Clear();
            tb4.Clear();
            tb5.Clear();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!m.ifDepartmentNameExist(tb1.Text.ToString()) && !m.ifRoleTitleExist(tb1.Text.ToString()) && !m.ifPositionTitleExist(tb1.Text.ToString()))
                {
                    switch (cbMaintenance.Text.ToString())
                    {
                        case "Departments":
                            m.updateDepartments(tb1.Text, titleID);
                            LoadDepartmentData();
                            break;
                        case "Postions":
                            m.updatePositions(tb1.Text, titleID);
                            LoadPositionData();
                            break;
                        case "Roles":
                            m.updateRoles(tb1.Text, titleID);
                            LoadRoleData();
                            break;
                        case "Leaves":
                            m.updateLeaves(tb1.Text, checkBox(), titleID);
                            LoadLeaveCategoryData();
                            break;
                        case "Deductions":
                            m.updateDeductions(tb1.Text, Convert.ToInt32(tb2.Text), titleID);
                            tb2.Clear();
                            LoadDeductionData();
                            break;
                        case "Allowances":
                            m.updateAllowance(Convert.ToInt32(tb1.Text), Convert.ToInt32(tb2.Text), Convert.ToInt32(tb3.Text), 
                                Convert.ToInt32(tb4.Text), Convert.ToInt32(tb5.Text), titleID);
                            tbClear();
                            LoadAllowanceData();
                            break;
                    }
                }
                else if (m.ifDepartmentNameExist(tb1.Text.ToString()) || m.ifRoleTitleExist(tb1.Text.ToString()) || m.ifPositionTitleExist(tb1.Text.ToString()))
                {
                    MessageBox.Show("Title already exists");
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
            tb1.Clear();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ClearData();
            btnUpdate.Enabled = false;
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    switch (cbMaintenance.Text.ToString())
                    {
                        case "Departments":
                            m.deactivateDepartment(titleID);
                            LoadDepartmentData();
                            break;
                        case "Positions":
                            m.deactivatePosition(titleID);
                            LoadPositionData();
                            break;
                        case "Roles":
                            m.deactivateRole(titleID);
                            LoadRoleData();
                            break;
                        case "Leaves":
                            m.deactivateLeave(titleID);
                            LoadLeaveCategoryData();
                            break;
                        case "Deductions":
                            m.deactivateDeduction(titleID);
                            LoadLeaveCategoryData();
                            break;
                        case "Allowances":
                            m.deactivateDeduction(titleID);
                            LoadAllowanceData();
                            break;
                    }
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
            tb1.Clear();
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
            if (yesno == "True")
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            switch(cbMaintenance.Text)
            {
                case "Deductions":
                    titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
                    tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
                    tb2.Text = dataGridView1.SelectedRows[0].Cells["dg3rd"].Value.ToString();
                    break;
                case "Allowances":
                    titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());

                    tb1.Text = dataGridView1.SelectedRows[0].Cells["dg3rd"].Value.ToString();
                    tb2.Text = dataGridView1.SelectedRows[0].Cells["dg4th"].Value.ToString();
                    tb3.Text = dataGridView1.SelectedRows[0].Cells["dg5th"].Value.ToString();
                    tb4.Text = dataGridView1.SelectedRows[0].Cells["dg6th"].Value.ToString();
                    tb5.Text = dataGridView1.SelectedRows[0].Cells["dg7th"].Value.ToString();
                    break;
                default:
                    titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
                    tb1.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
                    break;
            }
            
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if(tb1.Text.Length > 2 && cbMaintenance.SelectedIndex != -1 && !btnUpdate.Enabled)
            {
                btnAdd.Enabled = true;
            }
            else if(tb1.Text.Length <= 0)
            {
                btnAdd.Enabled = false;
            }
        }

        private void cbMaintenance_SelectedValueChanged(object sender, EventArgs e)
        {
            firstInterface();
            switch (cbMaintenance.Text.ToString())
            {
                case "Departments":
                    changeToDepartment();
                    LoadDepartmentData();
                    break;
                case "Positions":
                    changeToPositon();
                    LoadPositionData();
                    break;
                case "Roles":
                    changeToRole();
                    LoadRoleData();
                    break;
                case "Leaves":
                    changeToLeaves();
                    LoadLeaveCategoryData();
                    break;
                case "Deductions":
                    changeToDeductions();
                    LoadDeductionData();
                    break;
                case "Allowances":
                    changeToAllowances();
                    LoadAllowanceData();
                    break;
            }
        }

        public void changeToDepartment()
        {
            dataGridView1.Columns["dg2nd"].HeaderText = "Department Name";
        }
        public void changeToPositon()
        {
            dataGridView1.Columns["dg2nd"].HeaderText = "Position Title";
        }
        public void changeToRole()
        {
            dataGridView1.Columns["dg2nd"].HeaderText = "Role Title";
        }
        public void changeToLeaves()
        {
            dataGridView1.Columns["dg2nd"].HeaderText = "Leave Type";
            dataGridView1.Columns["dg3rd"].Visible = true;
        }
        public void changeToDeductions()
        {
            tb2.Visible = true;

            lb2.Text = "Amount";
            lb2.Visible = true;

            dataGridView1.Columns["dg2nd"].HeaderText = "Deduction Type";
            dataGridView1.Columns["dg3rd"].HeaderText = "Amount";

            dataGridView1.Columns["dg3rd"].Visible = true;
        }
        public void changeToAllowances()
        {
            tb2.Visible = true;
            tb3.Visible = true;
            tb4.Visible = true;
            tb5.Visible = true;

            lb1.Text = "Training";
            lb2.Text = "Transportation";
            lb3.Text = "Load";
            lb4.Text = "Provision";
            lb5.Text = "OB";

            lb2.Visible = true;
            lb3.Visible = true;
            lb4.Visible = true;
            lb5.Visible = true;

            dataGridView1.Columns["dg2nd"].HeaderText = "Employee Name";
            dataGridView1.Columns["dg3rd"].HeaderText = "TrainingA";
            dataGridView1.Columns["dg4th"].HeaderText = "TransportationA";
            dataGridView1.Columns["dg5th"].HeaderText = "LoadA";
            dataGridView1.Columns["dg6th"].HeaderText = "ProvisionTA";
            dataGridView1.Columns["dg7th"].HeaderText = "OBA";

            dataGridView1.Columns["dg3rd"].Visible = true;
            dataGridView1.Columns["dg4th"].Visible = true;
            dataGridView1.Columns["dg5th"].Visible = true;
            dataGridView1.Columns["dg6th"].Visible = true;
            dataGridView1.Columns["dg7th"].Visible = true;
        }

        public void firstInterface()
        {
            tb2.Visible = false;
            tb3.Visible = false;
            tb4.Visible = false;
            tb5.Visible = false;

            lb1.Text = "Title";
            lb2.Visible = false;
            lb3.Visible = false;
            lb4.Visible = false;
            lb5.Visible = false;

            dataGridView1.Columns["dg1st"].HeaderText = "ID";
            dataGridView1.Columns["dg2nd"].HeaderText = "Title";
            dataGridView1.Columns["dg3rd"].HeaderText = "Picture Required";
            dataGridView1.Columns["dg3rd"].Visible = false;
            dataGridView1.Columns["dg4th"].Visible = false;
            dataGridView1.Columns["dg5th"].Visible = false;
            dataGridView1.Columns["dg6th"].Visible = false;
            dataGridView1.Columns["dg7th"].Visible = false;
            cbPicture.Visible = false;
        }

        private void btnUpdate_EnabledChanged_1(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled; 
        }
    }
}