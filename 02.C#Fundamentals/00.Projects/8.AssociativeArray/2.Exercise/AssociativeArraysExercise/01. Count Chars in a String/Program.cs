using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] texts = Console
                .ReadLine()
                .Split();

            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var word in texts)
            {
                char[] temp = word.ToCharArray();

                foreach (var letter in temp)
                {
                    if (dict.ContainsKey(letter))
                    {
                        dict[letter]++;
                    }
                    else
                    {
                        dict[letter] = 1;
                    }
                }
            }

            foreach (var letter in dict)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
