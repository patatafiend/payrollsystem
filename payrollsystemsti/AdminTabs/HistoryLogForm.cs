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
	public partial class HistoryLogForm : Form
	{
		Methods m = new Methods();
		public HistoryLogForm()
		{
			InitializeComponent();
		}

		
		private void HistoryLogForm_Load(object sender, EventArgs e)
		{
            // TODO: This line of code loads data into the 'stipayrolldbDataSet8.HistoryTable' table. You can move, or remove it, as needed.
            this.historyTableTableAdapter2.Fill(this.stipayrolldbDataSet8.HistoryTable);
            
            SqlConnection con = new SqlConnection(m.connStr);
			con.Open();
			SqlCommand cmd = new SqlCommand("SELECT * FROM HistoryTable ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			dgv_HistoryLog.DataSource = dt;
			con.Close();
			
        }

		private void btnSearch_Click(object sender, EventArgs e)
		{
			// Get the selected value from the combo box
			string selectedValue = cb_HistoryLog.SelectedItem.ToString();

			// Extract the part after the comma
			string searchValue = selectedValue.Split(',')[0].Trim();

			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				conn.Open();
				// Query to search for matching results in the HistoryFrom column
				string query = "SELECT * FROM HistoryTable WHERE HistoryFrom LIKE @SearchValue";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

					// Execute the query and fill the DataTable
					DataTable dt = new DataTable();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(dt);

					// Bind the DataTable to a DataGridView or any other control to display the results
					dgv_HistoryLog.DataSource = dt;
				}
			}



		}

	}
}
