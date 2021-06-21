namespace P03.WildFarm.Factories
{
    using System;

    using Foods;
    using Contracts;

    public static class FoodFactory
    {
        public static IFood CreateFood(string type, int quantity)
        {
            if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                return new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return new Seeds(quantity);
            }
            else
            {
                throw new ArgumentException("Invalid type!");
            }
        }
    }
}

