using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03._Word_Count
{
    class StartUp
    {
        static void Main()
        {
            var wordsPath = @".\words.txt";
            var words = File.ReadAllLines(wordsPath);

            var textPath = @".\text.txt";
            var textReader = File.ReadAllLines(textPath);

            var contents = new Dictionary<string, int>();

            foreach (var line in textReader)
            {
                var currLine = ChangeSybols("", line, '.', ',', '-', '?', '!');

                foreach (var word in currLine.Split())
                {
                    if (!words.Contains(word))
                    {
                        continue;
                    }

                    if (!contents.ContainsKey(word))
                    {
                        contents[word] = 0;
                    }

                    contents[word]++;
                }
            }

            var result = new string[contents.Count];
            var cnt = 0;
            var ordered = contents
                .OrderByDescending(a => a.Value)
                .ToList();
            foreach (var (word, count) in ordered)
            {
                var currResult = $"{word} - {count}";
                result[cnt++] = currResult;
            }

            File.WriteAllLines(@".\actualResults.txt", result);
        }

        static string ChangeSybols(string symbolToChageWith, string str, params char[] symbols)
        {
            var sb = new StringBuilder();

            foreach (var chr in str)
            {
                if (symbols.Contains(chr))
                {
                    sb.Append(symbolToChageWith);
                }
                else
                {
                    sb.Append(chr);
                }
            }

            return sb.ToString().TrimEnd().ToLower();
        }
    }
}
