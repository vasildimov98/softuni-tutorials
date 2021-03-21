using System;
using System.Linq;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for (int i = 1; i <= end; i++)
            {
                if (IsDividedByEight(i) && HoldsAnOddNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsDividedByEight(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool HoldsAnOddNumber(int number)
        {
            bool holdsOddNumber = false;
            while (number != 0)
            {
                if ((number % 2) != 0)
                {
                    return true;
                }
                number /= 10;
            }
            return holdsOddNumber;
        }

    }
}
