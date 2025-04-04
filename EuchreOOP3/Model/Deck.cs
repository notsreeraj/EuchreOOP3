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
        public Deck(int theme)
        {
            SetDeck(theme);
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




        private void SetDeck(int theme)
        {
            switch (theme)
            {
                case 0:
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
                    break;
                case 1:
                    DeckOfCards = new List<Card>
            {
                // Add Hearts
                new Card(Suits.Heart, Ranks.Ace, Resources.WYB_HA),
                new Card(Suits.Heart, Ranks.King, Resources.WYB_HK),
                new Card(Suits.Heart, Ranks.Queen, Resources.WYB_HQ),
                new Card(Suits.Heart, Ranks.Jack, Resources.WYB_HJ),
                new Card(Suits.Heart, Ranks.Ten, Resources.WYB_H10),
                new Card(Suits.Heart, Ranks.Nine, Resources.WYB_H9),

                // Add Diamonds
                new Card(Suits.Diamond, Ranks.Ace, Resources.WYB_DA),
                new Card(Suits.Diamond, Ranks.King, Resources.WYB_DK),
                new Card(Suits.Diamond, Ranks.Queen, Resources.WYB_DQ),
                new Card(Suits.Diamond, Ranks.Jack, Resources.WYB_DJ),
                new Card(Suits.Diamond, Ranks.Ten, Resources.WYB_D10),
                new Card(Suits.Diamond, Ranks.Nine, Resources.WYB_D9),

                // Add Spades
                new Card(Suits.Spades, Ranks.Ace, Resources.WYB_SA),
                new Card(Suits.Spades, Ranks.King, Resources.WYB_SK),
                new Card(Suits.Spades, Ranks.Queen, Resources.WYB_SQ),
                new Card(Suits.Spades, Ranks.Jack, Resources.WYB_SJ),
                new Card(Suits.Spades, Ranks.Ten, Resources.WYB_S10),
                new Card(Suits.Spades, Ranks.Nine, Resources.WYB_S9),

                // Add Clubs
                new Card(Suits.Clubs, Ranks.Ace, Resources.WYB_CA),
                new Card(Suits.Clubs, Ranks.King, Resources.WYB_CK),
                new Card(Suits.Clubs, Ranks.Queen, Resources.WYB_CQ),
                new Card(Suits.Clubs, Ranks.Jack, Resources.WYB_CJ),
                new Card(Suits.Clubs, Ranks.Ten, Resources.WYB_C10),
                new Card(Suits.Clubs, Ranks.Nine, Resources.WYB_C9)
            };
                    break;
                case 2:
                    DeckOfCards = new List<Card>
            {
                // Add Hearts
                new Card(Suits.Heart, Ranks.Ace, Resources.WRB_HA),
                new Card(Suits.Heart, Ranks.King, Resources.WRB_HK),
                new Card(Suits.Heart, Ranks.Queen, Resources.WRB_HQ),
                new Card(Suits.Heart, Ranks.Jack, Resources.WRB_HJ),
                new Card(Suits.Heart, Ranks.Ten, Resources.WRB_H10),
                new Card(Suits.Heart, Ranks.Nine, Resources.WRB_H9),

                // Add Diamonds
                new Card(Suits.Diamond, Ranks.Ace, Resources.WRB_DA),
                new Card(Suits.Diamond, Ranks.King, Resources.WRB_DK),
                new Card(Suits.Diamond, Ranks.Queen, Resources.WRB_DQ),
                new Card(Suits.Diamond, Ranks.Jack, Resources.WRB_DJ),
                new Card(Suits.Diamond, Ranks.Ten, Resources.WRB_D10),
                new Card(Suits.Diamond, Ranks.Nine, Resources.WRB_D9),

                // Add Spades
                new Card(Suits.Spades, Ranks.Ace, Resources.WRB_SA),
                new Card(Suits.Spades, Ranks.King, Resources.WRB_SK),
                new Card(Suits.Spades, Ranks.Queen, Resources.WRB_SQ),
                new Card(Suits.Spades, Ranks.Jack, Resources.WRB_SJ),
                new Card(Suits.Spades, Ranks.Ten, Resources.WRB_S10),
                new Card(Suits.Spades, Ranks.Nine, Resources.WRB_S9),

                // Add Clubs
                new Card(Suits.Clubs, Ranks.Ace, Resources.WRB_CA),
                new Card(Suits.Clubs, Ranks.King, Resources.WRB_CK),
                new Card(Suits.Clubs, Ranks.Queen, Resources.WRB_CQ),
                new Card(Suits.Clubs, Ranks.Jack, Resources.WRB_CJ),
                new Card(Suits.Clubs, Ranks.Ten, Resources.WRB_C10),
                new Card(Suits.Clubs, Ranks.Nine, Resources.WRB_C9)
            };
                    break;
                case 3:
                    DeckOfCards = new List<Card>
            {
                // Add Hearts
                new Card(Suits.Heart, Ranks.Ace, Resources.WO_HA),
                new Card(Suits.Heart, Ranks.King, Resources.WO_HK),
                new Card(Suits.Heart, Ranks.Queen, Resources.WO_HQ),
                new Card(Suits.Heart, Ranks.Jack, Resources.WO_HJ),
                new Card(Suits.Heart, Ranks.Ten, Resources.WO_H10),
                new Card(Suits.Heart, Ranks.Nine, Resources.WO_H9),

                // Add Diamonds
                new Card(Suits.Diamond, Ranks.Ace, Resources.WO_DA),
                new Card(Suits.Diamond, Ranks.King, Resources.WO_DK),
                new Card(Suits.Diamond, Ranks.Queen, Resources.WO_DQ),
                new Card(Suits.Diamond, Ranks.Jack, Resources.WO_DJ),
                new Card(Suits.Diamond, Ranks.Ten, Resources.WO_D10),
                new Card(Suits.Diamond, Ranks.Nine, Resources.WO_D9),

                // Add Spades
                new Card(Suits.Spades, Ranks.Ace, Resources.WO_SA),
                new Card(Suits.Spades, Ranks.King, Resources.WO_SK),
                new Card(Suits.Spades, Ranks.Queen, Resources.WO_SQ),
                new Card(Suits.Spades, Ranks.Jack, Resources.WO_SJ),
                new Card(Suits.Spades, Ranks.Ten, Resources.WO_S10),
                new Card(Suits.Spades, Ranks.Nine, Resources.WO_S9),

                // Add Clubs
                new Card(Suits.Clubs, Ranks.Ace, Resources.WO_CA),
                new Card(Suits.Clubs, Ranks.King, Resources.WO_CK),
                new Card(Suits.Clubs, Ranks.Queen, Resources.WO_CQ),
                new Card(Suits.Clubs, Ranks.Jack, Resources.WO_CJ),
                new Card(Suits.Clubs, Ranks.Ten, Resources.WO_C10),
                new Card(Suits.Clubs, Ranks.Nine, Resources.WO_C9)
            };
                    break;
                case 4:
                    DeckOfCards = new List<Card>
            {
                // Add Hearts
                new Card(Suits.Heart, Ranks.Ace, Resources.RB_HA),
                new Card(Suits.Heart, Ranks.King, Resources.RB_HK),
                new Card(Suits.Heart, Ranks.Queen, Resources.RB_HQ),
                new Card(Suits.Heart, Ranks.Jack, Resources.RB_HJ),
                new Card(Suits.Heart, Ranks.Ten, Resources.RB_H10),
                new Card(Suits.Heart, Ranks.Nine, Resources.RB_H9),

                // Add Diamonds
                new Card(Suits.Diamond, Ranks.Ace, Resources.RB_DA),
                new Card(Suits.Diamond, Ranks.King, Resources.RB_DK),
                new Card(Suits.Diamond, Ranks.Queen, Resources.RB_DQ),
                new Card(Suits.Diamond, Ranks.Jack, Resources.RB_DJ),
                new Card(Suits.Diamond, Ranks.Ten, Resources.RB_D10),
                new Card(Suits.Diamond, Ranks.Nine, Resources.RB_D9),

                // Add Spades
                new Card(Suits.Spades, Ranks.Ace, Resources.RB_SA),
                new Card(Suits.Spades, Ranks.King, Resources.RB_SK),
                new Card(Suits.Spades, Ranks.Queen, Resources.RB_SQ),
                new Card(Suits.Spades, Ranks.Jack, Resources.RB_SJ),
                new Card(Suits.Spades, Ranks.Ten, Resources.RB_S10),
                new Card(Suits.Spades, Ranks.Nine, Resources.RB_S9),

                // Add Clubs
                new Card(Suits.Clubs, Ranks.Ace, Resources.RB_CA),
                new Card(Suits.Clubs, Ranks.King, Resources.RB_CK),
                new Card(Suits.Clubs, Ranks.Queen, Resources.RB_CQ),
                new Card(Suits.Clubs, Ranks.Jack, Resources.RB_CJ),
                new Card(Suits.Clubs, Ranks.Ten, Resources.RB_C10),
                new Card(Suits.Clubs, Ranks.Nine, Resources.RB_C9)
            };
                    break;
            }
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