using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            foreach (var ch in text)
            {
                result.Append((char)(ch + 3));
            }

            Console.WriteLine(result);
        }
    }
}
