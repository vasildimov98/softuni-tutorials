namespace P01.Vehicles.IO.Modules
{
    using System;

    using P01.Vehicles.IO.Contracts;

    public class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
