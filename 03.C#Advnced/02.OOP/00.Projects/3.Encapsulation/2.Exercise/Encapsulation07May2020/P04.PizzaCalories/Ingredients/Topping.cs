namespace P04.PizzaCalories.Ingredients
{
    using System;
 
    public class Topping
    {
        private const string TYPE = "meat veggies cheese sauce";
        private const double WEIGHT_PER_GRAMS = 2;
        private const double MEAT = 1.2;
        private const double VEGGIES = 0.8;
        private const double CHEESE = 1.1;
        private const double SOUCE = 0.9;

        private string type;
        private double weight;
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (!TYPE.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double Calories => (WEIGHT_PER_GRAMS * this.Weight) * GetGrams(this.type);
        private double GetGrams(string type)
        {
            if (type.ToLower() == "meat")
            {
                return MEAT;
            }
            else if (type.ToLower() == "veggies")
            {
                return VEGGIES;
            }
            else if (type.ToLower() == "cheese")
            {
                return CHEESE;
            }
            else
            {
                return SOUCE;
            }
        }
    }
}
