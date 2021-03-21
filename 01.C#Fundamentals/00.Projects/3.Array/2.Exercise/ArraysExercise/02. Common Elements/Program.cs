using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.
                ReadLine().
                Split();
            string[] arr2 = Console.
                ReadLine().
                Split();

            foreach (string word1 in arr2)
            {
               foreach(string word2 in arr1)
                {
                    if (word1 == word2)
                    {
                        Console.Write(word1+ " ");
                    }
                }
            }
        }
    }
}
