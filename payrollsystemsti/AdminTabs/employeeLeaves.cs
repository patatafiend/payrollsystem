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
			if(checkifAdmin())
			{
				availableLeavesAdmin();
			}
			else
			{
				availableLeaveUser();
			}
			
			
		}

		

		private void btn_back(object sender, EventArgs e)
		{
			this.Close();
		}

		//all employees leaves
		private void availableLeavesAdmin()
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

		//available leaves for the current user
		private void availableLeaveUser()
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				// Show leave for only the logged-in user
				string query = "SELECT * FROM LeaveTypeAvailable WHERE [Employee ID] = @UserID";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@UserID", Methods.CurrentUser.EmployeeID);

				// Execute the query and fill the DataTable
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				// Bind the DataTable to the DataGridView
				dgv_empLeaves.DataSource = dt;

			}
		}

		private Boolean checkifAdmin()
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				// Query to get the RoleID of the current user from EmployeeAccounts
				string query = "SELECT RoleID FROM EmployeeAccounts WHERE EmployeeID = @EmployeeID";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@EmployeeID", Methods.CurrentUser.EmployeeID);
					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.Read())
					{
						int userRoleID = reader["RoleID"] != DBNull.Value ? (int)reader["RoleID"] : -1;
						reader.Close();

						// Query to check if the RoleID matches in the Roles table
						string roleQuery = "SELECT Maintenance FROM Roles WHERE RoleID = @RoleID";
						using (SqlCommand roleCmd = new SqlCommand(roleQuery, conn))
						{
							roleCmd.Parameters.AddWithValue("@RoleID", userRoleID);
							SqlDataReader roleReader = roleCmd.ExecuteReader();
							if (roleReader.Read())
							{
								// Check if the Maintenance role is true
								return roleReader["Maintenance"] != DBNull.Value && (bool)roleReader["Maintenance"];
							}
						}
					}
				}
			}
			return false;
		}
	}

}
