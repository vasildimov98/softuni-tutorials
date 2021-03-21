using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            PrintTopPart(counter);
            PrintBottomPart(counter);
        }

        static void PrintTopPart(int num)
        {
            for (int counter = 1; counter <= num; counter++)
            {
                for (int i = 1; i <= counter; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintBottomPart(int num)
        {
            for (int counter = num - 1; counter >= 1; counter--)
            {
                for (int i = 1; i <= counter; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
