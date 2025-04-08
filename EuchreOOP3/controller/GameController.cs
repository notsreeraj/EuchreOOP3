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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using EuchreView.model;

namespace Controller
{
    public class GameController
    {
        public const int QP = 2;
        public const int CP = 4;
        public static GameState Game;
        public static int Theme = 0;
        public static bool dealerSet = false;
        public static bool trumpSet = false;
        public static List<PictureBox> PickedCards = new List<PictureBox>();
        public static bool Passed = false;
        public static bool OrderedUp = false;
        public static bool DealerPassed = false;

        #region Static Method
        /// <summary>
        /// method to start a quickPlay by adding 2 players to the players list
        /// </summary>
        public static void StartQuickplay()
        {
            try { Game = new GameState(QP); }
            catch (Exception ex)
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
            if (deck != null)
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
            lblCurrenPlayer.Text = Game.Turn.UserName;


            Console.WriteLine($" from UpdateCurrentPlayer in GameController: Current Player is {Game.Players[currentPlayerIndex].UserName}");


        }
        /// <summary>
        /// this the most important method in controller regarding to ai 
        /// this will make the ai to make a move according to the game state
        /// </summary>
        /// <param name="gameMode"></param>
        /// <param name="gameForm"></param>
        public static void MakeAIMove(Constants.GameModes gameMode, frmGame gameForm)
        {
            Console.WriteLine("Calling MakeAIMove Method");
            switch (gameMode)
            {
                case Constants.GameModes.DealerSetting:
                    if (!dealerSet)
                    {
                        MakeAIPickCard(gameForm.LblDealerName);
                    }
                    break;
                case Constants.GameModes.TrumpSetting:
                    // Pass label5 to trump setting logic
                    MakeAIDecideTrump( gameForm);
                    break;
                      
                case Constants.GameModes.Tricks:
                    // Pass label5 to tricks logic
                    break;
            }
        }
        /// <summary>
        /// This method makes the ai to pick a card from the top of the deck 
        /// by calling the instance method and checks if the picked card is a black jack
        /// </summary>
        /// <param name="LblDealerName"></param>
        public static void MakeAIPickCard(Label LblDealerName)
        {

            Card pickedCard = Game.Turn.PickCard(Game.Deck);

            ShowPickedCards(pickedCard);
            
            Game.Deck.RemoveCard(pickedCard);

            if (pickedCard.IsBlackJack())
            {
                Game.Dealer = Game.Turn;
                dealerSet = true;
                // LblDealerName.Text += Game.Dealer.UserName;
            }

        }

        /// <summary>
        /// Method which make ai decision on trump selection phase of the game
        /// </summary>
        /// <param name="lblPlayerDecideTrump"></param>
        /// <param name="gameForm"></param>
        /// <summary>
        /// Method which handles AI decisions during the trump selection phase of the game
        /// </summary>
        /// <param name="lblPlayerDecideTrump">Label showing the current player for trump decisions</param>
        /// <param name="gameForm">Reference to the game form for UI updates</param>
        public static void MakeAIDecideTrump( frmGame gameForm)
        {
            Console.WriteLine("MakeAIDecideTrump called");

            AIPlayer currentPlayer = Game.Turn as AIPlayer;
            Player dealer = Game.Dealer;
            Card.Suits potentialTrump = Game.Trump;

            if (Game.Dealer as AIPlayer == currentPlayer)
            {
                AIDealerMove(gameForm);
            }
            else if(Game.Dealer as AIPlayer != currentPlayer)
            {
                AINonDealerMove(gameForm);
            }
        }

