using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            char prevChar = '0';
            foreach (var currChar in input)
            {
                if (currChar != prevChar)
                {
                    result.Append(currChar);
                    prevChar = currChar;
                }
            }

            Console.WriteLine(result);
        }
    }
}
