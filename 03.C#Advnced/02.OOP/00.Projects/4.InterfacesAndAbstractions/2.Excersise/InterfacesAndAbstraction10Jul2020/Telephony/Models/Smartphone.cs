namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Contracts;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string site)
        {
            if (site.Any(ch => char.IsDigit(ch)))
            {
               return "Invalid URL!";
            }
            
            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
