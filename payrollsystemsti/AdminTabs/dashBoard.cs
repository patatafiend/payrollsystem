using payrollsystemsti.AdminTabs;
using payrollsystemsti.EmployeeTabs;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

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
		private employeeLeaves employeeLeaves;

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
			lbGetDepartment = lb_curDepartment_name;
			lbEmpID = lbEmployeeID;
			lbLeaves = lb_Total_Leaves;
			lbAbsents = lb_absents_num;
			lbPanelName1 = lb_TotalLeaves;
			lbPhone = lb_EmpPhoNum;
			lbEmail = lb_EmpEmail;
			lbposition = lb_EmpPosition;
			lbEmpName = lb_EmpName;

			
		}

		private void dashBoard_Load(object sender, EventArgs e)
		{
			findCurrentUserNotifications();

			lb_EmpPhoNum.Text = "Phone No.: "+ Methods.CurrentUser.EmployeeNumber.ToString();
			lb_EmpEmail.Text = "Email address: " + Methods.CurrentUser.EmailAddress.ToString();
			lbEmployeeID.Text = "EmployeeID: " + Methods.CurrentUser.EmployeeID.ToString();
			lb_EmpPosition.Text = "Position: " + Methods.CurrentUser.employeePosition.ToString();
			lb_totalEmployee_num.Text = m.GetTotalEmployeeCount().ToString();
			lb_Total_Leaves.Text = m.getTotalCurrentAvailableLeaves(Methods.CurrentUser.EmployeeID).ToString();
			lb_roles_name.Text = getUserRole(Methods.CurrentUser.EmployeeRole);



		}
		private void InitializeEventHandlers()
		{
			
		}

		private void Pnl_leave_Click(object sender, EventArgs e) //Leave Application
		{
			leaveApplication = new leaveApplication();
			leaveApplication.ShowDialog();
		}

		

		private void DepartmentList_FormClosed(object sender, FormClosedEventArgs e)
		{
			DepartmentList = null;
		}

		//notification panel
		private void pnl_notification_DoubleClick(object sender, EventArgs e)
		{

			MessageBox.Show("Double Clicked notification");

		}

		//roles panel
		private void pnl_roles_DoubleClick(object sender, EventArgs e)
		{

			manageRoles roles = new manageRoles();
			roles.Show();
		}
		//department panel
		private void pnl_Department_DoubleClick(object sender, EventArgs e)
		{
			departmentList departmentList = new departmentList();
			departmentList.Show();
		}

		//employee panel
		private void pnl_totalEmployee_DoubleClick(object sender, EventArgs e)
		{
			employeeList employeeList = new employeeList();
			employeeList.Show();
		}

		//absent panel
		private void pnl_totalAbsent_DoubleClick(object sender, EventArgs e)
		{
			MessageBox.Show("Double Clicked absent");
		}

		//leave panel
		private void pnl_totalLeaves_DoubleClick(object sender, EventArgs e)
		{
			employeeLeaves employeeLeaves = new employeeLeaves();
			employeeLeaves.Show();
		}


		//total notification current user
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

		private string getUserRole(int userrole)
		{
			string role = "";
			using (SqlConnection conn = new SqlConnection(m.connStr))
			{
				try
				{
					conn.Open();
					string query = "SELECT RoleTitle FROM Roles WHERE RoleID = @userrole";
					SqlCommand cmd = new SqlCommand(query, conn);
					cmd.Parameters.AddWithValue("@userrole", userrole);

					SqlDataReader reader = cmd.ExecuteReader();

					if (reader.Read())
					{
						role = reader["RoleTitle"].ToString();
					}
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

			return role;
		}

		
	}
}
