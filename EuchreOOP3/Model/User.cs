using EuchreOOP3.Properties;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBAL;


using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DBAL
{
    /// <summary>
    /// class of user
    /// </summary>
    public class User
    {
        #region 
        public static bool LoadingDB = false;
        public static List<User> Users = new List<User>();
        private static int AutoUserId = 1000;
        public static User CurrentUser;

        public enum Genders
        {
            Male,
            Female,
            Other
        }

        #endregion

        #region Propoerties
        private int _userId;
        private string _emailID;
        private string _passWord;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = AutoUserId;
                AutoUserId++;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders Gender { get; set; }
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
                    Console.WriteLine($"Email Value : {value}");
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
        public string Username { get; set; }
        public string Password
        {
            get { return _passWord; }
            set
            {
                if (!LoadingDB)
                {
                    _passWord = Tools.HashPassword(value);
                }
                else _passWord = value;
            }
        }
        public int MatchesPlayed { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Draw { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public User()
        {
            SetDefault();
            Users.Add(this);
        }

        public User(string firstName, string lastName, Genders gender, string email, string userName, string password)
        {
            UserId = 0;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Username = userName;
            Password = password;
            MatchesPlayed = 0;
            Win = 0;
            Loss = 0;
            Draw = 0;

            // adding this user to the users list
            Users.Add(this);

        }
        #endregion

        #region Instance Method
        /// <summary>
        /// method to set default values properties
        /// </summary>
        private void SetDefault()
        {
            UserId = 0;
            FirstName = "firstName";
            LastName = "lastName";
            Gender = Genders.Male;
            Email = "email";
            Username = "userName";
            Password = "password";
            MatchesPlayed = 0;
            Win = 0;
            Loss = 0;
            Draw = 0;
        }


        // Return serilaized string of user details
        public override string ToString()
        {
            return $@"
*****************************************************
                    UserID : {UserId}
                    FirstName : {FirstName}
                    LastName : {LastName}
                    Gender : {(Genders)Gender}
                    Email : {Email}
                    Username : {Username}  
                    Password : {Password}
                    Matches Played: {MatchesPlayed}
                    Win : {Win}
                    Loss : {Loss}
                    Draw : {Draw}
*****************************************************
                    ";
        }

        /// <summary>
        /// populate users
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void PopulateUsers()
        {
            if (Users != null)
            {
                Users.Clear();
                Console.WriteLine("Users cleared");
            }
            try
            {
                Console.WriteLine("Connecting to server");
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM [User]";
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Genders gender;
                        Enum.TryParse(reader["Gender"].ToString(), out gender);
                        LoadingDB = true;
                        User user = new User(
                            reader["FirstName"].ToString(),
                            reader["LastName"].ToString(),
                            gender,
                            reader["Email"].ToString(),
                            reader["Username"].ToString(),
                            reader["Password"].ToString()
                        );

                        user.MatchesPlayed = (int)reader["MatchesPlayed"];
                        user.Win = (int)reader["Win"];
                        user.Loss = (int)reader["Loss"];
                        user.Draw = (int)reader["Draw"];
                        LoadingDB = false;
                        //Users.Add(user);
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"[ERROR] Failed to Populate Users  ");
            }
        }




        /// <summary>
        /// Update user stats 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="matchesPlayed"></param>
        /// <param name="win"></param>
        /// <param name="loss"></param>
        /// <param name="draw"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateUserStats(int userId, int matchesPlayed, int win, int loss, int draw)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("spUpdateUserStats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@MatchesPlayed", matchesPlayed);
                    cmd.Parameters.AddWithValue("@Win", win);
                    cmd.Parameters.AddWithValue("@Loss", loss);
                    cmd.Parameters.AddWithValue("@Draw", draw);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[ERROR] Failed to Update User Stats");
            }
        }

        /// <summary>
        /// Insert a new user into the database
        /// </summary>
        /// <param name="user">User object to insert</param>
        /// <returns>True if successful, false otherwise</returns>
        /// <exception cref="Exception">Throws exception if insert fails</exception>
        public static bool InsertUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("spInsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@UserID", user.UserId);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender.ToString());
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@MatchesPlayed", user.MatchesPlayed);
                    cmd.Parameters.AddWithValue("@Win", user.Win);
                    cmd.Parameters.AddWithValue("@Loss", user.Loss);
                    cmd.Parameters.AddWithValue("@Draw", user.Draw);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"[ERROR] Failed to Insert User => {ex}");
            }
        }


        #endregion

        #region Static Method

        public static string GetUseName(int UserID)
        {
            foreach (User user in Users)
            {
                if (user.UserId == UserID)
                {
                    return user.Username;
                }

            }
            throw new Exception("Failed to Retrieve User Info. User Not Found .");
        }

        /// <summary>
        /// Return a User if the credentials is valid
        /// </summary>
        /// <param name="emailid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User IsUserValid(string emailid, string password)
        {
            Console.WriteLine($"emailid Input {emailid}");
            Console.WriteLine($"Password Input {Tools.HashPassword(password)}");
            foreach (User user in Users)
            {
                Console.WriteLine($"Email Comparison: {user.Email == emailid}");
                Console.WriteLine($"Password Comparison: {user.Password == Tools.HashPassword(password)}");
                if (!(user.Password == Tools.HashPassword(password)))
                {
                    Console.WriteLine($@"Password from the user lisr : {user.Password}
                                        Password from the input : {Tools.HashPassword(password)}");
                }
                if (user.Email == emailid && user.Password == Tools.HashPassword(password))
                {
                    return user;
                }
            }
            return null;
        }



        /// <summary>
        /// method to validate email id
        /// </summary>
        /// <param name="passkey"></param>
        /// <returns></returns>
        public static bool IsEmailValid(string email)
        {


            if (string.IsNullOrWhiteSpace(email))
            {

                return false;
            }

            // Regex pattern for a valid email address
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {

                return false;
            }

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
        /// Testing Users list
        /// </summary>
        public static void PrintAllUsers()
        {
            foreach (User user in Users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        /// <summary>
        /// method to get the geust user from the list for gues acces
        /// </summary>
        /// <returns></returns>
        public static User GetGuestUser()
        {
            foreach (User user in Users)
            {
                if (user.Username == "guest")
                {
                    return user;
                }
            }
            return null;
        }

        public static void IsPasswordValid(string password)
        {
            if (password.Length > 8)
            {
                throw new Exception("Password must be less than 9 characters long.");
            }

            // Check if the password contains only allowed characters
            char[] allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$".ToCharArray();
            if (!password.All(ch => allowedChars.Contains(ch)))
            {
                throw new Exception("Password can only contain letters, numbers, and the special characters @, #, $.");
            }
        }




        #endregion




    }// class ends here
}// namespace ends here