using System;

namespace _09._List_Of_Predicates
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sequence = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var resultList = new List<int>();

            var maxNumberInSequence = sequence.Max();

            var isDevided = true;
            for (int i = maxNumberInSequence; i <= n; i++)
            {
                int number = i;
                for (int index = 0; index < sequence.Length; index++)
                {
                    int divisor = sequence[sequence.Length - 1 - index];
                    var func = FindIfTrue(number, divisor);
                    if (!func(number, divisor))
                    {
                        isDevided = false;
                        break;
                    }
                }

                if (isDevided)
                {
                    resultList.Add(number);
                }
                else
                {
                    isDevided = true;
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }

        static Func<int, int, bool> FindIfTrue(int number, int divisor)
        {
            Func<int, int, bool> func = (x, y) =>
            {
                if (x % y == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            return func;
        }
    }
}
