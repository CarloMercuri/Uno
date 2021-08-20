using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnoForms.CustomForms;
using UnoForms.GameLogic;
using UnoForms.Models;

namespace UnoForms.Forms
{
    public partial class MainGameForm : Form
    {
        private Point MouseDownLocation;
        private Label lbl { get; set; }
        private GameControllerSinglePlayer controller { get; set; }

        // The playing character's hand. Show the card face up
        private List<PlayingCardControl> LocalHand { get; set; }

        // The opponent's hand. Show the cards face down
        private List<PlayingCardControl> RemoteHand { get; set; }

        private int PlayingPanelMidSpot { get; set; }
        private int CardsSpacing = 40;
        private int LocalHandYPos { get; set; }

        public MainGameForm()
        {
            //this.TransparencyKey = Color.Transparent;
            this.AllowTransparency = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Paint += testPaint;
            InitializeComponent();
            CardControl.InitializeCards();
            controller = new GameControllerSinglePlayer();
            LocalHand = new List<PlayingCardControl>();
            PlayingPanelMidSpot = panel_PlayingArea.Width / 2;
            LocalHandYPos = this.Height - Constants.PlayingCardHeight + 70;
            //CreateTestCard();

            lbl = new Label();
            lbl.Location = new Point(50, 50);
            //pictureBox1.Controls.Add(lbl);
            lbl.ForeColor = Color.White;
            this.KeyDown += PressKey;
          
            //pictureBox1.Visible = false;
            PictureBox deck = new PictureBox();

            //deck.Location = new Point(pictureBox1.Width - 300, pictureBox1.Height / 2);
            //deck.Size = new Size(100, 150);

            Bitmap bmp = new Bitmap(100, 150);
            Bitmap src = Properties.Resources.deck_100x150;

            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    //Color cl = Color.Red;
                    //Color cl = Color.FromArgb(0, 0, 0, 0);
                    
                    //bmp.SetPixel(i, j, cl);
                }
            }

            deck.Image = src;
            deck.SizeMode = PictureBoxSizeMode.StretchImage;
            deck.BackColor = Color.Transparent;
            //pictureBox1.Controls.Add(deck);


        }

        private void testPaint(object sender, PaintEventArgs e)
        {
            
        }

        public void RefreshLocalCardsVisual(List<PlayingCard> cards)
        {

        }

        private void ReassignLocalHandIndexes()
        {
            for (int i = 0; i < LocalHand.Count; i++)
            {
                LocalHand[i].IndexInHand = i;
            }
        }

        public void RemoveCardFromHand(int index)
        {

            for (int i = 0; i < LocalHand.Count; i++)
            {
                if(i < index)
                {
                    LocalHand[i].xPos = LocalHand[i].xPos + 20;
                } else if(i > index)
                {
                    LocalHand[i].xPos = LocalHand[i].xPos - 20;
                }
            }

         
            
            LocalHand[index].RemoveCard();
            LocalHand[index] = null;
            LocalHand.RemoveAt(index);

            ReassignLocalHandIndexes();

            
        }

        public void AddCardToHand(PlayingCard card)
        {
            int xPos = 0;
            int yPos = LocalHandYPos;

            PlayingCardControl pcc = new PlayingCardControl(card,
                panel_PlayingArea, new Point(xPos, yPos), 2);

            if (LocalHand.Count <= 0)
            {
                xPos = PlayingPanelMidSpot - pcc.pBox_Main.Width / 2;
                
            } else
            {
                for (int i = 0; i < LocalHand.Count; i++)
                {
                    LocalHand[i].ChangeCardLocation(LocalHand[i].xPos - CardsSpacing / 2,
                        LocalHand[i].yPos, true);

                }

                xPos = LocalHand[LocalHand.Count - 1].pBox_Main.Location.X + CardsSpacing;
            }

            pcc.ChangeCardLocation(xPos, yPos, true);

            
           

            LocalHand.Add(pcc);

            
        }
  

        private void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V)
            {
                AddCardToHand(controller.PullCardFromDeck());
            }

            if (e.KeyCode == Keys.B)
            {
                RemoveCardFromHand(4);
            }
        }

        private void ShowDeck()
        {
            controller = new GameControllerSinglePlayer();

            for (int i = 0; i < 19; i++)
            {
                PlayingCard crd = controller.PullCardFromDeck();
                lbl.Text = controller.MainDeck.Count.ToString();
                PlayingCardControl card = new PlayingCardControl(crd,
                this, new Point(40 * i , this.Height - Constants.PlayingCardHeight / 2), 19 - i);
            }

            PictureBox pb = new PictureBox();
            pb.Size = new Size(96, 158);
            pb.Location = new Point(this.Width / 2, this.Height / 2 - pb.Height / 2);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = CardControl.GetCardTexture(CardColor.Green, CardSeed.Four);

            //pictureBox1.Controls.Add(pb);
            
        }

        private void CreateTestCard()
        {
            PlayingCardControl card = new PlayingCardControl(new PlayingCard(CardColor.Blue, CardSeed.PlusTwo),
                this, new Point(this.Width / 2, this.Height / 2));

            card.pBox_Main.MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseDownLocation = args.Location;
                }
            };

            card.pBox_Main.MouseMove += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    card.pBox_Main.Left = args.X + card.pBox_Main.Left - MouseDownLocation.X;
                    card.pBox_Main.Top = args.Y + card.pBox_Main.Top - MouseDownLocation.Y;
                }
            };
        }

        
    }
}
