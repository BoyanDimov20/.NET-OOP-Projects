namespace Warships
{
    using Warships.Engine;
    using Warships.Engine.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new EngineKeys();
            engine.Run();

        }
    }
}
