using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace payrollsystemsti
{
	
	
	public partial class employeeList : Form
	{
		Methods m = new Methods();
		public employeeList()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void employeeList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

		private void LoadData()
		{
            using (SqlConnection sqlCon = new SqlConnection(m.connStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * FROM EmployeeAccounts", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dgv_EmployeeList.AutoGenerateColumns = false;
                dgv_EmployeeList.DataSource = dtbl;
            }
        }
    }
}
