using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using payrollsystemsti.AdminTabs;

namespace payrollsystemsti
{
    public partial class formSettings : Form
    {
        private formSettings form;
        private Profile Profile;


        public formSettings()
        {
            InitializeComponent();
        }

        changePass changeForm;

        private void changePassword_Click(object sender, EventArgs e)
        {
            if (changeForm == null)
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



        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            // Show employee salary form or activate if already open
            if (Profile == null)
            {
                Profile = new Profile();
                Profile.FormClosed += Profile_FormClosed;
                Profile.Dock = DockStyle.Fill;
                Profile.Show();
            }
            else
            {
                Profile.Activate();
            }


        }
        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Profile = null;
        }
       
    }
}

