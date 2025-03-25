using Controller;
using DBAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EuchreOOP3
{
    public partial class frmGame : Form
    {
        public static List<Panel> HandPanels = new List<Panel>();
        public static List<PictureBox> Tricks = new List<PictureBox>();
        //public static List<PictureBox> PickedCards = new List<PictureBox>();
        public  string CurrentPlayer = GameController.Game.Turn.UserName;


        // Add this public property to access label5
        public Label LblDealerName
        {
            get { return lblDealerName; }
        }
        public frmGame()
        {
            InitializeComponent();
            MapHandPanels();
            MapPickedCardsPB();




        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            // load the deck to the picture box , 
            // Display the last card in the deck to the user using the picture box using a method in gameController
            
            ShowDeck();

            SetPlayers();
            panDealer.Visible = true;
            lblCurrentPlayer.Text = GameController.Game.Turn.UserName;
            //AnimatePanelToLocation(panDealer, 276,148, 50);


        }

        private void panBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private  void ShowDeck()
        {
            pbDeck.BackgroundImage = GameController.ViewTopCard(GameController.Game.Deck);
            pbDeck.BackgroundImageLayout = ImageLayout.Stretch; 
        }
        
        private void SetPlayers()
        {
            // set up everything related to a player in the form
            /*
             Player Identification 
            Player points 
            Player hand


             */
            LoadPlayerControlObjects();
            GenerateTrickPictureBoxes(GameController.GetNumPlayers());
            // method to map the Player handVIew list to the pb in each panel
            // we must do this for every player in the list of players in the deck
        }

        /// method which just maps the handPanels to an array of panel to access them
        private void MapHandPanels()
        {
            HandPanels.Add(panBottom);
            HandPanels.Add(panTop);
            HandPanels.Add(panRight);
            HandPanels.Add(panLeft);
        }
       
        /// <summary>
        /// method to map the picture boxes which show which card was picked by the player
        /// while setting dealer to list of pb called PickedCards
        /// </summary>
        private void MapPickedCardsPB()
        {
            GameController.PickedCards.Add(pbHPickedCard);
            GameController.PickedCards.Add(pbAI1Pick);
            GameController.PickedCards.Add(pbAI2Pick);
            GameController.PickedCards.Add(pbAI3Pick);
        }

        /// <summary>
        /// method to map generated picture boxes to a list of pbs
        /// </summary>
        private void MapTrickPB()
        {

        }

        /// <summary>
        /// method to show the panel of player hands according to the number of players in the players list in gamestate
        /// </summary>
        private void LoadPlayerControlObjects()
        {
            // load the panels according to the number of players
            // this should be dynamic
            int numberOfPlayers = GameController.GetNumPlayers();
            if(numberOfPlayers !=2)
            {

                HandPanels[0].Visible = true;
                HandPanels[1].Visible = true;
                HandPanels[2].Visible = true;
                HandPanels[3].Visible = true;

                
                GameController.PickedCards[2].Visible = true;
                GameController.PickedCards[3].Visible = true;

            }
            else
            {
                HandPanels[0].Visible = true;
                HandPanels[1].Visible = true;

                GameController.PickedCards[0].Visible = true;
                GameController.PickedCards[1].Visible = true;
            }
        }

        private void LoadCardsToEachPictureBox()
        {
            int numberOfPlayers = GameController.GetNumPlayers();
            List<Player> players = GameController.Game.Players;
            if(numberOfPlayers != 2)
            {
                GameController.LoadHandToView(panBottom, players[0]);
                GameController.LoadHandToView(panLeft, players[1]);
                GameController.LoadHandToView(panRight, players[2]);
                GameController.LoadHandToView(panTop, players[3]);
                 
            }
            else
            {
                GameController.LoadHandToView(panBottom, players[0]);
                GameController.LoadHandToView(panTop, players[1]);


            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbDeck_Click(object sender, EventArgs e)
        {
            // clicking on this object must imitate the player picking up a card from the deck
            // prepare another panel just with a deck and icons to represent the players
        }

        /// <summary>
        /// Generates specified number of picture boxes in the trick panel
        /// </summary>
        /// <param name="numberOfBoxes">Number of picture boxes to generate</param>
        private void GenerateTrickPictureBoxes(int numberOfBoxes)
        {
            // Clear existing picture boxes from the panel
            panTrick.Controls.Clear();
            Tricks.Clear();

            // Calculate spacing between picture boxes
            int spacing = 10; // pixels between each picture box
            int totalWidth = (175 * numberOfBoxes) + (spacing * (numberOfBoxes - 1));
            int startX = (panTrick.Width - totalWidth) / 2; // Center the picture boxes

            for (int i = 0; i < numberOfBoxes; i++)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(175, 244),
                    Location = new Point(startX + (i * (175 + spacing)), (panTrick.Height - 244) / 2),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // Add to both the panel and our list of trick picture boxes
                panTrick.Controls.Add(pb);
                Tricks.Add(pb);
            }
        }

        

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmOptions settings = new frmOptions();
            settings.ShowDialog();
            // make sure to load resume button and whichever button is loaded


           // AnimatePanelLeft();
        }



        private void pbDealerDeck_Click(object sender, EventArgs e)
        {

            Card PickedCard = GameController.Game.Turn.PickCard(GameController.Game.Deck);

            // pbHPickedCard.BackgroundImage = PickedCard .View;
            GameController.ShowPickedCards(PickedCard);
            GameController.Game.Deck.RemoveCard(PickedCard);
            

            if (!PickedCard.IsBlackJack() && GameController.HasEnoughCardsForPlayers())
            {
                GameController.UpdateCurrentPlayer(lblCurrentPlayer);
            }
            else 
            {
                GameController.dealerSet = true;
                GameController.Game.Dealer = GameController.Game.Turn;
       
                
                //AnimatePanelDown(panDealer, 50);
                lblDealerName.Text += GameController.Game.Dealer.UserName;
                MessageBox.Show($"{GameController.Game.Turn.UserName} got the First Black Jack!! He is the dealer"); 
                AnimatePanelDown(panDealer, 50);
                //AnimatePanelToLocation(panTrumpChoices, 650, 648, 50);


                // run the method to set up the new deck and deal the hands
            }

        }


        #region Animation
        /// <summary>
        /// ALl these methods are generated by Copilot with prompt
        /// </summary>
        private Timer panelDownTimer;
        private int targetY;
        private const int VerticalAnimationSpeed = 20;

        /// <summary>
        /// Initializes and starts the animation to move panel down
        /// </summary>
        /// <param name="panel">The panel to animate</param>
        /// <param name="distance">Distance to move down in pixels</param>
        private void AnimatePanelDown(Panel panel, int distance)
        {

            // Store target Y position
            targetY = panel.Location.Y + distance;

            // Initialize timer if it hasn't been created yet
            if (panelDownTimer == null)
            {
                panelDownTimer = new Timer();
                panelDownTimer.Interval = 16; // Approximately 60 FPS
                panelDownTimer.Tick += (sender, e) => PanelDownTimer_Tick(panel);
            }

            // Start the animation
            panelDownTimer.Start();
                    }

        /// <summary>
        /// Timer tick event handler that handles the downward animation
        /// </summary>
        private void PanelDownTimer_Tick(Panel panel)
        {
            // Calculate new Y position
            int currentY = panel.Location.Y;

            if (currentY < targetY)
            {
                // Move the panel down
                panel.Location = new Point(
                    panel.Location.X,
                    currentY - VerticalAnimationSpeed
                );
            }
            else
            {
                // Animation complete
                panelDownTimer.Stop();
                // Ensure panel is exactly at target position
                panel.Location = new Point(panel.Location.X, targetY);
                // Hide the panel
                panel.Visible = false;
            }
        }
        #endregion

   
        /// <summary>
        /// this triggers when the lable showing whos turn it is updated when the UpdateCurrentPlayer is called 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCurrentPlayer_TextChanged(object sender, EventArgs e)
        {

            // this can work fro all three gamemodes , Dealer setting , Trump selection , Tricks
            Constants.GameModes gameMode = GameController.Game.GameMode;
            // call the MakeMove in GameController
            if (GameController.Game.IsAIPlayer() && GameController.HasEnoughCardsForPlayers())
            {
                GameController.MakeAIMove(gameMode, this);

                if (GameController.dealerSet && (GameController.Game.Dealer == GameController.Game.Turn))
                {
                    MessageBox.Show($"{GameController.Game.Turn.UserName} got the First Black Jack!! He is the dealer");
                    
                    AnimatePanelDown(panDealer, 50);
                    
                }
                GameController.UpdateCurrentPlayer(lblCurrentPlayer);
                // check if the dealer has been set
            }

        }


       
        /// <summary>
        /// event handler to set up the next mode of the gamestate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDealerName_TextChanged(object sender, EventArgs e)
        {
            GameController.Game.Deck = new Deck();
            
            GameController.Game.GameMode = Constants.GameModes.TrumpSetting;
            GameController.Game.Deal();
            ShowDeck();
            pbDeck.Visible = true;

            // assign the intitial potential trump
            GameController.Game.Trump = GameController.Game.Deck.GetTopCard().Suit;

            lblTrmpSuit.Text += GameController.Game.Trump.ToString();
            /// call the method to load the cards to the panel 
            LoadCardsToEachPictureBox();
            
        }

        private void btnOrderUp_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPass_Click(object sender, EventArgs e)
        {

        }


    }
}
    