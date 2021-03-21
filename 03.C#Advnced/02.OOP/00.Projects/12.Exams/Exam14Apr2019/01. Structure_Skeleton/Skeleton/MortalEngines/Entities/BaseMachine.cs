namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private double healthPoints;
        private IPilot pilot;

        private BaseMachine()
        {
            this.Targets = new List<string>();
        }

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
            : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }
        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                this.healthPoints = value > 0 ? value : 0;
            }
        }
        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    this.ThrowNullReferenceExceptionWithMessage("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }
        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                this.ThrowNullReferenceExceptionWithMessage("Target cannot be null");
            }

            var demage = this.AttackPoints - target.DefensePoints;

            target.HealthPoints -= demage;

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var targets = this.Targets.Count > 0 ?
                string.Join(',', this.Targets) :
                "None";

            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:F2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}")
                .AppendLine($" *Targets: {targets}");

            return sb.ToString().TrimEnd();
        }

        private void ThrowNullReferenceExceptionWithMessage(string message)
        {
            throw new NullReferenceException(message);
        }
    }
}
