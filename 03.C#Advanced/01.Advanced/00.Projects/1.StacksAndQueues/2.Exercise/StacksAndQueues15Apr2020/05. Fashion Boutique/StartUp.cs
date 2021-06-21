using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var clothes = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stackOfClothes = new Stack<int>();
            PushClothes(clothes, stackOfClothes);

            var capacity = int.Parse(Console.ReadLine());

            var racks = 1;
            var sum = 0;

            while (true)
            {
                if (!stackOfClothes.Any() || capacity == 0)
                {
                    break;
                }

                var clothe = stackOfClothes.Pop();
                sum += clothe;

                if (sum == capacity)
                {
                    if (stackOfClothes.Any())
                    {
                        racks++;
                        sum = 0;
                    }
                }

                if (sum > capacity)
                {
                    racks++;
                    sum = clothe;
                }
            }

            if (clothes.All(a => a == 0))
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(capacity == 0 ? 0 : racks);
            }
        }

        private static void PushClothes(int[] clothes, Stack<int> stackOfClothes)
        {
            for (int i = 0; i < clothes.Length; i++)
            {
                stackOfClothes.Push(clothes[i]);
            }
        }
    }
}
