using System;
using System.Collections.Generic;
using System.Text;

namespace Warships.Ships
{
    class Boat : Ship
    {
        private const int Rows = 1;
        private const int Cols = 3;
        public char[,] Body { get; set; } = new char[Rows, Cols];
        public Boat()
        {
            Name = "Boat";
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
