namespace P04.Generating01Vectors
{
    using System;
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var vector = new int[number];
            GenVectorWithZeroAndOne(vector, 0);
        }

        private static void GenVectorWithZeroAndOne(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenVectorWithZeroAndOne(vector, index + 1);
            }
        }
    }
}
