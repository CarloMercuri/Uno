using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoForms.Models;

namespace UnoForms.GameLogic
{
    public class GameControllerSinglePlayer
    {
        public PlayerController LocalPlayerController { get; set; }
        public PlayerController RemotePlayerController { get; set; }
        public List<PlayingCard> MainDeck { get; set; }
        private Random _Random { get; set; }

        public GameControllerSinglePlayer()
        {
            _Random = new Random();
            MainDeck = new List<PlayingCard>();

            // Fill the deck according to the official rules 
            // on letsplayuno.com


            for (int c = 0; c < 4; c++)
            {
                MainDeck.Add(new PlayingCard((CardColor)c, CardSeed.Zero));
                for (int s = 1; s <= 9; s++)
                {
                    // 2 for each number
                    MainDeck.Add(new PlayingCard((CardColor)c, (CardSeed)s));
                    MainDeck.Add(new PlayingCard((CardColor)c, (CardSeed)s));
                }
            }
        }

        public PlayingCard PullCardFromDeck()
        {
            if (MainDeck.Count <= 0) return null;

            int rnd = _Random.Next(0, MainDeck.Count);

            PlayingCard card = MainDeck[rnd];
            MainDeck.RemoveAt(rnd);

            return card;
        }


        public void PlayCard()
        {

        }

    }
}
