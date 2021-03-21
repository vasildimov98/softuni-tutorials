using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int sum = n / p;
            if (n % p != 0)
            {
                sum += 1;
            }
            Console.WriteLine(sum);
        }
    }
}
