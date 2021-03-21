using System;

namespace MilitaryElite.IO.Modules
{
    public class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
