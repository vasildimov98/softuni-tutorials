using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            string result = Character(symbol1, symbol2);
            Console.WriteLine(result);
        }

        static string Character(char a, char b)
        {
            int start = Math.Min(a, b);
            int end = Math.Max(a, b);
            string result = "";
            for (int i = start + 1; i <= end - 1; i++)
            {
                result += (char)i + " ";
            }
            return result;
        }
    }
}
