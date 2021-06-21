namespace RobotService.Models.Garages
{
    using Contracts;
    using Robots.Contracts;
    using Utilities.Messages;

    using System;
    using System.Collections.Generic;

    public class Garage : IGarage
    {
        private const int GARAGE_CAPACITY = 10;

        private IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots
            => (IReadOnlyDictionary<string, IRobot>)this.robots;
        public int Capacity => GARAGE_CAPACITY;

        public void Manufacture(IRobot robot)
        {
            if (this.Capacity == this.robots.Count )
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            var robotName = robot.Name;

            if (this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robotName));
            }

            this.robots[robotName] = robot;
        }
        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var robot = this.robots[robotName];

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
