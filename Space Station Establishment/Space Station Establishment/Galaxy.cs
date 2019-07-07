﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewEstablishment
{
    class Galaxy
    {
        int size;
        char[,] galaxy;
        public Hero Hero { get; set; }

        public int Size
        {
            get { return size; }
        }



        public Galaxy(int size)
        {
            Hero = new Hero();
            this.size = size;
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
            int randRow = rng.Next(0, size);
            int randCol = rng.Next(0, size);

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
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
            galaxy[randRow, randCol] = 'S';
            Hero.Row = randRow;
            Hero.Col = randCol;

            Show();
        }

        public void Show()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                {
                    Console.Write(galaxy[i, j]);
                }
            }
            Console.WriteLine();
        }

        public void Read()
        {
            for (int i = 0; i < size; i++)
            {
                var command = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    if (command[j] == 'S')
                    {
                        Hero.Row = i;
                        Hero.Col = j;
                    }
                    galaxy[i, j] = command[j];
                }
            }
        }


        public void Down()
        {
            bool teleported = false;
            if (galaxy[Hero.Row + 1, Hero.Col] == 'O')
            {
                for (int i = 0; i < size && !teleported; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row + 1 && j != Hero.Col)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row + 1, Hero.Col] = '-';
                            galaxy[i, j] = 'S';
                            Hero.Row = i;
                            Hero.Col = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[Hero.Row + 1, Hero.Col] != '-')
            {
                Hero.StarPower += int.Parse(galaxy[Hero.Row + 1, Hero.Col].ToString());
                galaxy[Hero.Row + 1, Hero.Col] = 'S';
            }
            else
            {
                galaxy[Hero.Row + 1, Hero.Col] = 'S';
            }
            if (!teleported)
            {
                galaxy[Hero.Row, Hero.Col] = '-';
                Hero.Row++;
            }
        }
        public void Up()
        {
            bool teleported = false;
            if (galaxy[Hero.Row - 1, Hero.Col] == 'O')
            {
                for (int i = 0; i < size && !teleported; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row - 1 && j != Hero.Col)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row - 1, Hero.Col] = '-';
                            galaxy[i, j] = 'S';
                            Hero.Row = i;
                            Hero.Col = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[Hero.Row - 1, Hero.Col] != '-')
            {
                Hero.StarPower += int.Parse(galaxy[Hero.Row - 1, Hero.Col].ToString());
                galaxy[Hero.Row - 1, Hero.Col] = 'S';
            }
            else
            {
                galaxy[Hero.Row - 1, Hero.Col] = 'S';
            }
            if (!teleported)
            {
                galaxy[Hero.Row, Hero.Col] = '-';
                Hero.Row--;
            }
        }

        public void Left()
        {
            bool teleported = false;
            if (galaxy[Hero.Row, Hero.Col - 1] == 'O')
            {
                for (int i = 0; i < size && !teleported; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row && j != Hero.Col - 1)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row, Hero.Col - 1] = '-';
                            galaxy[i, j] = 'S';
                            Hero.Row = i;
                            Hero.Col = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[Hero.Row, Hero.Col - 1] != '-')
            {
                Hero.StarPower += int.Parse(galaxy[Hero.Row, Hero.Col - 1].ToString());
                galaxy[Hero.Row, Hero.Col - 1] = 'S';
            }
            else
            {
                galaxy[Hero.Row, Hero.Col - 1] = 'S';
            }
            if (!teleported)
            {
                galaxy[Hero.Row, Hero.Col] = '-';
                Hero.Col--;
            }
        }



        public void Right()
        {
            bool teleported = false;
            if (galaxy[Hero.Row, Hero.Col + 1] == 'O')
            {
                for (int i = 0; i < size && !teleported; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row && j != Hero.Col + 1)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row, Hero.Col + 1] = '-';
                            galaxy[i, j] = 'S';
                            Hero.Row = i;
                            Hero.Col = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[Hero.Row, Hero.Col + 1] != '-')
            {
                Hero.StarPower += int.Parse(galaxy[Hero.Row, Hero.Col + 1].ToString());
                galaxy[Hero.Row, Hero.Col + 1] = 'S';
            }
            else
            {
                galaxy[Hero.Row, Hero.Col + 1] = 'S';
            }
            if (!teleported)
            {
                galaxy[Hero.Row, Hero.Col] = '-';
                Hero.Col++;
            }
        }
        public bool IsSave(string command)
        {
            if (command == "right")
            {
                if (Hero.Col + 1 < size)
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
                if (Hero.Row + 1 < size)
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
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                {
                    Console.Write(galaxy[i, j]);
                    if (Hero.Row == i && j == size - 1)
                    {
                        Console.Write("  <- Here you are");
                    }
                }
            }
            Console.WriteLine();
        }

    }
}
