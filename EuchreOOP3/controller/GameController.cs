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
            Console.WriteLine(" GameController: AI is Making a Move according to the Game Mode");
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
                    MakeAIDecideTrump(gameForm.LblPlayerDecideTrump, gameForm);
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
            Console.WriteLine($"AI has Picked : {pickedCard.ToString()}");
            Game.Deck.RemoveCard(pickedCard);

            if (pickedCard.IsBlackJack())
            {
                Game.Dealer = Game.Turn;
                dealerSet = true;
                // LblDealerName.Text += Game.Dealer.UserName;
            }

        }


        public static void MakeAIDecideTrump(Label lblPlayerDecideTrump, frmGame gameForm)
        {
            AIPlayer currentPlayer = Game.Turn as AIPlayer;
            Player dealer = Game.Dealer;
            Card.Suits potentialTrump = Game.Trump;


            if (dealer as AIPlayer != currentPlayer)
            {
                // this will happen only when the  previus player passes
                Console.WriteLine($"Player who passed is {currentPlayer.UserName}");
                //GameController.UpdateCurrentPlayer(lblPlayerDecideTrump);

                if (currentPlayer.GetTrumpDecision(potentialTrump) == Constants.TrumpDecision.OrderUp)
                {
                    Console.WriteLine($"{currentPlayer.UserName} has order up");

                    AssignTurnToDealer(lblPlayerDecideTrump);
                    MessageBox.Show($"{currentPlayer.UserName} has decided to order up so  now you gotta exchange a card from you hand with the top card in the deck");

                    OrderedUp = true;
                    // the player in turn now must be the dealer and he must exchange the topcard of the deck with one of his cards
                }
                else
                {
                    Console.WriteLine($"{currentPlayer.UserName} has passed");
                    MessageBox.Show($"{currentPlayer.UserName} has decide to Pass, So Its The Dealers chance to Choose any suit as the trump");
                    UpdateCurrentPlayer(lblPlayerDecideTrump);
                    Passed = true;
                }

                // ge the player in turn '
                // must mus confirm that the player in turn is an ai player
                // if it is ai let the ai choose whether it should make it trump or not 
                // here the ai should analyze the trump suit and compare it with the cards in its hand
                //
            }
            else if (dealer as AIPlayer == currentPlayer)
            {
                if (Passed)
                {
                    Console.WriteLine($"State of the game : {currentPlayer.UserName} is the dealer and he can choose any suit as trump other the potential trump");
                    MessageBox.Show($"As {currentPlayer.UserName} is the dealer and Rest of the players has passed, You can choose any suit as trump suit except the potential trump");

                    // give the dealer a window or panel to let the  dealer choose any suit as trump
                    //AssignTurnToDealer(lblPlayerDecideTrump);

                    if (currentPlayer.GetTrumpDecision(potentialTrump) == Constants.TrumpDecision.Pass)
                    {
                        Console.WriteLine("The dealer has Passed");
                        UpdateCurrentPlayer(lblPlayerDecideTrump);
                        DealerPassed = true;
                    }


                    /*
                     Here ai can pass or order up
                    that is exchange the cards or 
                    2.	If the non-dealer passes, then the dealer gets to choose whether he wants to keep this as the trump. 
                    Here he can either pick up the card and replace it with another card from his hand and the new card would be the trump, 
                    or he can pass the chance to choose a trump.
                     
                     */
                    // this is triggered when the dealer decision is not to pass
                    else
                    {

                        currentPlayer.ExchangeCard(Game.Deck, Game.Trump);
                        Game.Trump = Game.Deck.GetTopCard().Suit;
                        MessageBox.Show($"{currentPlayer.UserName} has chosen {Game.Trump} as the trump suit!");
                        trumpSet = true;
                        gameForm.LbltrumpSuit.Text = $"The Selected Trump for the Round is {Game.Trump}";
                        Game.GameMode = Constants.GameModes.Tricks;

                    }



                    // this is to reset the boolian

                    Passed = false;
                }
                else if (OrderedUp)
                {
                    Console.WriteLine($"State of the game : {currentPlayer.UserName} is the dealer and he must exchange the topcard of the deck with one of his own");
                    currentPlayer.ExchangeCard(Game.Deck, Game.Trump);
                    Game.Trump = Game.Deck.GetTopCard().Suit;
                    MessageBox.Show($"Alright the trump has been set as {Game.Trump} by {currentPlayer.UserName}");
                    trumpSet = true;

                    Card.Suits newTrump = Game.Trump;
                    gameForm.LbltrumpSuit.Text = $"The Selected Trump for the Round is {newTrump}";
                    Game.GameMode = Constants.GameModes.Tricks;
                    // this happens when any player has chose order up
                    // this will give the dealer to exchange a topcard from the decl with any card in his deck which is not a trump *********************
                    //TODO

                    // this line is to reset the boolian
                    OrderedUp = false;
                }
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
            player.SetUpHand(HandPanel);
            player.LoadPlayerHand();

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
