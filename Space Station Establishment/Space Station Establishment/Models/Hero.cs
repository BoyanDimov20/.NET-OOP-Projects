using MovementInGalaxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEstablishment
{
    class Hero
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int StarPower { get; set; }
        public char Symbol { get; set; }

        public Hero(string name, char symbol)
        {
            Name = name;
            StarPower = 0;
            Symbol = symbol;
        }


    }
}
