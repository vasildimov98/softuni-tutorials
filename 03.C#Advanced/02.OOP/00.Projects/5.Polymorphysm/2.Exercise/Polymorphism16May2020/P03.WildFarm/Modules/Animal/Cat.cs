namespace P03.WildFarm.Modules.Animal
{
    public class Cat : Feline
    {
        private const string CAT_SOUND = "Meow";
        private const double CAT_WEIGHT_INCREASE = 0.30;
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }

        public override string Sound => CAT_SOUND;

        public override void Eat(int quantity)
        {
            base.FoodEaten += quantity;

            base.Weight += CAT_WEIGHT_INCREASE * quantity;
        }
    }
}
