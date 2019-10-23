using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Ships
{
    class ShortShip : Ship
    {
        private const int Rows = 2;
        private const int Cols = 3;
        public char[,] Body { get; set; } = new char[Rows, Cols];
        public ShortShip()
        {
            Name = "Short Ship";
            GenerateBody();
        }

        public void GenerateBody()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Body[i, j] = '#';
                }
            }
        }

    }
}
