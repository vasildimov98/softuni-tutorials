namespace P03.WildFarm.Modules.Animal
{
    public class Owl : Bird
    {
        private const string OWL_SOUND = "Hoot Hoot";
        private const double OWL_WEIGHT_INCREASE = 0.25;
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {

        }

        public override string Sound => OWL_SOUND;

        public override void Eat(int quantity)
        {
            base.FoodEaten += quantity;
            base.Weight += OWL_WEIGHT_INCREASE * quantity;
        }
    }
}
