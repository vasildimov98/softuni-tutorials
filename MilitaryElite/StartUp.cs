namespace MilitaryElite
{
    using MilitaryElite.Core;
    using MilitaryElite.IO;
    using MilitaryElite.IO.Modules;

    public class StartUp
    {
        public static void Main()
        {
            IReadable readable = new Reader();
            IWritable writable = new Writer();

            IEngine engine = new Engine(readable, writable);

            engine.Run();
        }
    }
}
