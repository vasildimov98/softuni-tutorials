using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<user>(?<=\s)[a-z0-9]+[.\-_]*[A-Za-z]+)@(?<host>[A-Za-z]+-?[A-Za-z]+\.[A-Za-z]*-?[A-Za-z]+(\.\w+)*)";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, regex);

            foreach (Match email in matches)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
