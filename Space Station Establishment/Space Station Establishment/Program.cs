using System;

namespace NewEstablishment
{
    class Program
    {
        static int n = 0;
        static char[,] galaxy;
        static int starPower = 0;
        static int myRow = 0;
        static int myCol = 0;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            galaxy = new char[n, n];
            bool wentVoid = false;

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    if (command[j] == 'S')
                    {
                        myRow = i;
                        myCol = j;
                    }
                    galaxy[i, j] = command[j];
                }
            }

            while (starPower < 50)
            {
                var command = Console.ReadLine();
                if (command == "right" && IsSave(command))
                {
                    Right();
                }
                else if (command == "left" && IsSave(command))
                {
                    Left();
                }
                else if (command == "down" && IsSave(command))
                {
                    Down();
                }
                else if (command == "up" && IsSave(command))
                {
                    Up();
                }
                else if (!IsSave(command))
                {
                    wentVoid = true;
                    break;
                }

               //  Testing
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(galaxy[i,j]);
                    }
                }
                Console.WriteLine();
                
            }
            if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starPower}");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {starPower}");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(galaxy[i, j]);
                }
                Console.WriteLine();

            }


        }

        private static void Up()
        {
            bool teleported = false;
            if (galaxy[myRow - 1, myCol] == 'O')
            {
                for (int i = 0; i < n && !teleported; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != myRow - 1 && j != myCol)
                        {
                            galaxy[myRow, myCol] = '-';
                            galaxy[myRow - 1, myCol] = '-';
                            galaxy[i, j] = 'S';
                            myRow = i;
                            myCol = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[myRow - 1, myCol] != '-')
            {
                starPower += int.Parse(galaxy[myRow - 1, myCol].ToString());
                galaxy[myRow - 1, myCol] = 'S';
            }
            else
            {
                galaxy[myRow - 1, myCol] = 'S';
            }
            if (!teleported)
            {
                galaxy[myRow, myCol] = '-';
                myRow--;
            }
        }

        private static void Down()
        {
            bool teleported = false;
            if (galaxy[myRow + 1, myCol] == 'O')
            {
                for (int i = 0; i < n && !teleported; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != myRow + 1 && j != myCol)
                        {
                            galaxy[myRow, myCol] = '-';
                            galaxy[myRow + 1, myCol] = '-';
                            galaxy[i, j] = 'S';
                            myRow = i;
                            myCol = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[myRow + 1, myCol] != '-')
            {
                starPower += int.Parse(galaxy[myRow + 1, myCol].ToString());
                galaxy[myRow + 1, myCol] = 'S';
            }
            else
            {
                galaxy[myRow + 1, myCol] = 'S';
            }
            if (!teleported)
            {
                galaxy[myRow, myCol] = '-';
                myRow++;
            }
        }

        private static void Left()
        {
            bool teleported = false;
            if (galaxy[myRow, myCol - 1] == 'O')
            {
                for (int i = 0; i < n && !teleported; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != myRow && j != myCol - 1)
                        {
                            galaxy[myRow, myCol] = '-';
                            galaxy[myRow, myCol - 1] = '-';
                            galaxy[i, j] = 'S';
                            myRow = i;
                            myCol = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[myRow, myCol - 1] != '-')
            {
                starPower += int.Parse(galaxy[myRow, myCol - 1].ToString());
                galaxy[myRow, myCol - 1] = 'S';
            }
            else
            {
                galaxy[myRow, myCol - 1] = 'S';
            }
            if (!teleported)
            {
                galaxy[myRow, myCol] = '-';
                myCol--;
            }
        }



        private static void Right()
        {
            bool teleported = false;
            if (galaxy[myRow, myCol + 1] == 'O')
            {
                for (int i = 0; i < n && !teleported; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (galaxy[i, j] == 'O' && i != myRow && j != myCol + 1)
                        {
                            galaxy[myRow, myCol] = '-';
                            galaxy[myRow, myCol + 1] = '-';
                            galaxy[i, j] = 'S';
                            myRow = i;
                            myCol = j;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
            else if (galaxy[myRow, myCol + 1] != '-')
            {
                starPower += int.Parse(galaxy[myRow, myCol + 1].ToString());
                galaxy[myRow, myCol + 1] = 'S';
            }
            else
            {
                galaxy[myRow, myCol + 1] = 'S';
            }
            if (!teleported)
            {
                galaxy[myRow, myCol] = '-';
                myCol++;
            }
        }
        private static bool IsSave(string command)
        {
            if (command == "right")
            {
                if (myCol + 1 < n)
                {
                    return true;
                }
                galaxy[myRow, myCol] = '-';
                return false;
            }
            else if (command == "left")
            {
                if (myCol - 1 >= 0)
                {
                    return true;
                }
                galaxy[myRow, myCol] = '-';
                return false;
            }
            else if (command == "up")
            {
                if (myRow - 1 >= 0)
                {
                    return true;
                }
                galaxy[myRow, myCol] = '-';
                return false;
            }
            else if (command == "down")
            {
                if (myRow + 1 < n)
                {
                    return true;
                }
                galaxy[myRow, myCol] = '-';
                return false;
            }
            return true;
        }
    }
}
