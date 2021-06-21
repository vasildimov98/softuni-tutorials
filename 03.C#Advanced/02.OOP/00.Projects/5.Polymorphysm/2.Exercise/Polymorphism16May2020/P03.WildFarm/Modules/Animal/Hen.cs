namespace P03.WildFarm.Modules.Animal
{
    public class Hen : Bird
    {
        private const string HEN_SOUND = "Cluck";
        private const double HEN_WEIGHT_INCRESE = 0.35; 

        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {

        }

        public override string Sound => HEN_SOUND;

        public override void Eat(int quantity)
        {
            base.FoodEaten += quantity;

            base.Weight += quantity * HEN_WEIGHT_INCRESE;
        }
    }
}
