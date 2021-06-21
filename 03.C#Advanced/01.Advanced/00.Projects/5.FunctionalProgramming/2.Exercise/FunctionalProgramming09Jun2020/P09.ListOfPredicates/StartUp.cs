namespace P09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var upperBound = int.Parse(Console.ReadLine());

            var seq = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var listOfPredicate = GetAllPredicates(seq);

            var max = seq.Max();

            var result
                = GetAllNumbers(upperBound, max, listOfPredicate);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<Predicate<int>> GetAllPredicates(int[] seq)
        {
            var list = new List<Predicate<int>>();
            for (int i = 0; i < seq.Length; i++)
            {
                list.Add(GetPredicate(seq[i]));
            }

            return list;
        }

        private static List<int> GetAllNumbers(int upperBound, int max, List<Predicate<int>> listOfPredicate)
        {
            var list = new List<int>();
            for (int num = max; num <= upperBound; num++)
            {
                var isDevisable = true;
                foreach (var predicate in listOfPredicate)
                {
                    if (!predicate(num))
                    {
                        isDevisable = false;
                        break;
                    }
                }

                if (isDevisable)
                {
                    list.Add(num);
                }
            }

            return list;
        }

        private static Predicate<int> GetPredicate(int num)
        {
            return n => n % num == 0;
        }
    }
}
