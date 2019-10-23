using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            
            while (true)
            {
                int bulls = 0;
                int cows = 0;
                Console.Write("Guess the number: ");
                int tryNum = 0;
                try
                {
                    tryNum = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    continue;
                }
                if (tryNum == game.IntNumber)
                {
                    break;
                }
                int temp = tryNum;
                int realTemp = game.IntNumber;

                while (temp != 0) // Checking For bulls
                {
                    if (temp % 10 == realTemp % 10)
                    {
                        bulls++;
                        
                    }
                    if (game.ListNumber.Contains(temp % 10))
                    {
                        cows++;
                    }
                    temp /= 10;
                    realTemp /= 10;
                }

                Console.WriteLine("Bulls: " + bulls);
                Console.WriteLine("Cows: " + Math.Abs(bulls - cows));

            }

            Console.Clear();
            Console.Beep();
            Console.WriteLine("You won!");
            Console.WriteLine("The number is " + game.IntNumber);
            while (true)
            {
                var key = Console.ReadKey();
                break;
            }

        }
    }
}
