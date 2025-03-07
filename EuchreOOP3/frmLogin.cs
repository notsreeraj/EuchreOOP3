using DBAL;
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
    public partial class frmLogin : Form
    {
        frmMainMenu MainMenu;
        public frmLogin( frmMainMenu mm)
        {
            MainMenu = mm;
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            frmRegister formRegister = new frmRegister(this); 
            formRegister.ShowDialog(); 
           // this.Hide(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // validate the current user typed in user credentials 
            // set the current user reference to the same user in the users list
             User.CurrentUser = User.IsUserValid(txbEmail.Text, txbPassword.Text);
            if (User.CurrentUser == null)
            {
                MessageBox.Show("[Error] Invalid User Credenrials");
            }
            else
            {
                MessageBox.Show($"{User.CurrentUser.Username} Has logged in");

            }

            // load the main form back
            MainMenu.Show();
            this.Close();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            // create a default user and set them as the current user
            User.CurrentUser = User.GetGuestUser();
            MainMenu.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainMenu.Close();
        }
    }
}
