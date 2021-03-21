namespace P04.PizzaCalories.Module
{
    using System;
    using P04.PizzaCalories.Ingredients;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int CAPACITY = 10;
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }
        public int NumberOfToppings => this.toppings.Count;
        public double TotalCalories => this.toppings
            .Select(t => t.Calories)
            .Sum()
            + this.Dough.CaloriesPerGram;
        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings + 1 > CAPACITY)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
