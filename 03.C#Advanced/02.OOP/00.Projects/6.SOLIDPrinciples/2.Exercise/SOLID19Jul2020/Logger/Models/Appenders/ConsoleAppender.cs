namespace Logger.Models.Appenders
{
    using System;
    using Models.Contracts;
    using Models.Enumerators;
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var format = this.Layout.Format;

            var dateTime = error.DateTime;
            var level = error.Level;
            var message = error.Message;

            var formattedMessage = string.Format(format,
                dateTime.ToString("M/dd/yyyy h:mm:ss tt"),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.Level.ToString().ToUpper()}," +
                $" Messages appended: {this.MessagesAppended}";
        }
    }
}
