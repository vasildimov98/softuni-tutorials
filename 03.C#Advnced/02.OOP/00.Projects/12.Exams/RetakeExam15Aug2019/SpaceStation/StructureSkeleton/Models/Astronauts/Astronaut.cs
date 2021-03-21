namespace SpaceStation.Models.Astronauts
{
    using Bags;
    using Contracts;
    using SpaceStation.Common;
    using System;


    public abstract class Astronaut : IAstronaut
    {
        private const int OXYGEN_DECREASE = 10;

        private string name;
        private double oxygen;

        private Astronaut()
        {
            this.Bag = new Backpack();
        }
        protected Astronaut(string name, double oxygen)
            : this()
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, ExceptionMessages.INVALID_ASTRONAUT_NAME);
                }

                this.name = value;
            }
        }
        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (oxygen < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_ASTRONAUT_OXYGEN);
                }

                this.oxygen = value;
            }
        }
        public bool CanBreath => this.Oxygen > 0;
        public IBag Bag { get; }

        public virtual void Breath()
        {
            if (this.Oxygen - OXYGEN_DECREASE > 0)
            {
                this.Oxygen -= OXYGEN_DECREASE;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
