using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnoForms.Forms;

namespace UnoForms.Models
{
    public class PlayerController
    {
        private MainGameForm MainForm { get; set; }
        private List<PlayingCard> CurrentHeldCards { get; set; }

        public PlayerController(MainGameForm _mainForm)
        {
            MainForm = _mainForm;
        }

        public void ReceiveCard(PlayingCard card)
        {

        }
        
    }
}
