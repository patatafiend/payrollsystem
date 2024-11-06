using payrollsystemsti.AdminTabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class OvertimeManagement : Form
    {
        public OvertimeManagement()
        {
            InitializeComponent();
        }

        private void lbLM_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            OT_Details OTD = new OT_Details();         
            OTD.Show();
        }


    }
}
