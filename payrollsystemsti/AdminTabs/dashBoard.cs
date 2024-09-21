using payrollsystemsti.AdminTabs;
using payrollsystemsti.EmployeeTabs;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

namespace payrollsystemsti
{
	public partial class dashBoard : Form
	{

		List<Control> panels;
		List<Control> buttons;
		List<Control> textboxes;
		List<Control> label;

		Methods m = new Methods();


		private leaveApplication leaveApplication;
		private departmentList DepartmentList;
		public static dashBoard dashboardInstance;
		public PictureBox pbGetImageUser;
		public Label lbGetName;
		public Label lbGetDepartment;
		public Label lbEmpID;
		public Label lbLeaves;
		public Label lbAbsents;
		public Label lbPanelName1;
		public Label lbPhone;
		public Label lbEmail;
		public Label lbposition;
		public Label lbEmpName;

		public static Boolean isClickable;
		private Color gradientBottomColor;
		private Color gradientAngle;

		public PointF GradientTopColor { get; private set; }

		public dashBoard()
		{
			InitializeComponent();
			InitializeEventHandlers();
			dashboardInstance = this;
			pbGetImageUser = pbCurrentUser;
			lbGetName = lbWelcome;
			lbGetDepartment = lb_curDepartment;
			lbEmpID = lbEmployeeID;
			lbLeaves = lb_Total_Leaves;
			lbAbsents = lb_absents;
			lbPanelName1 = lb_TotalLeaves;
			lbPhone = lb_EmpPhoNum;
			lbEmail = lb_EmpEmail;
			lbposition = lb_EmpPosition;
			lbEmpName = lb_EmpName;

		}

		private void dashBoard_Load(object sender, EventArgs e)
		{
			findCurrentUserNotifications();
		}

		public Panel GetEmployeePanel()
		{
			return pnl_Employee;
		}

		public Label GetEmployeeLabel()
		{
			return lb_Total_Leaves;
		}

		public Label GetTotalLabel()
		{
			return lb_TotalLeaves;
		}

		private void InitializeEventHandlers()
		{
			pnl_Employee.Click += Pnl_Employee_Click;
			pnl_Department.Click += Pnl_Department_Click;
		}

		private void Pnl_leave_Click(object sender, EventArgs e) //Leave Application
		{
			leaveApplication = new leaveApplication();
			leaveApplication.ShowDialog();
		}

		//employee list
		private void Pnl_Employee_Click(object sender, EventArgs e)
		{

			//if (isClickable)
			//{
			//	var employeeListForm = formDashboard.Instance.PnlContainer.Controls.OfType<employeeList>().FirstOrDefault();

			//	if (employeeListForm == null)
			//	{
			//		employeeListForm = new employeeList()
			//		{
			//			Dock = DockStyle.Fill,
			//			Name = "employeeList",
			//			TopLevel = false,

			//		};
			//		formDashboard.Instance.PnlContainer.Controls.Add(employeeListForm);
			//		employeeListForm.Show();
			//	}

			//	employeeListForm.BringToFront();
			//}
		}

		//department list

		private void Pnl_Department_Click(object sender, EventArgs e)
		{
			//if (isClickable)
			//{
			//	var departmentListForm = formDashboard.Instance.PnlContainer.Controls.OfType<departmentList>().FirstOrDefault();

			//	if (departmentListForm == null)
			//	{
			//		departmentListForm = new departmentList()
			//		{
			//			Dock = DockStyle.Fill,
			//			Name = "departmentList",
			//			TopLevel = false,

			//		};
			//		formDashboard.Instance.PnlContainer.Controls.Add(departmentListForm);
			//		departmentListForm.Show();
			//	}

			//	departmentListForm.BringToFront();
			//}
		}

		private void DepartmentList_FormClosed(object sender, FormClosedEventArgs e)
		{
			DepartmentList = null;
		}

		private void findCurrentUserNotifications()
		{
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				try
				{
					conn.Open();
					string query = "SELECT NotificationID, NotificationMessage, Date FROM Notifications WHERE EmployeeID = @EmployeeID";
					SqlCommand cmd = new SqlCommand(query, conn);
					cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(Methods.CurrentUser.EmployeeID));

					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					DataTable notificationsTable = new DataTable();
					adapter.Fill(notificationsTable);

					//load data
					dgv_Mdashboardnotif.DataSource = notificationsTable;

					//update the notification number
					lb_notification_num.Text = notificationsTable.Rows.Count.ToString();


					lb_notification_num.Text = notificationsTable.Rows.Count.ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred: " + ex.Message);
				}
				finally
				{
					conn.Close();
				}
			}
		}
	}
}

