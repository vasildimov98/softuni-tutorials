using System;
using System.Text.RegularExpressions;

namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while ((input = Console.ReadLine()) != "Last note")
            {
                string validNote = @"(?<=\s|^)(?<peak>[A-Za-z0-9!@#$?]+)=(?<length>[0-9]+)<<(?<geohash>(.*?)+$)";

                Match match = Regex.Match(input, validNote);

                if (match.Success)
                {
                    int length = int.Parse(match.Groups["length"].Value);
                    string geohash = match.Groups["geohash"].Value;

                    if (geohash.Length == length)
                    {
                        Regex pattern = new Regex("[^A-Za-z0-9]+");
                        string peak = match.Groups["peak"].Value;
                        peak = pattern.Replace(peak, string.Empty);
                        Console.WriteLine($"Coordinates found! {peak} -> {geohash}");
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
