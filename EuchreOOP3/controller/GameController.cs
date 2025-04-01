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
            Console.WriteLine($"AI has Picked : {pickedCard}");
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
        public static void MakeAIDecideTrump(Label lblPlayerDecideTrump, frmGame gameForm)
        {
            Console.WriteLine("MakeAIDecideTrump called");
            AIPlayer currentPlayer = Game.Turn as AIPlayer;
            Player dealer = Game.Dealer;
            Card.Suits potentialTrump = Game.Trump;

            // Log the current game state for debugging
            Console.WriteLine($"Current State - OrderedUp: {OrderedUp}, Passed: {Passed}, DealerPassed: {DealerPassed}");
            Console.WriteLine($"Current Player: {currentPlayer.UserName}, Is Dealer: {currentPlayer == dealer}");

            // Case 1: AI player is not the dealer
            if (dealer != currentPlayer)
            {
                Console.WriteLine("AI PLAYER IS NOT THE DEALER");

                // First round of trump selection
                if (!Passed && !DealerPassed)
                {
                    // AI decides whether to order up or pass
                    if (currentPlayer.GetTrumpDecision(potentialTrump) == Constants.TrumpDecision.OrderUp)
                    {
                        Console.WriteLine($"[STATE] {currentPlayer.UserName} (non-dealer AI) decided to order up");
                        MessageBox.Show($"{currentPlayer.UserName} has decided to order up. The dealer must exchange a card from their hand with the top card in the deck.");

                        // Set OrderedUp flag and assign turn to dealer
                        OrderedUp = true;
                        AssignTurnToDealer(lblPlayerDecideTrump);
                    }
                    else
                    {
                        Console.WriteLine($"[STATE] {currentPlayer.UserName} (non-dealer AI) decided to pass");
                        MessageBox.Show($"{currentPlayer.UserName} has decided to pass. It's now the dealer's turn to decide.");

                        // Set Passed flag and move to next player (dealer)
                        Passed = true;
                        UpdateCurrentPlayer(lblPlayerDecideTrump);

                        // Make UI buttons available for human dealer
                        if (!(Game.Dealer is AIPlayer))
                        {
                            gameForm.BtnOrderUp.Enabled = true;
                            gameForm.BtnPass.Enabled = true;
                        }
                    }
                }
                // Second round of trump selection (after both passed in first round)
                else if (Passed && DealerPassed)
                {
                    Console.WriteLine($"[STATE] Second round, {currentPlayer.UserName} (non-dealer AI) gets to choose any suit except {potentialTrump}");

                    // AI decides on a new trump suit
                    Card.Suits newTrump = currentPlayer.DecideTrumpSuit(potentialTrump);

                    // 70% chance AI will select a new trump
                    if (new Random().Next(10) < 7)
                    {
                        Console.WriteLine($"[STATE] {currentPlayer.UserName} selected {newTrump} as trump");
                        MessageBox.Show($"{currentPlayer.UserName} has chosen {newTrump} as the trump suit!");

                        // Set trump and game state
                        Game.Trump = newTrump;
                        trumpSet = true;
                        gameForm.LbltrumpSuit.Text = $"The Selected Trump for the Round is {newTrump}";
                        Game.GameMode = Constants.GameModes.Tricks;

                        // Reset flags
                        Passed = false;
                        DealerPassed = false;
                    }
                    else
                    {
                        Console.WriteLine($"[STATE] {currentPlayer.UserName} passed again in second round");
                        MessageBox.Show($"{currentPlayer.UserName} has passed again. It's now the dealer's final choice.");

                        // Move to dealer for final decision
                        UpdateCurrentPlayer(lblPlayerDecideTrump);

                        // Do not reset Passed and DealerPassed flags to maintain game state
                    }
                }
            }
            // Case 2: AI player is the dealer
            else
            {
                Console.WriteLine("AI PLAYER IS THE DEALER");

                // First round, non-dealer ordered up
                if (OrderedUp)
                {
                    Console.WriteLine($"[STATE] {currentPlayer.UserName} (dealer AI) must exchange a card as non-dealer ordered up");

                    // AI dealer exchanges a card
                    currentPlayer.ExchangeCard(Game.Deck, Game.Trump);

                    // Set game state
                    Game.Trump = potentialTrump;
                    MessageBox.Show($"{currentPlayer.UserName} has exchanged a card. The trump is set as {Game.Trump}.");
                    trumpSet = true;
                    gameForm.LbltrumpSuit.Text = $"The Selected Trump for the Round is {Game.Trump}";
                    Game.GameMode = Constants.GameModes.Tricks;

                    // Reset flag
                    OrderedUp = false;
                }
                // First round, non-dealer passed
                else if (Passed && !DealerPassed)
                {
                    Console.WriteLine($"[STATE] {currentPlayer.UserName} (dealer AI) decides whether to pick up or pass");

                    // AI dealer decides whether to pick up or pass
                    if (currentPlayer.GetTrumpDecision(potentialTrump) == Constants.TrumpDecision.OrderUp)
                    {
                        Console.WriteLine($"[STATE] {currentPlayer.UserName} (dealer AI) decided to pick up");

                        // AI dealer exchanges a card
                        currentPlayer.ExchangeCard(Game.Deck, Game.Trump);

                        // Set game state
                        Game.Trump = potentialTrump;
                        MessageBox.Show($"{currentPlayer.UserName} has picked up the card and set {Game.Trump} as trump.");
                        trumpSet = true;
                        gameForm.LbltrumpSuit.Text = $"The Selected Trump for the Round is {Game.Trump}";
                        Game.GameMode = Constants.GameModes.Tricks;

                        // Reset flag
                        Passed = false;
                    }
                    else
                    {
                        Console.WriteLine($"[STATE] {currentPlayer.UserName} (dealer AI) decided to pass");
                        MessageBox.Show($"{currentPlayer.UserName} has passed. Moving to second round of trump selection.");

                        // Set flag and move to first non-dealer player
                        DealerPassed = true;
                        Passed = false; // Reset for second round

                        // Find first non-dealer player
                        int dealerIndex = Game.Players.IndexOf(dealer);
                        int nextPlayerIndex = (dealerIndex + 1) % Game.Players.Count;
                        Game.Turn = Game.Players[nextPlayerIndex];
                        lblPlayerDecideTrump.Text = Game.Turn.UserName;
                    }
                }
                // Second round, dealer's final choice
                else if (Passed && DealerPassed)
                {
                    Console.WriteLine($"[STATE] Final choice for {currentPlayer.UserName} (dealer AI) in second round");

                    // Dealer must choose a trump in the final round
                    Card.Suits newTrump = currentPlayer.DecideTrumpSuit(potentialTrump);

                    // Set game state
                    Game.Trump = newTrump;
                    MessageBox.Show($"{currentPlayer.UserName} has chosen {newTrump} as the trump suit!");
                    trumpSet = true;
                    gameForm.LbltrumpSuit.Text = $"The Selected Trump for the Round is {newTrump}";
                    Game.GameMode = Constants.GameModes.Tricks;

                    // Reset flags
                    Passed = false;
                    DealerPassed = false;
                }
            }

            // Log the updated game state
            Console.WriteLine($"After AI decision - OrderedUp: {OrderedUp}, Passed: {Passed}, DealerPassed: {DealerPassed}");
            Console.WriteLine($"Trump set: {trumpSet}, GameMode: {Game.GameMode}");
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
