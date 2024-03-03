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
                if(tbUser.Text.Length > 0)
                {
                    tbPassword.Focus();
                }
                else
                {
                    tbUser.Focus();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbPassword.Text.Length > 0)
                {
                    tbNewPass.Focus();
                }
                else
                {
                    tbPassword.Focus();
                }
            }
        }

        private void txtNpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbNewPass.Text.Length > 0)
                {
                    tbConfirmPass.Focus();
                }
                else
                {
                    tbNewPass.Focus();
                }
            }
        }

        private void txtCpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbConfirmPass.Text.Length > 0)
                {
                    btnConfirm.Focus();
                }
                else
                {
                    tbConfirmPass.Focus();
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
                
                con.DataGet("SELECT 1 FROM Users WHERE Username = '"+tbUser.Text+"' and Password = '"+tbPassword.Text+"'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                if(dt.Rows.Count > 0) {
                    if(tbNewPass.Text == tbConfirmPass.Text)
                    {
                        if(tbNewPass.Text.Length > 3)
                        {
                            con.DataSend("UPDATE Users SET Password = '"+tbNewPass.Text+"' " +
                                "WHERE Username = '"+tbUser.Text+"' and" +
                                " Password = '"+tbPassword.Text+"'");
                            MessageBox.Show("Password Changed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        }
                        else
                        {
                            errorProvider1.SetError(tbNewPass, "Please enter minimum 4 Character Password");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(tbNewPass, "Password dont Match");
                        errorProvider1.SetError(tbConfirmPass, "Password dont Match");
                    }
                }
                else
                {
                    errorProvider1.SetError(tbUser, "Wrong Username or Password");
                    errorProvider1.SetError(tbPassword, "Wrong Username or Password");
                }
            }
        }
    }
}
