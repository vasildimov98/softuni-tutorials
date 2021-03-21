namespace P09.FibonacciSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var arr = Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();


            var numberToSearch = int.Parse(Console.ReadLine());

            var numberIndexInCollection = FindNumberIndex(arr, numberToSearch);

            Console.WriteLine(numberIndexInCollection);
        }

        private static int FindNumberIndex(int[] arr, int numberToSearch)
        {
            var fib2 = 0L;
            var fib1 = 1L;
            var fibonacciIndex = fib2 + fib1;

            while (fibonacciIndex < arr.Length)
            {
                fib2 = fib1;
                fib1 = fibonacciIndex;
                fibonacciIndex = fib2 + fib1;
            }

            var offset = -1L;
           
            while (fibonacciIndex > 1)
            {
                var index = Math.Min(offset + fib2, arr.Length - 1);

                if (numberToSearch > arr[index])
                {
                    offset = index;
                    fibonacciIndex = fib1;
                    fib1 = fib2;
                    fib2 = fibonacciIndex - fib1;
                }
                else if (numberToSearch < arr[index])
                {
                    fibonacciIndex = fib2;
                    fib1 -= fibonacciIndex;
                    fib2 = fibonacciIndex - fib1;
                }
                else return (int)index;
            }

            if (fib1 == 1
                && arr[offset + 1 >= arr.Length ? offset : offset + 1] == numberToSearch)
                return (int)offset + 1;

            return -1;
        }
    }
}
