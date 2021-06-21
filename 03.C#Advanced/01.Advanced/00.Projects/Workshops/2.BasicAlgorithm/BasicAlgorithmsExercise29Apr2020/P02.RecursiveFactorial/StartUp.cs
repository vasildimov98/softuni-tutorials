using System;

namespace P02.RecursiveFactorial
{
    class StartUp
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var result = Factorial(number);

            Console.WriteLine(result);
        }

        static long Factorial(int number)
        {
            // 5 -> 5 * 4 * 3 * 2 * 1 = 120

            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
