using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = ReadJaggedArray(rows);

            AnalyseArray(jaggedArray, rows);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var data = command
                    .Split();

                var row = int.Parse(data[1]);
                var col = int.Parse(data[2]);
                var value = int.Parse(data[3]);

                if (!Validator(jaggedArray, row, col))
                {
                    continue;
                }

                if (data[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (data[0] == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        static void PrintJaggedArray(double[][] jaggedArr)
        {
            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
        static bool Validator(double[][] arr, int row, int col)
        {
            if (row < 0 ||
                row >= arr.Length ||
                col < 0 ||
               col >= arr[row].Length)
            {
                return false;
            }

            return true;
        }
        static void AnalyseArray(double[][] arr, int rows)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (arr[row].Length == arr[row + 1].Length)
                {
                    for (int col = 0; col < arr[row].Length; col++)
                    {
                        arr[row][col] *= 2;
                        arr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < arr[row].Length; col++)
                    {
                        arr[row][col] /= 2;
                    }

                    for (int col = 0; col < arr[row + 1].Length; col++)
                    {
                        arr[row + 1][col] /= 2;
                    }
                }
            }
        }
        static double[][] ReadJaggedArray(int rows)
        {

            var jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArray(' ');

                jaggedArray[row] = data;
            }

            return jaggedArray;
        }
        static double[] ParseArray(params char[] splitSymbols)
        {
            return Console
                .ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
    }
}
