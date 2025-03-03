
using EuchreOOP3.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace DBAL
{
    /// <summary>
    /// class of user
    /// </summary>
    public class User
    {
        #region Variable
        public static User CurrentUser = new User();
        public static List<User> Users = new List<User>();
        #endregion

        #region Properties
        private int _userID;
        private int _passKey;
        private string _emailID;
        public int UserID
        {
            get { return _userID; }
            set
            {
                try
                {
                    //call the method to check whether the user id is valid or not , it must be unique
                    if (IsUserIdUnique(value))
                    {
                        _userID = value;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get
            {
                return _emailID;
            }
            set
            {
                try
                {
                    // call the method to verify the email id from the database
                    if (IsEmailUnique(value) && IsEmailValid(value))
                    {
                        _emailID = value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public int PassKey
        {
            get { return _passKey; }
            set
            {
                try
                {
                    if (PassKeyValid(value)) ;
                    {
                        _passKey = Tools.HashPasswordToInt(value);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Constructors

        public User()
        {
            SetDefaults();
        }

        public User(int userID, string firstName, string lastName, string email, int passKey)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassKey = passKey;
        }


        #endregion


        #region instance method


        /// <summary>
        /// ToString method
        /// </summary>
        public override string ToString()
        {
            return FirstName + " " + LastName + $"({Email})";
        }




        #endregion

        #region Static Methods
        /// <summary>
        /// method to validate email id
        /// </summary>
        /// <param name="passkey"></param>
        /// <returns></returns>

        public static bool IsEmailValid(string email)
        {

            if (string.IsNullOrWhiteSpace(email)) throw new Exception("White spaces are not allowed");
            // Define a regex pattern for a valid email address
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern)) throw new Exception("Invalid EmailID Format ");
            return true;


        }


        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsEmailUnique(string email)
        {
            foreach (User user in Users)
            {
                if (string.Equals(user.Email, email, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Email ID is already in use");
                }
            }
            return true;
        }




        /// <summary>
        ///  method to validate password
        /// </summary>

        public static bool PassKeyValid(int passkey)
        {
            if (passkey < 1000 || passkey > 9999)
            {
                throw new Exception("Password must be a numeric value between 1000 and 9999");
            }
            return true;
        }


        /// <summary>
        /// method to check whether the user id is unique and valid
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsUserIdUnique(int userId)
        {
            foreach (User user in Users)
            {
                if (user.UserID == userId)
                {
                    throw new Exception("User ID is already in use");
                }
            }
            return true; // User ID is unique
        }


        /// <summary>
        /// Check if there is a user with same credentials
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="passKey"></param>
        /// <returns></returns>
        public static bool IsUserFound(string emailID, int passKey)
        {
            foreach (User user in Users)
            {
                //string.Equals(user.Email, emailID, StringComparison.OrdinalIgnoreCase
                if (user.Email == emailID && user.PassKey == passKey)
                {
                    return true; // User found with matching credentials
                }
            }
            return false;
        }

        /// <summary>
        /// Check if there is a user with same credentials
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="passKey"></param>
        /// <returns></returns>
        public static User GetValidUser(string emailID, int passKey)
        {
            foreach (User user in Users)
            {
                //if (user.Email == emailID && user.PassKey == passKey)
                if (string.Equals(user.Email, emailID, StringComparison.OrdinalIgnoreCase) && user.PassKey == passKey)
                {
                    return user; // User found with matching credentials
                }
            }
            throw new Exception("User Cannot be Found");
        }


        /// <summary>
        /// Method to setfefault values
        /// </summary>
        private void SetDefaults()
        {
            FirstName = Constants.DEFAULT_FIRST_NAME;
            LastName = Constants.DEFAULT_LAST_NAME;
        }

        ///  <summary>
        /// insert a new user
        /// </summary>
        /// <param name="passkeyWithoutHash"></param>
        /// <exception cref="Exception"></exception>
        public bool InsertUser (int passkeyWithoutHash)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spInsertUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@userID", UserID);
                        cmd.Parameters.AddWithValue("@firstName", FirstName);
                        cmd.Parameters.AddWithValue("@lastName", LastName);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@Passkey", passkeyWithoutHash);

                        // Execute the stored procedure
                        return (cmd.ExecuteNonQuery() == 1);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to Add user " + ex.Message);
            }

        }

        /// <summary>
        /// Method to update a users info
        /// </summary>
        public  bool UpdateUser()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spUpdateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@userID", UserID);
                        cmd.Parameters.AddWithValue("@firstName", FirstName);
                        cmd.Parameters.AddWithValue("@lastName", LastName);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@Passkey", PassKey);

                        // Execute the stored procedure
                        return (cmd.ExecuteNonQuery() ==1);

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Failde to Update the User : " + ex.Message);
            }
        }


        public bool UpdateStats()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spUpdtaeStats", conn))
                    {
                        cmd.CommandType= CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("MatchesPlayed", MatchesPlayed);
                        cmd.Parameters.AddWithValue("Win", Wins);
                        cmd.Parameters.AddWithValue("Loss", Losses);
                        cmd.Parameters.AddWithValue("Draw", Draws);

                        return (cmd.ExecuteNonQuery() == 1);
                    }
                    


                }
            }
            catch (Exception ex) 
            {

                throw new Exception("Failde to Update the User : " + ex.Message);
            }
        }


        /// <summary>
        /// method to populate users form the data base
        /// </summary>
        public static void PopulateUsers()
        {
            if (Users != null)
            {
                Users.Clear();
            }
            try
            {
                // new connection object is instantiated here
                SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB);
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT* 
                                    FROM Users";
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.UserID = (int)reader["UserID"];
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.PassKey = (int)reader["PassKey"];
                    Users.Add(user);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        ///  to get a user from the list
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static User FindUser(int userID)
        {
            foreach (User user in Users)
            {
                if (user.UserID == userID)
                {
                    return user;
                }

            }
            throw new Exception("User Cannot be Found");
        }

        /// <summary>
        /// To delete a user from the database
        /// </summary>
        /// <param name="userID"></param>
        /// <exception cref="Exception"></exception>
        public static bool DeleteUser(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spDeleteUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@userID", userID);
                        return (cmd.ExecuteNonQuery() == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Delete the user :  " + ex.Message);
            }

        }

        #endregion
    }// class ends here
}// namespace ends here