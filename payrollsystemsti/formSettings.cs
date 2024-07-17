using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Drawing;

namespace payrollsystemsti
{
    public partial class formSettings : Form
    {

        List<Control> panels;
        List<Control> buttons;
        List<Control> textboxes;

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
            Initialize_Add();
            comboBox1.SelectedIndex = 0;

        }

        void Initialize_Add()
        {
            panels = new List<Control>();
            buttons = new List<Control>();
            textboxes = new List<Control>();

            panels.Add(panel1);

            buttons.Add(button1);

            textboxes.Add(textBox1);

        }

         void ApplyTheme(Color back, Color btn, Color pan,Color tbox, Color Combox, Color TextColor)
        {
            this.BackColor = back;
            comboBox1.BackColor = Combox;
            comboBox1.ForeColor = TextColor;

            foreach (Control item in panels)
            {
                item.BackColor = pan;
            }
            foreach (Control item in buttons)
            {
                item.BackColor = btn;
                item.ForeColor = TextColor;
            }
            foreach (Control item in textboxes)
            {
                item.BackColor = tbox;
                item.ForeColor = TextColor;
            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Light")
            {
                ApplyTheme(Color.White, zcolor(240, 240, 240), zcolor(181, 181, 181), zcolor(110, 110, 110), Color.White,Color.Black);
            }
            else if(comboBox1.Text == "Dark")
            {
                ApplyTheme(zcolor(30, 30, 30), zcolor(45, 45, 45), zcolor(104, 104, 104), zcolor(51, 51, 51), Color.Black, Color.White);
            }

        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

    }
}
