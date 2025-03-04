
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
        #region 
        public static List<User> Users = new List<User>();
        private static int AutoUserId = 1000;

        public  enum Genders 
        { 
            Male,
            Femal,
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
  

        #endregion

        #region Constructor
        #endregion

        #region Instance Method
        #endregion

        #region Static Method
        #endregion




    }// class ends here
}// namespace ends here