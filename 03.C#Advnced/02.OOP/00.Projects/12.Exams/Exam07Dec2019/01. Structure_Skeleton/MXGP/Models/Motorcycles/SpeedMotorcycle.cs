namespace MXGP.Models.Motorcycles
{
    using System;
    using Utilities.Messages;
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 125;

        private const int MIN_HORSE_POWER = 50;
        private const int MAX_HORSE_POWER = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {

        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MIN_HORSE_POWER || MAX_HORSE_POWER < value)
                {
                    var msg = $"Invalid horse power: {value}.";
                    throw new ArgumentException(msg);
                }

                this.horsePower = value;
            }
        }
    }
}
