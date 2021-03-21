using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private Node Head;
    private Node Tail;
    public void AddFirst(T item)
    {
        Node oldHead = this.Head;

        Head = new Node(item);
        this.Head.Next = oldHead;

        if (Count == 0)
        {
            this.Tail = this.Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node oldTail = this.Tail;

        this.Tail = new Node(item);
        if (this.Count == 0)
        {
            this.Head = this.Tail;
        }
        else
        {
            oldTail.Next = this.Tail;
        }

        Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new  InvalidOperationException();
        }

        Node oldHead = this.Head;

        this.Head = this.Head.Next;
        this.Count--;
        if (this.Count == 0)
        {
            this.Tail = null;
        }

        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        Node OldTail = this.Tail;
        
        if (Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            Node newTail = GetSecondToLast();
            newTail.Next = null;
            this.Tail = newTail;
        }

        this.Count--;
        return OldTail.Value;
    }

    private Node GetSecondToLast()
    {
        Node current = this.Head;

        while (current.Next != this.Tail)
        {
            current = current.Next;
        }

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
