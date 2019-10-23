namespace Warships
{
    using System;
    using Warships.Engine.Contracts;

    public class EngineCommands : IEngine
    {
        private BattleField FirstField = new BattleField(1);
        private BattleField SecondField = new BattleField(2);

        public void Run()
        {
            while (FirstField.AnyAlive() && SecondField.AnyAlive())
            {
                NewTurn(FirstField);

                NewTurn(SecondField);
            }
            End();
        }
        public void GetInfo()
        {
            Console.WriteLine("You control the game via commands.");
        }

        private void NewTurn(BattleField field)
        {
            ConsoleKeyInfo key = default;
            GetChanges(field);

            Console.Write("Command: ");
            var command = Console.ReadLine().Split();
            var row = 0;
            var col = 0;
            if (command[0] == "Cheat")
            {
                field.GetCheatedField();
                key = Console.ReadKey();
            }
            else if (command.Length == 2)
            {
                row = int.Parse(command[0]);
                col = int.Parse(command[1]);
                field.FireAt(row, col);
            }
            GetChanges(field);
            key = Console.ReadKey();

        }
        private void GetChanges(BattleField field)
        {
            Console.Clear();
            field.GetField();
        }
        private void End()
        {
            Console.WriteLine("You won!!");
            Console.Beep();
        }
    }
}
