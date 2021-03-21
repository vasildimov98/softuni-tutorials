using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string str1 = input[0];
            string str2 = input[1];

            int min = Math.Min(str1.Length, str2.Length);

            int sum = 0;
            for (int i = 0; i < min; i++)
            {
                sum += str1[i] * str2[i];
            }

            if (min == str1.Length)
            {
                for (int i = min; i < str2.Length; i++)
                {
                    sum += str2[i];
                }
            }

            if (min == str2.Length)
            {
                for (int i = min; i < str1.Length; i++)
                {
                    sum += str1[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