        private static void AINonDealerMove(frmGame gameForm)
        {
            AIPlayer currentPlayer = Game.Turn as AIPlayer;
            Card.Suits potentialTrump = Game.Trump;

            if (DealerPassed) // this is the second chance to the non dealer 
            {
                // choose any suit as trump
                Game.Trump = currentPlayer.DecideTrumpSuit(potentialTrump);
                trumpSet = true;
                Game.GameMode = Constants.GameModes.Tricks;

                MessageBox.Show($"{currentPlayer.UserName} has decided  any trump as {Game.Trump.ToString()} [Inside AINonDealer method]");
             
            }
            else // this would be when the previus player has passed
            {
                // get the ai decision on first chance 
                 if(currentPlayer.GetTrumpDecision(potentialTrump) == Constants.TrumpDecision.OrderUp)
                {
                    OrderedUp = true;
                    trumpSet = true;
                    Game.Makers.Add(Game.Turn);
                    AssignTurnToDealer(gameForm.LblPlayerDecideTrump);                   
                    MessageBox.Show($"{currentPlayer.UserName} has Order up [Inside AINonDealer method]");
                 
                }
                else
                {
                    Passed = true;
                    UpdateCurrentPlayer(gameForm.LblPlayerDecideTrump);
                    MessageBox.Show($"{currentPlayer.UserName} has passed their turn [Inside AINonDealer method]");
                }
            }
        }
        /// <summary>
        /// Method to let ai make a choice when it is a dealer and the gamemode is trump decision. This is the only method which is called when ai is dealer no matter how many players it is 
        /// We are also letting ai be dumb due to we are forcing it to make a decision where the game would initiate without passing the chance
        /// </summary>
        /// <param name="gameForm"></param>
        private static void AIDealerMove(frmGame gameForm)
        {
            AIPlayer currentPlayer = Game.Turn as AIPlayer;
            Card.Suits potentialTrump = Game.Trump;

            if (OrderedUp) // this is when someone has ordered up
            {
                
                currentPlayer.ExchangeCard( Game.Deck,potentialTrump);  
                // updating conditions
                OrderedUp = false;
                Game.GameMode= Constants.GameModes.Tricks;
                
                // Set trump
                Game.Trump = potentialTrump;
                trumpSet = true;
                

                MessageBox.Show($"{currentPlayer.UserName} has exchanged the trump and trump is set [Inside AINonDealer method]");

                
            }
            else if (DealerPassed) // this is when everyone has passed second time
            {
                Game.Trump = currentPlayer.DecideTrumpSuit(potentialTrump);
                trumpSet = true;
                Game.GameMode = Constants.GameModes.Tricks;
                Game.Makers.Add( currentPlayer );


                MessageBox.Show($"{currentPlayer.UserName} has chosen any suit as trump , trump is {Game.Trump}[Inside AIDealer method]");

               
            }
            else // this would be when everyone has passd their first chance
            {
                currentPlayer.ExchangeCard(Game.Deck, potentialTrump);
                Game.GameMode = Constants.GameModes.Tricks;
                Game.Trump = potentialTrump;
                trumpSet = true;

                Game.Makers.Add( currentPlayer );
                

                MessageBox.Show($"{currentPlayer.UserName} as the dealer has choses any suit as trump and the trump is {Game.Trump} [Inside AINonDealer method]");

                

                // here we are forcfully making ai pass , can be changed later
            }
        }

        /// <summary>
        /// method to load the image of the picked card to the pb in the panel which is inside the frmGame
        /// </summary>
        /// <param name="pickedCard"></param>
        public static void ShowPickedCards(Card pickedCard)
        {
            for (int i = 0; i < Game.Players.Count; i++)
            {
                if (Game.Players[i] == Game.Turn) PickedCards[i].BackgroundImage = pickedCard.View;
            }
        }

        /// <summary>
        /// method to reset the picked card picture boxes 
        /// </summary>
        public static void ResetPickedCardPB()
        {
            foreach (PictureBox pb in PickedCards)
            {
                pb.BackgroundImage = null;
            }
        }

        /// <summary>
        /// Method to set up the hand view of a player
        /// </summary>
        /// <param name="HandPanel"></param>
        /// <param name="player"></param>
        public static void LoadHandToView(Panel HandPanel, Player player)
        {
            player.MapHand(HandPanel);
            // only call this if the player is hplayer
            player.LoadPlayerHand();

            // else call the method to load card back images for the ai player
            

        }


        /// <summary>
        /// method to check whether there is enough cards to pick from
        /// It compare the number of cards in the deck to the number of players
        /// </summary>
        /// <returns></returns>
        public static bool HasEnoughCardsForPlayers()
        {
            return Game.Deck.DeckOfCards.Count >= Game.Players.Count;
        }

        /// <summary>
        /// method called when the non dealer ordersup and the turn is assigned to dealer
        /// </summary>
        public static void AssignTurnToDealer(Label lblPTurnTrump)
        {
            Console.WriteLine($"It is now the dealer turn to exchange card with the top card , as prevois player hase chosed to order up");

            Game.Turn = Game.Dealer;
            lblPTurnTrump.Text = Game.Turn.UserName;
        }

        #endregion

    }
}
