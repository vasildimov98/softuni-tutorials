namespace P03.WildFarm.Factories
{
    using System;

    using P03.WildFarm.Contract;
    using P03.WildFarm.Modules.Food;

    public static class FoodFactory
    {
        public static IFood CreateFood(string type, int quantity)
        {
            if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Vegetable")
            {
                return new Vegetable(quantity);
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
                throw new ArgumentException();
            }
        }
    }
}
