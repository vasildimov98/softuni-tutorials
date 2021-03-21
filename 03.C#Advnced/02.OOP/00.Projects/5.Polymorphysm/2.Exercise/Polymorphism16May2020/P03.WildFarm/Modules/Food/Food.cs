namespace P03.WildFarm.Modules.Food
{
    using P03.WildFarm.Contract;
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
