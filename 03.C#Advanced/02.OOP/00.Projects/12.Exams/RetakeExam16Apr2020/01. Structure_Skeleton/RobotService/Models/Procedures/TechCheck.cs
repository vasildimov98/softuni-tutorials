namespace RobotService.Models.Procedures
{
    using Robots.Contracts;

    public class TechCheck : Procedure
    {
        private const int ENERGY_DECR = 8;
        private const int LOWER_BOUND = 0;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (!robot.IsChipped)
            {
                robot.IsChecked = true;
            }

            if (robot.Energy - ENERGY_DECR < LOWER_BOUND)
            {
                robot.Energy = LOWER_BOUND;
            }
            else
            {
                robot.Energy -= ENERGY_DECR;
            }
        }
    }
}
