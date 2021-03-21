using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> initialQuality = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> drums = new List<int>();

            for (int i = 0; i < initialQuality.Count; i++)
            {
                drums.Add(initialQuality[i]);
            }

            string command = "";

            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int power = int.Parse(command);

                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= power;

                    if (drums[i] <= 0)
                    {
                        int price = initialQuality[i] * 3;

                        if (price <= savings)
                        {
                            savings -= price;
                            drums[i] = initialQuality[i];
                        }
                        else
                        {
                            drums.RemoveAt(i);
                            initialQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drums));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
