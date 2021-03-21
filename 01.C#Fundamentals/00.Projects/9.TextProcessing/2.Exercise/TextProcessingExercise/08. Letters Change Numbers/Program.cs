using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<double> numbers = new List<double>();

            foreach (var str in input)
            {
                char firstLeter = str[0];
                int posotionFistLetter = firstLeter % 32;
                char secondLeter = str[str.Length - 1];
                int posotionSecondLetter = secondLeter % 32;

                string temp = "";

                for (int i = 1; i < str.Length - 1; i++)
                {
                    temp += str[i];
                }

                double number = double.Parse(temp);

                if (char.IsUpper(firstLeter))
                {
                    number /= posotionFistLetter;
                }
                else if (char.IsLower(firstLeter))
                {
                    number *= posotionFistLetter;
                }

                if (char.IsUpper(secondLeter))
                {
                    number -= posotionSecondLetter;
                }
                else if (char.IsLower(secondLeter))
                {
                    number += posotionSecondLetter;
                }

                numbers.Add(number);
            }

            double sum = Math.Round(numbers.Sum(), 2, MidpointRounding.AwayFromZero);

            Console.WriteLine($"{sum:F2}");
        }
    }
}
