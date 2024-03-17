using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

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
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public Image ConvertToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
            }
        }

        public byte[] RetrieveEmployeeImageData(int employeeID)
        {
            // Implement your logic to fetch ImageData from EmployeeAccounts table based on EmployeeID
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
    }
}
