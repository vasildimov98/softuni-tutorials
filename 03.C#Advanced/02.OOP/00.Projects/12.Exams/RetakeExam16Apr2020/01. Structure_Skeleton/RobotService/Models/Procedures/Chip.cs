using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int HAPPINESS_DECR = 5;
        private const int LOWER_BOUND_OF_HAPPINESS = 0;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }
            else
            {
                robot.IsChipped = true;
            }


            if (robot.Happiness - HAPPINESS_DECR < LOWER_BOUND_OF_HAPPINESS)
            {
                robot.Happiness = LOWER_BOUND_OF_HAPPINESS;
            }
            else
            {
                robot.Happiness -= HAPPINESS_DECR;
            }
        }
    }
}
