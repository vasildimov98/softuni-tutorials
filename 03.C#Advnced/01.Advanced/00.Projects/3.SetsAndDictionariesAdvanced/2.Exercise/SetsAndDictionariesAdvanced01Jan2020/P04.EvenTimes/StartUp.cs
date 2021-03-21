namespace P04.EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, int> collectionOfNumbers;
        public static void Main()
        {
            collectionOfNumbers = new Dictionary<string, int>();

            var countOfInts = int.Parse(Console.ReadLine());

            GetAllNumbers(countOfInts);

            var result = collectionOfNumbers
                .FirstOrDefault(n => n.Value % 2 == 0);

            PrintResult(result);
        }

        private static void PrintResult(KeyValuePair<string, int> result)
        {
            if (result.Key != null)
            {
                Console.WriteLine(result.Key);
            }
        }

        private static void GetAllNumbers(int countOfInts)
        {
            for (int i = 0; i < countOfInts; i++)
            {
                var number = Console.ReadLine();

                if (!collectionOfNumbers.ContainsKey(number))
                {
                    collectionOfNumbers[number] = 0;
                }

                collectionOfNumbers[number]++;
            }
        }
    }
}
