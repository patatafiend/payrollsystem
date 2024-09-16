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
			SqlCommand cmd = new SqlCommand("SELECT * FROM HistoryTable WHERE HistoryFrom != 'Login'", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			dgv_HistoryLog.DataSource = dt;
			con.Close();
			
        }

		
	}
}
