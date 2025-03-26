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
    public partial class frmRegister : Form
    {
        private static frmLogin frmLogin;
        public frmRegister( frmLogin formLogin)
        {
            frmLogin = formLogin;
            InitializeComponent();
        }



        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try{
                

                if(User.IsEmailValid(txbEmail.Text) && IsPasswordConfirm())
                {
                    User newUser = new User();
                    newUser.FirstName = txbFirstName.Text;
                    newUser.LastName = txbLastName.Text;
                    newUser.Username = txbUsername.Text;
                    Console.WriteLine("Email Input in the form: " + txbEmail.Text); 
                    newUser.Email = txbEmail.Text;
                    newUser.Password = txbPassword.Text;
                    User.InsertUser(newUser);
                    User.PopulateUsers();
                    User.PrintAllUsers();

                    frmLogin.TxbEmail.Text = newUser.Email;
                }
                
                this.Close();
                frmLogin.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"[Errror] Failed to Create User : {ex.ToString()}");
            }
            /*
             
             */
        }

        #region Instance method

        private bool IsPasswordConfirm()
        {
            return(txbPassword.Text == txbConfirmPassword.Text);
        }

        #endregion

        private void frmRegister_Load(object sender, EventArgs e)
        {
            // load the Genders to the combo box
            cboGenders.DataSource = Enum.GetValues(typeof(User.Genders));
        }


        #region Event Handlers

        /// <summary>
        /// event handler for key press in the txt box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {            // List of allowed characters (letters, digits, and basic punctuation)
                char[] allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

                // Check if the pressed key is not in the list of allowed characters
                if (Array.IndexOf(allowedChars, e.KeyChar) == -1 && !char.IsControl(e.KeyChar))
                {
                    //isEdited = true;
                    // If not allowed, prevent the character from being entered into the text box
                    e.Handled = true;
                    MessageBox.Show("Special characters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("KeyPress Error : " + ex.Message);
            }
        }

        /// <summary>
        /// event handler for key press in the txt box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {            // List of allowed characters (letters, digits, and basic punctuation)
                char[] allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

                // Check if the pressed key is not in the list of allowed characters
                if (Array.IndexOf(allowedChars, e.KeyChar) == -1 && !char.IsControl(e.KeyChar))
                {
                    
                    // If not allowed, prevent the character from being entered into the text box
                    e.Handled = true;
                    MessageBox.Show("Special characters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("KeyPress Error : " + ex.Message);
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin.Show();
             
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // List of allowed characters (letters, digits, and specific special characters)
                char[] allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$".ToCharArray();

                // Check if the pressed key is not in the list of allowed characters
                if (Array.IndexOf(allowedChars, e.KeyChar) == -1 && !char.IsControl(e.KeyChar))
                {
                    // If not allowed, prevent the character from being entered into the text box
                    e.Handled = true;
                    MessageBox.Show("Password can only contain letters, numbers, and the special characters @, #, $.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("KeyPress Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
