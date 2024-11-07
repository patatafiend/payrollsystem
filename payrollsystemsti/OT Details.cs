using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class OT_Details : Form
    {
        public static OT_Details ot;
        Methods m = new Methods();
        CultureInfo ci = new CultureInfo("en-US");
        public OT_Details()
        {
            InitializeComponent();
            ot = this;
        }
        private int empID;
        private string date;
        public int employeeID
        {
            set
            {
                empID = value;
            }
            get
            {
                return empID;
            }
        }

        public string AppDate
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }
        private void OT_Details_Load(object sender, EventArgs e)
        {
            int depID = Convert.ToInt32(m.GetEmpDepartmentID(empID));
            int position = Convert.ToInt32(m.GetEmpPositionID(empID));
            lbFullName.Text = m.GetEmpName(empID);
            lbEmpID.Text = empID.ToString();
            lbDepartment.Text = m.getDepartmentName(depID);
            lbPosition.Text = m.getPositionTitle(position);
            lbReason.Text = GetReason(empID, date);
            lbAD.Text = GetAppliedDate(empID, date);
            lbDate.Text = date;
            lbFrom.Text = GetFormattedTime(GetFrom(empID, date));
            lbTo.Text = GetFormattedTime(GetTo(empID, date));
            pbProfile.Image = m.ConvertToImage(m.GetEmpPicture(empID));

        }

        public string GetFormattedTime(string militaryTime)
        {
            if (string.IsNullOrEmpty(militaryTime))
            {
                return string.Empty;
            }

            DateTime time = DateTime.ParseExact(militaryTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            return time.ToString("hh:mm tt");
        }

        public string GetReason(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT Justification FROM OvertimeApplications WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            return reader["Justification"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        public string GetFrom(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT StartTime FROM OvertimeApplications WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            return reader["StartTime"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }
        public string GetTo(int empID, string date)
        {
            
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT EndTime FROM OvertimeApplications WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            return reader["EndTime"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        public string GetAppliedDate(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT AppliedDate FROM OvertimeApplications WHERE EmployeeID = @empID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            return Convert.ToDateTime(reader["AppliedDate"]).ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            return " ";
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
