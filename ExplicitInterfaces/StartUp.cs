namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Core;
    using ExplicitInterfaces.IO.Contracts;
    using ExplicitInterfaces.IO.Modules;
    using System;
    public class StartUp
    {
        static void Main()
        {
            IReadable readable = new Reader();
            IWritable writable = new Writer();

            IEngine engine = new Engine(readable, writable);

            engine.Run();
        }
    }
}
