using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti.AdminTabs
{
    public partial class overtimeApplication : Form
    {
		Methods m = new Methods();
		public overtimeApplication()
        {
            InitializeComponent();
        }

		private void btnSubmit_Click(object sender, EventArgs e)
		{
            TimeSpan datetimestart = time.Value.TimeOfDay;
            TimeSpan datetimeout = timeout.Value.TimeOfDay;


            if (string.IsNullOrEmpty(tbReason.Text))
			{
				MessageBox.Show("Please enter a reason for your overtime application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				
				m.Add_Overtimepay(Methods.CurrentUser.UserID, datetimestart, datetimeout, tbReason.Text, DateTime.Now);
				MessageBox.Show("Overtime application submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			
		}
	}
}
