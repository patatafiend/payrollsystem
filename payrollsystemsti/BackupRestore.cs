using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class BackupRestore : Form
    {
        Methods m = new Methods();
        public BackupRestore()
        {
            InitializeComponent();
        }

        private void btnBrowseB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbLocationB.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if(tbLocationB.Text == string.Empty)
            {
                MessageBox.Show("Please enter backup file location");
            }
            else
            {
                Backup();
            }
        }

        public void Backup()
        {
            using (SqlConnection con = new SqlConnection(m.connStr))
            {
                con.Open();
                string database = con.Database.ToString();

                try
                {
                    string filePath = Path.Combine(tbLocationB.Text, database + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak");
                    string query = "BACKUP DATABASE [" + database + "] TO DISK = '" + filePath + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Database Backup Done!");
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Backup");
					btnBackup.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup failed: " + ex.Message);
                }
            }
        }

        public void Restore()
        {
            using (SqlConnection con = new SqlConnection(m.connStr))
            {
                con.Open();
                string database = con.Database.ToString();

                try
                {
                    string query1 = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand cmd = new SqlCommand(query1, con))
                    {
                        cmd.Parameters.AddWithValue("@database", database);
                        cmd.ExecuteNonQuery();
                    }

                    string query2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '" + tbLocationR.Text + "' WITH NOUNLOAD;";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@database", database);
                        cmd2.ExecuteNonQuery();
                    }

                    string query3 = "ALTER DATABASE [" + database + "] SET MULTI_USER ";
                    using (SqlCommand cmd3 = new SqlCommand(query3, con))
                    {
                        cmd3.Parameters.AddWithValue("@database", database);
                        cmd3.ExecuteNonQuery();
                    }

                    MessageBox.Show("Database Restore Done!");
					m.Add_HistoryLog(Methods.CurrentUser.UserID, Methods.CurrentUser.FirstName, Methods.CurrentUser.LastName, Methods.CurrentUser.DepartmentID, "User: " + Methods.CurrentUser.LastName + " " + Methods.CurrentUser.FirstName + ", Backup Restored");
				}
                catch (Exception ex)
                {
                    MessageBox.Show("Restore failed: " + ex.Message);
                }
            }
        }

        private void btnBrowseR_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "SQL SERVER database backup files|.bak";
            dialog.Title = "Database restore";
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                tbLocationR.Text = dialog.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (tbLocationB.Text == string.Empty)
            {
                MessageBox.Show("Please enter backup file location");
            }
            else
            {
                Restore();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbLocationR_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
