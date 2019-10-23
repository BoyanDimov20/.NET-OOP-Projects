namespace Warships.Field
{
    using System;

    public class FieldKeyMovement
    {
        private BattleField field;
        private int currentRow = 0;
        private int currentCol = 0;
        private int lastCondition;

        public FieldKeyMovement(BattleField field)
        {
            this.field = field;
            lastCondition = this.field.Condition[currentRow, currentCol];
            this.field.Condition[currentRow, currentCol] = -2;
        }
        public BattleField Run()
        {
            while (true)
            {
                field.GetField();
                string movementCommand = Move();
                if (movementCommand == "Fire")
                {
                    return field;
                }
                Console.Clear();
            }
        }

        private string ReadKey()
        {
            var readKey = Console.ReadKey();
            if (readKey.Key == ConsoleKey.LeftArrow)
            {
                return "Left";
            }
            else if (readKey.Key == ConsoleKey.RightArrow)
            {
                return "Right";
            }
            else if (readKey.Key == ConsoleKey.UpArrow)
            {
                return "Up";
            }
            else if (readKey.Key == ConsoleKey.DownArrow)
            {
                return "Down";
            }
            else if (readKey.Key == ConsoleKey.Enter)
            {
                return "Fire";
            }
            return String.Empty;
        }
        private string Move()
        {
            string command = ReadKey();
            if (command == "Right")
            {
                if(FieldValidator.CheckPostion(currentRow, currentCol + 1, field.Size))
                {
                    field.Condition[currentRow, currentCol] = lastCondition;
                    currentCol++;
                    lastCondition = field.Condition[currentRow, currentCol];
                    field.Condition[currentRow, currentCol] = -2;
                }
            }
            else if (command == "Left")
            {
                if (FieldValidator.CheckPostion(currentRow, currentCol - 1, field.Size))
                {
                    field.Condition[currentRow, currentCol] = lastCondition;
                    currentCol--;
                    lastCondition = field.Condition[currentRow, currentCol];
                    field.Condition[currentRow, currentCol] = -2;
                }
            }
            else if (command == "Up")
            {
                if (FieldValidator.CheckPostion(currentRow - 1, currentCol, field.Size))
                {
                    field.Condition[currentRow, currentCol] = lastCondition;
                    currentRow--;
                    lastCondition = field.Condition[currentRow, currentCol];
                    field.Condition[currentRow, currentCol] = -2;
                }
            }
            else if (command == "Down")
            {
                if (FieldValidator.CheckPostion(currentRow + 1, currentCol, field.Size))
                {
                    field.Condition[currentRow, currentCol] = lastCondition;
                    currentRow++;
                    lastCondition = field.Condition[currentRow, currentCol];
                    field.Condition[currentRow, currentCol] = -2;
                }
            }
            else if (command == "Fire")
            {
                if (this.lastCondition == 1)
                {
                    field.Condition[currentRow, currentCol] = -1;
                }
                else
                {
                    field.Condition[currentRow, currentCol] = lastCondition;
                }
            }
            return command;
        }
    }
}
