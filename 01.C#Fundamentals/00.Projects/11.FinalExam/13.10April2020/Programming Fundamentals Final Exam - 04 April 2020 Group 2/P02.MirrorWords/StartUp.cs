namespace P02.MirrorWords
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var pattern = @"([@#])(?<firstWord>[A-z]{3,})\1\1(?<secondWord>[A-z]{3,})\1";

            var regex = new Regex(pattern);

            var text = Console.ReadLine();

            var matches = regex.Matches(text);

            SearchForMirrorWords(matches);
        }

        private static void SearchForMirrorWords(MatchCollection matches)
        {
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                var mirrorWords = new List<string>();

                LookForMirrorWords(matches, mirrorWords);

                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");

                    Console.WriteLine(string.Join(", ", mirrorWords));
                }
            }
        }

        private static void LookForMirrorWords(MatchCollection matches, List<string> mirrorWords)
        {
            foreach (Match match in matches)
            {
                var firstWord = match.Groups["firstWord"].Value;
                var secondWord = match.Groups["secondWord"].Value;

                var charArray = secondWord.ToCharArray().Reverse().ToArray();

                var reversedWord = new string(charArray);

                if (firstWord == reversedWord)
                {
                    var mirrorWordPair = $"{firstWord} <=> {secondWord}";

                    mirrorWords.Add(mirrorWordPair);
                }
            }
        }
    }
}
