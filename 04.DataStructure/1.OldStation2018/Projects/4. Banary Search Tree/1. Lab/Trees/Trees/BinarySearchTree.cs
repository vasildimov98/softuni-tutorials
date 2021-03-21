using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
    private Node root;

    private BinarySearchTree(Node current)
    {
        this.Copy(current);
    }

    public BinarySearchTree()
    {
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = this.root;
        int compare = 0;
        while (current != null)
        {
            compare = value.CompareTo(current.Value);
            if (compare < 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (compare > 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        Node newNode = new Node(value);
        if (compare < 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        int compare = 0;
        while (current != null)
        {
            compare = value.CompareTo(current.Value);
            if (compare < 0)
            {
                current = current.Left;
            }
            else if (compare > 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }
        return current != null;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node parent = null;
        Node min = this.root;

        while (min.Left != null)
        {
            parent = min;
            min = min.Left;
        }

        if (parent == null)
        {
            this.root = null;
        }
        else
        {
            parent.Left = min.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;
        int compare = 0;
        while (current != null)
        {
            compare = item.CompareTo(current.Value);

            if (compare < 0)
            {
                current = current.Left;
            }
            else if (compare > 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }

        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = startRange.CompareTo(node.Value);
        int compareHight = endRange.CompareTo(node.Value);

        if (compareLow < 0)
        {
            Range(node.Left, queue, startRange, endRange);
        }
        if (compareLow <= 0 && compareHight >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (compareHight > 0)
        {
            Range(node.Right, queue, startRange, endRange);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.InOrder(root, action);
    }

    private void InOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.InOrder(node.Left, action);
        action(node.Value);
        this.InOrder(node.Right, action);
    }

}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> BST = new BinarySearchTree<int>();

        BST.Insert(15);
        BST.Insert(10);
        BST.Insert(8);
        BST.Insert(20);
        BST.Insert(18);
        BST.Insert(25);
        BST.Insert(25);
        BST.Insert(9);
        BinarySearchTree<int> searchTree = BST.Search(9);

        Console.WriteLine(BST.Contains(3));
        Console.WriteLine(BST.Contains(321));
        BST.EachInOrder(x => Console.WriteLine(x));
    }
}
