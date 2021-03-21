namespace BorderControl.IO.Models
{
    using System;
    using BorderControl.IO.Contracts;

    public class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
