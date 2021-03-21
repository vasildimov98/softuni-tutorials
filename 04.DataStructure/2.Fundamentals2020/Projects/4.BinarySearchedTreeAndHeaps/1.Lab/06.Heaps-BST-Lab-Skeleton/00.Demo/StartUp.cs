namespace _00.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var tree = new Tree<int>(17,
                    new Tree<int>(9,
                        new Tree<int>(3),
                        new Tree<int>(11)),
                    new Tree<int>(25,
                        new Tree<int>(20),
                        new Tree<int>(31)));


            // Order DFS
            var dsfOrder = tree.OrderDfs();

            Console.WriteLine(string.Join(" ", dsfOrder));

            Console.WriteLine();

            // Order BFS
            var bfsOrder = tree.OrderBfs();

            Console.WriteLine(string.Join(" ", bfsOrder));

            // Recursion - 1 - n
            Console.WriteLine(Recursion(10));
        }

        private static int Recursion(int n)
        {
            if (n == 1)
            {
                return n;
            }

            return n + Recursion(n - 1);
        }
    }
}
