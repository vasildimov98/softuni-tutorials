namespace P02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class MyStack<T> : IEnumerable<T>
    {
        private const int INIT_CAP = 2;

        private T[] collection;

        public MyStack()
        {
            this.collection = new T[INIT_CAP];
        }

        public int Count;

        public void Push(T element)
        {
            if (this.Count == this.collection.Length)
            {
                this.Resize();
            }

            this.collection[this.Count] = element;

            this.Count++;
        }
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new Exception("No elements");
            }

            var poppedElement = this.collection[this.Count - 1];

            this.Count--;

            if (this.Count * 4 < this.collection.Length)
            {
                this.Shrink();
            }

            return poppedElement;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Shrink()
        {
            var newLength = this.collection.Length / 4;
            var tempArr = new T[newLength];

            for (int i = 0; i < this.Count; i++)
            {
                tempArr[i] = this.collection[i];
            }

            this.collection = tempArr;
        }
        private void Resize()
        {
            var newLength = this.collection.Length * 2;
            var tempArr = new T[newLength];

            for (int i = 0; i < this.collection.Length; i++)
            {
                tempArr[i] = this.collection[i];
            }

            this.collection = tempArr;
        }
    }
}
