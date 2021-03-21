namespace P03.PermutationWithRepetitionOptimization
{
    using System;
    class Program
    {
        static void Main()
        {
            var set = Console
                .ReadLine()
                .Split();

            Array.Sort(set);
            Permute(set, 0, set.Length - 1);
        }

        private static void Permute(string[] set, int startIndex, int endIndex)
        {
            Console.WriteLine(string.Join(" ", set));
            for (int left = endIndex - 1; left >= startIndex; left--)
            {
                for (int right = left + 1; right <= endIndex; right++)
                {
                    if (set[left] != set[right])
                    {
                        Swap(set, left, right);
                        Permute(set, left + 1, endIndex);
                    }
                }


                var firstElement = set[left];
                for (int i = left; i <= endIndex - 1; i++)
                {
                    set[i] = set[i + 1];
                }

                set[endIndex] = firstElement;
            }
        }

        private static void Swap(string[] set, int left, int right)
        {
            var temp = set[left];
            set[left] = set[right];
            set[right] = temp;
        }
    }
}
