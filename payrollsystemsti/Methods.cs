using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace payrollsystemsti
{
    internal class Methods
    {
        //random password generator variables
        //private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        //private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //private const string Digits = "0123456789";
        //private const string SpecialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?";
        //Connection String
        public string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt = false";

        //convert image to binaru
        public byte[] ConvertImageToBinary(Image img)
        {
            if (img == null)
            {
                MessageBox.Show("its nullllll");
                return null;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            
        }
        //convert binary image to image
        public Image ConvertToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
            }
        }

        //retrieve image data from database based on employeeID
        public byte[] RetrieveEmployeeImageData(int employeeID)
        {
            byte[] imageData = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string imageQuery = "SELECT ImageData FROM EmployeeAccounts WHERE EmployeeID = @employeeID";

                using (SqlCommand imageCmd = new SqlCommand(imageQuery, conn))
                {
                    imageCmd.Parameters.AddWithValue("@employeeID", employeeID);

                    using (SqlDataReader imageReader = imageCmd.ExecuteReader())
                    {
                        if (imageReader.Read())
                        {
                            if (!(imageReader["ImageData"] is DBNull))
                            {
                                imageData = (byte[])imageReader["ImageData"];
                            }
                        }
                    }
                }
            }
            return imageData;
        }

        //public string passwordGenerator(int passlength = 12)
        //{
        //    string validChars = LowerCase + UpperCase + Digits + SpecialChars;
        //    Random random = new Random();

        //    // Ensure the password has at least one character of each type
        //    string mandatoryChars =
        //        LowerCase[random.Next(LowerCase.Length)].ToString() +
        //        UpperCase[random.Next(UpperCase.Length)].ToString() +
        //        Digits[random.Next(Digits.Length)].ToString() +
        //        SpecialChars[random.Next(SpecialChars.Length)].ToString();

        //    // Fill the rest of the password length with random characters from the combined set
        //    string remainingChars = new string(Enumerable.Repeat(validChars, passlength - mandatoryChars.Length)
        //        .Select(s => s[random.Next(s.Length)]).ToArray());

        //    // Combine and shuffle mandatory and remaining characters to ensure randomness
        //    string unshuffledPassword = mandatoryChars + remainingChars;

        //    // Shuffle the resultant password to ensure mandatory characters are randomly distributed
        //    string shuffledPassword = new string(unshuffledPassword.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());

        //    // Escape single quotes to prevent SQL injection issues
        //    string sqlSafePassword = shuffledPassword.Replace("'", "''");

        //    return sqlSafePassword;
        //}

        public bool ValidateEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // checks if the database have a combination of firstname and lastname
        public bool ifEmployeeExists(string fname, string lname)
        {
            string query = "SELECT 1 FROM EmployeeAccounts WHERE FirstName = @FirstName AND LastName = @LastName";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", fname);
                    cmd.Parameters.AddWithValue("@LastName", lname);

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }
        // checks if the database already has ssn
        public bool ifSSNExists(string ssn)
        {
            string query = "SELECT 1 FROM EmployeeAccounts WHERE SSN = @SSN";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SSN", ssn);

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                }
            }
        }

        public string setItem(string p)
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

        public bool ValidateNumber(string number)
        {
            string pattern = @"^(09|\d{2})[-]?(\d{3})[-]?(\d{4})$";
            return Regex.IsMatch(number, pattern);
        }

		public int GetTotalEmployeeCount()
		{
			int totalCount = 0;
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				conn.Open();
				string query = "SELECT COUNT(*) FROM EmployeeAccounts";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					totalCount = (int)cmd.ExecuteScalar();
				}
			}
			return totalCount;
		}

        public string getDepartmentName(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentName FROM Departments WHERE DepartmentID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string name = (string)cmd.ExecuteScalar();
                    return name;
                }
            }
        }

        public string getPositionTitle(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT PositionTitle FROM Positions WHERE PositionID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string name = (string)cmd.ExecuteScalar();
                    return name;
                }
            }
        }

        public string getRoleTitle(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT RoleTitle FROM Roles WHERE RoleID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string name = (string)cmd.ExecuteScalar();
                    return name;
                }
            }
        }

        public bool ifRoleTitleExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Roles WHERE IsDeactivated = 0 AND RoleTitle = @role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@role", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        public bool ifDepartmentNameExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Departments WHERE IsDeactivated = 0 AND DepartmentName = @department";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@department", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        public bool ifPositionTitleExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Positions WHERE IsDeactivated = 0 AND PositionTitle = @position";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@position", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }

        public bool ifDeductionExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Deductions WHERE IsDeactivated = 0 AND DeductionType = @deduction";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@deduction", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }

        public bool ifLeaveCategoryExist(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM LeaveCategory WHERE IsDeactivated = 0 AND DeductionType = @deduction";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@deduction", title);
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }

        public bool insertToDepartments(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Departments(DepartmentName) VALUES(@title)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Departments: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool insertToPositions(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Positions(PositionTitle) VALUES(@title)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Positions: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool insertToRoles(string title)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Roles(RoleTitle) VALUES(@title)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Roles: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool insertToLeaves(string title, bool hasProof)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO LeaveCategory (CategoryName, hasProof) VALUES (@catname, @proof)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", title);
                    cmd.Parameters.AddWithValue("@proof", hasProof);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Leaves: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool insertToDeductions(string title, int amount)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Deductions (DeductionType, Amount) VALUES (@type, @amount)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Deductions: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool insertToAllowances(int empID, int training, int trans, int load, int provision, int oba)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Allowance (EmployeeID, TrainingA, TransportationA, LoadA, ProvisionTA, OBA) " +
                    "VALUES (@empID, @training, @trans, @load, @provision, @oba)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@training", training);
                    cmd.Parameters.AddWithValue("@trans", trans);
                    cmd.Parameters.AddWithValue("@load", load);
                    cmd.Parameters.AddWithValue("@provision", provision);
                    cmd.Parameters.AddWithValue("@oba", oba);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error inserting into Deductions: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool InsertOtherData(int employeeID, int incentives, int regularH, int specialH, int adjustment)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            INSERT INTO Others (EmployeeID, Incentives, RegularH, SpecialH, Adjustment) 
            VALUES (@employeeID, @incentives, @regularH, @specialH, @adjustment);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@incentives", incentives);
                    cmd.Parameters.AddWithValue("@regularH", regularH);
                    cmd.Parameters.AddWithValue("@specialH", specialH);
                    cmd.Parameters.AddWithValue("@adjustment", adjustment);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if insert was successful
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception (e.g., log, display error message)
                        MessageBox.Show($"Error inserting into Others: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        public bool UpdateOtherData(int employeeID, int incentives, int regularH, int specialH, int adjustment)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            UPDATE Others 
            SET Incentives = @incentives, RegularH = @regularH, SpecialH = @specialH, Adjustment = @adjustment
            WHERE EmployeeID = @employeeID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add all the parameters here (including @otherID to identify the record)
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@incentives", incentives);
                    cmd.Parameters.AddWithValue("@regularH", regularH);
                    cmd.Parameters.AddWithValue("@specialH", specialH);
                    cmd.Parameters.AddWithValue("@adjustment", adjustment);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception (e.g., log, display error message)
                        MessageBox.Show($"Error updating Others: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }




        public bool updateDepartments(string title, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Departments SET DepartmentName = @departmentName WHERE DepartmentID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@departmentName", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Departments: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool updatePositions(string title, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Positions SET PositionTitle = @position WHERE PositionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@position", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Positions: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool updateRoles(string title, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Roles SET RoleTitle = @role WHERE RoleID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@role", title);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Roles: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool updateLeaves(string title, bool hasProof, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE LeaveCategory SET CategoryName = @name, hasProof= @status " +
                    "WHERE CategoryID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", title);
                    cmd.Parameters.AddWithValue("@status", hasProof);
                    cmd.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Leaves: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool updateDeductions(string title, int amount, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET DeductionType = @type, Amount = @amount " +
                    "WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool updateAllowance(int training, int trans, int load, int provision, int oba, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Allowance SET TrainingA = @training, TransportationA = @trans, " +
                    "LoadA = @load, ProvisionTA = @provision, OBA = @oba WHERE AllowanceID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@training", training);
                    cmd.Parameters.AddWithValue("@trans", trans);
                    cmd.Parameters.AddWithValue("@load", load);
                    cmd.Parameters.AddWithValue("@provision", provision);
                    cmd.Parameters.AddWithValue("@oba", oba);
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateRole(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Roles SET IsDeactivated = @status WHERE RoleID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Role: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateDepartment(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Departments SET IsDeactivated = @status WHERE DepartmentID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Department: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivatePosition(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Positions SET IsDeactivated = @status WHERE PositionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Position: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateLeave(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE LeaveCategory SET IsDeactivated = @status WHERE CategoryID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Leave: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateDeduction(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET IsDeactivated = @status WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateOthers(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Others SET IsDeactivated = @status WHERE OthersID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 1);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deactivating the Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool deactivateAllowance(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Allowance SET IsDeactivated = @status WHERE AllowanceID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@status", 1);
                    cmd.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating Deduction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public decimal GetTotalHours(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SUM(TotalHours) AS TotalHours " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public decimal GetTotalHoursOT(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SUM(TotalOvertime) AS TotalOvertime " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetTotalLateMin(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SUM(Late) AS Late " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetAbsents(DateTime payStart, DateTime payEnd, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) " +
                               "FROM Attendance " +
                               "WHERE Date >= @payStart AND Date <= @payEnd AND EmployeeID = @employeeID AND TotalHours = @thw";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@payStart", payStart);
                    cmd.Parameters.AddWithValue("@payEnd", payEnd);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@thw", 0);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetTotalHours(int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SUM(TotalHours) AS TotalHours " +
                               "FROM Attendance " +
                               "WHERE EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public decimal GetTotalHoursOT(int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SUM(TotalOvertime) AS TotalOvertime " +
                               "FROM Attendance " +
                               "WHERE EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetTotalLateMin(int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SUM(Late) AS Late " +
                               "FROM Attendance " +
                               "WHERE EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal GetAbsents(int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) " +
                               "FROM Attendance " +
                               "WHERE EmployeeID = @employeeID AND TotalHours = @thw";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@thw", 0);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static class CurrentUser
        {
            public static int UserID { get; set; }
            public static string FirstName { get; set; }
            public static string LastName { get; set; }
            public static string Username { get; set; }
        }
		}
}
