using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Demo
{
    public class StartUp
    {
        public static void Main()
        {
            var matrix = new int[2, 3];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = col + 1;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            var arr = new int[5] { 1, 2, 3, 4, 5 };

            //O(1);
            Console.WriteLine(arr[1]);
            Console.WriteLine(arr[4]);

            var newArr = new int[arr.Length * 2];

            //O(n)
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            var firstNode = new Node<int>(1);
            var secondNode = new Node<int>(2);
            var thirdNode = new Node<int>(3);

            firstNode.Next = secondNode;
            secondNode.Next = thirdNode;

            var linkedList = new LinkedList<int>();

            var node = new LinkedListNode<int>(1);
        }

        private static long GetOperationsCount(int n)
        {
            long counter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
