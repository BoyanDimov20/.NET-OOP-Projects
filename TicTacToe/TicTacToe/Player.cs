using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        public Player(char symbol)
        {
            Symbol = symbol;
        }
        
        public char Symbol { get; set; }

    }
}
