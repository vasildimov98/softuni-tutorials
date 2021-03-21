using System;
using System.Collections.Generic;

namespace _03._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            //skipTest_String044170

            string hiddenMessage = Console.ReadLine(); 

            List<char> allCharacter = new List<char>();

            allCharacter.AddRange(hiddenMessage);

            List<int> numbers = new List<int>();
            List<char> nonNumbers = new List<char>();
            GetLists(allCharacter, numbers, nonNumbers);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            GetLists(numbers, takeList, skipList);

            string result = "";
            for (int i = 0; i < takeList.Count; i++)
            {
                int takeIndex = takeList[i];
                int skipIndex = skipList[i];

                for (int j = 0; j < takeIndex; j++)
                {
                    result += nonNumbers[0];
                    nonNumbers.RemoveAt(0);
                    if (nonNumbers.Count == 0)
                    {
                        break;
                    }
                }

                for (int j = 0; j < skipIndex; j++)
                {
                    if (nonNumbers.Count == 0)
                    {
                        break;
                    }
                    nonNumbers.RemoveAt(0);
                }
            }

            Console.WriteLine(result);
        }

        private static void GetLists(List<char> allCharacter, List<int> numbers, List<char> nonNumbers)
        {
            for (int i = 0; i < allCharacter.Count; i++)
            {
                if (allCharacter[i] >= '0' && allCharacter[i] <= '9')
                {
                    int number = allCharacter[i] - 48;
                    numbers.Add(number);
                }
                else
                {
                    nonNumbers.Add(allCharacter[i]);
                }
            }
        }

        private static void GetLists(List<int> numbers, List<int> takeList, List<int> skipList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
        }
    }
}
