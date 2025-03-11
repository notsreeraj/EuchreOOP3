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
            HideAllPanels();
        }

        public frmOptions()
        {
            InitializeComponent();
            Console.WriteLine("frmOption is called");
        }

        private void btnSoundClickEvent(object sender, EventArgs e)
        {
            HideAllPanels();
            panelSound.Visible = true;
        }

        private void btnThemes_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            flowLayoutPanelThemes.Visible = true;
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelPolicy.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelThemes.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelthemesCard.Visible = true;
        }

        private void button2ExitFrm_Click(object sender, EventArgs e)
        {
            this.Close(); // close the form
        }

        private void bthExit2_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panelExitInstructions.Visible = true;
        }

        private void panelThemes_Paint(object sender, PaintEventArgs e)
        {
            // Handle paint event if needed
        }

        // Method to hide all panels
        private void HideAllPanels()
        {
            panelExitInstructions.Visible = false;
            panelthemesCard.Visible = false;
            panelThemes.Visible = false;
            panelPolicy.Visible = false;
            panelSound.Visible = false;
            flowLayoutPanelThemes.Visible = false;
        }

        private void panelthemesCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        // Method to add buttons and panels to their respective arrays
    }
}
