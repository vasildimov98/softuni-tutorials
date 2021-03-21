namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        // O(1)
        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }

            this.Count++;
        }

        // O(1)
        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.tail = this.head = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }

            this.Count++;
        }

        // O(1)
        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        // O(1)
        public T GetLast()
        {
            this.EnsureNotEmpty();

            return this.tail.Item;
        }

        // O(1)
        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var itemToReturn = this.head.Item;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                this.head.Next = null;
                newHead.Previous = null;
                this.head = newHead;
            }

            this.Count--;
            return itemToReturn;
        }

        // O(1)
        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            var itemToReturn = this.tail.Item;

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                var newTail = this.tail.Previous;
                this.tail.Previous = null;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;
            return itemToReturn;
        }

        // O(n)
        public IEnumerator<T> GetEnumerator()
        {
            var currEl = this.head;
            while (currEl != null)
            {
                yield return currEl.Item;
                currEl = currEl.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("List is empty!");
        }
    }
}