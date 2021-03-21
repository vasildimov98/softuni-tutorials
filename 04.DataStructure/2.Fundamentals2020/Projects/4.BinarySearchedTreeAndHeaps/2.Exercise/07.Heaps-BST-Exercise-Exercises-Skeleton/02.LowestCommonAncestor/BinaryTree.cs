namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;

            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            this.RightChild = rightChild;

            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var queue = new Queue<BinaryTree<T>>();
            this.FindNodes(queue, this, first, second);

            var firstNode = queue.Dequeue();
            var secondNode = queue.Dequeue();

            var firstNodeAncestors = new List<BinaryTree<T>>();
            var secondNodeAncestors = new List<BinaryTree<T>>();

            this.FindNodeAncestors(firstNodeAncestors, firstNode);
            this.FindNodeAncestors(secondNodeAncestors, secondNode);

            var current = firstNode;
            foreach (var ancestor in firstNodeAncestors)
            {
                current = ancestor;

                if (secondNodeAncestors.Contains(current))
                {
                    break;
                }
            }

            return current.Value;
        }

        private void FindNodeAncestors(List<BinaryTree<T>> ancestors, BinaryTree<T> node)
        {
            if (node.Parent == null)
            {
                return;
            }

            ancestors.Add(node.Parent);
            FindNodeAncestors(ancestors, node.Parent);
        }

        private void FindNodes(Queue<BinaryTree<T>> queue, BinaryTree<T> curr, T first, T second)
        {
            if (curr == null)
            {
                return;
            }

            if (this.IsEqual(first, curr.Value)
                || this.IsEqual(second, curr.Value))
            {
                queue.Enqueue(curr);
            }

            this.FindNodes(queue, curr.LeftChild, first, second);
            this.FindNodes(queue, curr.RightChild, first, second);
        }

        private bool IsEqual(T value1, T value2)
        {
            return value1.CompareTo(value2) == 0;
        }
    }
}
