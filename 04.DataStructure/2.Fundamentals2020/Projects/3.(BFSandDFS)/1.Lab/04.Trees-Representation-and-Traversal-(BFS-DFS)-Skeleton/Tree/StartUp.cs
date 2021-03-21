namespace Tree
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // 7 - 19 - 1, 12, 31, 21, 14 - 23, 6

            var tree =
                new Tree.Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));
            // BFS order
            var orderedTreeByBFS = tree.OrderBfs();

            Console.WriteLine(string.Join(", ", orderedTreeByBFS));

            Console.WriteLine();

            // Recursion 
            Recursion(15);

            Console.WriteLine();

            // DFS order
            var orderedTreeByDFS = tree.OrderDfs();
            Console.WriteLine(string.Join(", ", orderedTreeByDFS));

            Console.WriteLine();

            // Add Child
            tree.AddChild(6, new Tree<int>(18));
            var orderedTreeByDFS1 = tree.OrderDfs();
            Console.WriteLine(string.Join(", ", orderedTreeByDFS1));

            Console.WriteLine();

            // Remove Child
            tree.RemoveNode(6);
            var orderedTreeByDFS2 = tree.OrderBfs();
            Console.WriteLine(string.Join(", ", orderedTreeByDFS2));

            Console.WriteLine();

            // Remove Root
            tree.RemoveNode(7);
            var orderedTreeByDFS3 = tree.OrderBfs();
            Console.WriteLine(string.Join(", ", orderedTreeByDFS3));

            Console.WriteLine();

            // Swap 14 and 23
            tree =
                new Tree.Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));

            tree.Swap(14, 23);
            var orderedTreeByDFS4 = tree.OrderBfs();
            Console.WriteLine(string.Join(", ", orderedTreeByDFS4));
        }

        private static void Recursion(int number)
        {
            if (number == 0)
            {
                return;
            }

            Recursion(number - 1);
            Console.WriteLine(number);
        }
    }
}
