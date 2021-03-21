namespace Telephony.Exeptions
{
    using System;
    public class InvalidURLExeption : Exception
    {
        private const string DEF_MSG = "Invalid URL!";
        public InvalidURLExeption()
            : base(DEF_MSG)
        {
        }

        public InvalidURLExeption(string message)
            : base(message)
        {
        }
    }
}
