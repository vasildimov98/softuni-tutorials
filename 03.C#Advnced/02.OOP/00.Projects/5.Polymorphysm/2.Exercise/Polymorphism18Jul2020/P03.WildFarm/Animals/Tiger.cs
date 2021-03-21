namespace P03.WildFarm.Animals
{
    using System;

    using Contracts;
    
    public class Tiger : Feline
    {
        private const double WEIGHT_INCREASE = 1.00;
        private const string SOUND = "ROAR!!!";

        public Tiger(string name, double weight, string livingRegion, string breed)
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

            if (typeOfFood != "Meat")
            {
                throw new ArgumentException($"{typeof(Tiger).Name} does not eat {typeOfFood}!");
            }

            base.Weight += WEIGHT_INCREASE * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
