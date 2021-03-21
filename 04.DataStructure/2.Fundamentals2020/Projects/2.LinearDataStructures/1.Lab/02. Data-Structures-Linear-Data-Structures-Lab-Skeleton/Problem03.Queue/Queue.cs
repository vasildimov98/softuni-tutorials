namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {

        }

        public Queue(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.Enqueue(item);
            }
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this._head = newNode;
            }
            else
            {
                var current = this._head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.EnsureItIsNotEmpty();
            var elementToReturn = this._head.Value;
            var tempHead = this._head.Next;
            this._head.Next = null;
            this._head = tempHead;
            this.Count--;

            return elementToReturn;
        }

        public T Peek()
        {
            this.EnsureItIsNotEmpty();
            return this._head.Value;
        }

        public bool Contains(T item)
        {
            if (this.Count == 0)
            {
                return false;
            }
            else
            {
                var current = this._head;

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
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureItIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }

    }
}