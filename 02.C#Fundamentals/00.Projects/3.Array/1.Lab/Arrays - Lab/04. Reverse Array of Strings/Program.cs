using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] arr = Console.ReadLine().Split(' ').ToArray();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[(arr.Length - 1) - i]);
            //}

            var items = Console.ReadLine().Split(' ').ToArray();
            for (int i = 0; i < items.Length / 2; i++)
            {
                var oldElement = items[i];
                items[i] = items[items.Length - 1 - i];
                items[items.Length - 1 - i] = oldElement;
            }

            Console.WriteLine(string.Join(" ", items));

        }
    }
}
