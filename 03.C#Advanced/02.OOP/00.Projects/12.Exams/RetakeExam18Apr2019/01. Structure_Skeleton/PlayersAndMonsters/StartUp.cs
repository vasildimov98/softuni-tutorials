namespace PlayersAndMonsters
{
    using IO;
    using PlayersAndMonsters.Core;

    public class StartUp
    {
        public static void Main()
        {
            var reader = new Reader();
            var writer = new Writer();
            var engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}