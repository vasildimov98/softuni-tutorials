namespace RobotService.Models.Robots
{
    using Contracts;
    using RobotService.Utilities.Messages;
    using System;

    public abstract class Robot : IRobot
    {
        private string DEF_OWNER_NAME = "Service";
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = DEF_OWNER_NAME;
        }

        public string Name { get; }
        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < MIN_VALUE || MAX_VALUE < value)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }
        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < MIN_VALUE || MAX_VALUE < value)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return string.Format(OutputMessages.RobotInfo, this.GetType().Name, this.Name, this.Happiness, this.Energy);
        }
    }
}
