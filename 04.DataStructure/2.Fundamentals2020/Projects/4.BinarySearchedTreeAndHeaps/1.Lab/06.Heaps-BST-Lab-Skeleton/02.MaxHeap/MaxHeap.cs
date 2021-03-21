namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size
            => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }

            return this.elements[0];
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = this.GetParent(index);
            while (index > 0 
                && this.IsGreater(index, parentIndex))
            {
                this.SwapElements(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParent(index);
            }
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private void SwapElements(int firstIndex, int secondIndex)
        {
            var temp = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = temp;
        }

        private int GetParent(int index)
        {
            var parentIndex = (index - 1) / 2;

            return parentIndex;
        }
    }
}
