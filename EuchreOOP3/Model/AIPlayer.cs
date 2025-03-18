using DBAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreView.model
{
    class AIPlayer : Player
    {

        public AIPlayer(int playerID, string userName) : base(playerID)
        {
            UserName = userName;
        }

        /// <summary>
        /// Method to let AI pick a card from the given deck 
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public override Card PickCard(Deck deck)
        {
            // Custom logic for AI player

            Console.WriteLine("  AIPlayer: pickcard method is Called .");
            return deck.GetTopCard();
        }

        public override Card PlayCard()
        {
            // Custom logic for AI player
            Console.WriteLine("AIPlayer: AI is playing a card.");
            return null;
        }



        public void TestPickCard()
        {
            Console.WriteLine("AI picked a card");
        }




    }
}