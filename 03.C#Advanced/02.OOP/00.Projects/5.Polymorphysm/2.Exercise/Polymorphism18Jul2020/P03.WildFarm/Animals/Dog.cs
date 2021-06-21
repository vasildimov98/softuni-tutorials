namespace P03.WildFarm.Animals
{
    using System;

    using Contracts;

    public class Dog : Mammal
    {
        private const double WEIGHT_INCREASE = 0.40;
        private const string SOUND = "Woof!";

        public Dog(string name, double weight, string livingRegion)
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

            if (typeOfFood != "Meat")
            {
                throw new ArgumentException($"{typeof(Dog).Name} does not eat {typeOfFood}!");
            }

            base.Weight += WEIGHT_INCREASE * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
