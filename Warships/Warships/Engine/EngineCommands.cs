namespace Warships
{
    using System;
    using Warships.Common;
    using Warships.Engine.Contracts;
    using Warships.Field;

    public class EngineCommands : IEngine
    {
        private BattleField FirstField = new BattleField();
        private BattleField SecondField = new BattleField();

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
            FieldCommandMovement movement = new FieldCommandMovement(field);

            movement.Run();
            Console.WriteLine(GlobalMessages.NextTurnMessage);
        }
        private void End()
        {
            Console.WriteLine("You won!!");
            Console.Beep();
        }
    }
}
