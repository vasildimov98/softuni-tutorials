using SpaceStation.Common;
using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();

            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    var output = this.ProcceedCommand(input);

                    writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private string ProcceedCommand(string[] input)
        {
            if (input[0] == "AddAstronaut")
            {
                return this.controller.AddAstronaut(input[1], input[2]);
            }
            else if (input[0] == "AddPlanet")
            {
                return this.controller.AddPlanet(input[1], input.Skip(2).ToArray());
            }
            else if (input[0] == "RetireAstronaut")
            {
                return this.controller.RetireAstronaut(input[1]);
            }
            else if (input[0] == "ExplorePlanet")
            {
                return this.controller.ExplorePlanet(input[1]);
            }
            else if (input[0] == "Report")
            {
                return this.controller.Report();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_COMMAND);
            }
        }
    }
}
