using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace payrollsystemsti.Tabs
{
    public partial class manageEmployee : Form
    {

        Methods m = new Methods();
        int titleID = 0;

        public manageEmployee()
        {
            InitializeComponent();
        }

        private void ClearData()
        {
            cbMaintenance.SelectedIndex = -1;
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

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled;
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
                        dataGridView1.Rows[n].Cells["dgID"].Value = row["DepartmentID"].ToString();
                        dataGridView1.Rows[n].Cells["dgTitle"].Value = row["DepartmentName"].ToString();
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
                        dataGridView1.Rows[n].Cells["dgID"].Value = row["PositionID"].ToString();
                        dataGridView1.Rows[n].Cells["dgTitle"].Value = row["PositionTitle"].ToString();
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
                        dataGridView1.Rows[n].Cells["dgID"].Value = row["RoleID"].ToString();
                        dataGridView1.Rows[n].Cells["dgTitle"].Value = row["RoleTitle"].ToString();
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
                        dataGridView1.Rows[n].Cells["dgID"].Value = row["CategoryID"].ToString();
                        dataGridView1.Rows[n].Cells["dgTitle"].Value = row["CategoryName"].ToString();
                        dataGridView1.Rows[n].Cells["dgPicture"].Value = hasProof(row["hasProof"].ToString());
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ifDepartmentNameExist(tbTitle.Text.ToString()) && !ifRoleTitleExist(tbTitle.Text.ToString()) && !ifPositionTitleExist(tbTitle.Text.ToString()))
            {
                switch (cbMaintenance.Text.ToString())
                {
                    case "Departments":
                        insertToDepartments(tbTitle.Text);
                        LoadDepartmentData();
                        break;
                    case "Positions":
                        insertToPositions(tbTitle.Text);
                        LoadPositionData();
                        break;
                    case "Roles":
                        insertToRoles(tbTitle.Text);
                        LoadRoleData();
                        break;
                    case "Leaves":
                        insertToLeaves(tbTitle.Text, checkBox());
                        LoadLeaveCategoryData();
                        break;
                }
            }
            else if (ifDepartmentNameExist(tbTitle.Text.ToString()) || ifRoleTitleExist(tbTitle.Text.ToString()) || ifPositionTitleExist(tbTitle.Text.ToString()))
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
                if (!ifDepartmentNameExist(tbTitle.Text.ToString()) && !ifRoleTitleExist(tbTitle.Text.ToString()) && !ifPositionTitleExist(tbTitle.Text.ToString()))
                {
                    switch (cbMaintenance.Text.ToString())
                    {
                        case "Departments":
                            updateDepartments(tbTitle.Text.ToString());
                            LoadDepartmentData();
                            break;
                        case "Postions":
                            updatePositions(tbTitle.Text.ToString());
                            LoadPositionData();
                            break;
                        case "Roles":
                            updateRoles(tbTitle.Text.ToString());
                            LoadRoleData();
                            break;
                        case "Leaves":
                            LoadLeaveCategoryData();
                            break;
                    }
                }
                else if (ifDepartmentNameExist(tbTitle.Text.ToString()) || ifRoleTitleExist(tbTitle.Text.ToString()) || ifPositionTitleExist(tbTitle.Text.ToString()))
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

        public bool insertToDepartments(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Departments(DepartmentName) VALUES(@title)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Departments: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool insertToPositions(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Positions(PositionTitle) VALUES(@title)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Positions: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool insertToRoles(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Roles(RoleTitle) VALUES(@title)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Roles: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool insertToLeaves(string title, bool hasProof)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO LeaveCategory (CategoryName, hasProof) VALUES (@catname, @proof)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", title);
                    cmd.Parameters.AddWithValue("@proof", hasProof);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Leaves: " + ex.Message);
                        return false;
                    }
                }
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

        public bool updateLeaves(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE LeaveCategory SET CategoryName = @name WHERE CategoryID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", title);
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

        public bool ifRoleTitleExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Roles WHERE IsDeactivated = 0 AND RoleTitle = @role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@role", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        public bool ifDepartmentNameExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Departments WHERE IsDeactivated = 0 AND DepartmentName = @department";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@department", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        public bool ifPositionTitleExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Positions WHERE IsDeactivated = 0 AND PositionTitle = @position";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@position", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
            tbTitle.Text = dataGridView1.SelectedRows[0].Cells["dgTitle"].Value.ToString();
            titleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["dgID"].Value.ToString());
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
            hideLeaves();
            switch (cbMaintenance.Text.ToString())
            {
                case "Departments":
                    LoadDepartmentData();
                    break;
                case "Positions":
                    LoadPositionData();
                    break;
                case "Roles":
                    LoadRoleData();
                    break;
                case "Leaves":
                    LoadLeaveCategoryData();
                    changeToLeaves();
                    break;
            }
        }

        public void changeToLeaves()
        {
            cbPicture.Visible = true;
            dataGridView1.Columns["dgPicture"].Visible = true;
        }

        public void hideLeaves()
        {
            cbPicture.Visible = false;
            dataGridView1.Columns["dgPicture"].Visible = false;
        }


        private void btnUpdate_EnabledChanged_1(object sender, EventArgs e)
        {
            btnCancel.Visible = btnUpdate.Enabled; 
        }
    }
}