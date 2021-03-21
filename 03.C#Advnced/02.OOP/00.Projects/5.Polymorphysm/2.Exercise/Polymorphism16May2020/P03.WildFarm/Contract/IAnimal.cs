namespace P03.WildFarm.Contract
{
    public interface IAnimal : IEatable
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string AskForFood();


    }
}
