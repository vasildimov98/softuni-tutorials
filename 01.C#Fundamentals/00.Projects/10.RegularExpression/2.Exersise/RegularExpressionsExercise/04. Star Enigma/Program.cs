using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string star = @"[starSTAR]";
            string regex = @"@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>[0-9]+)[^@\-!:>]*!(?<type>[AD])![^@\-!:>]*->(?<soldier>[0-9]*)";

            int n = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int count = Regex.Matches(input, star).Count;

                StringBuilder tempResult = new StringBuilder();
                foreach (var charecter in input)
                {
                    char newChar = (char)(charecter - count);
                    tempResult.Append(newChar);
                }
                string result = tempResult.ToString();

                Match matches = Regex.Match(result, regex);

                if (matches.Groups.Count == 5)
                {
                    string name = matches.Groups["name"].Value;
                    string action = matches.Groups["type"].Value;

                    if (action == "A")
                    {
                        attacked.Add(name);
                    }
                    else if (action == "D")
                    {
                        destroyed.Add(name);
                    }
                }
            }

            attacked.Sort();
            destroyed.Sort();

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var plan1 in attacked)
            {
                Console.WriteLine($"-> {plan1}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var plan2 in destroyed)
            {
                Console.WriteLine($"-> {plan2}");
            }
        }
    }
}
