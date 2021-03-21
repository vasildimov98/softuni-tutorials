namespace P11.Words
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        private static Dictionary<char, int> unique;
        private static int count;
        static void Main()
        {
            var word = Console
                .ReadLine()
                .ToCharArray();

            if (WordIsAllUniqueLetter(word))
            {
                count = GetFactorial(word.Length);
            }
            else FindAllUniquePermutation(word, 0);

            Console.WriteLine(count);
        }

        private static void FindAllUniquePermutation(char[] word,
            int index)
        {
            if (index == word.Length)
            {
                if (PermutationIsWithoutRepetition(word))
                    count++;
                return;
            }

            var swapped = new bool['z' + 1];
            for (int i = index; i < word.Length; i++)
            {
                if (swapped[word[i]]) continue;

                swapped[word[i]] = true;
                Swap(word, index, i);
                FindAllUniquePermutation(word, index + 1);
                Swap(word, index, i);
            }
        }

        private static int GetFactorial(int number)
        {
            var factorial = 1;
            for (int i = 2; i <= number; i++)
                factorial *= i;
            return factorial;
        }

        private static bool WordIsAllUniqueLetter(char[] word)
        {
            unique = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!unique.ContainsKey(word[i]))
                    unique[word[i]] = 0;

                unique[word[i]]++;
            }

            return unique.Count == word.Length;
        }

        private static bool PermutationIsWithoutRepetition(char[] word)
        {
            for (int i = 0; i < word.Length - 1; i++)
                if (word[i] == word[i + 1]) return false; ;

            return true;
        }

        private static void Swap(char[] word, int firstIndex, int secondIndex)
        {
            var temp = word[firstIndex];
            word[firstIndex] = word[secondIndex];
            word[secondIndex] = temp;
        }
    }
}
