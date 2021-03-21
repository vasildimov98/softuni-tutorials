    using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numberOfPeople = new int[n];

            int sum = 0;
            for (int i = 0; i < numberOfPeople.Length; i++)
            {
                numberOfPeople[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numberOfPeople.Length; i++)
            {
                Console.Write(numberOfPeople[i] + " ");
                sum += numberOfPeople[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
