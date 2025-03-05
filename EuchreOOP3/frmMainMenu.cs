using System;
using DBAL;
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
    public partial class frmMainMenu: Form
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
                User.PrintAllUsers();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }

            // load the the login page
            frmLogin formLogin = new frmLogin(this);
            this.Hide();
            formLogin.ShowDialog();
            Console.WriteLine($"Current User : {User.CurrentUser}");
            lblUserName.Text = User.CurrentUser.Username;
        }
    }
}
