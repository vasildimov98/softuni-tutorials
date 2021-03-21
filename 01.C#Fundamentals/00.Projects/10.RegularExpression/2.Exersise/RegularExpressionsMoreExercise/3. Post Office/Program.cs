using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console
                .ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string capitalLetters = @"([#$%*&])(?<capitals>[A-Z]+)\1";

            Match match1 = Regex.Match(firstPart, capitalLetters);
            string capitals = match1.Groups["capitals"].Value;

            foreach (char letter in capitals)
            {
                int ASCIIcode = letter;

                string asciiCode = $@"{ASCIIcode}:(?<length>[0-9][0-9])";
                Match match2 = Regex.Match(secondPart, asciiCode);
                int length = int.Parse(match2.Groups["length"].Value);

                string words = $@"(?<=\s|^){letter}[^\s]{{{length}}}(?=\s|$)";
                Match match3 = Regex.Match(thirdPart, words);

                string word = match3.Value;

                Console.WriteLine(word);
            }
        }
    }
}
