using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern1 = @"[0-9]";

            MatchCollection matches = Regex.Matches(input, pattern1);

            BigInteger coolThreshold = BigInteger.Parse(matches[0].Value);
            for (int i = 1; i < matches.Count; i++)
            {
                coolThreshold *= BigInteger.Parse(matches[i].Value);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            string pattern2 = @"([:][:]|[*][*])(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection matches1 = Regex.Matches(input, pattern2);

            int count = matches1.Count;
            List<string> cools = new List<string>();

            foreach (Match match in matches1)
            {
                BigInteger sum = 0;
                string emoji = match.Groups["emoji"].Value;
                foreach (var ch in emoji)
                {
                    sum += ch;
                }

                if (sum > coolThreshold)
                {
                    cools.Add(match.Value);
                }
            }

            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            if (cools.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, cools));
            }



        }
    }

   
}
