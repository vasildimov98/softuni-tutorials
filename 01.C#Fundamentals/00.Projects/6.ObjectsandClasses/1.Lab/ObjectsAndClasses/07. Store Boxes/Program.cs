using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            List<Box> boxes = new List<Box>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] data = command
                    .Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuatity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Item.Name = itemName;
                box.Item.Price = itemQuatity * itemPrice;
                box.ItemQuantity = itemQuatity;
                box.ItemPrice = itemPrice;

                boxes.Add(box);
            }

            boxes = boxes.OrderByDescending(b => b.Item.Price).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.ItemPrice:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Item.Price:F2}");
            }

        }
    }
}
