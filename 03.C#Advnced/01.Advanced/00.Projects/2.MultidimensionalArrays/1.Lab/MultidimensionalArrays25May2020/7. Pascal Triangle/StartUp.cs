using System;

namespace _7._Pascal_Triangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = new long[rows][];

            jaggedArray[0] = new long[1];

            jaggedArray[0][0] = 1;

            if (rows > 1)
            {
                jaggedArray[1] = new long[2];
                jaggedArray[1][0] = 1;
                jaggedArray[1][1] = 1;
            }


            for (int row = 2; row < rows; row++)
            {
                jaggedArray[row] = new long[row + 1];

                jaggedArray[row][0] = 1;

                for (int col = 1; col < row; col++)
                {
                    jaggedArray[row][col] = jaggedArray[row - 1][col - 1]
                        + jaggedArray[row - 1][col];
                }

                jaggedArray[row][row] = 1;
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
