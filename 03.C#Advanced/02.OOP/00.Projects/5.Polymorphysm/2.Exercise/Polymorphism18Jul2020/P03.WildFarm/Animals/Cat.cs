namespace P03.WildFarm.Animals
{
    using System;

    using Contracts;

    public class Cat : Feline
    {
        private const double WEIGHT_INCREASE = 0.30;
        private const string SOUND = "Meow";

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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

            if (typeOfFood != "Meat" && typeOfFood != "Vegetable")
            {
                throw new ArgumentException($"{typeof(Cat).Name} does not eat {typeOfFood}!");
            }

            base.Weight += WEIGHT_INCREASE * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
