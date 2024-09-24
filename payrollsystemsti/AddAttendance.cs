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

namespace payrollsystemsti
{
    public partial class AddAttendance : Form
    {
        Methods m = new Methods();
        public AddAttendance()
        {
            InitializeComponent();
        }

        private bool InsertAttendance(int empID, int fingerID, int hoursW, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "INSERT INTO Attedance(EmployeeID, FingerID, TotalHours, Date) VALUES (@empID, @fingerID, @totalH, @date)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@totalH", hoursW);
                    cmd.Parameters.AddWithValue("@date", date);


                    try
                    {
                       int result =  cmd.ExecuteNonQuery();
                       return result > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                        return false;
                    }
                }
            }
        }
    }
}
