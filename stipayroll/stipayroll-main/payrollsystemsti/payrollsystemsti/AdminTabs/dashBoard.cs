using payrollsystemsti.EmployeeTabs;
using System.Windows.Forms;
using System;

namespace payrollsystemsti
{
	public partial class dashBoard : Form
	{
		private leaveApplication leaveApplication;
		public dashBoard()
		{
			InitializeComponent();
			InitializeEventHandlers();

		}

		private void InitializeEventHandlers()
		{
			pnl_Leave.Click += Pnl_leave_Click;
		}

		private void Pnl_leave_Click(object sender, EventArgs e)
		{
			
			leaveApplication = new leaveApplication();
			leaveApplication.ShowDialog();
		}	

		private void dashBoard_Load(object sender, System.EventArgs e)
		{

		}



		private void pnl_Employee_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}