using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})\]";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string message = match.Groups["message"].Value;
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (int letter in message)
                    {
                        stringBuilder.Append(letter + " ");
                    }

                    Console.WriteLine($"{command}: {stringBuilder.ToString().TrimEnd()}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
