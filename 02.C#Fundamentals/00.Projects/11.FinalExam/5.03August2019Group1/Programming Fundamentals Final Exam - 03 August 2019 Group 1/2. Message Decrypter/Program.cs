using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"^([$%])(?<tag>[A-Z][a-z]{3,})\1: \[(?<firstGroup>[0-9]+)\]\|\[(?<secondGroup>[0-9]+)\]\|\[(?<thirdGroup>[0-9]+)\]\|$";

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                string result = "";
                if (match.Success)
                {
                    char fisrt = (char)int.Parse(match.Groups["firstGroup"].Value);
                    char second = (char)int.Parse(match.Groups["secondGroup"].Value);
                    char third = (char)int.Parse(match.Groups["thirdGroup"].Value);
                    string tag = match.Groups["tag"].Value;
                    result = string.Concat(fisrt, second, third);

                    Console.WriteLine($"{tag}: {result}");
                }
                else if (!match.Success)
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
