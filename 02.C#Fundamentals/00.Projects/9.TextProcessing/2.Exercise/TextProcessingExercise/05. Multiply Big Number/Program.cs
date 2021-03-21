using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine().TrimStart(new char[] { '0' });

            int number2 = int.Parse(Console.ReadLine());

            if (number2 == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<int> result = new List<int>();
            int rest = 0;
            int product = 0;
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int numb = number1[i] - '0';
                product = numb * number2;
                product += rest;
                result.Add(product % 10);
                rest = product / 10;
            }

            if (rest > 0)
            {
                result.Add(rest);
            }

            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
