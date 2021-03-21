namespace P04.CombinationsWithoutRepetition
{
    using System;

    class StartUp
    {
        private static int[] combinations;
        static void Main()
        {
            var lastNumber = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());

            combinations = new int[slots];

            ShowCombinationWithoutRepetion(0, lastNumber);
        }

        private static void ShowCombinationWithoutRepetion(int combinationIndex, int lastNumber, int currNumber = 1)
        {
            if (combinationIndex == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int currElement = currNumber; currElement <= lastNumber; currElement++)
            {
                combinations[combinationIndex] = currElement;
                ShowCombinationWithoutRepetion(combinationIndex + 1, lastNumber, currElement + 1);
            }
        }
    }
}
