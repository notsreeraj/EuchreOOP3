﻿using DBAL;
using System;
using Model;
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
        private int titleDirection = 1;


        public TextBox TxbEmail { get { return txbEmail; } }

        public frmLogin( frmMainMenu mm)
        {
            MainMenu = mm;
            InitializeComponent();
            InitializeTitleAnimation();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            frmRegister formRegister = new frmRegister(this); 
            formRegister.ShowDialog(); 
           // this.Hide(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                 User.CurrentUser = User.IsUserValid(txbEmail.Text, txbPassword.Text);
                if (User.CurrentUser == null)
                {
                    throw new Exception("Invalid user!!!, Please type in Valid User Credentials");
                }
                MainMenu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

             
            

            
        }
        private void InitializeTitleAnimation()
        {
        //    timerEuchre = new Timer();
            //timerEuchre.Interval = 50; // Set the interval to 50 milliseconds
            //timerEuchre.Tick += timerEuchre_Tick;
            //timerEuchre.Start();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            // create a default user and set them as the current user
            try
            {
                User.CurrentUser = User.GetGuestUser();
                MainMenu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainMenu.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void timerEuchre_Tick(object sender, EventArgs e)
        {
           
            //lblTitle.Left += 5 * titleDirection;

            
            //if (lblTitle.Left <= 0 || lblTitle.Right >= this.ClientSize.Width)
            //{
                
            //    titleDirection *= -1;
            //}

        }
    }
}
