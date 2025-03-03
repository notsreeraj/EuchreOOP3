using System;
using System.Collections.Generic;
using System.Linq;
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
        /// hasing method using sha256 algorithm (Secure Hash Algorithm 2)
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int HashPasswordToInt(int password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                // Convert the integer to a string
                string passwordString = password.ToString();

                // Convert the string to bytes
                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(passwordString);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Take the first 4 bytes of the hash and convert to an integer
                return BitConverter.ToInt32(hashBytes, 0); // Converts 4 bytes to an integer
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
}