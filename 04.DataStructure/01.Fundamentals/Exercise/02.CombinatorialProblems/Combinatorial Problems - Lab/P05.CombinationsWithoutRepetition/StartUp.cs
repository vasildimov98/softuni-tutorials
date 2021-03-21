namespace P05.CombinationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        private static string[] set;
        private static string[] combinations;
        public static void Main()
        {
            set = Console.ReadLine().Split();
            var slot = int.Parse(Console.ReadLine());
            combinations = new string[slot];
            CombinateWithoutRepetion(0, 0);
        }

        private static void CombinateWithoutRepetion(int combinateIndex, int elementIndex)
        {
            if (combinateIndex == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int setIndex = elementIndex; setIndex < set.Length; setIndex++)
            {
                combinations[combinateIndex] = set[setIndex];
                CombinateWithoutRepetion(combinateIndex + 1, setIndex + 1);
            }
        }
    }
}
