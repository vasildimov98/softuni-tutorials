namespace Restaurant.Beverages.HotBeverages
{
    using System;
    public class Coffee : HotBeverage
    {
        private const decimal COFFEE_PRICE = 3.50m;
        private const double COFFEE_MILLILITERS = 50;

        private double caffeine;
        public Coffee(string name, double caffeine)
            : base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine
        {
            get
            {
                return this.caffeine;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Caffeine cannot be empty!");
                }

                this.caffeine = value;
            }
        }
    }
}
