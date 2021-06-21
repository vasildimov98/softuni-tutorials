namespace P03.PizzaCalories.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using P03.PizzaCalories.Contracts;

    public class Pizza
    {
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 15;

        private const int MAX_COUNT_OF_TOPPINGS = 10;

        private string name;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfPizza);
                }

                this.name = value;
            }
        }
        public Dough Dough { get; set; }
        public int NumberOfToppings
            => this.toppings.Count;
        public double TotalCalories
            => this.CalculateTotalCalories();

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings + 1 > MAX_COUNT_OF_TOPPINGS)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberToppings);
            }

            this.toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }

        private double CalculateTotalCalories()
        {
            return this.Dough.CaloriesPerGram + this.toppings.Sum(t => t.CaloriesPerGram);
        }
    }
}
