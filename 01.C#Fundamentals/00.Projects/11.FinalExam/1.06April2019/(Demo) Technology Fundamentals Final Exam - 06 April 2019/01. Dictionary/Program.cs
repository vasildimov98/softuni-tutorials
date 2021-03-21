using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string[] definitions = Console
                .ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var def in definitions)
            {
                string[] arr = def
                    .Split(": ");
                string word = arr[0];
                string definition = arr[1];

                if (!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                }
                dict[word].Add(definition);
            }

            string[] words = Console
                .ReadLine()
                .Split(" | ");

            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    Console.WriteLine(word);
                    foreach (var def in dict[word].OrderByDescending(a => a.Length))
                    {
                        Console.WriteLine($" -{def}");
                    }
                }
            }

            string finalCommand = Console.ReadLine();

            if (finalCommand == "End")
            {
                return;
            }
            else if (finalCommand == "List")
            {
                var sortedDict = dict
                    .OrderBy(a => a.Key)
                    .ToDictionary(k => k.Key, v => v.Value);
                Console.WriteLine(string.Join(" ", sortedDict.Keys));
            }
        }
    }
}
