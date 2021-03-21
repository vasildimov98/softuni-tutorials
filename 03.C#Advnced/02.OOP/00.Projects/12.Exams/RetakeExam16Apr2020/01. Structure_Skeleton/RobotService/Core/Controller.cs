namespace RobotService.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using RobotService.Models.Garages;
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Procedures;
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;

    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly IProcedure techCheck;
        private readonly IProcedure rest;
        private readonly IProcedure work;
        private readonly IProcedure chip;
        private readonly IProcedure charge;
        private readonly IProcedure polish;

        public Controller()
        {
            this.garage = new Garage();

            this.chip = new Chip();
            this.techCheck = new TechCheck();
            this.rest = new Rest();
            this.work = new Work();
            this.charge = new Charge();
            this.polish = new Polish();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            robot = this.CreateRobot(robotType, name, energy, happiness, procedureTime);

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, robot.Name);
        }
        public string Chip(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.chip.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robot.Name);
        }
        public string TechCheck(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.techCheck.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robot.Name);
        }
        public string Rest(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.rest.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robot.Name);
        }
        public string Work(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.work.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robot.Name, procedureTime);
        }
        public string Charge(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.charge.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robot.Name);
        }
        public string Polish(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.polish.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robot.Name);
        }
        public string Sell(string robotName, string ownerName)
        {
            this.CheckIfRobotExists(robotName);

            var robot = this.garage
                .Robots[robotName];

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }
        public string History(string procedureType)
        {
            string outputMessage;
            if (procedureType == nameof(Chip))
            {
                outputMessage = this.chip.History();
            }
            else if (procedureType == nameof(TechCheck))
            {
                outputMessage = this.techCheck.History();
            }
            else if (procedureType == nameof(Rest))
            {
                outputMessage = this.rest.History();
            }
            else if (procedureType == nameof(Work))
            {
                outputMessage = this.work.History();
            }
            else if (procedureType == nameof(Charge))
            {
                outputMessage = this.charge.History();
            }
            else
            {
                outputMessage = this.polish.History();
            }

            return outputMessage;
        }

        private IRobot CreateRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            return robot;
        }
        private void CheckIfRobotExists(string robotName)
        {
            if (!garage.Robots.Any(a => a.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
