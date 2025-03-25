/* *****************************
 * Title:    Class representing the Constants
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
        public const string DEF_AI3_NAME = "AI 3";
        #endregion


        #region GameState
        public enum GameModes
        {
            DealerSetting,
            TrumpSetting,
            Tricks
        }

        public enum TrumpDecision
        {
            OrderUp,
            Pass
        }

        #endregion

        #region Card

        public const int RB_BOOST = 15;
        public const int LB_BOOST = 10;
        public const int TR_BOOST = 5;

        public const int HIGHES_RANK_POSSIBLE = 17;

        #endregion


    }
}