using EuchreOOP3.Properties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Card;

namespace Model
{
    public class Deck
    {
        #region Variables

        #endregion

        #region Properties
        public List<Card> DeckOfCards { get; set; }
        public event EventHandler DeckChanged;

        #endregion

        #region Contructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Deck()
        {
            SetDeck();
            this.Shuffle();

            // OnDeckChanged();

        }


        #endregion

        #region Instance 

        /// <summary>
        /// Method to raise the event and invoke any method subscibed to this event
        /// </summary>
        protected virtual void OnDeckChanged()
        {
            Console.WriteLine("DeckChanged Event is raised");
            DeckChanged?.Invoke(this, EventArgs.Empty);
        }




        /// <summary>
        /// method to set the deck of cards 
        /// </summary>
        private void SetDeck()
        {
            DeckOfCards = new List<Card>
            {
                // Add Hearts
                new Card(Suits.Heart, Ranks.Ace, Resources.WG_HA),
                new Card(Suits.Heart, Ranks.King, Resources.WG_HK),
                new Card(Suits.Heart, Ranks.Queen, Resources.WG_HQ),
                new Card(Suits.Heart, Ranks.Jack, Resources.WG_HJ),
                new Card(Suits.Heart, Ranks.Ten, Resources.WG_HT),
                new Card(Suits.Heart, Ranks.Nine, Resources.WG_H9),

                // Add Diamonds
                new Card(Suits.Diamond, Ranks.Ace, Resources.WG_DA),
                new Card(Suits.Diamond, Ranks.King, Resources.WG_DK),
                new Card(Suits.Diamond, Ranks.Queen, Resources.WG_DQ),
                new Card(Suits.Diamond, Ranks.Jack, Resources.WG_DJ),
                new Card(Suits.Diamond, Ranks.Ten, Resources.WG_DT),
                new Card(Suits.Diamond, Ranks.Nine, Resources.WG_D9),

                // Add Spades
                new Card(Suits.Spades, Ranks.Ace, Resources.WG_SA),
                new Card(Suits.Spades, Ranks.King, Resources.WG_SK),
                new Card(Suits.Spades, Ranks.Queen, Resources.WG_SQ),
                new Card(Suits.Spades, Ranks.Jack, Resources.WG_SJ),
                new Card(Suits.Spades, Ranks.Ten, Resources.WG_ST),
                new Card(Suits.Spades, Ranks.Nine, Resources.WG_S9),

                // Add Clubs
                new Card(Suits.Clubs, Ranks.Ace, Resources.WG_CA),
                new Card(Suits.Clubs, Ranks.King, Resources.WG_CK),
                new Card(Suits.Clubs, Ranks.Queen, Resources.WG_CQ),
                new Card(Suits.Clubs, Ranks.Jack, Resources.WG_CJ),
                new Card(Suits.Clubs, Ranks.Ten, Resources.WG_CT),
                new Card(Suits.Clubs, Ranks.Nine, Resources.WG_C9)
            };


        }
        /// to view the cards in the deck 
        public void ViewCards()
        {
            Console.WriteLine("*");
            foreach (Card card in DeckOfCards)
            {
                Console.WriteLine($"Card: {card.ToString()}");
            }
            Console.WriteLine("*");

        }


        /// <summary>
        /// Returns the card at the top of the deck
        /// </summary>
        /// <returns></returns>
        public Card GetTopCard()
        {
            if (DeckOfCards.Count > 1)
            {
                return DeckOfCards[DeckOfCards.Count - 1];
            }
            throw new Exception("Not Enough Cards in the deck");

        }


        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = DeckOfCards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (DeckOfCards[i], DeckOfCards[j]) = (DeckOfCards[j], DeckOfCards[i]);
            }
        }

        /// <summary>
        /// Method to remove the card in the argument and also is subscribed to the deckChange event
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCard(Card card)
        {
            DeckOfCards.Remove(card);
            //OnDeckChanged();
        }

        public void AddCard(Card card)
        {
            DeckOfCards.Add(card);
            OnDeckChanged();
        }
        #endregion

        #region Static Methods




        #endregion
    }
}