using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Create_Custom_Data_Structures
{
    public class MyList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] data;
        public MyList()
            : this(InitialCapacity)
        {
        }

        public MyList(int capacity)
        {
            this.data = new T[capacity];
        }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }

            this.data[this.Count] = element;
            this.Count++;
        }

        public bool Remove(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    this.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var removed = this.data[index];

            this.Shift(index);

            this.Count--;

            if (this.Count * 4 <= this.data.Length)
            {
                this.Shrink();
            }

            return removed;
        }

        public void Clear()
        {
            this.data = new T[InitialCapacity];
            this.Count = 0;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            var temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public void Insert(int index, T element)
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }

            if (index != this.Count)
            {
                ValidateIndex(index);
            }

            ShiftToTheRight(index);

            this.data[index] = element;
                
            this.Count++;
        }

        private void ValidateIndex(int index)
        {
            if (!(index >= 0 && index < this.Count))
            {
                throw new System.Exception("Index out of range!");
            }
        }
        private void Resize()
        {
            var newCapacity = this.Count * 2;

            var newData = new T[newCapacity];

            for (int i = 0; i < this.Count; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        private void Shrink()
        {
            var newData = new T[this.data.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
        }

        private void ShiftToTheRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.data[i] = this.data[i - 1];
            }
        }

        public IEnumerator<T> GetEnumerator()
        => this.data
            .ToList()
            .Take(this.Count)
            .GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
