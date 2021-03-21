using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string operatior = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            double result = Calculatior(num1, operatior, num2);
            Console.WriteLine(result);
        }

        static double Calculatior(int num1, string operatior, int num2)
        {
            double result = 0;

            switch (operatior)
            {
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
            }

            return result;
        }
    }
}
