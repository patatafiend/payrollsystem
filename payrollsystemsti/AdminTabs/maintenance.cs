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
            tbTitle.Clear();
            tbAmount.Clear();
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
                        dataGridView1.Rows[n].Cells["dg3rd"].Value = hasProof(row["Amount"].ToString());
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!m.ifDepartmentNameExist(tbTitle.Text.ToString()) && !m.ifRoleTitleExist(tbTitle.Text.ToString()) && !m.ifPositionTitleExist(tbTitle.Text.ToString()))
            {
                switch (cbMaintenance.Text.ToString())
                {
                    case "Departments":
                        m.insertToDepartments(tbTitle.Text);
                        LoadDepartmentData();
                        break;
                    case "Positions":
                        m.insertToPositions(tbTitle.Text);
                        LoadPositionData();
                        break;
                    case "Roles":
                        m.insertToRoles(tbTitle.Text);
                        LoadRoleData();
                        break;
                    case "Leaves":
                        m.insertToLeaves(tbTitle.Text, checkBox());
                        LoadLeaveCategoryData();
                        break;
                    case "Deductions":
                        m.insertToDeductions(tbTitle.Text, Convert.ToInt32(tbAmount.Text));
                        LoadDeductionData();
                        break;
                }
            }
            else if (m.ifDepartmentNameExist(tbTitle.Text.ToString()) || m.ifRoleTitleExist(tbTitle.Text.ToString()) || m.ifPositionTitleExist(tbTitle.Text.ToString()))
            {
                MessageBox.Show("Title already exists");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
            tbTitle.Clear();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deactivate this row?", "Deactivation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!m.ifDepartmentNameExist(tbTitle.Text.ToString()) && !m.ifRoleTitleExist(tbTitle.Text.ToString()) && !m.ifPositionTitleExist(tbTitle.Text.ToString()))
                {
                    switch (cbMaintenance.Text.ToString())
                    {
                        case "Departments":
                            updateDepartments(tbTitle.Text);
                            LoadDepartmentData();
                            break;
                        case "Postions":
                            updatePositions(tbTitle.Text);
                            LoadPositionData();
                            break;
                        case "Roles":
                            updateRoles(tbTitle.Text);
                            LoadRoleData();
                            break;
                        case "Leaves":
                            updateLeaves(tbTitle.Text, checkBox());
                            LoadLeaveCategoryData();
                            break;
                        case "Deductions":
                            updateDeductions(tbTitle.Text, Convert.ToInt32(tbAmount.Text));
                            LoadDeductionData();
                            break;
                    }
                }
                else if (m.ifDepartmentNameExist(tbTitle.Text.ToString()) || m.ifRoleTitleExist(tbTitle.Text.ToString()) || m.ifPositionTitleExist(tbTitle.Text.ToString()))
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
            tbTitle.Clear();
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
                            deactivateDepartment();
                            LoadDepartmentData();
                            break;
                        case "Positions":
                            deactivatePosition();
                            LoadPositionData();
                            break;
                        case "Roles":
                            deactivateRole();
                            LoadRoleData();
                            break;
                        case "Leaves":
                            deactivateLeave();
                            LoadLeaveCategoryData();
                            break;
                        case "Deductions":
                            deactivateDeduction();
                            LoadLeaveCategoryData();
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
            tbTitle.Clear();
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

        

        public bool updateDepartments(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Departments SET DepartmentName = @departmentName WHERE DepartmentID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@departmentName", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Departments: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool updatePositions(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Positions SET PositionTitle = @position WHERE PositionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@position", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Positions: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool updateRoles(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Roles SET RoleTitle = @role WHERE RoleID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@role", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Roles: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool updateLeaves(string title, bool hasProof)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE LeaveCategory SET CategoryName = @name, IsDeactivated = @status " +
                    "WHERE CategoryID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", title);
                    cmd.Parameters.AddWithValue("@status", hasProof);
                    cmd.Parameters.AddWithValue("@ID", titleID);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Leaves: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool updateDeductions(string title, int amount)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET DeductionType = @type WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@ID", titleID);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateRole()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Roles SET IsDeactivated = @status WHERE RoleID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Role: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateDepartment()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Departments SET IsDeactivated = @status WHERE DepartmentID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Department: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivatePosition()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Positions SET IsDeactivated = @status WHERE PositionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Position: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        
        public bool deactivateLeave()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE LeaveCategory SET IsDeactivated = @status WHERE CategoryID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Leave: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateDeduction()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET IsDeactivated = @status WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", titleID);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dg1st"].Value.ToString());
            tbTitle.Text = dataGridView1.SelectedRows[0].Cells["dg2nd"].Value.ToString();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if(tbTitle.Text.Length > 2 && cbMaintenance.SelectedIndex != -1 && !btnUpdate.Enabled)
            {
                btnAdd.Enabled = true;
            }
            else if(tbTitle.Text.Length <= 0)
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
            tbAmount.Visible = true;
            lbAmount.Visible = true;
            dataGridView1.Columns["dg2nd"].HeaderText = "Deduction Type";
            dataGridView1.Columns["dg3rd"].HeaderText = "Amount";
            dataGridView1.Columns["dg3rd"].Visible = true;
        }

        public void firstInterface()
        {
            tbAmount.Visible = false;
            lbAmount.Visible = false;
            dataGridView1.Columns["dg1st"].HeaderText = "ID";
            dataGridView1.Columns["dg2nd"].HeaderText = "Title";
            dataGridView1.Columns["dg3rd"].HeaderText = "Picture Required";
            dataGridView1.Columns["dg3rd"].Visible = false;
            cbPicture.Visible = false;
        }

        private void btnUpdate_EnabledChanged_1(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled; 
        }
    }
}