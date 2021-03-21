namespace P03.WildFarm.Animals
{
    using System;

    using Contracts;

    public class Owl : Bird
    {
        private const double WEIGHT_INCREASE = 0.25;
        private const string SOUND = "Hoot Hoot";

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
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

            if (typeOfFood != "Meat")
            {
                throw new ArgumentException($"{typeof(Owl).Name} does not eat {typeOfFood}!");
            }

            base.Weight += WEIGHT_INCREASE * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
