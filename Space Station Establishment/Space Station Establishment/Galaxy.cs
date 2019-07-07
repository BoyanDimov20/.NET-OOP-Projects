using System;
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
                int startPowerIncome = int.Parse(galaxy[Hero.Row + 1, Hero.Col].ToString());
                Hero.StarPower += AskQuestion(startPowerIncome);   // Interesting recursion!
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
                int startPowerIncome = int.Parse(galaxy[Hero.Row - 1, Hero.Col].ToString());
                Hero.StarPower += AskQuestion(startPowerIncome);   // Interesting recursion!
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
                int startPowerIncome = int.Parse(galaxy[Hero.Row, Hero.Col - 1].ToString());
                Hero.StarPower += AskQuestion(startPowerIncome);   // Interesting recursion!
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
                int startPowerIncome = int.Parse(galaxy[Hero.Row, Hero.Col + 1].ToString());
                Hero.StarPower += AskQuestion(startPowerIncome);   // Interesting recursion!
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
        public int AskQuestion(int income)
        {
            
            Random random = new Random();
            int value1 = random.Next(1, 51);
            int value2 = random.Next(1, 51);
            Console.Write($"{value1} + {value2} = ");
            int result = int.Parse(Console.ReadLine());
            if (result == value1 + value2)
            {
                Console.WriteLine($"Well done! You just gained {income} star power!");
                return income;
            }
            else
            {
                Console.WriteLine("Wrong answer!");
                if (income == 0)
                {
                    Console.WriteLine("Sorry, but you lost all your star power.");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Try again!");
                    return AskQuestion(income / 2);
                }
            }
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
