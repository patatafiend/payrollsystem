﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class changePass : Form
    {
        Methods m = new Methods();
        public changePass()
        {
            InitializeComponent();
        }
        
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
				using (SqlConnection sqlConn = new SqlConnection(m.connStr))
				{
					sqlConn.Open();

					using (SqlCommand cmd = new SqlCommand("SELECT 1 FROM UserAccounts WHERE Username = @username AND Password = @password", sqlConn))
					{
						cmd.Parameters.AddWithValue("@username", tbUser.Text);
						cmd.Parameters.AddWithValue("@password", tbPassword.Text);

						DataTable dt = new DataTable();
						using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
						{
							sda.Fill(dt);

							if (dt.Rows.Count > 0)
							{
								if (tbNewPass.Text == tbConfirmPass.Text)
								{
									if (tbNewPass.Text.Length > 3)
									{
										using (SqlCommand updateCmd = new SqlCommand("UPDATE UserAccounts SET Password = @newPassword WHERE Username = @username AND Password = @oldPassword", sqlConn))
										{
											updateCmd.Parameters.AddWithValue("@newPassword", tbNewPass.Text);
											updateCmd.Parameters.AddWithValue("@username", tbUser.Text);
											updateCmd.Parameters.AddWithValue("@oldPassword", tbPassword.Text);

											updateCmd.ExecuteNonQuery();

											MessageBox.Show("Password Changed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
										}
									}
									else
									{
										errorProvider1.SetError(tbNewPass, "Please enter a minimum 4-character password");
									}
								}
								else
								{
									errorProvider1.SetError(tbNewPass, "Passwords don't match");
									errorProvider1.SetError(tbConfirmPass, "Passwords don't match");
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
		}

        private void tbConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}