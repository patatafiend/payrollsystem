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
	public partial class departmentList : Form
	{
		Methods m = new Methods();

		private string loggedInDepartment;
		public departmentList()
		{
			InitializeComponent();
		}

		private void btnExit_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}

		private void departmentList_Load_1(object sender, EventArgs e)
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

				dgv_DepartmentList.AutoGenerateColumns = false;
				dgv_DepartmentList.DataSource = dtbl;
			}
		}



	}
}
