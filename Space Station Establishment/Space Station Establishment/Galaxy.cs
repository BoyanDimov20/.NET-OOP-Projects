using MovementInGalaxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEstablishment
{
    class Galaxy : Movement
    {

        public Galaxy(int size, char heroSymbol)
        {
            Hero = new Hero(heroSymbol);
            this.Size = size;
            galaxy = new char[size, size];
        }


        public char this[int row, int col]
        {
            get
            {
                return galaxy[row, col];
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
                    galaxy[i, j] = randomValue;

                    int randomEmpty = rng.Next(0, 3);
                    if (randomEmpty == 0)
                    {
                        galaxy[i, j] = '-';
                    }
                }
            }
            galaxy[randRow, randCol] = Hero.Symbol;
            Hero.Row = randRow;
            Hero.Col = randCol;

            Show();
        }

        public void Show()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(galaxy[i, j]);
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
                    galaxy[i, j] = command[j];
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
                galaxy[Hero.Row, Hero.Col] = '-';
                return false;
            }
            else if (command == "left")
            {
                if (Hero.Col - 1 >= 0)
                {
                    return true;
                }
                galaxy[Hero.Row, Hero.Col] = '-';
                return false;
            }
            else if (command == "up")
            {
                if (Hero.Row - 1 >= 0)
                {
                    return true;
                }
                galaxy[Hero.Row, Hero.Col] = '-';
                return false;
            }
            else if (command == "down")
            {
                if (Hero.Row + 1 < Size)
                {
                    return true;
                }
                galaxy[Hero.Row, Hero.Col] = '-';
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
                    Console.Write(galaxy[i, j]);
                    if (Hero.Row == i && j == Size - 1)
                    {
                        Console.Write("  <- Here you are");
                    }
                }
            }
            Console.WriteLine();
        }
        
        public void ShowRules()
        {
            Console.WriteLine("The symbol \'S\' is your position in the galaxy. ");
            Console.WriteLine("The symbol \"-\" represents empty space.");
            Console.WriteLine();
            Console.WriteLine("You can move in all directions with the commands \"right\", \"left\", \"up\" and \"down\"");
            Console.WriteLine();
            Console.WriteLine("The goal is to collect 50 star power. ");
            Console.WriteLine("If your answer is wrong, your star power income will be halfed.");
            Console.WriteLine("In order to claim it you will be asked a math question.");
        }



    }
}
