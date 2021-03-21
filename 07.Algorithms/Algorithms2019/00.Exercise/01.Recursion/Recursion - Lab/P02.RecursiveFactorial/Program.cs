namespace P02.RecursiveFactorial
{
    using System;
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var numbFact = CalcFactorial(number);
            Console.WriteLine(numbFact);
        }

        private static long CalcFactorial(int number)
        {
            if (number <= 1) return 1;

            return number * CalcFactorial(number - 1);
        }
    }
}
