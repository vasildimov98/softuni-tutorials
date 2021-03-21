namespace P05.VariationsWithoutRepetition
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var set = Console
                .ReadLine()
                .Split()
                .ToArray();
            var slots = int.Parse(Console.ReadLine());

            var vector = new string[slots];
            var visited = new bool[set.Length];

            Variations(set, vector, visited, 0);
        }

        private static void Variations(string[] set, string[] vector, bool[] visited, int vectorIndex)
        {
            if (vectorIndex == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int setIndex = 0; setIndex < set.Length; setIndex++)
            {
                if (visited[setIndex]) continue;
                visited[setIndex] = true;
                vector[vectorIndex] = set[setIndex];
                Variations(set, vector, visited, vectorIndex + 1);
                visited[setIndex] = false;
            }
        }
    }
}
