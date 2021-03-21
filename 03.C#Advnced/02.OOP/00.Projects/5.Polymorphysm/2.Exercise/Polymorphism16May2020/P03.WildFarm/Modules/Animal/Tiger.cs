namespace P03.WildFarm.Modules.Animal
{
    public class Tiger : Feline
    {
        private const string TIGER_SOUND = "ROAR!!!";
        private const double TIGER_WEIGHT_INCREASE = 1.00;
        public Tiger(string name,
            double weight,
            int foodEaten,
            string livingRegion,
            string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }

        public override string Sound => TIGER_SOUND;

        public override void Eat(int quantity)
        {
            base.FoodEaten += quantity;
            base.Weight += TIGER_WEIGHT_INCREASE * quantity;
        }
    }
}
