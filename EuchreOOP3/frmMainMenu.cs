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
            newForm.Show(); // Show frmOptions
            this.Hide(); // Hide the current form

        }
    }
}
