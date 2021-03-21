using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string command = "";
            List<string> names = new List<string>();
            while ((command = Console.ReadLine()) != "end")
            {
                StringBuilder result = new StringBuilder();
                foreach (var symbol in command)
                {
                    char tempSymbol = (char)(symbol - key);
                    result.Append(tempSymbol);
                }

                string pattern = @"(?<=\s|)@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behaviour>[GN])!(?<=\s|)";

                Match match1 = Regex.Match(result.ToString(), pattern);

                string name = match1.Groups["name"].Value;
                string behaviour = match1.Groups["behaviour"].Value;

                if (behaviour == "G")
                {
                    names.Add(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
