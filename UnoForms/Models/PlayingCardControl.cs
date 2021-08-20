using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnoForms.Models
{
    public class PlayingCardControl
    {
        public PlayingCard CardType { get; set; }

  

        public PictureBox pBox_Main { get; set; }
        private Point OriginalLocation { get; set; }
        private Point AnimationEndLocation { get; set; }

        public int AnimationMovementSpeed { get; set; }
        public int IndexInHand { get; set; }

        private int _xPos { get; set; }

        public int xPos
        {
            get { return _xPos; }
            set { _xPos = value;  ChangeLocation(); }
        }

        private int _yPos { get; set; }

        public int yPos
        {
            get { return _yPos; }
            set { _yPos = value; ChangeLocation(); }
        }

        private Point MouseDownLocation { get; set; }
        private Control ParentControl { get; set; }
        private int IndexInControl { get; set; }

        private Timer tickTimer { get; set; }

        private int yRaiseAmount = 30;

        private bool MouseDown { get; set; }

        private bool SelectedAnimationEnabled { get; set; }

        private bool IsDragging { get; set; }

        public PlayingCardControl(PlayingCard card, Control control, Point location, int childIndex = -1)
        {
            tickTimer = new Timer();
            tickTimer.Interval = 1;
            tickTimer.Tick += TickTimer_Tick;
            tickTimer.Start();
            

            CardType = card;
            OriginalLocation = location;
            AnimationEndLocation = new Point(location.X, location.Y - yRaiseAmount);
            IndexInControl = childIndex;
            ParentControl = control;


            pBox_Main = new PictureBox();
            pBox_Main.Size = new Size(Constants.PlayingCardWidth, Constants.PlayingCardHeight);
            pBox_Main.SizeMode = PictureBoxSizeMode.Normal;
            pBox_Main.Location = location;
            pBox_Main.BackColor = Color.Transparent;

            pBox_Main.Image = CardControl.GetCardTexture(CardType.Color, CardType.Seed);

            pBox_Main.MouseDown += (sender, args) =>
            {
                MouseDown = true;
                SelectedAnimationEnabled = false;
                IsDragging = true;

                if (args.Button == MouseButtons.Left)
                {
                    MouseDownLocation = args.Location;
                    //pBox_Main.BringToFront();
                }
            };

            pBox_Main.MouseEnter += (sender, args) =>
            {
                SelectedAnimationEnabled = true;
            };

            pBox_Main.MouseLeave += (sender, args) =>
            {
                SelectedAnimationEnabled = false;
            };

            pBox_Main.MouseUp += (sender, args) =>
            {
                //ParentControl.Controls.SetChildIndex(pBox_Main, IndexInControl);
                pBox_Main.Location = OriginalLocation;
                SelectedAnimationEnabled = false;
                IsDragging = false;
                
            };

            pBox_Main.MouseMove += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    pBox_Main.Left = args.X + pBox_Main.Left - MouseDownLocation.X;
                    pBox_Main.Top = args.Y + pBox_Main.Top - MouseDownLocation.Y;
                }
            };

            control.Controls.Add(pBox_Main);

            pBox_Main.BringToFront();
           

        }

        public void RemoveCard()
        {
            ParentControl.Controls.Remove(pBox_Main);
        }

        public void ChangeCardLocation(Point p, bool teleport)
        {
            OriginalLocation = p;
            _xPos = p.X;
            _yPos = p.Y;

            if (teleport)
            {
                pBox_Main.Location = p;
            }
        }

        public void ChangeCardLocation(int x, int y, bool teleport)
        {
            OriginalLocation = new Point(x, y);
            _xPos = x;
            _yPos = y;

            if (teleport)
            {
                pBox_Main.Location = new Point(x, y);
            }
        }

        private void ChangeLocation()
        {
            //pBox_Main.Location = new Point(_xPos, _yPos);
            OriginalLocation = new Point(_xPos, _yPos);
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            int newY;

            if (IsDragging) return;


            if(pBox_Main.Location.X > OriginalLocation.X)
            {
                pBox_Main.Location = new Point(pBox_Main.Location.X - 1, pBox_Main.Location.Y);
            } else if(pBox_Main.Location.X < OriginalLocation.X)
            {
                pBox_Main.Location = new Point(pBox_Main.Location.X + 1, pBox_Main.Location.Y);
            }

            

            // Y AXIS
            if (SelectedAnimationEnabled)
            {
                newY = pBox_Main.Location.Y - 2;

                if (newY <= AnimationEndLocation.Y) newY = AnimationEndLocation.Y;

                pBox_Main.Location = new Point(pBox_Main.Location.X, newY);
            } else
            {
                newY = pBox_Main.Location.Y + 2;

                if (newY >= OriginalLocation.Y) newY = OriginalLocation.Y;

                pBox_Main.Location = new Point(pBox_Main.Location.X, newY);

            }
        }
    }
}
