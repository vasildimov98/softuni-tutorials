using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int productQuantity = int.Parse(Console.ReadLine());
            TotalPrice(product, productQuantity);
        }

        static void TotalPrice(string product, int productQuantity)
        {
            
            double totalPrice = 0;
            if (product == "coffee")
            {
                totalPrice = productQuantity * 1.5;
            }
            else if (product == "water")
            {
                totalPrice = productQuantity * 1;
            }
            else if (product == "coke")
            {
                totalPrice = productQuantity * 1.4;
            }
            else if (product == "snacks")
            {
                totalPrice = productQuantity * 2.00;
            }
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
