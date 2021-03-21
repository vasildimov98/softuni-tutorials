using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine(i + counter);
                sum += i + counter;
                counter++;
                
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
