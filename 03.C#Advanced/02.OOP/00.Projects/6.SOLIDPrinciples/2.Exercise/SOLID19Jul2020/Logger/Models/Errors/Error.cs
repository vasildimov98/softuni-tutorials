namespace Logger.Models.Errors
{
    using System;

    using global::Logger.Models.Contracts;
    using global::Logger.Models.Enumerators;

   

    public class Error : IError
    {
        public Error(DateTime dateTime, Level level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTime { get; private set; }

        public Level Level { get; private set; }

        public string Message { get; private set; }
    }
}
