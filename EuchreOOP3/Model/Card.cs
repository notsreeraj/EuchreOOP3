using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Model
{
    public class Card
    {
        #region Variables
        public  enum Suits
        {
            Heart,
            Diamond,
            Spades,
            Clubs
        }
        public enum Ranks
        {
            Ace,
            King,
            Queen,
            Jack,
            Ten = 10,
            Nine = 9,
        }
        #endregion

        #region Properties

        //private Ranks _rank;
        public Suits Suit { get; set; }
        public  Ranks Rank { get; set; }
        public Image View { get; set; }

        #endregion

        #region Contructors
        public Card(Suits suit , Ranks rank , Image image )
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

        ///
        public bool IsBlackJack()
        {
            return (Suit == Suits.Clubs || Suit == Suits.Spades) && Rank == Ranks.Jack ;
   
        }
        #endregion

        #region Static Methods

        /// method to print every card in  a list of card
        public static void PrintCards(List<Card> cards)
        {
            Console.WriteLine("_______________________________________");
            foreach(Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("_______________________________________");

        }
        #endregion
    }
}
