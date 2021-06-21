namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Contracts;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                return "Invalid number!";
            }

            return $"Dialing... {number}";
        }
    }
}
