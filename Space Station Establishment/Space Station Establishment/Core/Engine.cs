using MovementInGalaxy;
using NewEstablishment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Station_Establishment.Core
{
    static class Engine
    {
        public static void Run()
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.Write("Choose a symbol between \"S\", \"X\", \"A\",  \"B\": ");
            char symbol = char.Parse(Console.ReadLine());

            Console.Write("Enter your galaxy size: ");
            int galaxySize = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose your difficulty between \"Easy\" and \"Hard\": ");
            string difficult = Console.ReadLine();

            Galaxy galaxy = new Galaxy(galaxySize, playerName, symbol);
            galaxy.Generate();

            Console.WriteLine();
            Console.WriteLine($"If u can't find your {symbol}, type \"Where am i\""); // helps finding your S
            Console.WriteLine();
            Console.WriteLine("If u don't know the rules of the game, type \"Rules\"");

            while (galaxy.Hero.StarPower < 50)
            {
                bool showedPlace = false;
                var command = Console.ReadLine();
                if (command == "Where am i")
                {
                    galaxy.ShowHero();
                    showedPlace = true;
                }
                else if (command == "Rules")
                {
                    GameOptions.ShowRules();
                }
                if (command == "right" && galaxy.IsSave(command))
                {
                    Movement.Right(galaxy, galaxy.Hero);
                }
                else if (command == "left" && galaxy.IsSave(command))
                {
                    Movement.Left(galaxy, galaxy.Hero);

                }
                else if (command == "down" && galaxy.IsSave(command))
                {
                    Movement.Down(galaxy, galaxy.Hero);
                }
                else if (command == "up" && galaxy.IsSave(command))
                {
                    Movement.Up(galaxy, galaxy.Hero);
                }
                else if (!galaxy.IsSave(command))
                {
                    break;
                }

                if (difficult == "Easy" && !showedPlace)
                {
                    galaxy.Show();
                }

            }
            if (galaxy.Hero.StarPower >= 50)
            {
                Console.WriteLine($"Good news! {playerName} succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {galaxy.Hero.StarPower}");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {galaxy.Hero.StarPower}");
            }
            for (int i = 0; i < galaxySize; i++)
            {
                for (int j = 0; j < galaxySize; j++)
                {
                    Console.Write(galaxy[i, j]);
                }
                Console.WriteLine();

            }

        }
    
    }
}
