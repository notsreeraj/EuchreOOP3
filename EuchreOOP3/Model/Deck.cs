using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Deck
    {
        #region Variables

        #endregion

        #region Properties
        public List<Card> DeckOfCards { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Deck()
        {
            SetDeck();
        }
        #endregion

        #region Instance
        /// <summary>
        /// Method to set the deck of cards
        /// </summary>
        private void SetDeck()
        {
            DeckOfCards = new List<Card>();
            // Testing
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                foreach (Card.Ranks rank in Enum.GetValues(typeof(Card.Ranks)))
                {
                    DeckOfCards.Add(new Card(suit, rank));
                }
            }
        }
        /// <summary>
        /// To view the cards in the deck testing
        /// </summary>
        public void ViewCards()
        {
            Console.WriteLine("***************************************");
            foreach (Card card in DeckOfCards)
            {
                Console.WriteLine($"Card: {card.ToString()}");
            }
            Console.WriteLine("***************************************");

        }
         /// <summary>
         /// Return the card at the top of the deck
         /// </summary>
         /// <returns></returns>
        public Card GetTopCard()
        {
            return DeckOfCards[DeckOfCards.Count - 1];
        }

        /// <summary>
        /// Shuffle the deck of cards
        /// </summary>
        public void shuffle()
        {
            Random rng = new Random();
            for (int i = DeckOfCards.Count -1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (DeckOfCards[i], DeckOfCards[j]) = (DeckOfCards[j], DeckOfCards[i]);
            }
        }

        public void RemoveCardAtTop(Card card)
        {
            DeckOfCards.Remove(card);
        }
        #endregion

        #region Static Methods

        #endregion
    }

}
