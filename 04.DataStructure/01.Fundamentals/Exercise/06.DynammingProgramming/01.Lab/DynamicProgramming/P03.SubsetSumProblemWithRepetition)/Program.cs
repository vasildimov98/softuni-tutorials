namespace SubsetSumProblemWithRepetition_
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var set = new []{ 3, 5, 2 };
            var target = 17;
            var possibleSums = new bool[target + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[0])
                {
                    foreach (var num in set)
                    {
                        var newSum = sum + num;
                        if (newSum < possibleSums.Length)
                            possibleSums[newSum] = true;
                    }
                }
            }

            var numberByCount = new SortedDictionary<int, int>();
            while (target > 0)
            {
                foreach (var num in set)
                {
                    var newTarget = target - num;
                    if (newTarget >= 0 && possibleSums[newTarget])
                    {
                        target = newTarget;
                        if (!numberByCount.ContainsKey(num))
                            numberByCount[num] = 0;
                        numberByCount[num]++;
                    }
                }
            }

            foreach (var (num, count) in numberByCount)
            {
                Console.WriteLine($"{num} -> {count}");
            }
        }
    }
}
