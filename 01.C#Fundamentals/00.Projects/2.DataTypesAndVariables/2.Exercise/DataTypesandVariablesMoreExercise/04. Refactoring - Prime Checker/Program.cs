using System;

namespace _04._Refactoring___Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int prime = int.Parse(Console.ReadLine());
            for (int i = 2; i <= prime; i++)
            {
                bool isPrime = true;
                for (int cepitel = 2; cepitel < i; cepitel++)
                {
                    if (i % cepitel == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime.ToString().ToLower()}"); ;
            }

        }
    }
}
