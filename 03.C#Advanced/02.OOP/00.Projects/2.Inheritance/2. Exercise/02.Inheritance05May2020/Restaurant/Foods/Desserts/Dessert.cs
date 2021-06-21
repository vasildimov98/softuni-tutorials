namespace Restaurant.Foods.Desserts
{
    using System;
    public class Dessert : Food
    {
        private double calories;
        public Dessert(string name, decimal price, double grams, double calories)
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public double Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Calories cannot be less than zero!");
                }

                this.calories = value;
            }
        }
    }
}
