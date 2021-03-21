namespace P07.WordCruncher
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        private static string target;
        private static string[] words;
        private static List<string> permutation;
        private static HashSet<string> permutations;
        private static Dictionary<int, List<string>> wordsByLen;
        private static Dictionary<string, int> countByWords;
        static void Main()
        {
            words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();
            permutation = new List<string>();
            permutations = new HashSet<string>();
            wordsByLen = new Dictionary<int, List<string>>();
            countByWords = new Dictionary<string, int>();

            FilledCollection(words, target);
            FindPermuteByLen(target.Length);
            Console.WriteLine(string.Join(Environment.NewLine, permutations));
        }

        private static void FindPermuteByLen(int length)
        {
            if (length == 0)
            {
                permutations.Add(string.Join(" ", permutation));
                return;
            }

            foreach (var (len, words) in wordsByLen)
            {
                if (len > length) continue;

                foreach (var word in words)
                {
                    if (countByWords[word] == 0) continue;

                    permutation.Add(word);

                    if (isNotAMatch(word)) continue;

                    countByWords[word]--;

                    FindPermuteByLen(length - word.Length);

                    permutation.RemoveAt(permutation.Count - 1);
                    countByWords[word]++;
                }
            }
           
        }

        private static bool isNotAMatch(string word)
        {
            var currWord = string.Join("", permutation);
            if (target.StartsWith(currWord)) return false;

            permutation.RemoveAt(permutation.Count - 1);
            return true;
        }

        private static void FilledCollection(string[] words, string target)
        {
            foreach (var word in words)
            {
                if (!target.Contains(word)) continue;

                if (!wordsByLen.ContainsKey(word.Length))
                    wordsByLen[word.Length] = new List<string>();

                if (!countByWords.ContainsKey(word))
                    countByWords[word] = 0;

                wordsByLen[word.Length].Add(word);
                countByWords[word]++;
            }
        }
    }
}
