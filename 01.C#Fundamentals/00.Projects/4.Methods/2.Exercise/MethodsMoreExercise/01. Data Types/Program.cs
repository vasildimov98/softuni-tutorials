using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintResult(input);
        }

        private static void PrintResult(string input)
        {
            if (input == "int")
            {
                int number = int.Parse(Console.ReadLine());

                number *= 2;
                Console.WriteLine(number);
            }
            else if (input == "real")
            {
                double number = double.Parse(Console.ReadLine());

                number *= 1.5;

                Console.WriteLine($"{number:F2}");
            }
            else if (input == "string")
            {
                string text = Console.ReadLine();

                Console.WriteLine($"${text}$");
            }
        }
    }
}
