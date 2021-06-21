namespace P03.WildFarm.Modules.Animal
{
    public class Mouse : Mammal
    {
        private const string MOUSE_SOUND = "Squeak";
        private const double MOUSE_WEIGHT_INCREASE = 0.10;
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override string Sound => MOUSE_SOUND;

        public override void Eat(int quantity)
        {
            base.FoodEaten += quantity;

            base.Weight += MOUSE_WEIGHT_INCREASE * quantity;
        }
    }
}
