namespace MXGP.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;
    using MXGP.IO;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
              
        private readonly IChampionshipController championshipController;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();

            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var command = reader.ReadLine();

                if (command == "End")
                {
                    Environment.Exit(0);
                }

                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                try
                {
                    var output = ProcceedCommand(args, action);

                    writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private string ProcceedCommand(string[] args, string action)
        {
            string output;
            if (action == "CreateRider")
            {
                var name = args[1];
                output = this.championshipController.CreateRider(name);
            }
            else if (action == "CreateMotorcycle")
            {
                var motorcycleType = args[1];
                var model = args[2];
                var horsepower = int.Parse(args[3]);

                output = this.championshipController.CreateMotorcycle(motorcycleType, model, horsepower);
            }
            else if (action == "AddMotorcycleToRider")
            {
                var riderName = args[1];
                var motorcycleModel = args[2];

                output = this.championshipController.AddMotorcycleToRider(riderName, motorcycleModel);
            }
            else if (action == "AddRiderToRace")
            {
                var raceName = args[1];
                var riderName = args[2];

                output = this.championshipController.AddRiderToRace(raceName, riderName);
            }
            else if (action == "CreateRace")
            {
                var raceName = args[1];
                var laps = int.Parse(args[2]);

                output = this.championshipController.CreateRace(raceName, laps);
            }
            else 
            {
                var raceName = args[1];

                output = this.championshipController.StartRace(raceName);
            }

            return output;
        }
    }
}
