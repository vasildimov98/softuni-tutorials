using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            PrintMiddleCharacter(text);
        }

        static void PrintMiddleCharacter(string text)
        {
            if (text.Length % 2 == 0)
            {
                char firstSymbol = text[(text.Length / 2) - 1];
                int secondSymbol = text[text.Length / 2];

                Console.WriteLine(firstSymbol + "" + (char)secondSymbol);
            }
            else
            {
                char middleSybol = text[text.Length / 2];
                Console.WriteLine(middleSybol);
            }
        }
    }
}
