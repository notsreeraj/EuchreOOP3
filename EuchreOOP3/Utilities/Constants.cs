/* *****************************
 * Title:    Class representing the Constants
 * Author:  Sreeraj CS
 * Date:    12-08-2024
 * Purpose: to store constants
 * ***************************** */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAL
{
    /// <summary>
    /// class for constants
    /// </summary>
    public class Constants
    {
        public const int ZERO = 0;

        #region Users
        public const string DEFAULT_FIRST_NAME = " DEFAULT";
        public const string DEFAULT_LAST_NAME = "DEFAULT";

        #endregion

        #region Game
        public const string DEF_GAME_TITLE = "Title";
        public const string DEF_GAME_GENRE = "Genre";
        public static DateTime DEFAULT_RELEASEDATE = new DateTime(2000, 1, 1);


        #endregion

        #region Review
        public const string DEF_REVIEW_TEXT = "MEH";

        #endregion
    }
}