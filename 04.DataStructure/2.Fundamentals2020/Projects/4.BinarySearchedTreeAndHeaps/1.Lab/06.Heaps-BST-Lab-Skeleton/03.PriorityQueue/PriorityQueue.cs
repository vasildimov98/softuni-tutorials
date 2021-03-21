namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            this.ValidateIfQueueIsEmpty();
            var maxElement = this.Peek();
            this.SwapElements(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);
            return maxElement;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

        public T Peek()
        {
            this.ValidateIfQueueIsEmpty();

            return this.elements[0];
        }

        private void ValidateIfQueueIsEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = this.GetLeftChildIndex(index);
            while (this.ValidateIndex(leftChildIndex)
                && this.IsLesser(index, leftChildIndex))
            {
                var indexToSwap = leftChildIndex;

                var rightChildIndex = this.GetRigthChildIndex(index);
                if (this.ValidateIndex(rightChildIndex)
                && this.IsLesser(indexToSwap, rightChildIndex))
                {
                    indexToSwap = rightChildIndex;
                }

                this.SwapElements(index, indexToSwap);

                index = indexToSwap;
                leftChildIndex = this.GetLeftChildIndex(index);
            }
        }

        private bool IsLesser(int index, int leftChildIndex)
        {
            return this.elements[index].CompareTo(this.elements[leftChildIndex]) < 0;
        }

        private bool ValidateIndex(int leftChildIndex)
        {
            return leftChildIndex < this.Size;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1; 
        }

        private int GetRigthChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);
            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.SwapElements(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void SwapElements(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
