using System;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console
                .ReadLine()
                .Split();

            string result = "";
            foreach (var currentWord in arr)
            {
                for (int i = 0; i < currentWord.Length; i++)
                {
                    result += currentWord;
                }
            }

            Console.WriteLine(result);
        }
    }
}
