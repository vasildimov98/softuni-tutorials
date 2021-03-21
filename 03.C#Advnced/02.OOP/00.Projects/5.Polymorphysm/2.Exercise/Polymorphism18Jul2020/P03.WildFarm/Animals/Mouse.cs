namespace P03.WildFarm.Animals
{
    using System;

    using Contracts;

    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREASE = 0.10;
        private const string SOUND = "Squeak";

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override string ProduceSound
            => SOUND;

        public override void Eat(IFood food)
        {
            if (food == null)
            {
                return;
            }

            var typeOfFood = food.GetType().Name;

            if (typeOfFood != "Fruit" && typeOfFood != "Vegetable")
            {
                throw new ArgumentException($"{typeof(Mouse).Name} does not eat {typeOfFood}!");
            }

            base.Weight += WEIGHT_INCREASE * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
