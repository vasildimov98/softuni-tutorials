namespace MXGP.Models.Motorcycles
{
    using System;
    using Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {

        private const double CUBIC_CENTIMETERS = 450;

        private const int MIN_HORSE_POWER = 70;
        private const int MAX_HORSE_POWER = 100;

        private int horsePower;


        public PowerMotorcycle(string model, int horsePower) 
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
