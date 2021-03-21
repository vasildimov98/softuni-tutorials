using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int result = 0;
            switch (command)
            {
                case "add":
                    result = Add(num1, num2);
                    break;
                case "subtract":
                    result = Substract(num1, num2);
                    break;
                case "multiply":
                    result = Mul(num1, num2);
                    break;
                case "divide":
                    result = Devide(num1, num2);
                    break;
            }

            Console.WriteLine(result);

        }

        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        static int Substract(int num1, int num2)
        {
            return num1 - num2;
        }

        static int Mul(int num1, int num2)
        {
            return num1 * num2;
        }

        static int Devide(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}
