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

        public const string DEF_AI1_NAME = "AI 1";
        public const string DEF_AI2_NAME = "AI 2";
        #endregion


        #region GameState
        public enum GameModes
        {
            DealerSetting,
            TrumpSetting,
            Tricks
        }
        #endregion



    }
}