namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private LinkedNode head;
        private LinkedNode tail;

        private class LinkedNode
        {
            public LinkedNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public LinkedNode NextNode { get; set; }
            public LinkedNode PrevNode { get; set; }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var arr = this.ToArray();
                return arr[index];
            }
        }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new LinkedNode(element);
            }
            else
            {
                var newHead = new LinkedNode(element);
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new LinkedNode(element);
            }
            else
            {
                var newTail = new LinkedNode(element);
                newTail.PrevNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            this.ValidateOperation();

            var remove = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
                head.PrevNode = null;
            }

            this.Count--;
            return remove;
        }

        public T RemoveLast()
        {
            this.ValidateOperation();

            var removed = this.tail.Value;
            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                this.tail = this.tail.PrevNode;
                this.tail.NextNode = null;
            }

            this.Count--;
            return removed;
        }

        public void ForEach(Action<T> action)
        {
            var currEl = this.head;

            while (currEl != null)
            {
                action(currEl.Value);
                currEl = currEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            var cnt = 0;
            var currEl = this.head;

            while (currEl != null)
            {
                arr[cnt++] = currEl.Value;
                currEl = currEl.NextNode;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currEl = this.head;

            while (currEl != null)
            {
                yield return currEl.Value;
                currEl = currEl.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateOperation()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }

    }
}
