using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {

            string seq = @"([#$%*&])(?<name>[A-Za-z]+)\1=(?<length>[0-9]+)!!(?<code>.*?)$";
            Regex pattern = new Regex(seq);
            while (true)
            {
                string input = Console.ReadLine();
                if (pattern.IsMatch(input))
                {
                    Match match = pattern.Match(input);

                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;
                    StringBuilder result = new StringBuilder();
                    if (code.Length == length)
                    {
                        foreach (var symbol in code)
                        {
                            char newSymb = (char)(symbol + length);
                            result.Append(newSymb);
                        }
                        string name = match.Groups["name"].Value;
                        Console.WriteLine($"Coordinates found! {name} -> {result}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
