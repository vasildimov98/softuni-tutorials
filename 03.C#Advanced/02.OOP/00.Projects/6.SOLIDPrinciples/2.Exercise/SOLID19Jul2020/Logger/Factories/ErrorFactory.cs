namespace Logger.Factories
{
    using System;
    using System.Globalization;

    using global::Logger.Models.Errors;
    using global::Logger.Models.Contracts;
    using global::Logger.Models.Enumerators;

    public class ErrorFactory
    {
        public IError ProduceError(string dateTimeStr, string levelStr, string message)
        {
            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateTimeStr,
                    "M/dd/yyyy h:mm:ss tt",
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid time argument!", e);
            }

            var isParse = Enum.TryParse<Level>(levelStr, true, out Level level);

            if (!isParse)
            {
                throw new ArgumentException("Invalid level argument!");
            }

            return new Error(dateTime, level, message);
        }
    }
}
