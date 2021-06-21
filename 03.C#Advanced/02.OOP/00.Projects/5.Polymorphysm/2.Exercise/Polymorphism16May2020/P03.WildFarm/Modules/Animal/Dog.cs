namespace P03.WildFarm.Modules.Animal
{
    public class Dog : Mammal
    {
        private const string DOG_SOUND = "Woof!";
        private const double DOG_WEIGHT_INCREASE = 0.40;

        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override string Sound => DOG_SOUND;

        public override void Eat(int quantity)
        {
            base.FoodEaten += quantity;
            base.Weight += DOG_WEIGHT_INCREASE * quantity;
        }
    }
}
