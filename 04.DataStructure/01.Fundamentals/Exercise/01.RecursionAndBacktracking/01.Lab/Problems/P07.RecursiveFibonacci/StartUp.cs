namespace P07.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var fibonacci = CalcFibonacci(n, new Dictionary<int, long>());
            Console.WriteLine(fibonacci);
        }

        private static long CalcFibonacci(int n, Dictionary<int, long> dictionary)
        {
            if (n <= 1) return 1;

            if (dictionary.ContainsKey(n))
                return dictionary[n];

            var oneNumberBack = CalcFibonacci(n - 1, dictionary);
            var twoNumberBack = CalcFibonacci(n - 2, dictionary);

            var currFibonacci = oneNumberBack + twoNumberBack;

            if (!dictionary.ContainsKey(n))
                dictionary[n] = currFibonacci;

            return currFibonacci;
        }
    }
}
