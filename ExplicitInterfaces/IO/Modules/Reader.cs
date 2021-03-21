namespace ExplicitInterfaces.IO.Modules
{
    using System;
    using ExplicitInterfaces.IO.Contracts;

    class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
