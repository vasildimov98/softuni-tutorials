namespace P03.WildFarm.IO.Modules
{
    using System;

    using P03.WildFarm.IO.Contracts;

    public class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
