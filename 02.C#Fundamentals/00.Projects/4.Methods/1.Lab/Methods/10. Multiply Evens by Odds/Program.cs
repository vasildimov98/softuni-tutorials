using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvenAndOdds(num);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int num)
        {
            int result = GetSumOfEvenDigit(num) * GetSumOfOddDigit(num);
            return result;
        }

        static int GetSumOfEvenDigit(int num)
        {
            int sum1 = 0;
            while (num != 0)
            {
                int digit = num % 10;
                if (digit % 2 == 0)
                {
                    sum1 += digit;
                }
                num /= 10;
            }
            return sum1;
        }

        static int GetSumOfOddDigit(int num)
        {
            int sum2 = 0;
            while (num != 0)
            {
                int digit = num % 10;
                if (digit % 2 != 0)
                {
                    sum2 += digit;
                }
                num /= 10;
            }
            return sum2;
        }
    }
}
