namespace P02.SubsetSumProblemWithoutRepeats
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<int, int> sumsByFirstNumber;
        static void Main()
        {
            sumsByFirstNumber = new Dictionary<int, int>();
            var set = new[] { 3, 5, 1, 4, 2 };
            var target = 2;

            var isPossible = FindIfPossible(set, target);

            Console.WriteLine(isPossible);

            if (!isPossible) return;

            while (target > 0)
            {
                var prev = sumsByFirstNumber[target];
                Console.Write(prev + " ");
                target -= prev;
            }

            Console.WriteLine();
        }

        private static bool FindIfPossible(int[] set, int target)
        {
            var possibleSums = new HashSet<int> { 0 };

            foreach (var number in set)
            {
                var newPossibleSums = new HashSet<int>();
                foreach (var sum in possibleSums)
                {
                    var newSum = sum + number;

                    newPossibleSums.Add(newSum);

                    if (!sumsByFirstNumber.ContainsKey(newSum))
                    {
                        sumsByFirstNumber[newSum] = number;
                    }
                }

                possibleSums.UnionWith(newPossibleSums);

                if (possibleSums.Contains(target)) return true;
            }

            return false;
        }
    }
}
