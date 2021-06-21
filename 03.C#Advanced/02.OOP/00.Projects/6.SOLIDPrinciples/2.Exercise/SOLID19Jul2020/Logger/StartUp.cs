namespace Logger
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using global::Logger.Core;
    using global::Logger.Factories;
    using global::Logger.Models.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var countOfAppenders = int.Parse(Console.ReadLine());
            var appenders = new List<IAppender>();
            ParseAppendersInput(countOfAppenders, appenders);

            var logger = new Logger(appenders);

            var engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int countOfAppenders, List<IAppender> appenders)
        {
            var appenderFactory = new AppenderFactory();
            for (int i = 0; i < countOfAppenders; i++)
            {
                var appenderArg = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var appenderType = appenderArg[0];
                var layoutType = appenderArg[1];
                var level = "INFO";

                if (appenderArg.Length == 3)
                {
                    level = appenderArg[2];
                }

                try
                {
                    var appender = appenderFactory.ProduceAppender(appenderType,
                        layoutType, level);

                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
