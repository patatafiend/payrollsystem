﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
        //renz connection string
        //public string connStr = "Data Source=.;Initial Catalog=stipayrolldb;Integrated Security=True;Encrypt = false;TrustServerCertificate=True";
        //convert image to binaru
        public byte[] ConvertImageToBinary(Image img)
        {
            if (img == null)
            {
                // Create a white image
                Bitmap whiteImage = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(whiteImage))
                {
                    g.Clear(Color.White);
                }

                using (var ms = new MemoryStream())
                {
                    whiteImage.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }

            using (var ms = new MemoryStream())
            {
                // Determine a compatible format
                ImageFormat format;

                // Try commonly supported formats in order
                if (TrySaveImage(img, ImageFormat.Jpeg, ms))
                {
                    format = ImageFormat.Jpeg;
                }
                else if (TrySaveImage(img, ImageFormat.Png, ms))
                {
                    format = ImageFormat.Png;
                }
                else if (TrySaveImage(img, ImageFormat.Gif, ms))
                {
                    format = ImageFormat.Gif;
                }
                else
                {
                    // Handle unsupported format scenario (throw exception, return null, etc.)
                    throw new NotSupportedException("Image format not supported."); // Example handling
                }

                return ms.ToArray();
            }
        }

        private bool TrySaveImage(Image img, ImageFormat format, MemoryStream ms)
        {
            try
            {
                img.Save(ms, format);
                return true;
            }
            catch (ArgumentException)
            {
                // Handle potential exception when saving (e.g., invalid format)
                return false;
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

        public int GetDepartmentID(string depName)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentID FROM Departments WHERE DepartmentName = @name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", depName);

                    int id = (int)cmd.ExecuteScalar();
                    return id;
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
                string query = "SELECT COUNT(*) FROM LeaveCategory WHERE IsDeactivated = 0 AND CategoryName = @catname";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", title);
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
        public bool insertToRoles(string title, bool m, bool vh, bool lm, bool aa, bool br, bool em, bool a)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Roles(RoleTitle, Maintenance, ViewHistory, LeaveManagement, AccountArchive," +
                    " BackupRestore, EmployeeManagement, Attendance) VALUES(@title, @m, @vh, @lm, @aa, @br, @em, @a)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@m", m);
                    cmd.Parameters.AddWithValue("@vh", vh);
                    cmd.Parameters.AddWithValue("@lm", lm);
                    cmd.Parameters.AddWithValue("@aa", aa);
                    cmd.Parameters.AddWithValue("@br", br);
                    cmd.Parameters.AddWithValue("@em", em);
                    cmd.Parameters.AddWithValue("@a", a);

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

        public bool insertToLeaves(string title, bool hasProof, int defavailableleaves)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO LeaveCategory (CategoryName, hasProof, defaultAvailableLeaveDays) VALUES (@catname, @proof, @catnumofleaves)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@catname", title);
                    cmd.Parameters.AddWithValue("@proof", hasProof);
                    cmd.Parameters.AddWithValue("@catnumofleaves", defavailableleaves);

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

        public bool insertToDeductions(string title, int amount, string period)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Deductions (DeductionType, Amount, Period) VALUES (@type, @amount, @period)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@period", period);

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

        public bool insertToDeductionsT(string title, int amount , decimal add)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Deductions (DeductionType, Amount, Additional) VALUES (@type, @amount, @add)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@add", add);

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

        public bool InsertIncentivesData(int employeeID, int incentives, string remarks)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            INSERT INTO Others (EmployeeID, Incentives, ITremarks) 
            VALUES (@employeeID, @incentives, @remarks);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@incentives", incentives);
                    cmd.Parameters.AddWithValue("@remarks", remarks);

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
        public bool InsertAdjustmentData(int employeeID, int adjustment, string remarks)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            INSERT INTO Others (EmployeeID, Adjustment, ATremarks) 
            VALUES (@employeeID, @adj, @remarks);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@adj", adjustment);
                    cmd.Parameters.AddWithValue("@remarks", remarks);

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

        public bool InsertLoan(int employeeId, int sss, int hdmf, int company)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "INSERT INTO Loans (EmployeeID, SSS, HDMF, Company) VALUES (@employeeId, @sss, @hdmf, @company)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    command.Parameters.AddWithValue("@sss", sss);
                    command.Parameters.AddWithValue("@hdmf", hdmf);
                    command.Parameters.AddWithValue("@company", company);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception appropriately
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool InsertHoliday(string holidayType, string holidayName, string month, string day)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "INSERT INTO Holidays (HolidayType, HolidayName, HolidayMonth, HolidayDay) VALUES (@holidayT, @holidayName, @month, @day)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@holidayT", holidayType);
                    command.Parameters.AddWithValue("@holidayName", holidayName);
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception appropriately
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateHoliday(int holidayId, string holidayType, string holidayName, string month, string day)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "UPDATE Holidays SET HolidayType = @holidayT, HolidayName = @holidayName, HolidayMonth = @month, HolidayDay = @day " +
                    "WHERE HolidayID = @holidayId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@holidayId", holidayId);
                    command.Parameters.AddWithValue("@holidayT", holidayType);
                    command.Parameters.AddWithValue("@holidayName", holidayName);
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception appropriately
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateIncentivesData(int employeeID, int incentives, string remarks)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"UPDATE Others SET Incentives = @incentives, ITremarks = @remarks
                                 WHERE EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add all the parameters here (including @otherID to identify the record)
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@incentives", incentives);
                    cmd.Parameters.AddWithValue("@remarks", remarks);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception (e.g., log, display error message)
                        MessageBox.Show($"Error updating incentives: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public bool UpdateAdjustmentData(int employeeID, int adjustment, string remarks)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"UPDATE Others SET Adjustment = @adj, ATremarks = @remarks 
                                 WHERE EmployeeID = @employeeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add all the parameters here (including @otherID to identify the record)
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@adj", adjustment);
                    cmd.Parameters.AddWithValue("@remarks", remarks);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception (e.g., log, display error message)
                        MessageBox.Show($"Error updating Adjustment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool updateDeductions(string title, int amount, int id, string period)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET DeductionType = @type, Amount = @amount, Period = @period " +
                    "WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@period", period);

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

        public bool updateDeductionsT(string title, decimal amount, decimal add, int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET DeductionType = @type, Amount = @amount, Additional = @add " +
                    "WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", title);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@add", add);
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

        public bool activateAcc(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE EmployeeAccounts SET IsDeleted = @status WHERE EmployeeID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool activateDeduc(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Deductions SET IsDeactivated = @status WHERE DeductionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool activateDepartment(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Departments SET IsDeactivated = @status WHERE DepartmentID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool activateHoliday(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Holidays SET IsDeactivated = @status WHERE HolidayID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool activateLeave(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE LeaveCategory SET IsDeactivated = @status WHERE CategoryID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool activateRoles(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Roles SET IsDeactivated = @status WHERE RoleID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool activatePosition(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Positions SET IsDeactivated = @status WHERE PositionID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@status", 0);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error Activating the Account: " + ex.Message);
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

        public bool deactivateHoliday(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Holidays SET IsDeactivated = @status WHERE HolidayID = @ID";
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

        public bool checkDepartmentCount(int departmentID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM EmployeeAccounts WHERE DepartmentID = @depID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@depID", departmentID);

                    try
                    {
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
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

        //public decimal IsHoliday

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

        public string GetEmpName(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public string GetEmpNum(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Mobile FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Mobile"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }
        public string GetEmpEmail(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Email FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Email"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public string GetEmpDob(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Dob FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Dob"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public string GetEmpGender(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Gender FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Gender"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public string GetEmpPositionID(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT PositionID FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["PositionID"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public string GetEmpDepartmentID(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT DepartmentID FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["DepartmentID"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(age))
            {
                age--;
            }
            return age;
        }


        public int GetEmployeeIdByName(string fullName)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "SELECT EmployeeID FROM EmployeeAccounts WHERE CONCAT(FirstName, ' ', LastName) = @fullName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullName", fullName);

                    try
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            // Handle case where no employee is found
                            return -1; // Or throw an exception
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception appropriately
                        Console.WriteLine(ex.Message);
                        return -1; // Or throw an exception
                    }
                }
            }
        }

        public byte[] GetEmpPicture(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ImageData FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (byte[])reader["ImageData"];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public int GetSSSLoan(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SSS FROM Loans WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["SSS"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public int GetHDMFLoan(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT HDMF FROM Loans WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["HDMF"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public int GetCompanyLoan(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Company FROM Loans WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["Company"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public string GetGender(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Gender FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Gender"].ToString();
                    }
                    else
                    {
                        return "No Gender, Employee does not exist";
                    }
                }
            }
        }

        public int GetFingerID(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT fingerID FROM EmployeeAccounts WHERE EmployeeID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["fingerID"];
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
            //strings
            public static string FirstName { get; set; }
            public static string LastName { get; set; }
            public static string Username { get; set; }
            public static string DepartmentID { get; set; }
            public static string EmailAddress { get; set; }
            public static string EmployeeNumber { get; set; }

            //ints
            public static int EmployeeRole { get; set; }
            public static int employeePosition { get; set; }
            public static int UserID { get; set; }
            public static int EmployeeID { get; set; }







        }

        public void Add_HistoryLog(int employeeID, string firstName, string lastName, string department, string historyfrom)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO HistoryTable (EmployeeID, FirstName, LastName, Department, HistoryFrom,TimeAdded) " +
                               "VALUES (@employeeID, @firstName, @lastName, @department, @historyfrom, @loginTime)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@loginTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@historyfrom", historyfrom);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Add_Overtimepay(int employeeID, TimeSpan StartTime, TimeSpan EndTime, string Justification, DateTime AppliedDate)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO OvertimeApplications (EmployeeID, AppliedDate, StartTime, EndTime, Justification) " +
                               "VALUES (@employeeID, @appliedDate,@startTime, @endTime,  @justification)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@appliedDate", AppliedDate);
                    cmd.Parameters.AddWithValue("@startTime", StartTime);
                    cmd.Parameters.AddWithValue("@justification", Justification);
                    cmd.Parameters.AddWithValue("@endTime", EndTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int getTotalemployee()
        {
            int totalemployee = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM EmployeeAccounts";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        totalemployee = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving total employee count: {ex.Message}", "Error");
                }
            }

            return totalemployee;
        }

        public int getTotalCurrentAvailableLeaves(int currentuserid)
        {
            int totalCurrentAvailableLeaves = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Get the list of columns in the LeaveTypeAvailable table
                    DataTable schemaTable = conn.GetSchema("Columns", new[] { null, null, "LeaveTypeAvailable", null });
                    List<string> leaveColumns = new List<string>();

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string columnName = row["COLUMN_NAME"].ToString();
                        if (columnName != "Id" && columnName != "Employee ID")
                        {
                            leaveColumns.Add(columnName);
                        }
                    }

                    // Construct the dynamic SQL query
                    string sumColumns = string.Join(" + ", leaveColumns.Select(c => $"ISNULL(CAST([{c}] AS INT), 0)"));
                    string query = $"SELECT {sumColumns} AS TotalLeaves FROM LeaveTypeAvailable WHERE [Employee ID] = @currentuserid";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalCurrentAvailableLeaves = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving total current available leaves: {ex.Message}", "Error");
                }
            }

            return totalCurrentAvailableLeaves;
        }


         

        public bool IsTimedOutAM(int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT TimeOut_AM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@date", date);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public bool IsTimedInAM(int fingerID, string date)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_AM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);
                    cmd.Parameters.AddWithValue("@date", date);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public bool IsTimedInPM(int fID, string currentDate)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT TimeIn_PM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fID);
                    cmd.Parameters.AddWithValue("@date", currentDate);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public bool IsTimedOutPM(int fID, string currentDate)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT TimeOut_PM FROM Attendance WHERE fingerID = @fingerID AND Date = @date";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fID);
                    cmd.Parameters.AddWithValue("@date", currentDate);

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else if (result.ToString() == "00:00:00")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }



        public int getEmpID(int fingerID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT EmployeeID FROM EmployeeAccounts WHERE fingerID = @fingerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fingerID", fingerID);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int empID = (int)result;
                        return empID;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public string getEmpName(int fingerID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM EmployeeAccounts WHERE fingerID = @fingerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@fingerID", SqlDbType.Int).Value = fingerID;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        }
                    }
                }
            }
            return "Employee Doesn't Exist";
        }

        public bool insertAttedanceHistory(int empID, string time, string date, string status)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO AttedanceHistory(EmployeeID, Date, Status, Time) " +
                    "VALUES(@empID, @date, @status, @time)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }

        }

		public void Add_Notification_AcceptedOrRejected(string employeeID, string status, string requestType)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				conn.Open();

				string query = "INSERT INTO Notifications (EmployeeID, NotificationMessage, Date) VALUES (@employeeID, @notificationText, @dateCreated)";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					string notificationText = $"Your {requestType} request has been {status}.";

					cmd.Parameters.AddWithValue("@employeeID", employeeID);
					cmd.Parameters.AddWithValue("@notificationText", notificationText);
					cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);

					cmd.ExecuteNonQuery();
				}
			}
		}

        public int GetPayStart()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT PayStart FROM PayDefault";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["PayStart"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public int GetPayEnd()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT PayEnd FROM PayDefault";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return (int)reader["PayEnd"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public string GetEmployeeType(int empID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Type FROM EmployeeAccounts WHERE EmployeeID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", empID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Type"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
    }
}
