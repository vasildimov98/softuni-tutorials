namespace P05.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static SortedDictionary<char, int> countsOfOccurrences;
        public static void Main()
        {
            countsOfOccurrences = new SortedDictionary<char, int>();

            var sentence = Console.ReadLine();

            CountAllLetters(sentence);

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var (letter, count) in countsOfOccurrences)
            {
                Console.WriteLine($"{letter}: {count} time/s");
            }
        }

        private static void CountAllLetters(string sentence)
        {
            foreach (var letter in sentence)
            {
                if (!countsOfOccurrences.ContainsKey(letter))
                {
                    countsOfOccurrences[letter] = 0;
                }

                countsOfOccurrences[letter]++;
            }
        }
    }
}
