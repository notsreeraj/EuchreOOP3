using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DBAL;

namespace Model
{
    public class Card
    {
        #region Variables
        public enum Suits
        {
            Heart,
            Diamond,
            Spades,
            Clubs
        }
        public enum Ranks
        {
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace

        }

       public static Image BackTheme;
        #endregion

        #region Properties

        //private Ranks _rank;
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }
        public Image View { get; set; }

        #endregion

        #region Contructors
        public Card(Suits suit, Ranks rank, Image image)
        {
            Suit = suit;
            Rank = rank;
            View = image;

        }
        #endregion

        #region Instance 
        /// <summary>
        /// Method to represent the card object interms of string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"Suit : {Suit}, Rank : {Rank}");
        }

        /// <summary>
        /// Returns bool to see if the card is black jack or not
        /// </summary>
        /// <returns></returns>
        public bool IsBlackJack()
        {
            return (Suit == Suits.Clubs || Suit == Suits.Spades) && Rank == Ranks.Jack;

        }

        /// <summary>
        /// method which return the rank of the card ,
        /// considering the factors like right bowe and left bower
        /// </summary>
        /// <param name="trump"></param>
        /// <returns></returns>
        public int GetCardValue(Suits trump)
        {
            int baseValue = (int)Rank;

            // Check for Right Bower (Jack of Trump Suit)
            if (Suit == trump && Rank == Ranks.Jack)
            {
                return baseValue + Constants.RB_BOOST; // Highest rank
            }

            // Check for Left Bower (Jack of Same Color as Trump Suit)
            if (IsLeftBower(trump))
            {
                return baseValue + Constants.LB_BOOST; // Second highest rank
            }

            // Add boost for other trump cards
            if (Suit == trump)
            {
                return baseValue + Constants.TR_BOOST; // Boost for trump cards
            }

            // Return base value for non-trump cards
            return baseValue;
        }

        /// <summary>
        /// return bool by checking whether the card is the left bower or not
        /// </summary>
        /// <param name="trump"></param>
        /// <returns></returns>
        private bool IsLeftBower(Suits trump)
        {
            return (trump == Suits.Clubs && Suit == Suits.Spades && Rank == Ranks.Jack) ||
                   (trump == Suits.Spades && Suit == Suits.Clubs && Rank == Ranks.Jack) ||
                   (trump == Suits.Heart && Suit == Suits.Diamond && Rank == Ranks.Jack) ||
                   (trump == Suits.Diamond && Suit == Suits.Heart && Rank == Ranks.Jack);
        }

        #endregion

        #region Static Methods

        /// method to print every card in  a list of card
        public static void PrintCards(List<Card> cards)
        {
            Console.WriteLine("_");
            foreach (Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("_");

        }
        #endregion
    }
}