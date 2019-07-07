using System;
using System.Collections.Generic;
using System.Text;

namespace NewEstablishment
{
    class Hero
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int StarPower { get; set; }
        public char Symbol { get; set; }

        public Hero(char symbol)
        {
            StarPower = 0;
            Symbol = symbol;
        }


    }
}
