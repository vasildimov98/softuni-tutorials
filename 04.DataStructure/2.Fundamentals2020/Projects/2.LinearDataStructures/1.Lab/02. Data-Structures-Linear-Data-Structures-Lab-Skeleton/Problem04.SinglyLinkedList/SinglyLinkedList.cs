namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {

        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddFirst(item);
            }
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);
            newNode.Next = this._head;
            this._head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            this.EnsureItsNotEmpty();
            return this._head.Value;
        }

        public T GetLast()
        {
            this.EnsureItsNotEmpty();

            var current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.EnsureItsNotEmpty();
            var elementToReturn = this._head.Value;
            var temp = this._head.Next;
            this._head.Next = null;
            this._head = temp;
            this.Count--;

            return elementToReturn;
        }

        public T RemoveLast()
        {
            this.EnsureItsNotEmpty();

            T elementToReturn;
            if (this.Count == 1)
            {
                elementToReturn = this._head.Value;
                this._head = null;
            }
            else
            {
                var current = this._head;

                while (current.Next.Next != null)
                {
                    current = current.Next;
                }

                elementToReturn = current.Next.Value;
                current.Next = null;
            }

            this.Count--;

            return elementToReturn;
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

        private void EnsureItsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}