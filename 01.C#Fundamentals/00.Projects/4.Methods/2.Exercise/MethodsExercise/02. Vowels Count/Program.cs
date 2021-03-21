using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine().ToLower();
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                char symbol = name[i];

                if (IsVowel(symbol))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static bool IsVowel(char letter)
        {
            return letter == 'a' ||
                letter == 'e' ||
                letter == 'u' ||
                letter == 'i' ||
                letter == 'y' ||
                letter == 'o';
        }
    }
}
