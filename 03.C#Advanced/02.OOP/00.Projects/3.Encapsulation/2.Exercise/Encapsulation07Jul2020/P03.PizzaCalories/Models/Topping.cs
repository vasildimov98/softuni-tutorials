namespace P03.PizzaCalories.Models
{
    using System;
    using P03.PizzaCalories.Contracts;
    public class Topping
    {
        private const string TOPPINGS = "MEAT VEGGIES CHEESE SAUCE";

        private const string MEAT_TYPE = "MEAT";
        private const string VEGGIES_TYPE = "VEGGIES";
        private const string SAUCE_TYPE = "SAUCE";

        private const double MEAT = 1.2;
        private const double VEGGIES = 0.8;
        private const double CHEESE = 1.1;
        private const double SAUCE = 0.9;

        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 50;
        private const double BASE_CALORIES_PERGRAM = 2;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!TOPPINGS.Contains(value.ToUpper()))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTypeOfTopping, value));
                }

                this.type = value;
            }
        }
        public double Weight 
        {
            get => this.weight;
            private set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(string
                        .Format(ExceptionMessages.InvalidRangeOfWeightOfTopping, this.Type));
                }

                this.weight = value;
            }
        }
        public double CaloriesPerGram
            => this.Weight * this.GetCalories() * BASE_CALORIES_PERGRAM;

        private double GetCalories()
        {
            if (MEAT_TYPE.Contains(this.Type.ToUpper()))
            {
                return MEAT;
            }
            else if (VEGGIES_TYPE.Contains(this.Type.ToUpper()))
            {
                return VEGGIES;
            }
            else if (SAUCE_TYPE.Contains(this.Type.ToUpper()))
            {
                return SAUCE;
            }
            else
            {
                return CHEESE;
            }
        }
    }
}
