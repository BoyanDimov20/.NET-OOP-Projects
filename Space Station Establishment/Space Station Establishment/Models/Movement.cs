using NewEstablishment;
using Space_Station_Establishment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovementInGalaxy
{
    static class Movement
    {
        public static void Down(Galaxy galaxy, Hero Hero)
        {
            bool teleported = false; // black hole
            if (galaxy[Hero.Row + 1, Hero.Col] == 'O')
            {
                for (int i = 0; i < galaxy.Size && !teleported; i++)
                {
                    for (int j = 0; j < galaxy.Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row + 1 && j != Hero.Col)
                        {
                            galaxy.Map[Hero.Row, Hero.Col] = '-';
                            galaxy.Map[Hero.Row + 1, Hero.Col] = '-';
                            galaxy.Map[i, j] = Hero.Symbol;
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
                Hero.StarPower += GameOptions.AskQuestion(startPowerIncome);   // Interesting recursion!
                galaxy.Map[Hero.Row + 1, Hero.Col] = Hero.Symbol;
            }
            else
            {
                galaxy.Map[Hero.Row + 1, Hero.Col] = Hero.Symbol;
            }
            if (!teleported)
            {
                galaxy.Map[Hero.Row, Hero.Col] = '-';
                Hero.Row++;
            }
        }

        public static void Up(Galaxy galaxy, Hero Hero)
        {
            bool teleported = false;
            if (galaxy.Map[Hero.Row - 1, Hero.Col] == 'O')
            {
                for (int i = 0; i < galaxy.Size && !teleported; i++)
                {
                    for (int j = 0; j < galaxy.Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row - 1 && j != Hero.Col)
                        {
                            galaxy.Map[Hero.Row, Hero.Col] = '-';
                            galaxy.Map[Hero.Row - 1, Hero.Col] = '-';
                            galaxy.Map[i, j] = Hero.Symbol;
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
                Hero.StarPower += GameOptions.AskQuestion(startPowerIncome);   // Interesting recursion!
                galaxy.Map[Hero.Row - 1, Hero.Col] = Hero.Symbol;
            }
            else
            {
                galaxy.Map[Hero.Row - 1, Hero.Col] = Hero.Symbol;
            }
            if (!teleported)
            {
                galaxy.Map[Hero.Row, Hero.Col] = '-';
                Hero.Row--;
            }
        }

        public static void Left(Galaxy galaxy, Hero Hero)
        {
            bool teleported = false;
            if (galaxy.Map[Hero.Row, Hero.Col - 1] == 'O')
            {
                for (int i = 0; i < galaxy.Size && !teleported; i++)
                {
                    for (int j = 0; j < galaxy.Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row && j != Hero.Col - 1)
                        {
                            galaxy.Map[Hero.Row, Hero.Col] = '-';
                            galaxy.Map[Hero.Row, Hero.Col - 1] = '-';
                            galaxy.Map[i, j] = Hero.Symbol;
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
                Hero.StarPower += GameOptions.AskQuestion(startPowerIncome);   // Interesting recursion!
                galaxy.Map[Hero.Row, Hero.Col - 1] = Hero.Symbol;
            }
            else
            {
                galaxy.Map[Hero.Row, Hero.Col - 1] = Hero.Symbol;
            }
            if (!teleported)
            {
                galaxy.Map[Hero.Row, Hero.Col] = '-';
                Hero.Col--;
            }
        }



        public static void Right(Galaxy galaxy, Hero Hero)
        {
            bool teleported = false;
            if (galaxy[Hero.Row, Hero.Col + 1] == 'O')
            {
                for (int i = 0; i < galaxy.Size && !teleported; i++)
                {
                    for (int j = 0; j < galaxy.Size; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != Hero.Row && j != Hero.Col + 1)
                        {
                            galaxy.Map[Hero.Row, Hero.Col] = '-';
                            galaxy.Map[Hero.Row, Hero.Col + 1] = '-';
                            galaxy.Map[i, j] = Hero.Symbol;
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
                Hero.StarPower += GameOptions.AskQuestion(startPowerIncome);   // Interesting recursion!
                galaxy.Map[Hero.Row, Hero.Col + 1] = Hero.Symbol;
            }
            else
            {
                galaxy.Map[Hero.Row, Hero.Col + 1] = Hero.Symbol;
            }
            if (!teleported)
            {
                galaxy.Map[Hero.Row, Hero.Col] = '-';
                Hero.Col++;
            }
        }

        
    }
}
