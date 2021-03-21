using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Sequence_N_M
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Node> queue = new Queue<Node>();
            int[] input = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int first = input[0];
            int last = input[1];

            queue.Enqueue(new Node(first, null));
            Stack<int> stack = new Stack<int>();
            if (first < last)
            {
                while (true)
                {
                    Node element = queue.Dequeue();

                    if (element.Value == last)
                    {
                        while (element != null)
                        {
                            stack.Push(element.Value);
                            element = element.PrevNode;
                        }

                        Console.WriteLine(string.Join(" -> ", stack.ToArray()));
                        return;
                    }

                    queue.Enqueue(new Node(element.Value + 1, element));
                    if (element.Value + 1 == last)
                    {
                        Node temp = new Node(element.Value + 1, element);
                        while (temp != null)
                        {
                            stack.Push(temp.Value);
                            temp = temp.PrevNode;
                        }

                        Console.WriteLine(string.Join(" -> ", stack.ToArray()));
                        return;
                    }
                    queue.Enqueue(new Node(element.Value + 2, element));
                    if (element.Value + 2 == last)
                    {
                        Node temp = new Node(element.Value + 2, element);
                        while (temp != null)
                        {
                            stack.Push(temp.Value);
                            temp = temp.PrevNode;
                        }

                        Console.WriteLine(string.Join(" -> ", stack.ToArray()));
                        return;
                    }
                    queue.Enqueue(new Node(element.Value * 2, element));
                    if (element.Value * 2 == last)
                    {
                        Node temp = new Node(element.Value * 2, element);
                        while (temp != null)
                        {
                            stack.Push(temp.Value);
                            temp = temp.PrevNode;
                        }

                        Console.WriteLine(string.Join(" -> ", stack.ToArray()));
                        return;
                    }
                }
            }
            else if (first == last)
            {
                Console.WriteLine(first);
            }

        }
    }

    public class Node
    {
        public Node(int value, Node prevNode)
        {
            this.Value = value;
            this.PrevNode = prevNode;
        }
        public int Value;
        public Node PrevNode;
    }
}
