namespace P07.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static int replaceCost;
        private static int insertCost;
        private static int deleteCost;
        private static int[,] editCosts;
        static void Main()
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());

            var originalText = Console.ReadLine();
            var destinationText = Console.ReadLine();

            Run(originalText, destinationText);
        }

        private static void Run(string originalText, string destinationText)
        {
            var firstLen = destinationText.Length + 1;
            var secondLen = originalText.Length + 1;
            editCosts = new int[firstLen, secondLen];
            CompleteTable(originalText, destinationText);
        }

        private static void CompleteTable(string originalText, string destinationText)
        {
            FillFirstRow();
            FillFirstCol();
            for (int row = 1; row < editCosts.GetLength(0); row++)
            {
                for (int col = 1; col < editCosts.GetLength(1); col++)
                {
                    var cost = destinationText[row - 1] == originalText[col - 1] ? 0 : replaceCost;

                    var replace = editCosts[row - 1, col - 1] + cost;
                    var insert = editCosts[row - 1, col] + insertCost;
                    var delete = editCosts[row, col - 1] + deleteCost;

                    editCosts[row, col] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            //PrintMatrix(editCosts);
            PrintResult(editCosts, originalText, destinationText);
        }

        private static void PrintResult(int[,] editCosts, string originalText, string destinationText)
        {
            var row = destinationText.Length;
            var col = originalText.Length;
            Console.WriteLine($"Minimum edit distance: {editCosts[row, col]}");

            var operations = new Stack<string>();
            while (row > 0 && col > 0)
            {
                if (destinationText[row - 1] == originalText[col - 1])
                {
                    row--;
                    col--;
                }
                else
                {
                    var replace = editCosts[row - 1, col - 1] + replaceCost;
                    var insert = editCosts[row - 1, col] + insertCost;
                    var delete = editCosts[row, col - 1] + deleteCost;

                    if (replace <= insert && replace <= delete)
                    {
                        row--;
                        col--;
                        operations.Push($"Replace {originalText[col]} with {destinationText[row]}");
                    }
                    else if (delete < insert && delete < replace)
                    {
                        col--;
                        operations.Push($"{originalText[col]} is deleted");
                    }
                    else
                    {
                        row--;
                        operations.Push($"{destinationText[row]} is inserted");
                    }
                }
            }

            while (row > 0)
            {
                row--;
                operations.Push($"{destinationText[row]} is inserted");
            }

            while (col > 0)
            {
                col--;
                operations.Push($"{originalText[col]} is deleted");
            }

            Console.WriteLine(string.Join(Environment.NewLine, operations));
        }

        //private static void PrintMatrix(int[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write(matrix[row, col] + " ");
        //        }

        //        Console.WriteLine();
        //    }
        //}

        private static void FillFirstCol()
        {
            for (int row = 0; row < editCosts.GetLength(0); row++)
            {
                editCosts[row, 0] = row * insertCost;
            }
        }

        private static void FillFirstRow()
        {
            for (int col = 0; col < editCosts.GetLength(1); col++)
            {
                editCosts[0, col] = col * deleteCost;
            }
        }
    }
}
