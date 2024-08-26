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

namespace payrollsystemsti.AdminTabs
{
    public partial class Transfer : Form
    {
        Methods m = new Methods();
        public static Transfer trans;
        int departmentID;
        public Transfer()
        {
            InitializeComponent();
            trans = this;
        }

        public int DepartmentID
        {
            get
            {
                return departmentID;
            }
            set
            {
                departmentID = value;
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            tbDepartment.Text = m.getDepartmentName(departmentID);
        }

        private void LoadDepartments()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentName FROM Departments WHERE IsDeactivated = @status AND DepartmentID != @depID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Parameters.AddWithValue("@depID", departmentID);

                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        cbDepartments.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string departmentName = row[0].ToString();
                            cbDepartments.Items.Add(departmentName);
                        }
                    }
                }
            }
        }

        private bool TransferDepartment()
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE EmployeeAccounts SET DepartmentID = @id WHERE DepartmentID = @departmentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    cmd.Parameters.AddWithValue("@id", m.GetDepartmentID(cbDepartments.Text));

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error updating Departmnet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void cbDepartments_TextChanged(object sender, EventArgs e)
        {
            if(cbDepartments.Text.Length > 0)
            {
                btnTransfer.Enabled = true;
            }
            else
            {
                btnTransfer.Enabled = false;
            }
        }

        private void Cancel()
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (TransferDepartment())
            {
                MessageBox.Show("Employees Successfuly transfered!");
            }
        }
    }
}
