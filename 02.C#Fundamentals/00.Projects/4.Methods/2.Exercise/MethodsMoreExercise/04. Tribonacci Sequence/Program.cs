using System;

namespace _04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = GetArr(n);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static int[] GetArr(int n)
        {
            int tr1 = 1;
            int tr2 = 1;
            int tr3 = 2;

            int[] arr = new int[n];

            if (n >= 3)
            {
                arr[0] = tr1;
                arr[1] = tr2;
                arr[2] = tr3;
            }
            else if (n == 2)
            {
                arr[0] = tr1;
                arr[1] = tr2;
            }
            else if (n == 1)
            {
                arr[0] = 1;
            }

            int result = 0;

            for (int i = 3; i < n; i++)
            {
                result = tr1 + tr2 + tr3;
                tr1 = tr2;
                tr2 = tr3;
                tr3 = result;
                arr[i] = result;
            }

            return arr;
        }
    }
}
