using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03.Stack
{
    class MyStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 2;
        private T[] data;
        private int capacity;

        public MyStack()
            : this(InitialCapacity)
        {
        }
        public MyStack(int capacity)
        {
            this.data = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }

            this.data[this.Count] = element;

            this.Count++;
        }

        public T Pop()
        {
            var removed = this.data[this.Count - 1];

            this.Count--;

            if (this.Count <= this.data.Length / 4)
            {
                Shrink();
            }

            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[this.Count - 1 - i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            var copy = new T[this.Count * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.data[i];
            }

            this.data = copy;
        }

        private void Shrink()
        {
            var copy = new T[this.data.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.data[i];
            }

            this.data = copy;
        }
    }
}
