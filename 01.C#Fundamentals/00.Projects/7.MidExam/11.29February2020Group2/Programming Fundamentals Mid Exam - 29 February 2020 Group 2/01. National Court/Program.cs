using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int efficiency3 = int.Parse(Console.ReadLine());

            int people = int.Parse(Console.ReadLine());

            int totalEfficiency = efficiency1 + efficiency2 + efficiency3;

            int hours = 0;

            while (people > 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i == 4)
                    {
                        hours++;
                    }
                    else
                    {
                        people -= totalEfficiency;
                        hours++;
                    }

                    if (people <= 0)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"Time needed: {(hours)}h.");
        }
    }
}
