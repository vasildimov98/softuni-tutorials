namespace P02.Raiding
{
    using P02.Raiding.Core;
    using P02.Raiding.IO.Modules;
    using System;
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
