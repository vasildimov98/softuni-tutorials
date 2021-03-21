using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
                {
                    { ".-", "A" },
                    { "-...", "B" },
                    { "-.-.", "C" },
                    { "-..", "D" },
                    { ".", "E" },
                    { "..-.", "F" },
                    { "--.", "G" },
                    { "....", "H" },
                    { "..", "I" },
                    { ".---", "J" },
                    { "-.-", "K" },
                    { ".-..", "L" },
                    { "--", "M" },
                    { "-.", "N" },
                    { "---", "O" },
                    { ".--.", "P" },
                    { "--.-", "Q" },
                    { ".-.", "R" },
                    { "...", "S" },
                    { "-", "T" },
                    { "..-", "U" },
                    { "...-", "V" },
                    {".--", "W" },
                    { "-..-", "X" },
                    { "-.--", "Y" },
                    { "--..", "Z" },
                    { "|", " " },
                };

            string[] input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder messange = new StringBuilder();
            foreach (var code in input)
            {

                var tempDict = dict.Where(a => a.Key == code)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (var kvp in tempDict)
                {
                    messange.Append(kvp.Value);
                }

            }

            Console.WriteLine(messange);
        }
    }
}
