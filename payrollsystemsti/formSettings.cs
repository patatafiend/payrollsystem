using payrollsystemsti.Properties;
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
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }

        changePass changeForm;

        private void changePassword_Click(object sender, EventArgs e)
        {
            if(changeForm == null)
            {
                changePass changeForm = new changePass();
                changeForm.FormClosed += Changepass_FormClosed;
                changeForm.Dock = DockStyle.Fill;
                changeForm.Show();
            }
            else
            {
                changeForm.Activate();
            }
            
        }

        private void Changepass_FormClosed(object sender, FormClosedEventArgs e)
        {
            changeForm = null;
        }

        private void formSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
