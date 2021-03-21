using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"(?<char>[^0-9]+)(?<count>[0-9]+)";

            MatchCollection matches = Regex.Matches(input, regex);

            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                string symbol = match.Groups["char"].Value.ToUpper();
                int count = int.Parse(match.Groups["count"].Value);

                if (count == 0)
                {
                    continue;
                }

                for (int i = 0; i < count; i++)
                {
                    result.Append(symbol);
                }
            }

            var number = result.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {number}");
            Console.WriteLine(result);
        }
    }
}
