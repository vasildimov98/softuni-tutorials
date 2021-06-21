namespace P06.JaggedArrayManipulator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static double[][] jaggedArr;
        public static void Main()
        {
            var numberOfRows = int.Parse(Console.ReadLine());
            jaggedArr = new double[numberOfRows][];
            GetJaggendArrayFilled();
            AnalyseJAggedArray(numberOfRows);
            ProceesCommands();
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        private static void ProceesCommands()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var action = cmdArgs[0];
                var row = int.Parse(cmdArgs[1]);
                var col = int.Parse(cmdArgs[2]);
                var value = int.Parse(cmdArgs[3]);
                MakeAction(action, row, col, value);
            }
        }

        private static void MakeAction(string action, int row, int col, int value)
        {
            if (action == "Add" && ValidateCoordinates(row, col))
            {
                jaggedArr[row][col] += value;
            }
            else if (action == "Subtract" && ValidateCoordinates(row, col))
            {
                jaggedArr[row][col] -= value;
            }
        }

        private static bool ValidateCoordinates(int row, int col)
        {
            return row >= 0
                && row < jaggedArr.Length
                && col >= 0
                && col < jaggedArr[row].Length;
        }
        private static void AnalyseJAggedArray(int numberOfRows)
        {
            for (int row = 0; row < numberOfRows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] /= 2;
                    }
                }
            }
        }

        private static void GetJaggendArrayFilled()
        {
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var doubleArr = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArr[row] = doubleArr;
            }
        }
    }
}
