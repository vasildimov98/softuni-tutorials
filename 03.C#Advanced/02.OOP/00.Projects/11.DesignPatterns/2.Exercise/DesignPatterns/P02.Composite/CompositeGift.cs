namespace P02.Composite
{
    using System;
    using System.Collections.Generic;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> gifts;
        public CompositeGift(string name, decimal price)
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
        public override decimal CalculateTotalPrice()
        {
            var totalPrice = 0m;

            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (var gift in this.gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }
    }
}
