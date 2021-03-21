using System;

public class ArrayList<T>
{
    private const int Initial_Capacity = 2;

    private T[] arr;
    public ArrayList()
    {
        arr = new T[Initial_Capacity];
    }
    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return arr[index];
        }

        set
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            arr[index] = value;
        }
    }

    public void Add(T item)
    {
        if (Count == arr.Length)
        {
            Resize();
        }

        arr[Count++] = item;
    }

    private void Resize()
    {
        T[] newArr = new T[arr.Length * 2];
        for (int i = 0; i < arr.Length; i++)
        {
            newArr[i] = arr[i];
        }
        arr = newArr;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = arr[index];
        Shift(index);
        Count--;

        if (Count <= arr.Length/4)
        {
            Shrink();
        }

        return element;
    }

    private void Shrink()
    {
        T[] newArr = new T[arr.Length / 2];

        for (int i = 0; i < Count; i++)
        {
            newArr[i] = arr[i];
        }

        arr = newArr;
    }

    private void Shift(int index)
    {
        for (int i = index; i < Count; i++)
        {
            arr[i] = arr[i + 1];
        }
    }
}
