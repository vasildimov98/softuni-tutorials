namespace P03.CombinationsWithRepetition
{
    using System;

    public class StartUp
    {
        private static int[] combinations;

        public static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());

            combinations = new int[slots];

            CombinationsWithRepetition(0, numbers);
        }

        private static void CombinationsWithRepetition(int combinationIndex, int numbers, int currElement = 1)
        {
            if (combinationIndex == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int element = currElement; element <= numbers; element++)
            {
                combinations[combinationIndex] = element;
                CombinationsWithRepetition(combinationIndex + 1, numbers, element);
            }
        }
    }
}
