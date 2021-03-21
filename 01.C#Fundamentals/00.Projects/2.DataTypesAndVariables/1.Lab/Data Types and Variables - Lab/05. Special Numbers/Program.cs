using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int iCopy = i;
                for (int j = 0; j < i.ToString().Length; j++)
                {

                    int digit = iCopy % 10;
                    iCopy /= 10;
                    sum += digit;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
                sum = 0;
            }
        }
    }
}
