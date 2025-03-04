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

        public frmOptions()
        {
            InitializeComponent();
            Console.WriteLine("frmOption is called");
        }


        private void bthExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void OptionsSwitchEvent(object sender, EventArgs e)
        {
            // use this event handler for all buttons
            // take in the buttontxt and switch the panel according to it
        }

        // method to add buttons and panels to their respective arrays
    }
}
