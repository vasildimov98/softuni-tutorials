namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            this.EnsureNotEmpty();
            var firstElement = this.Peek();
            this.SwapElements(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);
            return firstElement;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.elements[0];
        }

        private void HeapifyDown(int currIndex)
        {
            var leftChildIndex = this.GetLeftChildIndex(currIndex);
            while (leftChildIndex < this.Size 
                && this.IsGreater(currIndex, leftChildIndex))
            {
                var indexToSwap = leftChildIndex;

                var rightChildIndex = this.GetRightChildIndex(currIndex);
                if (rightChildIndex < this.Size
                    && this.IsGreater(indexToSwap, rightChildIndex))
                {
                    indexToSwap = rightChildIndex;
                }

                this.SwapElements(currIndex, indexToSwap);

                currIndex = indexToSwap;
                leftChildIndex = this.GetLeftChildIndex(currIndex);
            }
        }

        private bool IsGreater(int parentIndex, int childIndex)
        {
            var parentValue = this.elements[parentIndex];
            var childValue = this.elements[childIndex];

            return parentValue.CompareTo(childValue) > 0;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private void HeapifyUp(int currIndex)
        {
            var parentIndex = this.GetParentIndex(currIndex);
            while (currIndex > 0 && this.IsLess(currIndex, parentIndex))
            {
                this.SwapElements(currIndex, parentIndex);
                currIndex = parentIndex;
                parentIndex = this.GetParentIndex(currIndex);
            }
        }

        private void SwapElements(int currIndex, int parentIndex)
        {
            var temp = this.elements[currIndex];
            this.elements[currIndex] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsLess(int childIndex, int parentIndex)
        {
            var child = this.elements[childIndex];
            var parent = this.elements[parentIndex];

            return child.CompareTo(parent) < 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }
        }
    }
}
