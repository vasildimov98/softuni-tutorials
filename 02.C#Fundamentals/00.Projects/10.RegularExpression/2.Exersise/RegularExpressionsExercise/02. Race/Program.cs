using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfParticipants = Console
                   .ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList();

            Dictionary<string, int> data = new Dictionary<string, int>();

            string regexLetter = @"[a-zA-z]";
            string regexNumber = @"[0-9]";

            string command = "";
            StringBuilder name = new StringBuilder();
            while ((command = Console.ReadLine()) != "end of race")
            {
                char[] arr = Regex
                    .Matches(command, regexLetter)
                    .Cast<Match>()
                    .Select(a => char.Parse(a.Value))
                    .ToArray();

                name.Clear();
                foreach (var letter in arr)
                {
                    if (char.IsLetter(letter))
                    {
                        name.Append(letter);
                    }
                }

                if (listOfParticipants.Contains(name.ToString()))
                {
                    int sum = Regex
                           .Matches(command, regexNumber)
                           .Cast<Match>()
                           .Select(s => int.Parse(s.Value))
                           .Sum();

                    if (!data.ContainsKey(name.ToString()))
                    {
                        data[name.ToString()] = sum;
                    }
                    else
                    {
                        data[name.ToString()] += sum;
                    }
                }
            }

            var sortedData = data
                .OrderByDescending(a => a.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            int count = 1;
            foreach (var racer in sortedData)
            {
                if (count == 1)
                {
                    Console.WriteLine($"1st place: {racer.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"2nd place: {racer.Key}");
                }
                else
                {
                    Console.WriteLine($"3rd place: {racer.Key}");
                    return;
                }
                count++;
            }
        }
    }
}
