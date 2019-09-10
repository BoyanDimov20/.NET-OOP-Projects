using System;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static Player you = new Player('X');
        static Player enemy = new Player('O');
        static void Main(string[] args)
        {
            
            while (true)
            {
                StartGame();


                Console.WriteLine("If you want to continue the game,");
                Console.WriteLine("press Enter!");
                var end = Console.ReadKey();
                if (end.Key != ConsoleKey.Enter)
                {
                    break;
                }
                Console.Clear();
                
            }




        }

        static void StartGame()
        {
            Table table = new Table();

            Player currentPlayer = you;
            table.Print();

            Progress(currentPlayer, table); // The actual game 
            
            Console.Clear();
            Console.Beep();
            Console.WriteLine();
            if (table.IsGameOver())
            {
                Console.WriteLine($"The winner is {table.Winner()}");
            }
            else
            {
                Console.WriteLine("It's Draw!");
            }
        }

        static void Progress(Player currentPlayer, Table table)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine($"It's '{currentPlayer.Symbol}' turn!");
                int row = 0;
                int col = 0;

                try
                {
                    Console.Write("Choose Row: ");
                    row = int.Parse(Console.ReadLine());

                    Console.Write("Choose Col: ");
                    col = int.Parse(Console.ReadLine());
                    if (table.Matrix[row][col] != '-')
                    {
                        Console.WriteLine("The position is taken");
                        Progress(currentPlayer, table);
                    }
                    table.Matrix[row][col] = currentPlayer.Symbol;

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid operation. Try Again!");
                    Progress(currentPlayer, table);
                }

                if (row > 3 || row < 0 || col > 3 || col < 0) // Checks for invalid row/col
                {
                    Console.Clear();
                    Console.WriteLine("Invalid position. Try Again!");
                    continue;
                }
                

                if (currentPlayer.Symbol == 'X')
                {
                    currentPlayer = enemy;
                }
                else
                {
                    currentPlayer = you;
                }

                Console.Clear();
                table.Print();

                if (table.IsGameOver() || table.Draw())
                {
                    break;
                }

            }
        }
    }
}
