namespace ProductShop
{
    using AutoMapper;

    using Core;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();

            engine.Run();
        }
    }
}