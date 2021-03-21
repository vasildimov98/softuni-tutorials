namespace P01.Fibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    class Program
    {
        private static Dictionary<int, long> memo;
        static void Main()
        {
            memo = new Dictionary<int, long>();
            var number = int.Parse(Console.ReadLine());

            var fibonacci = GetFibonacci(number);

            Console.WriteLine(fibonacci);
        }

        private static long GetFibonacci(int number)
        {
            if (memo.ContainsKey(number)) return memo[number];

            if (number <= 2) return 1;

            var result = GetFibonacci(number - 1) + GetFibonacci(number - 2);

            memo[number] = result;

            return result;
        }
    }
}
