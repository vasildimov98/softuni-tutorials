namespace P03.WildFarm
{
    using P03.WildFarm.Core.Modules;
    using P03.WildFarm.IO.Modules;

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
