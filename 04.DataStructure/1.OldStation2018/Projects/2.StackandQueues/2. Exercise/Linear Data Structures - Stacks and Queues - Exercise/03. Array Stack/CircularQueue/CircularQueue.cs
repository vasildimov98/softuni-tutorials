using System;

public class ArrayStack<T>
{
    private T[] elements;
    public int Count { get; private set; }
    private const int InitialCapacity = 16;
    public ArrayStack()
    {
        elements = new T[InitialCapacity];
    }

    public ArrayStack(int capacity)
    {
        elements = new T[capacity];
    }
    public void Push(T element)
    {
        elements[this.Count++] = element;

        if (Count >= this.elements.Length)
        {
            this.Grow();
        }
    }
    public T Pop()
    {

        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is Empty!");
        }
        this.Count--;
        return this.elements[this.Count];
    }
    public T[] ToArray()
    {
        T[] newArr = new T[Count];

        for (int i = 0; i < Count; i++)
        {
            newArr[i] = elements[Count - 1 - i];
        }
        return newArr;
    }
    private void Grow()
    {
        T[] newArr = new T[elements.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            newArr[i] = elements[i];
        }

        elements = newArr;
    }
}



public class Example
{
    public static void Main()
    {

        ArrayStack<int> arrayStack = new ArrayStack<int>();

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
