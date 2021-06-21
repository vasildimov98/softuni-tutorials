namespace Logger.Factories
{
    using System;
    
    using global::Logger.Models.Files;
    using global::Logger.Models.Appenders;
    using global::Logger.Models.Contracts;
    using global::Logger.Models.Enumerators;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }
        public IAppender ProduceAppender(string appenderType, string layoutType, string levelStr)
        {
            var layout = this.layoutFactory.ProduceLayout(layoutType);
            var isParse = Enum.TryParse<Level>(levelStr, true, out Level level);

            if (!isParse)
            {
                throw new ArgumentException("Invalid level arg!");
            }

            if (appenderType == "ConsoleAppender")
            {
                return new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                var file = new LogFile("\\data\\", "logs.txt");

                return new FileAppender(layout, level, file);
            }
            else
            {
                throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
