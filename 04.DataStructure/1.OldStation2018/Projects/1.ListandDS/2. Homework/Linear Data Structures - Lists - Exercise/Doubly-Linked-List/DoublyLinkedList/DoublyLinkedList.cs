using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNote<T>
    {
        public T Value { get; private set; }
        public ListNote<T> NextNote { get;  set; }
        public ListNote<T> PrevNote { get;  set; }

        public ListNote(T value)
        {
            Value = value;
        }
    }

    private ListNote<T> head;
    private ListNote<T> tail;
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (Count == 0)
        {
            head = tail = new ListNote<T>(element);
        }
        else
        {
            var newHead = new ListNote<T>(element);
            newHead.NextNote = head;
            head.PrevNote = newHead;
            head = newHead;
        }
        Count++;
    }

    public void AddLast(T element)
    {
        if (Count == 0)
        {
            tail = head = new ListNote<T>(element);
        }
        else
        {
            var newTail = new ListNote<T>(element);
            newTail.PrevNote = tail;
            tail.NextNote = newTail;
            tail = newTail;
        }
        Count++;
    }

    public T RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List emty");
        }


        var firsElement = head.Value;
        head = head.NextNote;
        if (head != null)
        {
            head.PrevNote = null;
        }
        else
        {
            tail = null;
        }
        Count--;
        return firsElement;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List emty");
        }


        var lastElement = tail.Value;
        tail = tail.PrevNote;
        if (tail != null)
        {
            tail.NextNote = null;
        }
        else
        {
            head = null;
        }
        Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNote = head;
        while (currentNote != null)
        {
            action(currentNote.Value);
            currentNote = currentNote.NextNote;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNote = head;
        while (currentNote != null)
        {
            yield return currentNote.Value;
            currentNote = currentNote.NextNote;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[Count];
        var currentNote = head;
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = currentNote.Value;
            currentNote = currentNote.NextNote;
        }
        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
