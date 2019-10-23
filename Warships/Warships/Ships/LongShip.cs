namespace Warships.Ships
{
    class LongShip : Ship
    {
        private const int Rows = 2;
        private const int Cols = 5;
        public char[,] Body { get; set; } = new char[Rows, Cols];
        public LongShip()
        {
            Name = "Long Ship";
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
