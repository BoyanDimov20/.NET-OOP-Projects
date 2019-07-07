using NewEstablishment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovementInGalaxy
{
    class Movement
    {
        public Hero Hero { get; set; }

        public char[,] galaxy { get; set; }
        public int Size { get; set; }


        public void Down()
        {

            bool teleported = false;
            if (galaxy[Hero.Row + 1, Hero.Col] == 'O')
            {
                for (int i = 0; i < Size && !teleported; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row + 1 && j != Hero.Col)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row + 1, Hero.Col] = '-';
                            galaxy[i, j] = Hero.Symbol;
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
                galaxy[Hero.Row + 1, Hero.Col] = Hero.Symbol;
            }
            else
            {
                galaxy[Hero.Row + 1, Hero.Col] = Hero.Symbol;
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
                for (int i = 0; i < Size && !teleported; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row - 1 && j != Hero.Col)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row - 1, Hero.Col] = '-';
                            galaxy[i, j] = Hero.Symbol;
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
                galaxy[Hero.Row - 1, Hero.Col] = Hero.Symbol;
            }
            else
            {
                galaxy[Hero.Row - 1, Hero.Col] = Hero.Symbol;
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
                for (int i = 0; i < Size && !teleported; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row && j != Hero.Col - 1)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row, Hero.Col - 1] = '-';
                            galaxy[i, j] = Hero.Symbol;
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
                galaxy[Hero.Row, Hero.Col - 1] = Hero.Symbol;
            }
            else
            {
                galaxy[Hero.Row, Hero.Col - 1] = Hero.Symbol;
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
                for (int i = 0; i < Size && !teleported; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row && j != Hero.Col + 1)
                        {
                            galaxy[Hero.Row, Hero.Col] = '-';
                            galaxy[Hero.Row, Hero.Col + 1] = '-';
                            galaxy[i, j] = Hero.Symbol;
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
                galaxy[Hero.Row, Hero.Col + 1] = Hero.Symbol;
            }
            else
            {
                galaxy[Hero.Row, Hero.Col + 1] = Hero.Symbol;
            }
            if (!teleported)
            {
                galaxy[Hero.Row, Hero.Col] = '-';
                Hero.Col++;
            }
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
    }
}
