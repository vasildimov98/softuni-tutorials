namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int INIT_SIZE = 3;
        private const int SIZE_INCREASE = 2;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = INIT_SIZE;
        }

        public override void Eat()
            => this.Size += SIZE_INCREASE;
    }
}
