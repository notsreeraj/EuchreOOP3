using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAL.Model
{
    public class Player : IPlayer
    {

        #region Properties
        public int PlayerID { get; set; }
        public List<Card> Hand { get; set; }
        public int Points { get; set; }
        public bool IsHuman { get; set; }

        #endregion

        #region Constructors
        public Player (int playerID, bool isHuman)
        {
            PlayerID = playerID;
            Hand = new List<Card>();
            Points = 0;
            IsHuman = isHuman; 
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Card PlayCard()
        {
            // choose the cards from the hand
            // TODO
            return null;
        }

        public Card PickCard(Deck deck)
        {
            return deck.GetTopCard();
            // Choose card from the given stack

            // TODO

        }

        /// <summary>
        /// Method to cjeck whether a hand is full
        /// </summary>
        /// <returns></returns>
        public bool IsHandFull()
        {
            // check if the player hand is full
            return (Hand.Count == 5);
        }

        /// <summary>
        /// Method to add card to hand
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool KeepCard(Card card)
        {
            if (Hand.Count() < 6)
            {
                Hand.Add(card);
                return true;
            }
            return false;
        }

        public Card AIPickCard(Deck deck)
        {
            return deck.GetTopCard();
        }

        public Card AIPlayCard()
        {
            return null;
        }
        #endregion
    }
}
