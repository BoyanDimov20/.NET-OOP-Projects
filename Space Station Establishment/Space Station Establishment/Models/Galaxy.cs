using MovementInGalaxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEstablishment
{
    class Galaxy
    {
        public char[,] Map { get; private set; }
        public int Size { get; private set; }
        public Hero Hero { get; private set; }

        public Galaxy(int size, string heroName, char heroSymbol)
        {
            Hero = new Hero(heroName, heroSymbol);
            this.Size = size;
            Map = new char[size, size];
        }


        public char this[int row, int col]
        {
            get
            {
                return Map[row, col];
            }
        }

        public void Generate()
        {
            Random rng = new Random();
            int randRow = rng.Next(0, Size);
            int randCol = rng.Next(0, Size);

            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    int randomNumber = rng.Next(1, 10);
                    char randomValue = randomNumber.ToString()[0];  // LOL
                    Map[i, j] = randomValue;

                    int randomEmpty = rng.Next(0, 3);
                    if (randomEmpty == 0)
                    {
                        Map[i, j] = '-';
                    }
                }
            }
            Map[randRow, randCol] = Hero.Symbol;
            Hero.Row = randRow;
            Hero.Col = randCol;

            Show();
        }

        public void Show()
        {
            Console.WriteLine($"Current Star Power: {Hero.StarPower}");
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(Map[i, j]);
                }
            }
            Console.WriteLine();
        }

        public void Read()
        {
            for (int i = 0; i < Size; i++)
            {
                var command = Console.ReadLine().ToCharArray();
                for (int j = 0; j < Size; j++)
                {
                    if (command[j] == Hero.Symbol)
                    {
                        Hero.Row = i;
                        Hero.Col = j;
                    }
                    Map[i, j] = command[j];
                }
            }
        }
        
        public bool IsSave(string command)
        {
            if (command == "right")
            {
                if (Hero.Col + 1 < Size)
                {
                    return true;
                }
                Map[Hero.Row, Hero.Col] = '-';
                return false;
            }
            else if (command == "left")
            {
                if (Hero.Col - 1 >= 0)
                {
                    return true;
                }
                Map[Hero.Row, Hero.Col] = '-';
                return false;
            }
            else if (command == "up")
            {
                if (Hero.Row - 1 >= 0)
                {
                    return true;
                }
                Map[Hero.Row, Hero.Col] = '-';
                return false;
            }
            else if (command == "down")
            {
                if (Hero.Row + 1 < Size)
                {
                    return true;
                }
                Map[Hero.Row, Hero.Col] = '-';
                return false;
            }
            return true;
        }

        public void ShowHero()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(Map[i, j]);
                    if (Hero.Row == i && j == Size - 1)
                    {
                        Console.Write("  <- Here you are");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
