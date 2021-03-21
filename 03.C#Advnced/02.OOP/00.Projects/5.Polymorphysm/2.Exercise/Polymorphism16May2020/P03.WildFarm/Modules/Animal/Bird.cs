namespace P03.WildFarm.Modules.Animal
{
    using P03.WildFarm.Contract;
    public abstract class Bird : Animal, IFlyable
    {
        public Bird(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }
    }
}
