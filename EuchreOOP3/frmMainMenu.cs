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
using System.Data.SqlClient;
using EuchreOOP3.Properties;
namespace EuchreOOP3
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions newForm = new frmOptions(); // Create an instance of frmOptions
            newForm.ShowDialog(); // Show frmOptions
            this.Hide(); // Hide the current form

        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            
            try
            {


                // Hide this form and show login
                this.Hide();
                frmLogin loginForm = new frmLogin(this);
                loginForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during form load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void TestDatabaseConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.EuchreUserDB))
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }
    }
}
