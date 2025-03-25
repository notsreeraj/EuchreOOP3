using DBAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreView.model
{
    class HPlayer : Player
    {


        #region Constructor
        public HPlayer(int playerID) : base(playerID)
        {
            UserName = User.GetUseName(playerID);
        }
        #endregion


        #region Instance method
        public override Card PickCard(Deck deck)
        {
            Console.WriteLine("Human Is Picked a card");
            return deck.GetTopCard();
        }

        public override Card PlayCard()
        {
            // TODO
            throw new NotImplementedException();
        }


        /// <summary>
        /// Method which exchanges the top card at the deck with the selected card by the user 
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="selectedCard"></param>
        public void ExchangeCard(Deck deck, Card selectedCard)
        {

        }
        #endregion
    }
}