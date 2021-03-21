using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string pattern = @"^(?<artist>[A-Z][a-z'\s]+):(?<song>[A-Z\s]+)$";

                Regex regex = new Regex(pattern);
                Match match = regex.Match(command);
                if (match.Success)
                {
                    int key = match.Groups["artist"].Value.Length;
                    StringBuilder result = new StringBuilder();
                    foreach (var letter in command)
                    {
                        if (letter == ':')
                        {
                            result.Append('@');
                        }
                        else if (letter == ' ')
                        {
                            result.Append(letter);
                        }
                        else if (letter == '\'')
                        {
                            result.Append(letter);
                        }
                        else
                        {
                            char temp = letter;
                            for (int i = 1; i <= key; i++)
                            {
                                temp++;
                                if (temp == '{')
                                {
                                    temp = 'a';
                                }
                                if (temp == '[')
                                {
                                    temp = 'A';
                                }
                            }
                            result.Append(temp);
                        }
                    }

                    Console.WriteLine($"Successful encryption: {result}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
