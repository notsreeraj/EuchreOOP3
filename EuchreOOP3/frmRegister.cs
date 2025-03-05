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
        public frmRegister()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            /*
             validate ea
             */
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            // load the Genders to the combo box
            cboGenders.DataSource = Enum.GetValues(typeof(User.Genders));
        }
    }
}
