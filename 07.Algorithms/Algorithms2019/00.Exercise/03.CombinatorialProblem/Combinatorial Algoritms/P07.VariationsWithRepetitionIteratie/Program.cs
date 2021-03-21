namespace P07.VariationsWithRepetitionIteratie
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var set = Console
                .ReadLine()
                .Split()
                .ToArray();

            var slots = int.Parse(Console.ReadLine());
            var vector = new int[slots];
            VariationsWithRepetition(set, vector);
        }

        private static void VariationsWithRepetition(string[] set, int[] vector)
        {
            var slots = vector.Length;

            var fistIndex = 0;
            var lastIndex = set.Length - 1;
            while (true)
            {
                PrintArr(set, vector);

                var index = slots - 1;

                while (index >= 0 && vector[index] == lastIndex)
                    index--;

                if (index < 0)
                    break;

                vector[index]++;
                for (int i = index + 1; i < vector.Length; i++)
                    vector[i] = fistIndex;
            }
        }

        private static void PrintArr(string[] set, int[] vector)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < vector.Length; i++)
                sb.Append($"{set[vector[i]]} ");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
