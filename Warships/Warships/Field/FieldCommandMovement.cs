namespace Warships.Field
{
    using System;

    public class FieldCommandMovement
    {
        private BattleField field;

        public FieldCommandMovement(BattleField field)
        {
            this.field = field;
        }
        public void Run()
        {
            GetChanges(field);
            Console.Write("Command: ");

            ReadCommand();

            GetChanges(field);
        }

        private void GetChanges(BattleField field)
        {
            Console.Clear();
            field.GetField();
        }
        private void ReadCommand()
        {
            var command = Console.ReadLine().Split();

            var row = 0;
            var col = 0;

            if (command[0] == "Cheat")
            {
                field.GetCheatedField();
                ConsoleKeyInfo key = Console.ReadKey();
            }
            else if (command.Length == 2)
            {
                if (row >= 0 && row < field.Size && col >= 0 && col < field.Size)
                {
                    row = int.Parse(command[0]);
                    col = int.Parse(command[1]);
                    field.FireAt(row, col);
                }
                else
                {
                    ReadCommand();
                }
            }
        }


    }
}
