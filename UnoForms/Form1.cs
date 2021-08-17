using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnoForms
{
    public partial class Form1 : Form
    {
        private int index = 0;
        // Arial Rounded MT Bold 42size
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += PressKey;
            CardControl.InitializeCards();
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Size = new Size(126, 188);
        }

        private void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V)
            {
                pictureBox1.Image = CardControl.GetCardTexture(CardColor.Wild, (CardSeed)1);
                index++;
                if(index > 13)
                {
                    index = 0;
                }
            }
        }


        private void KeyControl()
        {

        }

    }
}
