using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.DatingApp
{
    public class StartUp
    {
        static void Main()
        {
            var malesInfo = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var males = new Stack<int>(malesInfo);

            var femaleInfo = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var females = new Queue<int>(femaleInfo);

            var matchesCount = 0;
            while (males.Count > 0 && females.Count > 0)
            {
                var male = males.Peek();
                var female = females.Peek();

                if (female <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (male <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (female % 25 == 0)
                {
                    females.Dequeue();

                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }

                    continue;
                }

                if (male % 25 == 0)
                {
                    males.Pop();

                    if (males.Count > 0)
                    {
                        males.Pop();
                    }

                    continue;
                }

                if (female == male)
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            var malesText = males.Count > 0 ? string.Join(", ", males) : "none";

            Console.WriteLine($"Males left: {malesText}");

            var femalesText = females.Count > 0 ? string.Join(", ", females) : "none";

            Console.WriteLine($"Females left: {femalesText}");
        }
    }
}
