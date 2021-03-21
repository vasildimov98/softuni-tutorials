namespace Telephony
{
    using System;
    public class InvalidNumberExeption : Exception
    {
        private const string DEF_MSG = "Invalid number!";
        public InvalidNumberExeption()
            : base(DEF_MSG)
        {
        }

        public InvalidNumberExeption(string message)
            : base(message)
        {
        }
    }
}
