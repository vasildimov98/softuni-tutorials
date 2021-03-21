namespace _06._Reversed_List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class ReversedList<T> : IEnumerable<T>
    {
        public const int IntialCapacity = 2;

        public T[] arr;

        public ReversedList()
        {
            arr = new T[IntialCapacity];
        }

        public int Count { get; private set; }

        public int Capacity => arr.Length;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return arr[Count - 1 - index];
            }

            set
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                arr[index] = value;
            }
        }

        public void Add(T elem)
        {
            if (Count == arr.Length)
            {
                Resize();
            }

            arr[Count++] = elem;
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
                throw new IndexOutOfRangeException();
            }
            T removedItem = arr[index];
            Shift(index);
            Count--;
            return removedItem;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Shift(int index)
        {
            for (int i = Count - index; i < Count; i++)
            {
                arr[i - 1] = arr[i];
            }
        }
    }
}
