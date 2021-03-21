namespace P07.NChooseKCount
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, long> memory;
        public static void Main()
        {
            memory = new Dictionary<string, long>();

            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var binom = Binom(n, k);
            Console.WriteLine(binom);
        }

        private static long Binom(int row, int col)
        {
            if (row <= 1) return 1;
            if (col == 0 || col == row) return 1;

            var key = $"{row} {col}";
            if (memory.ContainsKey(key))
                return memory[key];

            var topLeftNum = Binom(row - 1, col - 1);
            var topRightNum = Binom(row - 1, col);

            var currNumber = topLeftNum + topRightNum;

            if (!memory.ContainsKey(key))
                memory[key] = currNumber;

            return currNumber;
        }
    }
}
