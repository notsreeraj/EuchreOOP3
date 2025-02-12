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
        public frmOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            panelSound.Visible = true;
            panelThemes.Visible = false;

        }

        private void bthExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemes_Click(object sender, EventArgs e)
        {
            panelThemes.Visible = true;
            
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {

        }
    }
}
