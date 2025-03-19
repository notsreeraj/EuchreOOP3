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


        /// method to set up deck  dealer selection event        private  Deck 

        public static bool FoundDealer( Card pickedCard)
        {
            
            if (pickedCard.IsBlackJack())
            {
                dealerSet = true;
                Game.Dealer = Game.Turn;
            }
            


            return false;
        }

        

        public static void UpdateCurrentPlayer(Label lblCurrenPlayer)
        {
            int currentPlayerIndex = Game.GetCurrentPlayerIndex();
            currentPlayerIndex = (currentPlayerIndex + 1) % Game.Players.Count();
            Game.Turn = Game.Players[currentPlayerIndex];
            Console.WriteLine($" GameController: Current Player is {Game.Players[currentPlayerIndex]}");
            lblCurrenPlayer.Text = Game.Turn.UserName;

            // maybe raise an event here to let it know that the player has changed if it is ai then call the method according to the type of event
 
        }

        public  static void MakeMoveAI(Constants.GameModes gameMode)
        {
            Console.WriteLine(" GameController: AI is Making a Move according to the Game Mode");
            switch (gameMode)
            {
                case Constants.GameModes.DealerSetting:

                    if (!dealerSet)
                    {
                        Card pickedCard = Game.Turn.PickCard(Game.Deck);
                        if (FoundDealer(pickedCard))
                        {
                            // change the
                            Console.WriteLine(pickedCard.ToString());
                            Game.Deck.RemoveCard(pickedCard);
                        
                        }
                    }
                    
                    ;

                    

                    break;

                case Constants.GameModes.TrumpSetting:
                    // 
                   

                    break;
                case Constants.GameModes.Tricks:
                    break;
            }

        }
        #endregion

    }
}
