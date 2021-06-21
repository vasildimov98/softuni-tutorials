namespace P01.Vehicles
{
    using P01.Vehicles.Core;
    using P01.Vehicles.IO.Modules;
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
