﻿using Controller;
using DBAL;
using EuchreOOP3.Properties;
using EuchreView.model;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace EuchreOOP3
{
    public partial class frmGame : Form
    {
        public static List<Panel> HandPanels = new List<Panel>();
        public static List<PictureBox> Tricks = new List<PictureBox>();
        //public static List<PictureBox> PickedCards = new List<PictureBox>();
        public  string CurrentPlayer = GameController.Game.Turn.UserName;
        public static bool IsLoading = false;


        // Add this public property to access label5
        public Label LblDealerName
        {
            get { return lblDealerName; }
        }
        public Label LblPlayerDecideTrump 
        {
            get { return lblPlayerDecideTrump; } 
        }

        public Label LbltrumpSuit 
        {
            get {return lblTrmpSuit; }                 
        }

        public Label LblMessage { get { return lblMessage; } }
        public Button BtnPass { get { return btnPass; } }
        public Button BtnOrderUp { get { return btnOrderUp; } }
        public frmGame()
        {
            InitializeComponent();
            MapHandPanels();
            MapPickedCardsPB();
            SubscribeToDeckChangeEvent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            IsLoading = true;
            // load the deck to the picture box , 
            // Display the last card in the deck to the user using the picture box using a method in gameController
            LoadPanelToLocation(panDealer, 296, 186);

            ShowDeck();

            SetPlayers();
            
            lblCurrentPlayer.Text = GameController.Game.Turn.UserName;
           // panDealer.Location = new System.Drawing.Point(296,186);
            

            IsLoading = false;
            


        }
        /// <summary>
        /// method which just subscirbe the event handler to the deckchange event
        /// </summary>
        public  void SubscribeToDeckChangeEvent()
        {
            GameController.Game.Deck.DeckChanged += UpdateDeckVIew;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panBottom_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Event handler which is subscribed to the DeckChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDeckVIew(object sender , EventArgs e)
        {   
                ShowDeck();    
        }

        private  void ShowDeck()
        {
            pbDeck.BackgroundImage = null;
            pbDeck.BackgroundImage = GameController.ViewTopCard(GameController.Game.Deck);
            pbDeck.BackgroundImageLayout = ImageLayout.Stretch; 
        }
        
        private void SetPlayers()
        {
            pbDealerDeck.BackgroundImage = Card.BackTheme;

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
        /// Loads a panel into a specific location.
        /// </summary>
        /// <param name="panel">The panel to be moved.</param>
        /// <param name="x">The x-coordinate of the new location.</param>
        /// <param name="y">The y-coordinate of the new location.</param>
        private void LoadPanelToLocation(Panel panel, int x, int y)
        {
            if (panel != null)
            {
                panel.Visible = true;
                panel.Location = new Point(x, y);
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

            if(GameController.Passed || GameController.OrderedUp && !GameController.Game.IsAIPlayer())
            {
                // call the exchange card method
            }
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

        



        /// <summary>
        /// event handler which handler the action of picking a card from the deck to find a black jack and assign the dealer role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbDealerDeck_Click(object sender, EventArgs e)
        {

            if( GameController.HasEnoughCardsForPlayers())
            {
                // to reset the picture boxes
                GameController.ResetPickedCardPB();

                Card PickedCard = GameController.Game.Turn.PickCard(GameController.Game.Deck);

                // pbHPickedCard.BackgroundImage = PickedCard .View;
                GameController.ShowPickedCards(PickedCard);
                GameController.Game.Deck.RemoveCard(PickedCard);


                    if (!PickedCard.IsBlackJack() && GameController.Game.GameMode == Constants.GameModes.DealerSetting)
                    {
                        GameController.UpdateCurrentPlayer(lblCurrentPlayer);
                    }
                    else
                    {
                        GameController.dealerSet = true;
                        GameController.Game.Dealer = GameController.Game.Turn;


                        //AnimatePanelDown(panDealer, 50);

                        MessageBox.Show($"{GameController.Game.Turn.UserName} got the First Black Jack!! He is the dealer");
                        MessageBox.Show("The Dealer has been Set. Click Ok to initiate the Trump deciding Mode");

                        AnimatePanelDown(panDealer, 50);
                        lblDealerName.Text += GameController.Game.Dealer.UserName;

                    }
            }
            else
            {
                MessageBox.Show("We are out of cards. Click Ok to set a new deck of cards");
                GameController.Game.Deck = new Deck(GameController.Theme);

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
            if (!IsLoading && GameController.Game.IsAIPlayer())
            {
                // this can work fro all three gamemodes , Dealer setting , Trump selection , Tricks
                Constants.GameModes gameMode = GameController.Game.GameMode;
                // call the MakeMove in GameController
                if (GameController.HasEnoughCardsForPlayers())
                {
                    if ( gameMode == Constants.GameModes.DealerSetting)
                    {
                        GameController.MakeAIMove(gameMode, this);

                        if (GameController.dealerSet && (GameController.Game.Dealer == GameController.Game.Turn))
                        {
                            MessageBox.Show($"{GameController.Game.Turn.UserName} got the First Black Jack!! He is the dealer");
                            LblDealerName.Text += GameController.Game.Dealer.UserName;
                            AnimatePanelDown(panDealer, 50);
                            //LblDealerName.Text += GameController.Game.Dealer.UserName;
                        }
                        else
                        {
                            GameController.UpdateCurrentPlayer(lblCurrentPlayer);
                        }

                        // check if the dealer has been set
                    }

                }
                else
                {
                    MessageBox.Show("We are out of cards. Click Ok to set a new deck of cards");
                    GameController.Game.Deck = new Deck(GameController.Theme);
                }
            }
        }


       
        /// <summary>
        /// event handler to set up the next mode of the gamestate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDealerName_TextChanged(object sender, EventArgs e)
        {
            if(!IsLoading)
            {

                // setting up new deck
                GameController.Game.Deck = new Deck(GameController.Theme);
                SubscribeToDeckChangeEvent();


                GameController.Game.GameMode = Constants.GameModes.TrumpSetting;// changing the game mode

                GameController.Game.Deal(); // dealing the cards among players
                ShowDeck(); // setting the deck to view
                pbDeck.Visible = true;

                // calll the method to change the image of the hands of ai player
                Player.ChangeAIHandView();

                // assign the intitial potential trump
                GameController.Game.Trump = GameController.Game.Deck.GetTopCard().Suit;

                lblTrmpSuit.Text += GameController.Game.Trump.ToString();
                /// call the method to load the cards to the panel 
                LoadCardsToEachPictureBox();

                // initiate the next mode of the game by setting up the first non-dealer after the dealer to the label
                GameController.UpdateCurrentPlayer(lblPlayerDecideTrump); 
            }
            
        }

        private void btnOrderUp_Click(object sender, EventArgs e)
        {

            if (GameController.Game.Dealer != GameController.Game.Turn)
            {
                // add the current player in turn to makers list 
                GameController.Game.Makers.Add(GameController.Game.Turn);

                GameController.OrderedUp = true;
                GameController.AssignTurnToDealer(lblPlayerDecideTrump);
                
            }


        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if(GameController.Game.Dealer == GameController.Game.Turn)
            {
                Console.WriteLine("The user is the dealer");
                GameController.DealerPassed = true;
            }

                GameController.Passed = true;

                
            // when clikc the next player is given a chance
            GameController.UpdateCurrentPlayer(lblPlayerDecideTrump);
            Console.WriteLine($"From frmGame pass click : {GameController.Game.Turn.UserName} is the player in turn");


        }
        private void lblPlayerDecideTrump_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("*********************************Initializing trump decision mode*********************************");

            if (!IsLoading)
            {
                

                if (GameController.Game.IsAIPlayer())
                {
                    Console.WriteLine($"AI Player's turn: {GameController.Game.Turn.UserName}");
                    Constants.GameModes gameMode = GameController.Game.GameMode;
                    GameController.MakeAIMove(gameMode, this);
                }
                else
                {
                    Console.WriteLine($"Human Player's turn: {GameController.Game.Turn.UserName}");
                    MakeHumanMove();
                }
                InitiateTricksRound();
            }
            else
            {
                Console.WriteLine("Game is still loading - skipping trump decision logic");
            }
        }

        #region Human Move

        private void MakeHumanMove()
        {
            Console.WriteLine("MakeHumanMove called");

            MessageBox.Show($"OrderedUp: {GameController.OrderedUp}, Passed: {GameController.Passed}, DealerPassed: {GameController.DealerPassed}");
           

            if (GameController.Game.Dealer == GameController.Game.Turn)
            {
                UnsubscribeExchangeCardFromHand();
                MessageBox.Show("You are the dealer");
                HumanDealerMove();
            }
            else
            {
                UnsubscribeExchangeCardFromHand();
                Console.WriteLine("Human player is NOT the dealer");
                HumanNonDealerMove();
            }
        }

        private void HumanDealerMove()
        {
            Console.WriteLine("HumanDealerMove called");
            

            if (GameController.OrderedUp)
            {
                Console.WriteLine("Condition: Trump has been ordered up by non-dealer");
                lblMessage.Text = "Trump suit has been order up";
                // enable exchange event handler
                SubscribeExchangeCardToHand();
                btnOrderUp.Enabled = false;
                btnPass.Enabled = false;

                GameController.OrderedUp = false;
            }
            else if (GameController.Passed)// every player passed
            {
                Console.WriteLine("Condition: Non-dealer has passed");
                lblMessage.Text = @"You can Exchange the card by click
 on any card from you deck and set trump
 or Pass this turn";
                SubscribeExchangeCardToHand();
                btnPass.Enabled = true;
                btnOrderUp.Enabled = false;

                GameController.Passed = false;
            }
            else if (GameController.Passed && GameController.DealerPassed)
            {
                UnsubscribeExchangeCardFromHand();
                Console.WriteLine("Condition: Both dealer and non-dealer have passed in first round");
                LoadTrumpSuitSelection();
                btnPass.Enabled = false;

                GameController.Passed = false;
                GameController.DealerPassed = false;
            }
            else
            {
                UnsubscribeExchangeCardFromHand();
                Console.WriteLine("HumanDealerMove: No condition matched");
            }
        }

        private void HumanNonDealerMove()
        {
            Console.WriteLine("HumanNonDealerMove called");
            //Console.WriteLine($"OrderedUp: {GameController.OrderedUp}, Passed: {GameController.Passed}, DealerPassed: {GameController.DealerPassed}");

            if (GameController.DealerPassed && GameController.Passed)
            {
                Console.WriteLine("Condition: Both dealer and non-dealer have passed");
                lblMessage.Text = "Dealer has passed so you can select any suit as trump";
                // any trump selection 
                LoadTrumpSuitSelection();
                btnOrderUp.Enabled = false;
                btnPass.Enabled = false;

                GameController.Passed = false;
                GameController.DealerPassed = false;
            }
            else if (GameController.Passed)// non dealer passed
            {
                Console.WriteLine("Condition: Previous non-dealer player has passed");
                lblMessage.Text = "Previous player has passed";
                btnOrderUp.Enabled = true;
                btnPass.Enabled = true;

                GameController.Passed = false;
            }
            else if (!GameController.Passed && !GameController.DealerPassed)
            {
                Console.WriteLine("Condition: Initial trump decision state");
                lblMessage.Text = "It is your chance";
                btnOrderUp.Enabled = true;
                btnPass.Enabled = true;
            }
            else
            {
                Console.WriteLine("HumanNonDealerMove: No condition matched");
            }
        }

        #endregion

        /// <summary>
        /// sets up the tricks gamemode of the game
        /// </summary>
        private void InitiateTricksRound()
        {
            
            if (GameController.trumpSet && GameController.Game.GameMode == Constants.GameModes.Tricks)
            {
                Console.WriteLine("Calling Initiate Tricks round");
                MessageBox.Show($"The game has been set up");
                btnOrderUp.Enabled = false;
                btnPass.Enabled = false;
                SubscribePlayCard();

                GameController.Game.AssigneMakerDefenders();

                // call the method to assign makers and defenders

                // give the first player in the defender list first chance to play or the player after the turn
                GameController.UpdateCurrentPlayer(lblTrickTurn);
            }
            else Console.WriteLine("The game has not been initiated as the trump is not set");
        }


       

       /// <summary>
       /// exchange event handler for the hand of the human player when he is the dealer and must be trum selection mode
       /// This will be mapped to each picture box of the hand panel
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       private void ExchangeCard(object sender , EventArgs e)
        {

            // the selected pb index is taken from the handView list of the user
            PictureBox selectedPictureBox = sender as PictureBox;
            List<PictureBox> handView = GameController.Game.Players[0].HandView;

  
            int cardIndex = handView.IndexOf(selectedPictureBox);
            MessageBox.Show($"The selected card index is {cardIndex} ");

            HPlayer player = GameController.Game.Turn as HPlayer;
           
            player.ExchangeSelectedCard(player.Hand[cardIndex], GameController.Game.Deck,GameController.Game.Trump);
            // Add the dealer to Makers when they exchange a card
            if (!GameController.Game.Makers.Contains(player))
            {
                GameController.Game.Makers.Add(player);
            }

            // assign the new trump
            GameController.trumpSet = true;


            
            // Disable the buttons 
            btnOrderUp.Enabled = false;
            btnPass.Enabled = false;
        }

        /// <summary>
        /// method to subscribe the hand of the player to the exchange event when the dealer is not ai , this must be only called when the human player is dealer and it is trump selection game mode
        /// </summary>
        private  void SubscribeExchangeCardToHand()
        {
            if (GameController.Game.Dealer is HPlayer && GameController.Game.GameMode == Constants.GameModes.TrumpSetting)
            {
                List<PictureBox> HandView = GameController.Game.Dealer.HandView;
                foreach (PictureBox Hand in HandView)
                {
                    Hand.Click += ExchangeCard;
                }
            }
        }
        /// <summary>
        /// method to unsubscribe to the even hanler for the hand , this will only be called when trump decided and the game mode is changed to tricks
        /// </summary>
        private void UnsubscribeExchangeCardFromHand()
        {
            try
            {
                if (GameController.Game.Dealer is HPlayer)
                {
                    List<PictureBox> HandView = GameController.Game.Dealer.HandView;
                    foreach (PictureBox Hand in HandView)
                    {
                        Hand.Click -= ExchangeCard;
                    }
                }
            }
            catch (Exception ex)
            { 
              Console.WriteLine(ex.ToString());  
                    
            }
        }

        #region Any Trump Selection
        ///
        private void LoadTrumpSuitSelection()
        {
            // call the method to map the array of image of suits

            if (!IsLoading)
            {
                LoadPanelToLocation(panTrumpSelection, 600, 258);
                panTrick.Visible = false;
                // get the current player 
                string currentPlayer = GameController.Game.Turn.UserName;
                Card.Suits trump = GameController.Game.Trump;
                LoadSuitsToView(trump, panTrumpSelection);
            }



        }


        /// <summary>
        /// Method to load the images of suits to the PictureBox controls in the specified panel, excluding the trump suit.
        /// Reffered copilot
        /// </summary>
        /// <param name="trump">The trump suit to exclude.</param>
        /// <param name="panel">The panel containing the PictureBox controls.</param>
        private void LoadSuitsToView(Card.Suits trump, Panel panel)
        {
            // Dictionary to map suit enums to their corresponding images
            Dictionary<Card.Suits, Image> suitImages = new Dictionary<Card.Suits, Image>
    {
        { Card.Suits.Heart, Resources.Heart },
        { Card.Suits.Diamond, Resources.Diamond },
        { Card.Suits.Spades, Resources.Spades },
        { Card.Suits.Clubs, Resources.Clubs }
    };

            // Reset the selected suit label
            if (panel.Controls["lblSelectedSuit"] is Label lblSelectedSuit)
            {
                lblSelectedSuit.Text = "Select a suit";
                lblSelectedSuit.Tag = null; // Store the suit enum in the Tag property
            }

            // Get all PictureBox controls in the panel
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            foreach (Control cont in panel.Controls)
            {
                if (cont is PictureBox pb)
                {
                    pictureBoxes.Add(pb);
                    // Clear previous image and unsubscribe from events
                    pb.BackgroundImage = null;
                    pb.Click -= SuitPictureBox_Click;
                    pb.Tag = null;
                }
            }

            // Get valid suits (all suits except the trump suit)
            List<Card.Suits> validSuits = new List<Card.Suits>();
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                if (suit != trump)
                {
                    validSuits.Add(suit);
                }
            }

            // Load images for valid suits into available PictureBoxes
            int pictureBoxIndex = 0;
            foreach (Card.Suits suit in validSuits)
            {
                if (pictureBoxIndex < pictureBoxes.Count)
                {
                    PictureBox pb = pictureBoxes[pictureBoxIndex];
                    pb.BackgroundImage = suitImages[suit];
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    pb.Tag = suit;
                    pb.Click += SuitPictureBox_Click;
                    pictureBoxIndex++;
                }
            }
        }

        /// <summary>
        /// Event handler for the click event of the suit PictureBox controls.
        /// Reffered copilot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuitPictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pb && pb.Tag is Card.Suits suit)
            {
                // Find the label in the same panel as the PictureBox
                if (pb.Parent.Controls["lblSelectedSuit"] is Label lblSelectedSuit)
                {
                    // Update the label text with the selected suit
                    lblSelectedSuit.Text = $"Selected: {suit}";
                    lblSelectedSuit.Tag = suit; // Store the suit enum in the Tag property
                }
            }
        }

        /// <summary>
        /// Event handler for the click event of the Set Trump button.
        /// Reffered copilot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetTrump_Click(object sender, EventArgs e)
        {
            // Find the label in the Trump Selection panel
            if (panTrumpSelection.Controls["lblSelectedSuit"] is Label lblSelectedSuit && lblSelectedSuit.Tag is Card.Suits selectedSuit)
            {
                // Assign the selected suit as the new trump
                GameController.Game.Trump = selectedSuit;
                GameController.trumpSet = true;

                // Update the trump suit label
                lblTrmpSuit.Text = $"The Selected Trump for the Round is {selectedSuit}";

                if (!GameController.Game.Makers.Contains(GameController.Game.Turn))
                {
                    GameController.Game.Makers.Add(GameController.Game.Turn);
                }

                // Change the game mode to Tricks
                GameController.Game.GameMode = Constants.GameModes.Tricks;

                // Display a message to the user
                MessageBox.Show($"Trump has been set to {selectedSuit}");
            }
            else
            {
                MessageBox.Show("Please select a suit first.");
                return; // Don't hide the panel if no suit is selected
            }

            // Hide the Trump Selection panel
            panTrumpSelection.Enabled = false;
            panTrumpSelection.Visible = false;
        }
        #endregion

        #region Play card 

        
        /// <summary>
        /// Event to trigger the play card method by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayCard(object sender, EventArgs e)
        {

            if (GameController.Game.IsHumanPlayerTurn())
            {
                PictureBox pb = sender as PictureBox;
                Player hPlayer = GameController.Game.Players[0];

                List<PictureBox> handView = hPlayer.HandView;
                List<Card> hand = hPlayer.Hand;
                

                MessageBox.Show($"The Selected card is {hand[handView.IndexOf(pb)].ToString()}");
                Card PlayCard = hand[handView.IndexOf(pb)];

                // remove this card from the hand view and  make the pb visible false and 
                hand.Remove(PlayCard);
                hPlayer.LoadPlayerHand();
                GameController.Game.Trick.Add(PlayCard);
                UpdateTricksView(GameController.Game.Trick);

                UnsSubscribePlayCard();

            }
            else
            {
                Console.WriteLine("Player is Not Human");
            }

        }

        /// <summary>
        /// method to update the tricks list
        /// </summary>
        /// <param name="trick"></param>
        public void UpdateTricksView(List<Card> trick)
        {
            for (int i = 0; i < trick.Count && i < Tricks.Count; i++)
            {

                Tricks[i].BackgroundImage = trick[i].View;
                Tricks[i].BackgroundImageLayout = ImageLayout.Stretch;

            }
        }

        /// <summary>
        /// Method to update Tricks view
        /// </summary>


        /// <summary>
        ///  method to subsribe the play card event to the picture boxes of the user hand
        /// </summary>
        private void SubscribePlayCard()
        {
               
                Console.WriteLine("Subcribing play card even handler");
                foreach (PictureBox hand in GameController.Game.Players[0].HandView)
                {
                    hand.Click += PlayCard;
                }           
        }

        /// <summary>
        /// method to unsubcribe the play card event to the picture boxes of the user hand
        /// </summary>
        private void UnsSubscribePlayCard()
        {
            Console.WriteLine("UnSubcribing play card even handler");

            if (GameController.Game.Turn is HPlayer)
            {
                foreach (PictureBox hand in GameController.Game.Players[0].HandView)
                {
                    hand.Click -= PlayCard;
                }
            }
        }

        #endregion

    } // class ends here
} // namespace ends here
    