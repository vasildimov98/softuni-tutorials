namespace Telephony.IO.Models
{
    using System;
    using Telephony.IO.Contracts;
    public class Reader : IReadable
    {
        string IReadable.ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
