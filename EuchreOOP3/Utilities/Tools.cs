using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBAL
{
    public class Tools
    {

        /// validate a string
        public static bool IsStringValid(string check)
        {
            foreach (char c in check)
            {
                if (char.IsDigit(c))
                {
                    throw new ArgumentException("The input must not contain any numbers");
                }
            }
            return true;
        }

        /// <summary>
        /// Hashing method using SHA-256 algorithm (Secure Hash Algorithm 2)
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert the string to bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }

                return hashString.ToString();
            }
        }


        /// method to validate an int between ranges
        /// 
        public static bool IsIntValid(int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Value is out of Range");
            }
            return true;
        }
    }
} // namespace ends here.