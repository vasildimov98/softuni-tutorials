namespace MXGP.Models.Motorcycles
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_SYMBOLS_LENGTH = 4;

        private string model;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)
                    || value.Length < MIN_SYMBOLS_LENGTH)
                {
                    var msg = $"Model {value} cannot be less than 4 symbols.";
                    throw new ArgumentException(msg);
                }

                this.model = value;
            }
        }
        public abstract int HorsePower { get; protected set; }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return (this.CubicCentimeters / this.HorsePower) * laps;
        }
    }
}
