namespace RobotService.Models.Procedures
{
    using System;

    using Robots.Contracts;
    using RobotService.Utilities.Messages;

    public class Charge : Procedure
    {
        private const int HAPPINESS_INCR = 12;
        private const int ENERGY_INCR = 10;
        private const int UPPER_BOUND = 100;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            this.IncreaseHappiness(robot);
            this.IncreaseEnergy(robot);
        }

        private void IncreaseEnergy(IRobot robot)
        {
            if (robot.Energy + ENERGY_INCR > UPPER_BOUND)
            {
                robot.Energy = UPPER_BOUND;
            }
            else
            {
                robot.Energy += ENERGY_INCR;
            }
        }

        private void IncreaseHappiness(IRobot robot)
        {
            if (robot.Happiness + HAPPINESS_INCR > UPPER_BOUND)
            {
                robot.Happiness = UPPER_BOUND;
            }
            else
            {
                robot.Happiness += HAPPINESS_INCR;
            }
        }
    }
}
