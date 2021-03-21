using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string number)
        {
            if (!number.All(d => char.IsDigit(d)))
            {
                throw new InvalidNumberExeption();
            }

            return $"Dialing... {number}";
        }
    }
}
