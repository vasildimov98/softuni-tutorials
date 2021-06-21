namespace RobotService.Models.Procedures
{
    using Robots.Contracts;

    public class Work : Procedure
    {
        private const int HAPPINESS_INCR = 12;
        private const int ENERGY_DECR = 6;

        private const int LOWER_BOUND = 0;
        private const int UPPER_BOUND = 100;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            this.IncreaseHappiness(robot);
            this.DecreaseEnergy(robot);
        }

        private void DecreaseEnergy(IRobot robot)
        {
            if (robot.Energy - ENERGY_DECR < LOWER_BOUND)
            {
                robot.Energy = LOWER_BOUND;
            }
            else
            {
                robot.Energy -= ENERGY_DECR;
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
