
using DBAL;
using EuchreView.model;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Model.Deck;



namespace Model

{
    public class GameState
    {
        


        // Fields
        public Deck Deck { get; set; }
        public Card.Suits Trump { get; set; } 
        public Player Dealer { get; set; }
        public Player Turn { get; set; }
        public List<Player> Players { get; set; }
        public List<Player> Makers { get; set; }
        public List<Player> Defenders { get; set; }
        public List<Card> Trick { get; set; }
        public Constants.GameModes GameMode { get; set; }

        //public Constants.TrumpDecision TrumpDecision { get; set; }

        public static int  currentPlayer;



        // Constructor
        public GameState( int numberofPlayers)
        {
            try{// setting up the common properties of the games state
                Deck = new Deck();
                Trump = 0;
                Dealer = null;
                Trick = new List<Card>();
                Players = new List<Player>();
                switch (numberofPlayers)
                {
                    case 2:
                        QuickPlay();
                        break;
                    case 4:
                        CoopPlay();
                        break;

                }
                // give the first turn to the firs player in the list
                Turn = Players[0];
                GameMode = Constants.GameModes.DealerSetting;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            
        }

        /// <summary>
        /// Method called to deal cards to the Players in the GamesState
        /// Must deal 5 cards each
        /// </summary>
        public void Deal()
        {
            int numPlayers = Players.Count();
            int dealer = GetDealerPosition();
            // Start with the player after dealers position dealers position
            int currentPlayer = (dealer + 1) % numPlayers;
            Console.WriteLine($@"
            ********************************************
            {Players[currentPlayer].UserName} is the current Player
            ********************************************

            ");
            bool Dealt = false;

            while (!Dealt)
            {
                // give the card to the next player
                Card topCard = Deck.GetTopCard();
                Players[currentPlayer].Hand.Add(topCard);
                Deck.RemoveCard(topCard);

                Console.WriteLine($"Player {Players[currentPlayer].UserName} has ");
                Card.PrintCards(Players[currentPlayer].Hand);

                if (IsDealer(Players[currentPlayer]))
                {
                    if (Players[currentPlayer].IsHandFull()) Dealt = true;
                }
                currentPlayer = (currentPlayer + 1) % numPlayers;
            }

   


            
        }

        ///method to Check whether a plauer is a dealer
        private bool IsDealer(Player currentPlayer)
        {
            return currentPlayer == Dealer;
        }

       
        private void QuickPlay()
        {
            try{
            // load 2 players to the Player list (2 contructors are called here)
            ///
            /// call the method to load 1 human player and 1 ai player to the list of players
            ///
            Players.Add(new HPlayer(User.CurrentUser.UserId));
            
            Players.Add(new AIPlayer(1,Constants.DEF_AI1_NAME));

                PrintPlayerCounts();
                PrintPlayerTypes();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Load User into Players {ex}");
            }

            // one will be the user and other will be an AI player
        }

        private void PrintPlayerTypes()
        {
            foreach(Player player in Players)
            {
                Console.WriteLine($"Player type is {player.GetType()}");
            }
        }

        private  void CoopPlay()
        {
            Console.WriteLine("Loading Quicplay");
            // load 4 player to the player list (2 contructors are called here)
            Players.Add(new HPlayer(User.CurrentUser.UserId));

            Players.Add(new AIPlayer(1 ,Constants.DEF_AI1_NAME));    
            Players.Add(new AIPlayer(2, Constants.DEF_AI2_NAME));
            Players.Add(new AIPlayer(3,Constants.DEF_AI3_NAME));

            PrintPlayerCounts();

            // two will be the user and the other 2 will be AI Player

        }

        /// <summary>
        /// Method to get the position of the Dealer in the players list
        /// </summary>
        public int GetDealerPosition()
        {
            for (int i = 0; i< Players.Count; i++)
            {
                if (Players[i] == Dealer) return i;
            }
            return 100;
        }

        /// <summary>
        /// method to identify the dealer from the list of players
        /// </summary>
        /// <returns></returns>
        public Player IdentifyDealer()
        {
            foreach(Player player in Players)
            {
                if (player == Dealer) return player;

            }
            return null;
        }

        // to test the number of players in the players list
        public void PrintPlayerCounts()
        {
            int humanCount = 0;
            int aiCount = 0;

            

            Console.WriteLine($"Number of human players: {humanCount}");
            Console.WriteLine($"Number of AI players: {aiCount}");
        }
        public static bool FindBlackJack(List<Card> cards)
        {
            if (cards.Count == 0)
            {
                return false; // Base case: if the list is empty, return false
            }

            if (cards[0].IsBlackJack())
            {
                return true; // Base case: if the first card is a Black Jack, return true
            }

            cards.RemoveAt(0); // Remove the first card from the list
            return FindBlackJack(cards); // Recursive call with the updated list
        }

        //public bool 


        /// <summary>
        /// To test the dealer assigning logic
        /// </summary>
        /// <returns></returns>
        public Player StartDealerSettings(Card pickedCard)
        {
            int playerIndex = 0;
            bool blackJackFound = false;

            while (!blackJackFound)
            {
                Player currentPlayer = Players[playerIndex];
                

                if (pickedCard.IsBlackJack())
                {
                    blackJackFound = true;
                    return currentPlayer;
                }
                else
                {
                    Deck.RemoveCard(pickedCard);
                    // Switch to the next player (alternates between 0 and 1)
                    playerIndex = (playerIndex + 1) % 2;
                }



            }

            return null; // This line should never be reached
        }

        /// <summary>
        /// method to see if the current player is an AI player
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public  bool IsAIPlayer()
        {
            // get the index from the current player int
            return Turn is AIPlayer;
        }

        /// <summary>
        /// method to get the reference of the player whose turn it is
        /// </summary>
        /// <returns></returns>
        public Player GetCurrentPlayer()
        {
            return Turn;
        }
        /// <summary>
        /// Method to return the position of the current player in the Players list
        /// </summary>
        /// <returns>Index of the current player</returns>
        public int GetCurrentPlayerIndex()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i] == Turn)
                {
                    return i;
                }
            }
            // Return -1 if the current player is not found in the list
            return -1;
        }
        /// <summary>
        /// Method to get the referenc of the human player
        /// </summary>
        /// <returns></returns>
        public Player GetHumanPlayer()
        {
            foreach (Player player in Players)
            {
                if (player is HPlayer)
                {
                    return player;
                }
            }
            return null; // Return null if no human player is found
        }

        /// <summary>
        /// return true if the current player is human
        /// </summary>
        /// <returns></returns>
        public bool IsHumanPlayerTurn()
        {
            return Turn is HPlayer;
        }

        /// <summary>
        /// returns true if the dealer is human player
        /// </summary>
        /// <returns></returns>
        public bool IsHumanDealer()
        {
            return Dealer is HPlayer;
        }
    } // class ends here
}// namespace ends here

