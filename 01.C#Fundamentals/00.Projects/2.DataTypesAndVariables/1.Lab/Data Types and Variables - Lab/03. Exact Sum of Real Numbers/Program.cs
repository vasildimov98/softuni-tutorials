using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal n1 = decimal.Parse(Console.ReadLine());
                sum += n1;
            }

            Console.WriteLine(sum);
        }
    }
}
