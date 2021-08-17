using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoForms.Models
{
    public class PlayingCard
    {
        public CardColor Color { get; set; }
        public CardSeed Seed { get; set; }

        public PlayingCard(CardColor _color, CardSeed _seed)
        {
            Color = _color;
            Seed = _seed;
        }
    }
}
