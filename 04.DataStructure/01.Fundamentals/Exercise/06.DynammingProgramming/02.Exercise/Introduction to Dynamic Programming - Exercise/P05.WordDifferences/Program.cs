namespace P05.WordDifferences
{
    using System;
    class Program
    {
        static void Main()
        {
            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            var table = new int[firstStr.Length + 1, secondStr.Length + 1];
            FillFirstRowAndCol(table);

            var result = GetCountOfInsrAndDel(table, firstStr, secondStr);

            Console.WriteLine($"Deletions and Insertions: {result}");
        }

        private static int GetCountOfInsrAndDel(int[,] table, string str1, string str2)
        {
            for (int row = 1; row < table.GetLength(0); row++)
                for (int col = 1; col < table.GetLength(1); col++)
                    if (str1[row - 1] == str2[col - 1])
                        table[row, col] = table[row - 1, col - 1];
                    else table[row, col] = Math.Min(table[row, col - 1], table[row - 1, col]) + 1;

            return table[table.GetLength(0) - 1, table.GetLength(1) - 1];
        }

        private static void FillFirstRowAndCol(int[,] table)
        {
            for (int row = 1; row < table.GetLength(0); row++)
                table[row, 0] = row;

            for (int col = 1; col < table.GetLength(1); col++)
                table[0, col] = col;
        }
    }
}
