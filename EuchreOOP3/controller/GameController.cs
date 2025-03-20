using Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EuchreOOP3;
using System.Windows.Forms;

using DBAL;

namespace Controller
{
    public class GameController
    {
        public const int QP = 2;
        public const int CP = 4;
        public static GameState Game  ;
        public static bool dealerSet = false;

        #region Static Method
        /// <summary>
        /// method to start a quickPlay by adding 2 players to the players list
        /// </summary>
        public static void StartQuickplay()
        {
            try{ Game = new GameState(QP); }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// method to start a Coop game mode by adding 4 players to the players list
        /// </summary>
        public static void StartCOOP()
        {
           try { Game = new GameState(CP); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // method toload the card at the top of the deck to the viewer
        public static Image ViewTopCard(Deck deck)
        {
            if(deck != null)
            {
                return deck.GetTopCard().View;
            }
            throw new Exception("Failed to Load the top Most card of the deck");
        }

        public static int GetNumPlayers()
        {
            return Game.Players.Count;
        }

        public static string GetTopCardDeck()
        {
            return Game.Deck.GetTopCard().ToString();
        }


         



        
        /// <summary>
        /// method to update the turn property of the gamestate object
        /// </summary>
        /// <param name="lblCurrenPlayer"></param>
        public static void UpdateCurrentPlayer(Label lblCurrenPlayer)
        {
            int currentPlayerIndex = Game.GetCurrentPlayerIndex();
            currentPlayerIndex = (currentPlayerIndex + 1) % Game.Players.Count();
            Game.Turn = Game.Players[currentPlayerIndex];
            Console.WriteLine($" GameController: Current Player is {Game.Players[currentPlayerIndex]}");
            lblCurrenPlayer.Text = Game.Turn.UserName;
 
        }

        public static void MakeAIMove(Constants.GameModes gameMode, frmGame gameForm)
        {
            Console.WriteLine(" GameController: AI is Making a Move according to the Game Mode");
            switch (gameMode)
            {
                case Constants.GameModes.DealerSetting:
                    MakeAIPickCard(gameForm.LblDealerName); // Pass the specific label
                    break;

                case Constants.GameModes.TrumpSetting:
                    // Pass label5 to trump setting logic
                    break;

                case Constants.GameModes.Tricks:
                    // Pass label5 to tricks logic
                    break;
            }
        }

        public static void MakeAIPickCard(Label LblDealerName)
        {
            if (!dealerSet)
            {
                Card pickedCard = Game.Turn.PickCard(Game.Deck);
                Console.WriteLine($"AI has Picked : {pickedCard.ToString()}");
                Game.Deck.RemoveCard(pickedCard);

               

                if (pickedCard.IsBlackJack())
                {
                    Game.Dealer = Game.Turn;
                    dealerSet = true;
                    LblDealerName.Text += Game.Dealer.UserName;
                }
            }
        }

        ///
        public static void LoadHandToView(Panel HandPanel)
        {
            
        }

        #endregion

    }
}
