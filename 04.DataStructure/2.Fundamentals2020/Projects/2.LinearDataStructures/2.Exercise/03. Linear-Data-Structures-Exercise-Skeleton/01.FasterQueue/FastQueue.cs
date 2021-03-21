namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        // O(1)
        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        // O(1)
        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var itemToReturn = this.head.Item;
            var newHead = this.head.Next;
            this.head.Next = null;
            this.head = newHead;

            this.Count--;
            return itemToReturn;
        }

        // O(1)
        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        // O(n)
        public bool Contains(T item)
        {
            var currEl = this.head;
            while (currEl != null)
            {
                if (currEl.Item.Equals(item))
                {
                    return true;
                }

                currEl = currEl.Next;
            }

            return false;
        }

        // O(n)
        public IEnumerator<T> GetEnumerator()
        {
            var currentEl = this.head;
            while (currentEl != null)
            {
                yield return currentEl.Item;
                currentEl = currentEl.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("Queue is empty!");
        }
    }
}