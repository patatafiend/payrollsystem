using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace payrollsystemsti
{
    internal class Methods
    {
        //random password generator variables
        private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string SpecialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?";
        //Connection String
        public string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt = false";

        //convert image to binaru
        public byte[] ConvertImageToBinary(Image img)
        {
            if (img == null)
            {
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

        public string passwordGenerator(int passlength = 12)
        {
            string validChars = LowerCase + UpperCase + Digits + SpecialChars;
            Random random = new Random();

            // Ensure the password has at least one character of each type
            string mandatoryChars =
                LowerCase[random.Next(LowerCase.Length)].ToString() +
                UpperCase[random.Next(UpperCase.Length)].ToString() +
                Digits[random.Next(Digits.Length)].ToString() +
                SpecialChars[random.Next(SpecialChars.Length)].ToString();

            // Fill the rest of the password length with random characters from the combined set
            string remainingChars = new string(Enumerable.Repeat(validChars, passlength - mandatoryChars.Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // Combine and shuffle mandatory and remaining characters to ensure randomness
            string unshuffledPassword = mandatoryChars + remainingChars;

            // Shuffle the resultant password to ensure mandatory characters are randomly distributed
            string shuffledPassword = new string(unshuffledPassword.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());

            // Escape single quotes to prevent SQL injection issues
            string sqlSafePassword = shuffledPassword.Replace("'", "''");

            return sqlSafePassword;
        }

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
	}
}
