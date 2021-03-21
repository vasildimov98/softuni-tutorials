using System;
public class LinkedStack<T>
{

    private Node<T> Head;
    
    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count == 0)
        {
            this.Head = new Node<T>(element);
        }
        else
        {
            Node<T> oldHead = this.Head;
            this.Head = new Node<T>(element);
            Head.NextNode = oldHead;
        }
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty!");
        }

        Node<T> OldHead = Head;
        Head = Head.NextNode;
        this.Count--;
        return OldHead.Value;
    }  

    public T[] ToArray()
    {
        T[] newArray = new T[Count];
        Node<T> current = Head;
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = current.Value;
            current = current.NextNode;
        }
        return newArray;
    }
    private class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
    }
}

public class Example
{
    public static void Main()
    {
        LinkedStack<int> arrayStack = new LinkedStack<int>();

        arrayStack.Push(1);
        arrayStack.Push(2);
        arrayStack.Push(3);
        arrayStack.Push(4);
        arrayStack.Push(5);
        arrayStack.Push(6);

        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        int first = arrayStack.Pop();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        arrayStack.Push(-7);
        arrayStack.Push(-8);
        arrayStack.Push(-9);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        first = arrayStack.Pop();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        arrayStack.Push(-10);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        first = arrayStack.Pop();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");
    }
}

