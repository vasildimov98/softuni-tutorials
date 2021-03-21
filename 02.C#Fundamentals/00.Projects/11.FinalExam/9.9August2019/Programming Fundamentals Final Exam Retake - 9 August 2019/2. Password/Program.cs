using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.{1,})\>(?<first>[0-9]{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})\<\1$";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string first = match.Groups["first"].Value;
                    string second = match.Groups["second"].Value;
                    string third = match.Groups["third"].Value;
                    string fourth = match.Groups["fourth"].Value;

                    StringBuilder password = new StringBuilder();

                    password.AppendJoin("", first, second, third, fourth);

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
