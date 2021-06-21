using System;

namespace P01.RhombusofStars
{
    class StartUp
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());


            for (int row = 0; row < num; row++)
            {
                PrintRow(num, row + 1);
            }

            for (int row = 0; row < num - 1; row++)
            {
                PrintRow(num, num - 1- row);
            }
        }

        private static void PrintRow(int num, int starCount)
        {
            var whiteSpace = new string(' ', num - starCount);

            Console.Write(whiteSpace);

            for (int star = 0; star < starCount; star++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
