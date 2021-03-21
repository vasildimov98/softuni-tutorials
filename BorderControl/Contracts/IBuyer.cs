namespace BorderControl.Contracts
{
    public interface IBuyer : IPerson
    {
        public int Food { get; }
        void BuyFood();
    }
}
