﻿namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNecessary();

            this.items[this.Count] = item;

            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 1; i <= this.Count; i++)
            {
                if (this.items[this.Count - i].Equals(item))
                {
                    return i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();
            var indexToInsert = this.Count - 1 - index;

            for (int i = this.Count; i > indexToInsert; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[indexToInsert + 1] = item;

            this.Count++;
        }

        public bool Remove(T item)
        {
            var indexOfItem = this.IndexOf(item);

            if (indexOfItem == -1)
            {
                return false;
            }

            this.RemoveAt(indexOfItem);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var indexToRemove = this.Count - 1 - index;

            for (int i = indexToRemove; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[this.Count - 1 - i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void GrowIfNecessary()
        {
            if (this.Count == this.items.Length)
            {
                this.Grow();
            }
        }
        private void Grow()
        {
            var newArr = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newArr[i] = this.items[i];
            }

            this.items = newArr;
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"{index} is outside of the list's borders! The current borders are 0 and {this.Count - 1} including!");
            }
        }
    }
}