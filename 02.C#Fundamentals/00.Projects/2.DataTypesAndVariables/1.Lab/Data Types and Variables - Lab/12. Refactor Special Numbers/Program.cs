using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int variable = 0;
            bool isTrue = false;
            for (int i = 1; i <= n; i++)
            {
                variable = i;
                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }
                isTrue = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", variable, isTrue);
                sum = 0;
                i = variable;
            }

        }
    }
}
