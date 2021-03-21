namespace P03.WildFarm.Modules.Animal
{
    using P03.WildFarm.Contract;
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
