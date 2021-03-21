namespace Telephony
{
    using System.Linq;
    public  class Smartphone : ISmartphone
    {
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
