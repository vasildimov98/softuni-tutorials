namespace P03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, int> wordsCounter;
        public static void Main()
        {
            wordsCounter = new Dictionary<string, int>();

            var wordsFileName = "words.txt";
            using var wordsReader = new StreamReader(wordsFileName);

            var collectionOfWords = wordsReader.ReadToEnd()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower())
                .ToHashSet();

            var textFileName = "text.txt";
            using var textReader = new StreamReader(textFileName);

            CountAllWords(collectionOfWords, textReader);

            using var wordsWriter = new StreamWriter("Output.txt");

            GetAllWordsWrittenOnOutputFile(wordsWriter);
        }

        private static void GetAllWordsWrittenOnOutputFile(StreamWriter wordsWriter)
        {
            foreach (var (word, count) in wordsCounter)
            {
                wordsWriter.WriteLine($"{word} - {count}");
            }
        }

        private static void CountAllWords(HashSet<string> collectionOfWords, StreamReader textReader)
        {
            var splitSymbols = new[] { ' ', '-', '.', ',', '?', '!' };
            do
            {
                var wordsInSentence = textReader.ReadLine()
                    .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var word in wordsInSentence)
                {
                    var wordAsLowerCase = word.ToLower();
                    if (!collectionOfWords.Contains(wordAsLowerCase))
                    {
                        continue;
                    }

                    if (!wordsCounter.ContainsKey(wordAsLowerCase))
                    {
                        wordsCounter[wordAsLowerCase] = 0;
                    }

                    wordsCounter[wordAsLowerCase]++;
                }

            } while (!textReader.EndOfStream);

            wordsCounter = wordsCounter
                .OrderByDescending(wr => wr.Value)
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
