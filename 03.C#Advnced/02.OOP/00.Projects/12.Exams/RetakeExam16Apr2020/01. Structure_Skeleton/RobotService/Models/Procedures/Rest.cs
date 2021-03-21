namespace RobotService.Models.Procedures
{
    using Robots.Contracts;

    public class Rest : Procedure
    {
        private const int HAPPINESS_DECR = 3;
        private const int ENERGY_INCR = 10;

        private const int LOWER_BOUND = 0;
        private const int UPPER_BOUND = 100;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            this.DecreaseHappiness(robot);
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

        private void DecreaseHappiness(IRobot robot)
        {
            if (robot.Happiness - HAPPINESS_DECR < LOWER_BOUND)
            {
                robot.Happiness = LOWER_BOUND;
            }
            else
            {
                robot.Happiness -= HAPPINESS_DECR;
            }
        }
    }
}
