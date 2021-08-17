using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoForms
{
    public static class CardControl
    {
        private static Bitmap[,] CardsTextures { get; set; }

        private static Size CardTextureSize = new Size(126, 188);

        // The X position of the wild (black) cards in the atlas
        private static int WildCardsXPos = 1638;

        public static void InitializeCards()
        {
            CardsTextures = new Bitmap[5, 13];
            Bitmap atlas = new Bitmap("C:/dev/hoved/UnoForms/UnoForms/bin/Resources/Textures/cards_texture_atlas.png");
            //Bitmap atlas = new Bitmap(Properties.Resources.UNO_cards_deck_svg);

            int xSpacing = CardTextureSize.Width;
            int ySpacing = CardTextureSize.Height;

            // Color cards
            //for (int c = 0; c < 4; c++)
            //{
            //    for (int i = 0; i < 13; i++)
            //    {
            //        CardsTextures[c, i] = new Bitmap(CardTextureSize.Width, CardTextureSize.Height);

            //        using (Graphics g = Graphics.FromImage(CardsTextures[c, i]))
            //        {
            //            g.DrawImage(atlas, new Rectangle(0, 0, CardTextureSize.Width, CardTextureSize.Height),
            //            new Rectangle(0 + CardTextureSize.Width * i, 0 + CardTextureSize.Height * c,
            //            CardTextureSize.Width, CardTextureSize.Height), GraphicsUnit.Pixel);
            //        }
            //    }
            //}

            for (int c = 0; c < 4; c++)
            {
                for (int i = 0; i < 13; i++)
                {
                    CardsTextures[c, i] = new Bitmap(CardTextureSize.Width, CardTextureSize.Height);

                    for (int w = 0; w < CardTextureSize.Width; w++)
                    {
                        for (int h = 0; h < CardTextureSize.Height; h++)
                        {
                            CardsTextures[c, i].SetPixel(w, h, atlas.GetPixel(0 + CardTextureSize.Width * i + w, 0 + CardTextureSize.Height * c + h));
                        }
                    }
                   
                }
            }

            // WILD CARDS. Only 2 for now, just gonna hardcode it like this

            CardsTextures[4, 0] = new Bitmap(CardTextureSize.Width, CardTextureSize.Height);

            using (Graphics g = Graphics.FromImage(CardsTextures[4, 0]))
            {
                g.DrawImage(atlas, new Rectangle(0, 0, CardTextureSize.Width, CardTextureSize.Height),
                new Rectangle(WildCardsXPos, 0, 126, 188), GraphicsUnit.Pixel);
            }

            CardsTextures[4, 1] = new Bitmap(CardTextureSize.Width, CardTextureSize.Height);

            using (Graphics g = Graphics.FromImage(CardsTextures[4, 1]))
            {
                g.DrawImage(atlas, new Rectangle(0, 0, CardTextureSize.Width, CardTextureSize.Height),
                new Rectangle(WildCardsXPos, CardTextureSize.Height, 126, 188), GraphicsUnit.Pixel);
            }

        }

        public static Bitmap GetCardTexture(CardColor color, CardSeed seed)
        {
            
            int _color = (int)color;
            int _seed = (int)seed;

            // out of bounds
            if (_color > 4) return null;
            
            if(color == CardColor.Wild && _seed > 1)
            {
                // There's only 2 wild cards for now
                return null;
            }

            return CardsTextures[_color, _seed];
        }
    }
}
