
using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string normal = Console.ReadLine();

            string reverse = "";

            for (int i = normal.Length - 1; i >= 0; i--)
            {
                reverse += normal[i];
            }

            Console.WriteLine(reverse);
        }
    }
}
