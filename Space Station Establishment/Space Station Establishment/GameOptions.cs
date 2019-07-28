using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Station_Establishment
{
    static class GameOptions
    {
        public static int AskQuestion(int income)
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
        public static void ShowRules()
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
