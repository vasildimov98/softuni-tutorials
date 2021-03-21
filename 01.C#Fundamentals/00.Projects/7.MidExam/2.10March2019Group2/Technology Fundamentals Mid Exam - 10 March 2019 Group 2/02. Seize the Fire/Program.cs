using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console
                .ReadLine()
                .Split("#");

            int amountOfWater = int.Parse(Console.ReadLine());
            List<int> cells = new List<int>();

            double effort = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                string[] data = arr[i].Split(" = ");

                string typeOfFire = data[0];
                int valueOfCells = int.Parse(data[1]);

                if (typeOfFire == "High" && (valueOfCells >= 81 && valueOfCells <= 125) && amountOfWater >= valueOfCells)
                {
                    amountOfWater -= valueOfCells;
                    cells.Add(valueOfCells);
                    effort += 0.25 * valueOfCells;
                }

                if (typeOfFire == "Medium" && (valueOfCells >= 51 && valueOfCells <= 80) && amountOfWater >= valueOfCells)
                {
                    amountOfWater -= valueOfCells;
                    cells.Add(valueOfCells);
                    effort += 0.25 * valueOfCells;
                }

                if (typeOfFire == "Low" && (valueOfCells >= 1 && valueOfCells <= 50) && amountOfWater >= valueOfCells)
                {
                    amountOfWater -= valueOfCells;
                    cells.Add(valueOfCells);
                    effort += 0.25 * valueOfCells;
                }
            }

            Console.WriteLine("Cells:");

            foreach (var cell in cells)
            {
                Console.WriteLine($"- {cell}");
            }

            Console.WriteLine($"Effort: {effort:F2}");

            Console.WriteLine($"Total Fire: {cells.Sum()}");
        }
    }
}
