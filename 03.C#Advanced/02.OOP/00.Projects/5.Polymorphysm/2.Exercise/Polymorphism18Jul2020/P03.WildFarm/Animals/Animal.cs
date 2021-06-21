namespace P03.WildFarm.Animals
{
    using Contracts;

    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;

            this.FoodEaten = 0;
        }

        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract string ProduceSound { get; }

        public abstract void Eat(IFood food);
    }
}
