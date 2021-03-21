using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"([*@])(?<tag>[A-Z][a-z]{3,})\1: \[(?<first>[A-Za-z]+)\]\|\[(?<second>[A-Za-z]+)\]\|\[(?<third>[A-Za-z]+)\]\|$";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);
                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;
                    string first = match.Groups["first"].Value;
                    string second = match.Groups["second"].Value;
                    string third = match.Groups["third"].Value;
                    List<int> numbers = new List<int>();
                    foreach (var letter in first)
                    {
                        numbers.Add(letter);
                    }

                    foreach (var letter in second)
                    {
                        numbers.Add(letter);
                    }

                    foreach (var letter in third)
                    {
                        numbers.Add(letter);
                    }

                    Console.WriteLine($"{tag}: {string.Join(" ", numbers)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
