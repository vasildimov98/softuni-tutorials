using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class StartUp
    {
        static void Main()
        {
            var sortedDict = new SortedDictionary<char, int>();
            var text = Console.ReadLine();
           
            for (int i = 0; i < text.Length; i++)
            {
                if (!sortedDict.ContainsKey(text[i]))
                {
                    sortedDict.Add(text[i], 0);
                }

                sortedDict[text[i]]++;
            }

            foreach (var (ch, times) in sortedDict)
            {
                Console.WriteLine($"{ch}: {times} time/s");
            }
        }
    }
}
