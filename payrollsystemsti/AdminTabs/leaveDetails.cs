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
    public partial class LeaveDetails : Form
    {
        Methods m = new Methods();
        public static LeaveDetails ld;
        public LeaveDetails()
        {
            InitializeComponent();
            ld = this;
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

        private void leaveDetails_Load(object sender, EventArgs e)
        {
            int depID = Convert.ToInt32(m.GetEmpDepartmentID(empID));
            int position = Convert.ToInt32(m.GetEmpPositionID(empID));
            lbFullName.Text = m.GetEmpName(empID);
            lbEmpID.Text = empID.ToString();
            lbDepartment.Text = m.getDepartmentName(depID);
            lbPosition.Text = m.getPositionTitle(position);
            
            lbDateRange.Text = GetDateRange(empID, date);

            pbProfile.Image = m.ConvertToImage(m.GetEmpPicture(empID));
            pbProof.Image = m.ConvertToImage(GetEmpProof(empID));
        }

        public byte[] GetEmpProof(int empID)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();

                string query = "SELECT MedicalCert FROM LeaveApplications WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["MedicalCert"] != DBNull.Value)
                            {
                                return (byte[])reader["MedicalCert"];
                            }
                            else
                            {
                                return null; // No proof document found (or null stored)
                            }
                        }
                        else
                        {
                            return null; // No record found for the employee
                        }
                    }
                }
            }
        }
        public string GetDateRange(int empID, string date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "SELECT DateStart, DateEnd FROM LeaveApplications WHERE EmployeeID = @empID AND AppliedDate = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@date", date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            return "Starting From " + Convert.ToDateTime(reader["DateStart"]).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(reader["DateEnd"]).ToString("MM/dd/yyyy");
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
    }
}
