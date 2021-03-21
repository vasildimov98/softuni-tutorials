namespace RobotService.Models.Procedures
{
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Robots.Contracts;
    using System;
    using RobotService.Utilities.Messages;

    public abstract class Procedure : IProcedure
    {
        private ICollection<IRobot> robots;

        public Procedure()
        {
            this.robots = new List<IRobot>();
        }

        protected IReadOnlyCollection<IRobot> Robots
            => (IReadOnlyCollection<IRobot>)this.robots;

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

            this.robots.Add(robot);
        }
    }
}
