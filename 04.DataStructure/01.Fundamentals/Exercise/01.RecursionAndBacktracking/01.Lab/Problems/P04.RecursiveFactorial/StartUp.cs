namespace P04.RecursiveFactorial
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var factorial = CalcFactorial(number);

            Console.WriteLine(factorial);
        }

        public static long CalcFactorial(int n)
        {
            if (n == 0)
                return 1;

            var currFactorial = n * CalcFactorial(n - 1);

            return currFactorial;
        }
    }
}
