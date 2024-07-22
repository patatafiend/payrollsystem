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

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		

		private void HistoryLogForm_Load_1(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			using (SqlConnection sqlCon = new SqlConnection(m.connStr))
			{
				sqlCon.Open();
				SqlDataAdapter sqlDa = new SqlDataAdapter("Select * FROM HistoryTable", sqlCon);
				DataTable dtbl = new DataTable();

				sqlDa.Fill(dtbl);

				dgv_HistoryLog.AutoGenerateColumns = false;
				dgv_HistoryLog.DataSource = dtbl;
			}
		}

		
	}
}
