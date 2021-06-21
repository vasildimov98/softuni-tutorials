namespace RobotService.Models.Procedures.Contracts
{
    using Robots.Contracts;

    public interface IProcedure
    {
        string History();

        void DoService(IRobot robot, int procedureTime);
    }
}
