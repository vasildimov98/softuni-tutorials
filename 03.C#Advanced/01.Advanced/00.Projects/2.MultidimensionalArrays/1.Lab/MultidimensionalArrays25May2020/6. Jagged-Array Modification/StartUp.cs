using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var jaggedArr = ReadJaggedArray(n);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command
                    .Split()
                    .ToArray();

                var row = int.Parse(data[1]);
                var col = int.Parse(data[2]);
                var value = int.Parse(data[3]);

                if (row < 0
                    || row >= n
                    || col < 0
                    || col >= n)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (data[0] == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else if (data[0] == "Subtract")
                {
                    jaggedArr[row][col] -= value;
                }
            }

            foreach (var row in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[][] ReadJaggedArray(int rows)
        {
            var jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = new int[rows];

                var data = ParseArray(' ');

                jaggedArray[row] = data;
            }

            return jaggedArray;
        }

        private static int[] ParseArray(params char[] splitSymbols)
        {
            return Console
                .ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
