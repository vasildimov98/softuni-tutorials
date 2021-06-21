namespace P03.ShoppingSpree
{
    using System;
    using P03.ShoppingSpree.Core;
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            try
            {
                engine.Run();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }
    }
}
