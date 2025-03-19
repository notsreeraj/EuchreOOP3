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
        public  string CurrentPlayer = GameController.Game.Turn.UserName;
        public frmGame()
        {
            InitializeComponent();
            MapHandPanels();
            
            
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            // load the deck to the picture box , 
            // Display the last card in the deck to the user using the picture box using a method in gameController
            
            SetDeck();

            SetPlayers();
            panDealer.Visible = true;
            lblCurrentPlayer.Text = GameController.Game.Turn.UserName;




        }

        private void panBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetDeck()
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
            LoadPlayerHandDis();
            GenerateTrickPictureBoxes(GameController.GetNumPlayers());
        }

        /// method which just maps the handPanels to an array of panel to access them
        private void MapHandPanels()
        {
            HandPanels.Add(panTop);
            HandPanels.Add(panBottom);
            HandPanels.Add(panRight);
            HandPanels.Add(panLeft);
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
        private void LoadPlayerHandDis()
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
            }
            else
            {
                HandPanels[0].Visible = true;
                HandPanels[1].Visible = true;
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

            // let the player pick the card (pickCard)
            // change the bgImage of the PB to the view of the card returned by the method
            // check if it is a black jack
            // if it is black jack assign the dealer position to the current player (ideally refer the property of the gamestate class)
            // if it is not remove the card from the deck and give the next player the chance to pick the card
            // update the current player
            // if the current player is AI call the method from AIPlayer to pick the card

            Card PickedCard = GameController.Game.Turn.PickCard(GameController.Game.Deck);
            
            pbPickedCard.BackgroundImage = PickedCard .View;

            if (PickedCard.IsBlackJack())
            {
                GameController.Game.Dealer = GameController.Game.Turn;
                GameController.dealerSet = true;
            }
            GameController.Game.Deck.RemoveCard(PickedCard);

            GameController.UpdateCurrentPlayer(lblCurrentPlayer);
            
            



        }


        #region Animation
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

        private void lblCurrentPlayer_TextChanged(object sender, EventArgs e)
        {
            // check if the dealer has been set
            if (GameController.dealerSet)
            {
                MessageBox.Show($"Dealer has been set as {GameController.Game.Dealer}");
            }


            // this can work fro all three gamemodes , Dealer setting , Trump selection , Tricks
            Constants.GameModes gameMode = GameController.Game.GameMode;
            // call the MakeMove in GameController
            if (GameController.Game.IsAIPlayer())
            {
                GameController.MakeMoveAI(gameMode);
                MessageBox.Show($"{GameController.Game.Turn.UserName} made his Move");
                

                GameController.UpdateCurrentPlayer(lblCurrentPlayer);
            }
            
        }
    }
}
    