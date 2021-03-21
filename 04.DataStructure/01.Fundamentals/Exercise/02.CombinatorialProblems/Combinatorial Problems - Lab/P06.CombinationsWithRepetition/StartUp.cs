namespace P06.CombinationsWithRepetition
{
    using System;
    class StartUp
    {
        private static string[] set;
        private static string[] combinations;
        static void Main()
        {
            set = Console.ReadLine().Split();
            var slot = int.Parse(Console.ReadLine());
            combinations = new string[slot];
            CombinationsWithRepetition();
        }

        private static void CombinationsWithRepetition(int combinationIndex = 0, int elementIndex = 0)
        {
            if (combinationIndex == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int setIndex = elementIndex; setIndex < set.Length; setIndex++)
            {
                combinations[combinationIndex] = set[setIndex];
                CombinationsWithRepetition(combinationIndex + 1, setIndex);
            }
        }
    }
}
