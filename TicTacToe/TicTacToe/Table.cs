using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Table
    {
        private const int InitialSize = 4;

        public Table()
        {
            Create();
        }

        public List<List<char>> Matrix { get; set; } = new List<List<char>>();

        private void Create()
        {
            
            for (int i = 0; i < InitialSize; i++)
            {
                Matrix.Add(new List<char>());
                for (int j = 0; j < InitialSize; j++)
                {
                    if (i == 0) // Creates 1-2-3 border
                    {
                        Matrix[i].Add(char.Parse(j.ToString()));
                    }
                    else if (j == 0)
                    {
                        Matrix[i].Add(char.Parse(i.ToString()));
                    }
                    else
                    {
                        Matrix[i].Add('-');
                    }
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < InitialSize; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < InitialSize; j++)
                {
                    Console.Write(Matrix[i][j]);
                }
            }
        }
        public bool Draw()
        {
            for (int i = 1; i < InitialSize; i++)
            {
                if (!Matrix[i].All(x => x != '-'))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsGameOver()
        {
            char symbol = '-';
            
            for (int i = 1; i < InitialSize; i++)
            {
                if (Matrix[i][1] == Matrix[i][2] && Matrix[i][2] == Matrix[i][3])
                {
                    symbol = Matrix[i][1];
                    if (symbol != '-')
                    {
                        break;
                    }
                }
                else if (Matrix[1][i] == Matrix[2][i] && Matrix[2][i] == Matrix[3][i])
                {
                    symbol = Matrix[1][i];
                    if (symbol != '-')
                    {
                        break;
                    }
                }
            }
            if (Matrix[1][1] == Matrix[2][2] && Matrix[2][2] == Matrix[3][3])
            {
                symbol = Matrix[1][1];
            }
            else if (Matrix[1][3] == Matrix[2][2] && Matrix[2][2] == Matrix[3][1])
            {
                symbol = Matrix[1][3];
            }

            if (symbol == '-')
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public char Winner()
        {
            char symbol = '-';

            for (int i = 1; i < InitialSize; i++)
            {
                if (Matrix[i][1] == Matrix[i][2] && Matrix[i][2] == Matrix[i][3])
                {
                    symbol = Matrix[i][1];
                    if (symbol != '-')
                    {
                        break;
                    }
                }
                else if (Matrix[1][i] == Matrix[2][i] && Matrix[2][i] == Matrix[3][i])
                {
                    symbol = Matrix[1][i];
                    if (symbol != '-')
                    {
                        break;
                    }
                }
            }
            if (Matrix[1][1] == Matrix[2][2] && Matrix[2][2] == Matrix[3][3])
            {
                symbol = Matrix[1][1];
            }
            else if (Matrix[1][3] == Matrix[2][2] && Matrix[2][2] == Matrix[3][1])
            {
                symbol = Matrix[1][3];
            }

            return symbol;
        }

        

    }
}
