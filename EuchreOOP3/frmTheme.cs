using Controller;
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
    public partial class frmTheme: Form
    {
        public static  List<PictureBox> Themes = new List<PictureBox>();
        public static int SelectedTheme = 0;
        public frmTheme()
        {
            InitializeComponent();
        }

        private void frmTheme_Load(object sender, EventArgs e)
        {
             MapCardThemes();

        }

        /// <summary>
        /// method to map the picture box into an a list
        /// </summary>
        public void MapCardThemes()
        {
            Themes.Add(pictureBox1);
            Themes.Add(pictureBox2);
            Themes.Add(pictureBox3);
            Themes.Add(pictureBox4);
            Themes.Add(pictureBox5);
        }



        /// <summary>
        /// method to get the index of the selected pb
        /// </summary>
        /// <param name="pb"></param>
        /// <returns></returns>
        public int GetThemeIndex(PictureBox pb)
        {
            foreach (PictureBox pbox in Themes)
            {
                if (pbox == pb)
                {
                    return Themes.IndexOf(pb);
                }
            }
            return -1;
        }

        public void ThemeSelection(object sender , EventArgs e)
        {
            if(sender is PictureBox)
            {
                 SelectedTheme = GetThemeIndex(sender as PictureBox);
                lblSelectedTheme.Text = $" Theme {SelectedTheme + 1}";
            }
        }

        public void SetTheme(object sender , EventArgs e)
        {
            if(sender is Button)
            {
                GameController.Theme = SelectedTheme;
                MessageBox.Show("The Theme Has Been Set.");
                this.Close();
            }
        }
    }
}
