using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console
                .ReadLine()
                .Split();

            Dictionary<string, int> presents = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                string word = arr[i].ToLower();
                if (presents.ContainsKey(word))
                {
                    presents[word]++;
                }
                else
                {
                    presents.Add(word, 1);
                }
            }

            foreach (var word in presents)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
