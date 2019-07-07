using System;

namespace NewEstablishment
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter your galaxy size: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose your difficulty between \"Easy\" and \"Hard\": " );
            string difficult = Console.ReadLine();

            Galaxy galaxy = new Galaxy(n);
            galaxy.Generate();

            // ReadMatrix();
            Console.WriteLine();
            Console.WriteLine("If u can't find your S, type \"Where am i\""); // helps finding your S

            while (galaxy.Hero.StarPower < 50)
            {
                bool showedPlace = false;
                var command = Console.ReadLine();
                if (command == "Where am i")
                {
                    galaxy.ShowHero();
                    showedPlace = true;
                }
                if (command == "right" && galaxy.IsSave(command))
                {
                    galaxy.Right();
                }
                else if (command == "left" && galaxy.IsSave(command))
                {
                    galaxy.Left();
                }
                else if (command == "down" && galaxy.IsSave(command))
                {
                    galaxy.Down();
                }
                else if (command == "up" && galaxy.IsSave(command))
                {
                    galaxy.Up();
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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(galaxy[i, j]);
                }
                Console.WriteLine();

            }

        }

    }
}
