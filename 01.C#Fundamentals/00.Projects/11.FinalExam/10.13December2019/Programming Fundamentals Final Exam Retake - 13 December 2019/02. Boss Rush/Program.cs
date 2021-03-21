using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string bossName = match.Groups["boss"].Value;
                    string title = match.Groups["title"].Value;

                    StringBuilder result = new StringBuilder();

                    result.AppendLine($"{bossName}, The {title}");
                    result.AppendLine($">> Strength: {bossName.Length}");
                    result.Append($">> Armour: {title.Length}");

                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
