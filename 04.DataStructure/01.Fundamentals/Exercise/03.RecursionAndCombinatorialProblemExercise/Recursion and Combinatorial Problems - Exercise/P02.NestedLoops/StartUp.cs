namespace P02.NestedLoops
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            GenerateVector(arr, n);
        }

        private static void GenerateVector(int[] matrix, int n, int row = 0)
        {
            if (row == matrix.Length)
            {
                Console.WriteLine(string.Join(" ", matrix));
                return;
            }

            for (int col = 1; col <= n; col++)
            {
                matrix[row] = col;
                GenerateVector(matrix, n, row + 1);
            }
        }
    }
}
