using System;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string twoNumbers = Console.ReadLine();
                string stringBeforeSpaces = twoNumbers.Substring(0, twoNumbers.IndexOf(" "));
                string stringAfterSpaces = twoNumbers.Substring(twoNumbers.IndexOf(" ") + 1);

                long leftNumber = long.Parse(stringBeforeSpaces);
                long rightNumber = long.Parse(stringAfterSpaces);

                long digit = 0;
                long sum = 0;
                if (leftNumber > rightNumber)
                {
                    leftNumber = Math.Abs(leftNumber);

                    while (leftNumber != 0)
                    {
                        digit = leftNumber % 10;
                        sum += digit;
                        leftNumber /= 10;  
                   }
                    Console.WriteLine(sum);
                }
                else
                {
                    rightNumber = Math.Abs(rightNumber);
                    while (rightNumber != 0)
                    {
                        digit = rightNumber % 10;
                        sum += digit;
                        rightNumber /= 10;
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
