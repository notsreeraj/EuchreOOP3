using DBAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public override Card PlayCard( Card card ,List<Card> tricks)
        {
            // take in the card to play
            Card playCard = card;
            int cardIndex = GetCardIndex(card);

            Hand.Remove(card);
            LoadPlayerHand();

            // the playcard will be the card from the hand , so find the index of the card or just remove them directly
            // getting the index of the card will be a good idea because we also need to update the handview list cause that contains the referene of the picture boxes inside frmGame
            return playCard;
            // TODO
           // throw new NotImplementedException();
        }


        /// <summary>
        /// method called to exchange card based on users click
        /// </summary>
        /// <param name="selectedCard"></param>
        /// <param name="deck"></param>
        /// <param name="trumpSuit"></param>
        /// <returns></returns>
        public bool ExchangeSelectedCard(Card selectedCard, Deck deck, Card.Suits trumpSuit)
        {
            // Ensure the selected card is in the player's hand
            if (Hand.Contains(selectedCard))
            {
                // Check if the selected card has the same suit as the trump suit
                if (selectedCard.Suit == trumpSuit)
                {
                    Console.WriteLine("Cannot exchange a card with the same suit as the trump suit.");
                    return false;
                }

                // Get the top card from the deck
                Card topCardFromDeck = deck.GetTopCard();
                deck.RemoveCard(topCardFromDeck);
                Console.WriteLine($"{topCardFromDeck.ToString()} has been removed from the Deck by the dealer");

                // Remove the selected card from the player's hand
                Hand.Remove(selectedCard);

                // Add the selected card to the deck
                deck.AddCard(selectedCard);

                // Add the top card from the deck to the player's hand
                Hand.Add(topCardFromDeck);
                Console.WriteLine($"{selectedCard.ToString()} has been exchanged with {topCardFromDeck.ToString()}");

                // Update the UI to reflect the card exchange
                LoadPlayerHand();

                return true;
            }
            else
            {
                Console.WriteLine("Selected card is not in the player's hand.");
                return false;
            }
        }

        #endregion
    }
}