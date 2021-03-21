namespace BorderControl
{
    using System;
    using BorderControl.Core;
    using BorderControl.IO.Contracts;
    using BorderControl.IO.Models;
    public class StartUp
    {
        public static void Main()
        {
            IReadable reader = new Reader();
            IWritable writer = new Writer();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
