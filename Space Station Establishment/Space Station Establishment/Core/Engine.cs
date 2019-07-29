using MovementInGalaxy;
using NewEstablishment;
using Space_Station_Establishment.Exceptions;
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

            char symbol = ChooseSymbol();

            int galaxySize = ChooseSize();

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
                    Console.Clear();
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

        private static int ChooseSize()
        {
            Console.Write("Enter your galaxy size: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input <= 0)
                {
                    throw new ArgumentException("Galaxy size cannot be negative.");
                }
                return input;
            }
            catch (FormatException)
            {
                Console.WriteLine(ExceptionMesseges.InvalidInputException);
                return ChooseSize();
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return ChooseSize();
            }

        }
        private static char ChooseSymbol()
        {
            Console.Write("Choose a symbol between \"S\", \"X\", \"A\",  \"B\": ");
            try
            {
                char input = char.Parse(Console.ReadLine());
                if (input != 'S' && input != 'X' && input != 'A' && input != 'B')
                {
                    throw new ArgumentException(ExceptionMesseges.InvalidInputException);
                }
                return input;
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return ChooseSymbol();
            }
            catch (FormatException)
            {
                Console.WriteLine(ExceptionMesseges.InvalidInputException);
                return ChooseSymbol();
            }
            

        }
    }
}
