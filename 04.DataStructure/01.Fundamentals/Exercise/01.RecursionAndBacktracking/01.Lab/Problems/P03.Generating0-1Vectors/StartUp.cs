namespace P03.Generating0_1Vectors
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var vecotor = new int[n];
            GenerateVectors(vecotor);
        }

        private static void GenerateVectors(int[] vector, int index = 0)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenerateVectors(vector, 1 + index);
            }
        }
    }
}
