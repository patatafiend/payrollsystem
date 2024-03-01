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
    public partial class changePass : Form
    {
        public changePass()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        private void textUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtUser.Text.Length > 0)
                {
                    txtPass.Focus();
                }
                else
                {
                    txtUser.Focus();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPass.Text.Length > 0)
                {
                    txtNpass.Focus();
                }
                else
                {
                    txtPass.Focus();
                }
            }
        }

        private void txtNpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNpass.Text.Length > 0)
                {
                    txtCpass.Focus();
                }
                else
                {
                    txtNpass.Focus();
                }
            }
        }

        private void txtCpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCpass.Text.Length > 0)
                {
                    confirm.Focus();
                }
                else
                {
                    txtCpass.Focus();
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            DialogResult action = MessageBox.Show("Change Password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (action == DialogResult.Yes)
            {
                
                con.DataGet("SELECT 1 FROM Users WHERE Username = '"+txtUser.Text+"' and Password = '"+txtPass.Text+"'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                if(dt.Rows.Count > 0) {
                    if(txtNpass.Text == txtCpass.Text)
                    {
                        if(txtNpass.Text.Length > 3)
                        {
                            con.DataSend("UPDATE Users SET Password = '"+txtNpass.Text+"' " +
                                "WHERE Username = '"+txtUser.Text+"' and" +
                                " Password = '"+txtPass.Text+"'");
                            MessageBox.Show("Password Changed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        }
                        else
                        {
                            errorProvider1.SetError(txtNpass, "Please enter minimum 4 Character Password");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtNpass, "Password dont Match");
                        errorProvider1.SetError(txtCpass, "Password dont Match");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtUser, "Wrong Username or Password");
                    errorProvider1.SetError(txtPass, "Wrong Username or Password");
                }
            }
        }
    }
}
