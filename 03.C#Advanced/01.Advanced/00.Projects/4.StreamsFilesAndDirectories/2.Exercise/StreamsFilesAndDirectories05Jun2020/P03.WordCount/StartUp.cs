namespace P03.WordCount
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, int> wordsCounter;
        public static void Main()
        {
            const string WORDS_FILE_NAME = "words.txt";
            const string TEXT_FILE_NAME = "text.txt";
            const string ACTUAL_RESULT_FILE_NAME = "actualResult.txt";
            const string SORT_RESULT_FILE_NAME = "sortResult.txt";

            wordsCounter = new Dictionary<string, int>();

            var words = File.ReadAllLines(WORDS_FILE_NAME)
                .Select(w => w.ToLower())
                .ToArray();

            GetAllWordsInDictionary(words);

            var textFileLines = File.ReadAllLines(TEXT_FILE_NAME);

            GetCountOfAllWords(words, textFileLines);

            var actualResultContents = GetResultAsString();

            WriteTextOnSpecifiedFile(ACTUAL_RESULT_FILE_NAME);

            wordsCounter = wordsCounter
                .OrderByDescending(w => w.Value)
                .ThenBy(w => w.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            WriteTextOnSpecifiedFile(SORT_RESULT_FILE_NAME);
        }

        private static void WriteTextOnSpecifiedFile(string fileName)
        {
            var contents = GetResultAsString();

            File.WriteAllText(fileName, contents);
        }

        private static string GetResultAsString()
        {
            var sb = new StringBuilder();
            foreach (var (word, count) in wordsCounter)
            {
                sb.AppendLine($"{word} - {count}");
            }

            return sb.ToString().Trim();
        }

        private static void GetCountOfAllWords(string[] words, string[] textFileLines)
        {
            var splitSymbols = new[] { " ", "-", ",", ".", "!", "?" };
            foreach (var line in textFileLines)
            {
                var wordsInTextFile = line
                    .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => w.ToLower())
                    .ToArray();

                foreach (var word in wordsInTextFile)
                {
                    if (words.Contains(word))
                    {
                        wordsCounter[word]++;
                    }
                }

            }
        }

        private static void GetAllWordsInDictionary(string[] words)
        {
            foreach (var word in words)
            {
                wordsCounter[word] = 0;
            }
        }
    }
}
