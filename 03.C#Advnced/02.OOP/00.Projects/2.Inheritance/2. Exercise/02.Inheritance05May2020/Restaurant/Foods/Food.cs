namespace Restaurant.Foods
{
    using System;
    public class Food : Product
    {
        private double grams;
        public Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("grams cannot be less than zero!");
                }

                this.grams = value;
            }
        }
    }
}
