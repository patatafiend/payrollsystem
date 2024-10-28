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
	public partial class employeeLeaves : Form
	{
		Methods m = new Methods();

		private string loggedInDepartment;
		public employeeLeaves()
		{
			InitializeComponent();
		}

		

		private void departmentList_Load_1(object sender, EventArgs e)
		{
			availableLeaves();
		}

		

		private void btn_back(object sender, EventArgs e)
		{
			this.Close();
		}

		private void availableLeaves()
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();

				// Get the list of columns from the LeaveTypeAvailable table, except the "Id" column
				DataTable schemaTable = conn.GetSchema("Columns", new string[] { null, null, "LeaveTypeAvailable", null });
				List<string> columns = new List<string>();

				foreach (DataRow row in schemaTable.Rows)
				{
					string columnName = row["COLUMN_NAME"].ToString();
					if (columnName != "Id")
					{
						columns.Add($"[{columnName}]");
					}
				}

				// Join the column names into a comma-separated string
				string columnList = string.Join(", ", columns);

				// Create the SQL query dynamically
				string query = $"SELECT {columnList} FROM LeaveTypeAvailable";

				SqlCommand cmd = new SqlCommand(query, conn);

				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				dgv_empLeaves.DataSource = dt;
			}
		}



	}
}
