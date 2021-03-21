using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedQueue<T>
{
    public int Count { get; private set; }

    private QueueNode<T> Head;
    private QueueNode<T> Tail;
    public void Enqueue(T element)
    {

        if (this.Count == 0)
        {
            this.Head = this.Tail = new QueueNode<T>(element);
        }
        else
        {
            QueueNode<T> OldTail = this.Tail;
            this.Tail = new QueueNode<T>(element);
            Tail.PrevNode = OldTail;
            OldTail.NextNode = this.Tail;
        }
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Quue is Empty!");
        }

        QueueNode<T> OldHead = this.Head;
        this.Head = this.Head.NextNode;
        if (this.Head != null)
        {
            this.Head.PrevNode = null;
        }
        else
        {
            this.Tail = null;
        }
        this.Count--;
        return OldHead.Value;
    }
    public T[] ToArray()
    {
        T[] newArr = new T[Count];
        QueueNode<T> current = Head;
        int index = 0;
        while (current != null)
        {
            newArr[index] = current.Value;
            index++;
            current = current.NextNode;
        }
        return newArr;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get;  set; }
        public QueueNode<T> PrevNode { get;  set; }
    }
}


class Example
{
    static void Main()
    {
        LinkedQueue<int> list = new LinkedQueue<int>();

        list.Enqueue(5);
        list.Enqueue(3);
        list.Enqueue(2);
        list.Enqueue(10);
        Console.WriteLine("Count = {0}", list.Count);
        Console.WriteLine(string.Join(", ", list.ToArray()));
        list.Dequeue();
        list.Dequeue();
        list.Dequeue();

        Console.WriteLine("Count = {0}", list.Count);
    }
}
