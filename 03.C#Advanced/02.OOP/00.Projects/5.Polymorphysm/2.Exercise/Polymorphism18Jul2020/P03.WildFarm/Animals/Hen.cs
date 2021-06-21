namespace P03.WildFarm.Animals
{
    using Contracts;

    public class Hen : Bird
    {
        private const double WEIGHT_INCREASE = 0.35;
        private const string SOUND = "Cluck";

        public Hen(string name, double weight, double wingSize)
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

            base.Weight += WEIGHT_INCREASE * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
