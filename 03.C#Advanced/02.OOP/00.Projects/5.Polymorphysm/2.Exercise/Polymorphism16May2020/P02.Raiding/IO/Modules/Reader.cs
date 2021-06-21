namespace P02.Raiding.IO.Modules
{
    using System;

    using P02.Raiding.IO.Contracts;
    public class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
