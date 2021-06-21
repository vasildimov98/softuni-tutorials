namespace Logger.Core
{
    using System;
    using System.Linq;

    using global::Logger.Factories;
    using global::Logger.Core.Contracts;
    using global::Logger.Models.Contracts;

    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var arg = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var reportLevel = arg[0];
                var time = arg[1];
                var message = arg[2];

                try
                {
                    var error = errorFactory.ProduceError(time, reportLevel, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
