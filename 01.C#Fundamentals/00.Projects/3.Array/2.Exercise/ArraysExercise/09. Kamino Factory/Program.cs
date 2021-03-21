using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main()
        {
            int lengthOfSequence = int.Parse(Console.ReadLine());

            string command;
            int maxCount = 0;
            int maxIndex = 0;
            int[] maxArr = new int[lengthOfSequence];
            int maxSample = 1;
            int currSample = 0;
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                int[] arr = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                currSample++;
                int bestCurrIndex = 0;
                int bestCurrCount = 0;
                int bestCurrSum = 0;
               
                for (int currIndex = 0; currIndex < arr.Length; currIndex++)
                {
                    if (arr[currIndex] == 0)
                    {
                        continue;
                    }
                    int currCount = 1;
                    for (int index = currIndex + 1; index < arr.Length; index++)
                    {
                        if (arr[index] == 1)
                        {
                            currCount++; 
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currCount > bestCurrCount)
                    {
                        bestCurrCount = currCount;
                        bestCurrIndex = currIndex;
                        bestCurrSum = arr.Sum();
                    }
                }

                if (bestCurrCount > maxCount ||
                  (bestCurrCount == maxCount && bestCurrIndex < maxIndex) ||
                  maxArr.Sum() < bestCurrSum)
                {
                    maxIndex = bestCurrIndex;
                    maxCount = bestCurrCount;
                    maxArr = arr;
                    maxSample = currSample;
                }
            }

            Console.WriteLine($"Best DNA sample {maxSample} with sum: {maxArr.Sum()}.");
            Console.WriteLine(string.Join(" ", maxArr));
        }
    }
}
