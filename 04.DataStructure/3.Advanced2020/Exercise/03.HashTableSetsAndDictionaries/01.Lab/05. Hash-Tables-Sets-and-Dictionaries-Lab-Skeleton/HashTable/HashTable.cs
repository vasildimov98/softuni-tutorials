namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int INITIAL_CAPACITY = 16;
        private const float MAX_LOAD_FACTOR = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public HashTable()
            : this(INITIAL_CAPACITY) { }

        public HashTable(int capacity)
            => this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];

        public int Count { get; private set; }

        public int Capacity { get => this.slots.Length; }

        public void Add(TKey key, TValue value)
        {
            this.ResizeIfNeeded();
            var foundSlotIndex = this.FindSlotIndex(key);

            if (this.slots[foundSlotIndex] == null)
                this.slots[foundSlotIndex] = new LinkedList<KeyValue<TKey, TValue>>();

            foreach (var kvp in this.slots[foundSlotIndex])
                if (this.AreEqual(key, kvp.Key))
                    throw new ArgumentException($"Key already exists {key}");

            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[foundSlotIndex].AddLast(newElement);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            this.ResizeIfNeeded();
            var foundSlotIndex = this.FindSlotIndex(key);

            if (this.slots[foundSlotIndex] == null)
                this.slots[foundSlotIndex] = new LinkedList<KeyValue<TKey, TValue>>();

            foreach (var kvp in this.slots[foundSlotIndex])
                if (this.AreEqual(key, kvp.Key))
                {
                    kvp.Value = value;
                    return false;
                }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[foundSlotIndex].AddLast(newElement);
            this.Count++;

            return true;
        }

        public bool Remove(TKey key)
        {
            var foundSlotIndex = this.FindSlotIndex(key);

            if (this.slots[foundSlotIndex] != null)
            {
                var currElement = this.slots[foundSlotIndex].First;

                while (currElement != null)
                {
                    if (this.AreEqual(key, currElement.Value.Key))
                    {
                        this.slots[foundSlotIndex].Remove(currElement);
                        this.Count--;
                        return true;
                    }

                    currElement = currElement.Next;
                }
            }

            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            var foundSlotIndex = this.FindSlotIndex(key);
            var list = this.slots[foundSlotIndex];

            if (list != null)
                foreach (var kvp in list)
                    if (this.AreEqual(key, kvp.Key))
                        return kvp;

            return null;
        }

        public TValue Get(TKey key)
        {
            var foundElement = this.Find(key);

            if (foundElement == null)
                throw new KeyNotFoundException("Element doesn't exists!");

            return foundElement.Value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var foundElement = this.Find(key);

            if (foundElement == null)
            {
                value = default;
                return false;
            }

            value = foundElement.Value;
            return true;
        }

        public bool ContainsKey(TKey key)
            => this.Find(key) != null;

        public TValue this[TKey key]
        {
            get => this.Get(key);
            set => this.AddOrReplace(key, value);
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[INITIAL_CAPACITY];
            this.Count = default;
        }

        public IEnumerable<TKey> Keys
        {
            get => this
                .Select(kvp => kvp.Key);
        }

        public IEnumerable<TValue> Values
        {
            get => this
                .Select(kvp => kvp.Value);
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in slots)
                if (list != null)
                    foreach (var kvp in list)
                        yield return kvp;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private int FindSlotIndex(TKey key)
         => Math.Abs(key.GetHashCode()) % this.Capacity;

        private void ResizeIfNeeded()
        {
            var loadFactor = ((float)(this.Count + 1) / this.Capacity);
            if (loadFactor >= MAX_LOAD_FACTOR)
                this.Resize();
        }

        private void Resize()
        {
            var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);

            foreach (var kvp in this)
                newHashTable.Add(kvp.Key, kvp.Value);

            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }

        private bool AreEqual(TKey firstKey, TKey secondKey)
           => firstKey.Equals(secondKey);
    }
}
