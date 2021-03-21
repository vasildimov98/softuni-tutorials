using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                string seq = @"([#$%*&])(?<name>[A-Za-z]+)\1=(?<length>[0-9]+)!!(?<code>.*?)$";
                Regex pattern = new Regex(seq);

                if (!pattern.IsMatch(input))
                {
                    Console.WriteLine("Nothing found!");
                }
                else
                {
                    Match match = pattern.Match(input);

                    string name = match.Groups["name"].Value;
                    string code = match.Groups["code"].Value;
                    int length = int.Parse(match.Groups["length"].Value);

                    if (!(length == code.Length))
                    {
                        Console.WriteLine("Nothing found!");
                    }
                    else
                    {
                        StringBuilder temp = new StringBuilder();
                        foreach (var symbol in code)
                        {
                            char tempChr = (char)(symbol + length);
                            temp.Append(tempChr);
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {temp.ToString()}");
                        return;
                    }
                }
            }
        }
    }
}
