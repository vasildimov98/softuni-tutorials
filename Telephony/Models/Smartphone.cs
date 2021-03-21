namespace Telephony.Models
{
    using System.Linq;
    using Telephony.Contracts;
    using Telephony.Exeptions;

    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }
        public string Browse(string site)
        {
            if (site.Any(chr => char.IsDigit(chr)))
            {
                throw new InvalidURLExeption();
            }

            return $"Browsing: {site}!";
        }
        public string Call(string number)
        {
            if (!number.All(d => char.IsDigit(d)))
            {
                throw new InvalidNumberExeption();
            }

            return $"Calling... {number}";
        }
    }
}
