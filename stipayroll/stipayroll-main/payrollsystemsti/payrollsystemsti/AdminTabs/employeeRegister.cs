using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace payrollsystemsti.AdminTabs
{
    public partial class employeeRegister : Form
    {

        Connection conn = new Connection();
        string fileName;
        public employeeRegister()
        {
            InitializeComponent();
        }

        // adds image
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    lbFileName.Text = fileName;
                    employeePic.Image = Image.FromFile(fileName);
                }
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            employeePic.Image = null;
        }

        private void employeeRegister_Load(object sender, EventArgs e)
        {
            this.ActiveControl = empName;
            LoadData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
        }

        //when enter is pressed and textbox has value, it goes to the next textbox 
        private void empName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (empName.Text.Length > 0)
                {
                    empDob.Focus();
                }
                else
                {
                    empName.Focus();
                }
            }
        }
        private void empNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (empNumber.Text.Length > 1)
                {
                    empEmail.Focus();
                }
                else
                {
                    empNumber.Focus();
                }
            }
        }
        private void empSSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (empSSN.Text.Length > 1)
                {
                    empPosition.Focus();
                }
                else
                {
                    empSSN.Focus();
                }
            }
        }

        private void empEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (empEmail.Text.Length > 0)
                {
                    empSSN.Focus();
                }
                else
                {
                    empEmail.Focus();
                }
            }
        }

        private void empAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (empAdd.Text.Length > 1)
                {
                    empNumber.Focus();
                }
                else
                {
                    empAdd.Focus();
                }
            }
        }

        private void empDob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                empAdd.Focus();
            }
        }
        private void empPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(empPosition.SelectedIndex > -1)
                {
                    empBasicRate.Focus();
                }
                else
                {
                    empPosition.Focus();
                }
                
            }
        }
        private void empBasicRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (empBasicRate.Text.Length > 1)
                {
                    btnSave.Focus();
                }
                else
                {
                    empBasicRate.Focus();
                }
            }
        }

        private void empNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar)&(Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void empSSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        // checks if textboxes are filled
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(empName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(empName, "Please enter Name");
            }
            else if (string.IsNullOrEmpty(empNumber.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(empNumber, "Please enter UserName");
            }
            else if (string.IsNullOrEmpty(empSSN.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(empSSN, "Please enter Social Security Number");
            }
            //else if (empSSN.Text.Length < 10)
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(empSSN, "Invalid SSN");
            //}
            //else if (empSSN.Text.Length < 11)
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(empSSN, "Invalid Number");
            //}
            else if (string.IsNullOrEmpty(empEmail.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(empEmail, "Please enter Email");
            }
            else if (string.IsNullOrEmpty(empAdd.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(empAdd, "Please enter Address");
            }
            else if (string.IsNullOrEmpty(empAdd.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(empAdd, "Please enter Address");
            }
            else if (employeePic.Image == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(employeePic, "Please Choose Image");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }
        // checks if the database already has name, mobile and ssn
        private bool ifEmployeeExists(string name, string mobile, string ssn)
        {
            conn.DataGet("SELECT 1 FROM Employee WHERE Name= '" + empName + "' AND Mobile = '"+ empNumber +"' AND SSN = '"+ empSSN +"'");
            DataTable dt = new DataTable();
            conn.sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        // converts image to binary
        byte[]ConvertImageToBinary(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        //saves inputed data in the textbox
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if(ifEmployeeExists(empName.Text, empNumber.Text, empSSN.Text))
                {
                    MessageBox.Show("Employee already Exists");
                }
                else
                {
                    conn.DataSend("INSERT INTO Employee (Mobile, SSN, Email, Name, Address, Dob, FileName, ImageData, BasicRate, Position, IsDeleted) VALUES" +
                        "  ('" + empNumber.Text + "','"+ empSSN.Text +"','" + empEmail.Text + "','" + empName.Text + "'," +
                        "'" + empAdd.Text + "','" + empDob.Value.ToString("MM/dd/yyyy") + "'," +
                        "'" + fileName + "','"+ConvertImageToBinary(employeePic.Image)+"', '"+empBasicRate.Text+"', '"+empPosition.Text+"'" +
                        ",'0')");
                    MessageBox.Show("Succesfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadData();
                }
            }
        }
        // clears data inside textboxes
        private void ClearData()
        {
            empID.Clear();
            empName.Clear();
            empNumber.Clear();
            empSSN.Clear();
            empEmail.Clear();
            empAdd.Clear();
            empDob.Value = DateTime.Now;
            employeePic.Image = null;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeactivate.Enabled = false;
            empPosition.SelectedIndex = -1;
            empBasicRate.Clear();
        }

        //loads data
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            conn.DataGet("SELECT * FROM Employee WHERE IsDeleted = 0");// gets all active employees in the database
            DataTable dt = new DataTable();
            conn.sda.Fill(dt);
            foreach (DataRow row in dt.Rows) {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["dgEmp"].Value = row["EmpID"].ToString();
                dataGridView1.Rows[n].Cells["dgName"].Value = row["Name"].ToString();
                dataGridView1.Rows[n].Cells["dgSSN"].Value = row["SSN"].ToString();
                dataGridView1.Rows[n].Cells["dgMobile"].Value = row["Mobile"].ToString();
                dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["DoB"].ToString()).ToString("dd/MM/yyyy");
                dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                dataGridView1.Rows[n].Cells["dgAdd"].Value = row["Address"].ToString();
                dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                dataGridView1.Rows[n].Cells["dgImageData"].Value = row["ImageData"].ToString();
                dataGridView1.Rows[n].Cells["dgPosition"].Value = row["Position"].ToString();
                dataGridView1.Rows[n].Cells["dgBasicRate"].Value = row["BasicRate"].ToString();
            }
        }

        // if double click on the data in datagridview, it goes to the textboxes
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool isDeleted = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["IsDeleted"].Value);
            if (isDeleted)
            {
                MessageBox.Show("This employee is deactivated.", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                empID.Text = dataGridView1.SelectedRows[0].Cells["dgEmp"].Value.ToString();
                empName.Text = dataGridView1.SelectedRows[0].Cells["dgName"].Value.ToString();
                empNumber.Text = dataGridView1.SelectedRows[0].Cells["dgMobile"].Value.ToString();
                empEmail.Text = dataGridView1.SelectedRows[0].Cells["dgEmail"].Value.ToString();
                empSSN.Text = dataGridView1.SelectedRows[0].Cells["dgSSN"].Value.ToString();
                empAdd.Text = dataGridView1.SelectedRows[0].Cells["dgAdd"].Value.ToString();

                string dobCellValue = dataGridView1.SelectedRows[0].Cells["dgDob"].Value.ToString();
                DateTime dob;

                if (DateTime.TryParseExact(dobCellValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    empDob.Value = dob;
                }
                else
                {
                    MessageBox.Show("Invalid date format");
                }

                lbFileName.Text = dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString();

                try
                {
                    employeePic.Image = Image.FromFile(lbFileName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    employeePic.Image = null;
                }

                empPosition.Text = dataGridView1.SelectedRows[0].Cells["dgPosition"].Value.ToString();
                empBasicRate.Text = dataGridView1.SelectedRows[0].Cells["dgBasicRate"].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDeactivate.Enabled = true;
            }
                
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this row?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                conn.DataSend("UPDATE Employee SET Email ='"+empEmail.Text+"', Address ='"+empAdd.Text+"', FileName ='"+fileName+"', " +
                    "ImageData ='"+ConvertImageToBinary(employeePic.Image)+"', Mobile ='"+empNumber.Text+"'," +
                    " Position = '"+empPosition.Text+"', BasicRate = '"+empBasicRate.Text+"' WHERE EmpID = '"+empID.Text+"'");
            }
            MessageBox.Show("Update Success!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearData();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string empID = dataGridView1.SelectedRows[0].Cells["dgEmp"].Value.ToString();
                conn.DataSend($"UPDATE Employee SET IsDeleted = 1 WHERE EmpID = '{empID}'");
                MessageBox.Show("Employee Deactivated", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to deactivate", "Deactivation Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //gets the value in the combo box role
        private void empPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empPosition.SelectedItem != null)
            {
                string p = empPosition.SelectedItem.ToString();
                empBasicRate.Text = setItem(p);
            }
        }
        //sets the value of textbox basicrate
        private string setItem(string p)
        {
            switch (p)
            {
                case "Sales Manager":
                    return "1000";
                case "Purchasing supervisor":
                    return "850";
                default:
                    return "610";
            }
        }

        //private void btnActivate_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        string empID = dataGridView1.SelectedRows[0].Cells["dgEmp"].Value.ToString();
        //        conn.DataSend($"UPDATE Employee SET IsDeleted = 0 WHERE EmpID = '{empID}'");
        //        MessageBox.Show("Employee Activated", "Activation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        LoadData();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a row to activate", "Activation Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
    }
}
