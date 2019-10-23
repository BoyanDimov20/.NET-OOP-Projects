namespace Warships.Engine
{
    using System;
    using Warships.Engine.Contracts;
    using Warships.Field;

    public class EngineKeys : IEngine
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
            Console.WriteLine($"You control the game via keyboard.");
        }

        private void NewTurn(BattleField field)
        {

            FieldKeyMovement readKey = new FieldKeyMovement(field);
            field = new BattleField(readKey.Run());

            GetChanges(field);

            Console.WriteLine($"You fire your shot!");
            var key = Console.ReadKey();
            Console.Clear();

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
