namespace P02.Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price)
            : base(name, price)
        {

        }

        public override decimal CalculateTotalPrice()
        {
            System.Console.WriteLine($"{this.name} with the price of {this.price}");

            return price;
        }
    }
}
