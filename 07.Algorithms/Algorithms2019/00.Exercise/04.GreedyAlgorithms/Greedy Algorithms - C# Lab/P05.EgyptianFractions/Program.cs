namespace P05.EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var args = Console
                .ReadLine()
                .Split('/')
                .Select(int.Parse)
                .ToArray();

            var numerator = args[0]; // 43;
            var denominator = args[1]; // 48;

            if (denominator <= numerator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{numerator}/{denominator} = ");

            var fractions = new List<string>();

            var currDenominator = 2;// 1/2

            while (numerator != 0)
            {
                var nextNumerator = numerator * currDenominator; // 86
                var indexNumerator = denominator; // 48

                var remaining = nextNumerator - indexNumerator; // 38

                if (remaining < 0)
                {
                    currDenominator++;
                    continue;
                }

                numerator = remaining;
                denominator *= currDenominator; // 
                fractions.Add($"1/{currDenominator++}");
            }

            Console.WriteLine(string.Join(" + ", fractions));
        }
    }
}
