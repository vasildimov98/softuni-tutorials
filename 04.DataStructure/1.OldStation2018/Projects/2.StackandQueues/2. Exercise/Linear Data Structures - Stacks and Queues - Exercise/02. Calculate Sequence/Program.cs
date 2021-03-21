using System;
using System.Collections.Generic;

namespace _02._Calculate_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(n);
            int[] elements = new int[50];
            for (int i = 0; i < 50; i++)
            {
                int element = queue.Dequeue();
                elements[i] = element;

                queue.Enqueue(element + 1);
                queue.Enqueue(2*element + 1);
                queue.Enqueue(element + 2);
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
