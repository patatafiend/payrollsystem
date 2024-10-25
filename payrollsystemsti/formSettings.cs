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
        public static formSettings fsettings;
        Methods m = new Methods();
        public formSettings()
        {
            InitializeComponent();
            fsettings = this;
        }

        private int loggedInID;

        changePass changeForm;

        public int LoggedInEmpID
        {
            set
            {
                loggedInID = value;
            }
            get
            {
                return loggedInID;
            }
        }

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

        private void FormSettings_Load(object sender, EventArgs e)
        {
            label5.Text = m.GetEmpName(loggedInID);
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
            profile11.Visible = true;
        }

        private void profile11_Load(object sender, EventArgs e)
        {
            profile11.Hide();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void profile11_VisibleChanged(object sender, EventArgs e)
        {
            label5.Visible = profile11.Visible;
            label6.Visible = profile11.Visible;
            label7.Visible = profile11.Visible;
            label8.Visible = profile11.Visible;
            label9.Visible = profile11.Visible;
            label10.Visible = profile11.Visible;
            label11.Visible = profile11.Visible;
            label12.Visible = profile11.Visible;
            label13.Visible = profile11.Visible;
        }
    }
}