using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    class Game
    {
        public List<int> ListNumber { get; set; } = new List<int>();
        public int IntNumber { get; set; }

        public Game()
        {
            CreateNum();
        }
        public void CreateNum()
        {
            Random randomNumber = new Random();
            List<int> number = new List<int>();

            while (number.Count < 4)
            {
                int digits = randomNumber.Next(9);

                if (!number.Exists(x => x == digits))
                {
                    number.Add(digits);
                }
            }

            ListNumber = number;
            IntNumber = int.Parse(string.Join("", number));

        }
        
    }
}
