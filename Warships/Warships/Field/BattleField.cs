namespace Warships
{
    using System;
    using Warships.Field;

    public class BattleField
    {
        private const int BattlefieldSize = 7;
        public BattleField()
        {
            SetCondition();
            GenerateShips();
        }
        public BattleField(BattleField field)
        {
            this.Condition = field.Condition;
        }
        
        public int[,] Condition { get; private set; } = new int[BattlefieldSize, BattlefieldSize];
        public int Size => BattlefieldSize; 

        public void GetField()
        {
            for (int i = 0; i < BattlefieldSize; i++)
            {
                for (int j = 0; j < BattlefieldSize; j++)
                {
                    if (Condition[i, j] == -1)
                    {
                        Console.Write('*');
                    }
                    else if (Condition[i, j] == -2)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('O');
                    }
                }
                Console.WriteLine();
            }
        } 
        public void GetCheatedField()
        {
            for (int i = 0; i < BattlefieldSize; i++)
            {
                for (int j = 0; j < BattlefieldSize; j++)
                {
                    if (Condition[i, j] == 0)
                    {
                        Console.Write('O');
                    }
                    else if (Condition[i, j] == 1)
                    {
                        Console.Write('@');
                    }
                    else if (Condition[i, j] == -1)
                    {
                        Console.Write('*');
                    }
                    else if (Condition[i, j] == -2)
                    {
                        Console.Write('X');
                    }
                }
                Console.WriteLine();
            }
        } 
        public void FireAt(int row, int col)
        {
            if (FieldValidator.CheckPostion(row, col, BattlefieldSize))
            {
                if (Condition[row, col] == 1)
                {
                    Condition[row, col] = -1;
                }
            }
        }
        public void SetCursor(int row, int col)
        {
            if (FieldValidator.CheckPostion(row, col, BattlefieldSize))
            {
                Condition[row, col] = -2;
            }
        }
        public bool AnyAlive()
        {
            for (int i = 0; i < BattlefieldSize; i++)
            {
                for (int j = 0; j < BattlefieldSize; j++)
                {
                    if (Condition[i, j] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        } 

        private void GenerateShips()
        {
            Random random = new Random();

            int iterator = 0;
            while(iterator < 6)
            {
                for (int i = 1; i < BattlefieldSize && iterator < 6; i++)
                {
                    for (int j = 1; j < BattlefieldSize && iterator < 6; j++)
                    {
                        int num = random.Next(0, 4);

                        if (num == 0 && i + 1 < BattlefieldSize && Condition[i, j] == 0)
                        {
                            iterator++;
                            Condition[i, j] = 1;
                            Condition[i + 1, j] = 1;
                        }
                    }
                }
            }


        } 
        private void SetCondition()
        {
            for (int i = 1; i < BattlefieldSize; i++)
            {
                for (int j = 1; j < BattlefieldSize; j++)
                {
                    Condition[i, j] = 0;
                }
            }   
        } 


    }
}
