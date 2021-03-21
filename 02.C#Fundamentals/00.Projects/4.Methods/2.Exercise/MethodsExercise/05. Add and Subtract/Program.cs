using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int sum = Sum(num1, num2);
            int result = Substract(sum, num3);
            Console.WriteLine(result);
        }

        static int Sum(int a, int b)
        {
            int sum = a + b;
          
            return sum;
        }

        static int Substract(int sum, int c)
        {
            int result = sum - c;
            return result;
        }
    }
}
