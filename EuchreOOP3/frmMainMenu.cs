using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using DBAL;
using Model;

namespace EuchreOOP3
{
    public partial class frmMainMenu : Form
    {

        public frmMainMenu()
        {

            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

            try
            {
                Console.WriteLine("Populating Users");
                User.PopulateUsers();
                //User.PrintAllUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // load the the login page
            frmLogin formLogin = new frmLogin(this);
            this.Hide();
            formLogin.ShowDialog();


            if (User.CurrentUser != null)
            {
                lblUserName.Text = User.CurrentUser.Username;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            frmOptions frmOption = new frmOptions();
            frmOption.ShowDialog();
            this.Hide();
        }

        private void btnQuckPlay_Click(object sender, EventArgs e)
        {
            try
            {// create a gamestate object with 2 players
                GameController.StartQuickplay();
                frmGame frmGame = new frmGame();
                frmGame.ShowDialog();

                // launch the fmrGame
                // create frmGame and show it
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] {ex}");
            }
        }

        private void btnCoUp_Click(object sender, EventArgs e)
        {
            try
            {// create a gamestate object with 2 players
                GameController.StartCOOP();
                frmGame frmGame = new frmGame();
                frmGame.ShowDialog();

                // launch the fmrGame
                // create frmGame and show it 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] {ex}");
            }
        }
    }
}
