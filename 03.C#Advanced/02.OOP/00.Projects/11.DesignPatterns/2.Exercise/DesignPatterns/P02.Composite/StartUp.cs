namespace P02.Composite
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var phone = new SingleGift("IShitPhone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var rootGiftBox = new CompositeGift("RootGiftBox", 0); 
            var truckToy = new SingleGift("TruckToy", 289); 
            var plainToy = new SingleGift("PlainToy", 587);
            rootGiftBox.Add(truckToy);
            rootGiftBox.Add(plainToy);
            var childGiftBox = new CompositeGift("ChildGiftBox", 0);
            var solderToy = new SingleGift("SolderToy", 200);
            childGiftBox.Add(solderToy);
            rootGiftBox.Add(childGiftBox);

            Console.WriteLine($"Total price of this composite present is {rootGiftBox.CalculateTotalPrice()}");
        }
    }
}
