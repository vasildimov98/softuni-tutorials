using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int start = Math.Min(first, second);
            int end = Math.Max(first, second);

            int sum = 0;
            for (int i = start + 1; i < end; i++)
            {
                char curr = (char)i;

                while (input.Contains(curr))
                {
                    sum += curr;
                    int index = input.IndexOf(curr);
                    input = input.Remove(index, 1);
                }

            }

            Console.WriteLine(sum);
        }
    }
}
