using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface Iplayer
    {
        #region Properties
        int PlayerID { get; set; }
        List<Card> Hand { get; set; }
        int Points { get; set; }

        #endregion


        #region Instance Methods
        /// <summary>
        /// method to pick a card from the list of cards
        /// if the hand is full, user must play a card and then pick a card
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        Card PickedCard(Deck deck);
        /// <summary>
        /// method to play a card from their hand
        /// </summary>
        /// <returns></returns>
        Card PlayCard();

        #endregion
    }
}
