namespace Telephony.Models
{
    using System.Linq;
    using Telephony.Contracts;
    using Telephony.Exeptions;

    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {

        }
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
