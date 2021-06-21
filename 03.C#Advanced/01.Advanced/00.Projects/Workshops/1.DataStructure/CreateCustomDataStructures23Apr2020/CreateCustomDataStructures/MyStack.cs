using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CreateCustomDataStructures
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] data;
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
            this.ValidateOperation();

            this.Count--;

            return this.data[Count];
        }

        public T Peek()
        {
            this.ValidateOperation();
            return this.data[this.Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.data[this.Count - 1 - i]);
            }
        }

        private void Resize()
        {
            var newData = new T[this.Count * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        private void ValidateOperation()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("MyStack is empty");
            }
        }

        public IEnumerator<T> GetEnumerator()
     => this.data
         .ToList()
         .Take(this.Count)
         .Reverse()
         .GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
