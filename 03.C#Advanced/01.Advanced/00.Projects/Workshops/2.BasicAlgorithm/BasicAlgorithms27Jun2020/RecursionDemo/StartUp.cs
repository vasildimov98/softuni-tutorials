namespace RecursionDemo
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
        }

        private static BigInteger Factorial(int n)
        {
            // Pre-Action -> base case!!!!
            if (n == 0)
            {
                return 1;
            }

            // Recursion -> step in the recursion or stack
            var fact = n * Factorial(n - 1);

            //Post-Action
            return fact;
        }
        private static int ArrSum(int[] arr, int index = 0)
        {
            var currElement = arr[index];

            if (arr.Length - 1 == index)
            {
                return currElement;
            }

            var sum = currElement + ArrSum(arr, index + 1);

            return sum;
        }
        private static int Pow(int number, int degree)
        {
            if (degree == 1)
            {
                return number;
            }

            return number * Pow(number, degree - 1);
        }
        private static void PrintNumbers(int currentNumber = 10)
        {
            if (currentNumber > 1)
            {
                PrintNumbers(currentNumber - 1);
            }

            Console.WriteLine(currentNumber);
        }
    }
}
