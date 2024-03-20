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
    public partial class leaveDetails : Form
    {
        public static leaveDetails ld;
        public leaveDetails()
        {
            InitializeComponent();
            ld = this;
        }
        private int empID;
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

        private void leaveDetails_Load(object sender, EventArgs e)
        {

        }
        private void ShowData()
        {
            //string query = "SELECT";
        }
    }
}
