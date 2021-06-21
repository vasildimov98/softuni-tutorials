namespace P03.WildFarm.Modules.Animal
{
    using P03.WildFarm.Contract;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string Sound { get; }
        public string AskForFood()
        {
            return $"{this.Sound}";
        }

        public abstract void Eat(int quantity);
      
    }
}
