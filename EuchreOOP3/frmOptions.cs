using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuchreOOP3
{
    public partial class frmOptions : Form
    {
        #region 
        private static Panel[] panOptions = new Panel[4];
        private static Button[] btnOptions = new Button[4];
        #endregion

        private void frmOptions_Load(object sender, EventArgs e)
        {
            //HideAllPanels();
            panelThemes.Visible = false;
            pnlHowToPlay.Visible = false;   
            textBoxHow.Text = "2 Player Euchre:\r\nPlaying guide\r\n1.\tSetting up the deck to play \r\nRemove cards ranking from 2-8 form the deck, the remaining would be used for the game\r\n2.\tAssigning the dealer.\r\nFrom the deck, which is shuffled, laid face down, the player must take a chance alternatively to pick the card at the top. The first one to get a blackjack of any suit would be the dealer for the game.\r\n3.\tAssign the hands based on the first method where the dealer hands out 5 cards each to the players\r\n4.\tDeciding the trump suit for the whole round\r\nThe non dealer will have 2 choices here, those are to order-up (Fix the Initial potential trump) and pass (change the trump suit).\r\nInitially there are 2 scenarios, \r\n1.\tNon dealer gets the chance to either order up (confirm the initial trump) or pass (change the initial trump), if he orders up the initial trump suit is confirmed to be the trump, and dealer must take that card and replace it another card from his hand and the round will start.\r\n2.\tIf the non-dealer passes, then the dealer gets to choose whether he wants to keep this as the trump. Here he can either pick up the card and replace it with another card from his hand and the new card would be the trump, or he can pass the chance to choose a trump.\r\n3.\tAt this point both parties have passed the chance to choose a trump once, so now the non-dealer gets a chance to pick any trump expect the initial potential trump as the trump suit.\r\n4.\tNow if the non-dealer also passes, the dealer can choose any suit as the trump, expect the potential trump suit.\r\n5.\tIf the dealer also passes the hand must reset again from the point of choosing the dealer.\r\n\r\n\r\n\r\nFrom here on the team which decided the trump will be referred as makers and the other team would be defenders\r\n\r\n5.\tAfter deciding the trump.\r\n\tDealer deals 5 cards to each player to the left of the dealer or in a clock wise direction.\r\n\tThe winner of a trick is decided based on the highest ranking card in that trick.\r\no\tThe defender must try to play a card higher than card played first.\r\n\tAnd the score is added after a set of 5 tricks . The first one to get 10 points wins the hand.\r\n\tAfter that we decide the dealer again , and the trump again.\r\nScoring Rules\r\nNumber of wins in a trick\tMaker\tDefender\r\n3 to 4 \t1 point\t2 point\r\n5 \t2 point\t4 point.\r\n\r\n\tNote : The scoring system is depends on whether a player is non-dealer or dealer.\r\n\t\t\r\n";
        }

        public frmOptions()
        {
            InitializeComponent();
            Console.WriteLine("frmOption is called");
        }

        private void btnSoundClickEvent(object sender, EventArgs e)
        {
            //HideAllPanels();
            //panelSound.Visible = true;
        }

        private void btnThemes_Click(object sender, EventArgs e)
        {
            //HideAllPanels();
            panelThemes.Visible = true;
            pnlHowToPlay.Visible = false;

        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            //HideAllPanels();
            //panelPolicy.Visible = true;
            pnlHowToPlay.Visible = true;   
            panelThemes.Visible = false;
        }



        private void bthExit2_Click(object sender, EventArgs e)
        {
            //HideAllPanels();
            //panelExitInstructions.Visible = true;
            this.Close();
        }

        private void panelThemes_Paint(object sender, PaintEventArgs e)
        {
            // Handle paint event if needed
        }

        // Method to hide all panels
        //private void HideAllPanels()
        //{
        //    panelExitInstructions.Visible = false;
        //    panelthemesCard.Visible = false;
        //    panelThemes.Visible = false;
        //    panelPolicy.Visible = false;
        //    panelSound.Visible = false;
        //    flowLayoutPanelThemes.Visible = false;
        //}

        private void panelthemesCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        // Method to add buttons and panels to their respective arrays
    }
}
