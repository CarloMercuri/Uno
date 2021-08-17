using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoForms
{
    public class Constants
    {
        public static int PlayingCardWidth = 126;
        public static int PlayingCardHeight = 188;
    }

    public enum GameState
    {
        LocalPlayerTurn = 0,
        RemotePlayerTurn = 1
    }

    public enum CardColor
    {
        Red = 0,
        Yellow = 1,
        Green = 2,
        Blue = 3,
        Wild = 4
    }

    public enum CardSeed
    {
        Zero = 0,
        // The wilds cards are 0 - 1 in the array
        PlusFour = 0,
        SwitchColor = 1,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Skip = 10,
        Reverse = 11,
        PlusTwo = 12,



    }
}