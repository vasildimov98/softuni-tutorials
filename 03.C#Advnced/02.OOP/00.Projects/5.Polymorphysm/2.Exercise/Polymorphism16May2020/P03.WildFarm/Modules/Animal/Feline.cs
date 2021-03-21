namespace P03.WildFarm.Modules.Animal
{
    using P03.WildFarm.Contract;
    public abstract class Feline : Mammal, IBreedable
    {
        public Feline(string name,
            double weight,
            int foodEaten,
            string livingRegion,
            string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
