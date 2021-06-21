namespace P03.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        string ProduceSound { get; }

        void Eat(IFood food);
    }
}
