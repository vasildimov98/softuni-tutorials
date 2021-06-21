using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        private const int HAPPINESS_DECR = 7;
        private const int LOWER_BOUND_OF_HAPPINESS = 0;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

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
