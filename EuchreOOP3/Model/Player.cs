using Controller;
using DBAL;
using EuchreOOP3.Properties;
using EuchreView.model;
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
        public event EventHandler HandChange;

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
        /// this is to raise the handChange event 
        /// </summary>
        protected virtual void OnHandChange()
        {
            Console.WriteLine("Hand change event raised");
            HandChange?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// method called to play a card from the hand of the player
        /// </summary>
        public abstract Card PlayCard(Card card , List<Card> tricks);

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

        /// <summary>
        /// method to load the images to the handview list of picture boxes 
        /// </summary>
        public void LoadPlayerHand()
        {
            // maybe add a verification 

            ResetHandView();

            for (int i = 0; i < Hand.Count && i < HandView.Count; i++)
            {
                
                HandView[i].BackgroundImage = Hand[i].View;
                HandView[i].BackgroundImageLayout = ImageLayout.Stretch; 
                
            }

            //if(this is AIPlayer)
            //{
            //    HandView[i].BackgroundImage = ;
            //    HandView[i].BackgroundImageLayout = ImageLayout.Stretch;
            //}
            // this will raise the HandChange Event
            OnHandChange();
        }

        // 
        public static void ChangeAIHandView()
        {
            foreach (Player player in GameController.Game.Players)
            {
                if (!(player is HPlayer))
                {
                    foreach (Card card in player.Hand)
                    {
                        card.View = Card.BackTheme;
                    }
                }
            }
        }
        
        

        /// <summary>
        /// method to reset the hand view
        /// </summary>
        public void ResetHandView()
        {
            foreach (PictureBox pb in HandView)
            {
                pb.BackgroundImage = null;
            }
        }

        /// <summary>
        /// event handler for the HandChange event which update the handView property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateHandView(object sender , EventArgs e)
        {
            // call the method to update the handView property
            // take the hand
            
        }

        /// <summary>
        /// method to get the index of the picked card to play
        /// </summary>
        /// <param name="selectedCard"></param>
        /// <param name="deck"></param>
        public int GetCardIndex(Card card)
        {
            
            for (int i = 0;i < Hand.Count;i++)
            {
                if (Hand[i] == card)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

    }

}