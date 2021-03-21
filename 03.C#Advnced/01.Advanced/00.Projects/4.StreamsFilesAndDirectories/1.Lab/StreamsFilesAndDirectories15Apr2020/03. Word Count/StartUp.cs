using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class StartUp
    {
        static void Main()
        {
            var readerForWords = new StreamReader("words.txt");

            var specialWords = readerForWords
                            .ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            var readerForText = new StreamReader("text.txt");

            var dict = new Dictionary<string, int>();
            while (true)
            {
                var line = readerForText.ReadLine();

                if (line == null)
                {
                    break;
                }

                var wordsInText = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.ToLower())
                    .ToArray();

                foreach (var item in wordsInText)
                {
                    var word = item.ToLower();
                    if (word.Contains('.'))
                    {
                        word = word.Replace(".", "");
                    }

                    if (word.Contains(','))
                    {
                        word = word.Replace(",", "");
                    }

                    if (word.Contains('-'))
                    {
                        word = word.Replace("-", "");
                    }

                    if (specialWords.Contains(word))
                    {
                        if (!dict.ContainsKey(word))
                        {
                            dict[word] = 0;
                        }

                        dict[word]++;
                    }
                }

            }

            var order = dict
                .OrderByDescending(a => a.Value)
                .ToList();
            using var writer = new StreamWriter("Output.txt");
            foreach (var (word, count) in order)
            {
                writer.WriteLine($"{word} - {count}");
            }
        }
    }
}
