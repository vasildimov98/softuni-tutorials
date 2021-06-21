namespace Restaurant.Beverages
{
    using System;
    public class Beverage : Product
    {
        private double milliliters;
        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        public double Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Milliliters cannot be less than zero!");
                }

                this.milliliters = value;
            }
        }
    }
}
