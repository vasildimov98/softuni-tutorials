using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                char alphabet = char.Parse(Console.ReadLine());

                sum += alphabet;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
