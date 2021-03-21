namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public Stack()
        {

        }

        public Stack(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
        }

        // O(1)
        public int Count { get; private set; }

        // O(1)
        public void Push(T item)
        {
            var newTop = new Node<T>(item);
            newTop.Next = this._top;
            this._top = newTop;
            this.Count++;
        }

        // O(1)
        public T Pop()
        {
            this.EnsureItsNotEmpty();
            var elementToReturn = this._top.Value;
            var temp = this._top.Next;
            this._top.Next = null;
            this._top = temp;
            this.Count--;

            return elementToReturn;
        }

        // O(1)
        public T Peek()
        {
            this.EnsureItsNotEmpty();

            return this._top.Value;
        }

        // O(n)
        public bool Contains(T item)
        {
            var current = this._top;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // O(n)
        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureItsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
        }
    }
}