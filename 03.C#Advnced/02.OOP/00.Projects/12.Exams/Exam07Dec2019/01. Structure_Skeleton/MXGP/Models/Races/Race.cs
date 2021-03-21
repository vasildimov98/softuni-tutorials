namespace MXGP.Models.Races
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Riders.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int MIN_SYMBOLS_LENGTH = 5;
        private const int MIN_LAPS_LENGTH = 1;

        private string name;
        private int laps;

        private readonly ICollection<IRider> riders;

        private Race()
        {
            this.riders = new List<IRider>();
        }
        public Race(string name, int laps)
            : this()
        {
            this.Name = name;
            this.Laps = laps;
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
        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MIN_LAPS_LENGTH)
                {
                    var msg = $"Laps cannot be less than 1.";
                    throw new ArgumentException(msg);
                }

                this.laps = value;
            }
        }
        public IReadOnlyCollection<IRider> Riders
            => (IReadOnlyCollection<IRider>)this.riders;

        public void AddRider(IRider rider)
        {
            this.ValidateRider(rider);

            this.riders.Add(rider);
        }

        private void ValidateRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider), "Rider cannot be null.");
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }

            if (this.Riders.Any(r => r.Name == rider.Name))
            {
                var msg = $"Rider {rider.Name} is already added in {this.Name} race.";
                throw new ArgumentNullException(rider.Name, msg);
            }
        }
    }
}
