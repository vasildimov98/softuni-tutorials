namespace ViceCity.Core
{
    using System;

    using IO;
    using Contracts;
    using IO.Contracts;
    using ViceCity.Common;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private readonly IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

            controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader
                    .ReadLine()
                    .Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    var output = this.ProceedCommands(input);

                    writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private string ProceedCommands(string[] input)
        {
            if (input[0] == "AddPlayer")
            {
                var name = input[1];

                return this.controller.AddPlayer(name);
            }
            else if (input[0] == "AddGun")
            {
                var type = input[1];
                var gunName = input[2];

                return this.controller.AddGun(type, gunName);
            }
            else if (input[0] == "AddGunToPlayer")
            {
                var name = input[1];

                return this.controller.AddGunToPlayer(name);
            }
            else if (input[0] == "Fight")
            {
                return this.controller.Fight();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.INVALID_COMMAND);
            }
        }
    }
}
