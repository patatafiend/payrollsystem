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
    public partial class PayPeriod : Form
    {
        Methods m = new Methods();
        public PayPeriod()
        {
            InitializeComponent();
        }

        private void PayPeriod_Load(object sender, EventArgs e)
        {
            lb1st.Text = m.GetPayStart().ToString();
            lb2nd.Text = m.GetPayEnd().ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb1.Text) && rb1.Checked)
            {
                if(!(Convert.ToInt32(tb1.Text) == 0) || !(Convert.ToInt32(tb1.Text) > 31))
                {
                    if (Convert.ToInt32(tb1.Text) < m.GetPayEnd())
                    {
                        UpdateFirst(Convert.ToInt32(tb1.Text));
                        MessageBox.Show("period updated");
                        lb1st.Text = m.GetPayStart().ToString();
                    }
                    else
                    {
                        MessageBox.Show("1st cut off should be less than 2nd cut off");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
                
            }

            if (!string.IsNullOrEmpty(tb1.Text) && rb2.Checked)
            {
                if (!(Convert.ToInt32(tb1.Text) == 0) || !(Convert.ToInt32(tb1.Text) > 31))
                {
                    if (Convert.ToInt32(tb1.Text) > m.GetPayStart())
                    {
                        UpdateSecond(Convert.ToInt32(tb1.Text));
                        MessageBox.Show("period updated");
                        lb2nd.Text = m.GetPayEnd().ToString();
                    }
                    else
                    {
                        MessageBox.Show("2nd cut off should be greater than 1st cut off");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        public bool UpdateFirst(int num)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE PayDefault SET PayStart = @start";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@start", num);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception appropriately
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateSecond(int num)
        {
            using (SqlConnection conn = new SqlConnection(m.connStr))
            {
                conn.Open();
                string query = "UPDATE PayDefault SET PayEnd = @end";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@end", num);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception appropriately
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        private void tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
