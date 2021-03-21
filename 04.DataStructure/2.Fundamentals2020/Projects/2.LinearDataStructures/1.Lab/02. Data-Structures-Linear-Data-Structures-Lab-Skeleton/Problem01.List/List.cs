namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;

        private T[] _items;

        public List(int capacity = DEFAULT_CAPACITY)
        {
            this._items = new T[capacity];
        }

        public List(IEnumerable<T> collection)
            : this()
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        // O(1)
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        // O(1)
        // When adding the nth element we have O(n)
        public void Add(T item)
        {
            this.ValidateNullArgument(item);

            this.GrowIfNessery();
            this._items[this.Count] = item;
            this.Count++;
        }

        // O(n)
        public bool Contains(T item)
        {
            foreach (var element in this._items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        // O(n)
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                var currentElement = this._items[i];
                if (currentElement.Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        // O(n)
        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNessery();
            this.ShiftRight(index);
            this._items[index] = item;
            this.Count++;
        }

        // O(n)
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

        // O(n)
        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            ShiftLeft(index);
            this._items[this.Count - 1] = default;
            this.Count--;
        }

        // O(n)
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void GrowIfNessery()
        {
            if (this.Count >= this._items.Length)
            {
                this.Grow();
            }
        }

        // O(n)
        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }
        }

        // O(n)
        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }
        }

        // O(n)
        private void Grow()
        {
            var newArr = new T[this._items.Length * 2];
            Array.Copy(this._items, newArr, this._items.Length);
            this._items = newArr;
        }

        private void ValidateNullArgument(T item)
        {
            if (item.Equals(null))
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                var msg = $"{index} is out of range! Try index between 0 and {this.Count - 1}";
                throw new IndexOutOfRangeException(msg);
            }
        }
    }
}