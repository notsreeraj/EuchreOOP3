
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
        public static List<User> Users = new List<User>();
        private static int AutoUserId = 1000;

        public  enum Genders 
        { 
            Male,
            Female,
            Other
        }

        #endregion

        #region Propoerties
        private int _userId;
        public int UserId {
            get { return _userId; } 
            set 
                {
                    _userId = AutoUserId;
                    AutoUserId++;
                } 
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders Gender{ get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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
            //setDefault();
            Users.Add(this);
        }
        
        public User(string firstName,string lastName,Genders gender,string email,string userName,string password)
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

                        Users.Add(user);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[ERROR] Failed to Populate Users => {ex} ");
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
                throw new Exception($"[ERROR] Failed to Update User Stats => {ex} ");
            }
        }


        #endregion

        #region Static Method

        public static void PrintAllUsers()
        {
            foreach(User user in Users)
            {
                Console.WriteLine(user.ToString());
            }
        }
        #endregion




    }// class ends here
}// namespace ends here