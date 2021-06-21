namespace MXGP.Models.Riders
{
    using System;

    using Contracts;
    using Motorcycles.Contracts;

    public class Rider : IRider
    {
        private const int MIN_SYMBOLS_LENGTH = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)
                    || value.Length < MIN_SYMBOLS_LENGTH)
                {
                    var msg = $"Name {value} cannot be less than 5 symbols.";
                    throw new ArgumentException(msg);
                }

                this.name = value;
            }
        }
        public IMotorcycle Motorcycle { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate
            => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle), "Motorcycle cannot be null.");
            }

            this.Motorcycle = motorcycle;
        }
        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
