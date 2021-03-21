namespace P05.Shuffle
{
    using System;
    using System.Linq;

    class Program
    {
        private static int foundPermutation = 0;
        static void Main()
        {
            var collection = new[] { 1, 2, 3, 4 };

            GenerateRandomPermutation(collection);
            Console.WriteLine();
            Permute(collection);
            Console.WriteLine(foundPermutation);
        }

        private static void GenerateRandomPermutation(int[] collection)
        {
            var rnd = new Random();

            var randomArr = collection.ToArray();

            for (int i = 0; i < collection.Length; i++)
            {
                int randomIndex = i + rnd.Next(0, randomArr.Length - i);

                Swap(randomArr, i, randomIndex);
            }

            Console.WriteLine(string.Join(" ", randomArr));
        }

        private static void Permute(int[] collection, int index = 0)
        {
            if (index == collection.Length)
            {
                foundPermutation++;
                Console.WriteLine(string.Join(" ", collection));
                return;
            }

            Permute(collection, index + 1);

            for (int i = index + 1; i < collection.Length; i++)
            {
                Swap(collection, index, i);
                Permute(collection, index + 1);
                Swap(collection, index, i);
            }
        }

        private static void Swap(int[] collection, int index, int i)
        {
            var temp = collection[index];
            collection[index] = collection[i];
            collection[i] = temp;
        }
    }
}
