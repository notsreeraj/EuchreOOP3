using DBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Model
{
    public abstract class Player
    {



        #region Properties
        public int PlayerID { get; set; }
        public List<Card> Hand { get; set; }
        public int Points { get; set; }
        public string UserName { get; set; }
        public List<PictureBox> HandView { get; set; }

        #endregion
        #region Constructor
        public Player(int playerID)
        {
            PlayerID = playerID;

            Hand = new List<Card>();
            Points = 0;
            HandView = new List<PictureBox>();
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// method called to play a card from the hand of the player
        /// </summary>
        public abstract Card PlayCard();

        /// <summary>
        /// method to pick a card from the deck of cards in in the game
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public abstract Card PickCard(Deck deck);


        /// <summary>
        /// method to check whether a hand is full
        /// </summary>
        /// <returns></returns>
        public bool IsHandFull()
        {
            // check if the players hand is full
            return (Hand.Count == 5);
        }


        /// <summary>
        /// method to Add card to Hand
        /// </summary>
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

        /// <summary>
        /// Methodd to map the reference of each picture box in a panel to the HandViewList
        /// </summary>
        /// <param name="panHand"></param>
        public void MapHand(Panel panHand)
        {
            foreach(Control control in panHand.Controls)
            {
                if(control is PictureBox pictureBox)
                {
                    HandView.Add(pictureBox);
                }
            }

        }

        public void LoadPlayerHand()
        {
            for (int i = 0; i < Hand.Count && i < HandView.Count; i++)
            {
                HandView[i].BackgroundImage = Hand[i].View;
                HandView[i].BackgroundImageLayout = ImageLayout.Stretch; // Optional: to ensure the image fits the PictureBox
            }
        }

        public void ExchangeSelectedCard(Card selectedCard , Deck deck)
        {

        }

        #endregion

    }

}