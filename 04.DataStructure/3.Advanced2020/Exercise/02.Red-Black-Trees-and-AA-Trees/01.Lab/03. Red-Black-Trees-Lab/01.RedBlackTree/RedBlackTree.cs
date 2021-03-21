namespace _01.RedBlackTree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private readonly bool IsRedColor = true;
        private readonly bool IsBlackColor = false;

        private Node<T> root;

        public RedBlackTree() { }

        private RedBlackTree(Node<T> node)
        {
            this.PreOrderCopy(node);
        }

        public void Insert(T element)
        {
            this.root = this.InsertNewNode(this.root, element);
            this.root.Color = this.IsBlackColor;
        }

        public void Delete(T element)
        {
            this.ValidateTreeNotEmpty();

            this.root = this.DeleteNode(this.root, element);
        }

        public void DeleteMax()
        {
            this.ValidateTreeNotEmpty();

            this.root = this.DeleteMaxNode(this.root);
        }

        public void DeleteMin()
        {
            this.ValidateTreeNotEmpty();

            this.root = this.DeleteMinNode(this.root);
        }

        public bool Contains(T element)
        {
            return this.FindElement(element) != null;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var foundElement = this.FindElement(element);

            return new RedBlackTree<T>(foundElement);
        }

        public T Ceiling(T value)
        {
            return this.Select(this.Rank(value) + 1);
        }

        public T Floor(T value)
        {
            return this.Select(this.Rank(value) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var elementsInRange = new Queue<T>();

            this.SelectElementsInRange(this.root, elementsInRange, startRange, endRange);

            return elementsInRange;
        }

        public int Count()
        {
            return this.GetSubtreeCount(this.root);
        }

        public int Rank(T value)
        {
            return this.GetValueRank(this.root, value);
        }

        public T Select(int rank)
        {
            var selectedNode = this.SelectNodeByRank(this.root, rank);
            if (selectedNode == null)
                throw new InvalidOperationException("Tree does't contain such node");

            return selectedNode.Value;
        }

        private void SelectElementsInRange(Node<T> current, Queue<T> queue, T startRange, T endRange)
        {
            if (current == null)
                return;

            if (this.CurrentNodeIsInLowerRange(startRange, current.Value))
                this.SelectElementsInRange(current.LeftChild, queue, startRange, endRange);
            if (this.CurrentNodeIsInRange(current.Value, startRange, endRange))
                queue.Enqueue(current.Value);
            if (this.CurrentNodeIsHigherRange(endRange, current.Value))
                this.SelectElementsInRange(current.RightChild, queue, startRange, endRange);
        }

        private bool CurrentNodeIsInRange(T nodeValue, T startRange, T endRange)
        {
            return (this.IsGreater(nodeValue, startRange)
                || this.IsEqual(nodeValue, startRange))
                && (this.IsLess(nodeValue, endRange)
                || this.IsEqual(nodeValue, endRange));
        }

        private bool CurrentNodeIsHigherRange(T higherRange, T nodeValue)
        {
            return this.IsGreater(higherRange, nodeValue);
        }

        private bool CurrentNodeIsInLowerRange(T lowerRange, T nodeValue)
        {
            return this.IsLess(lowerRange, nodeValue);
        }

        private Node<T> SelectNodeByRank(Node<T> node, int rank)
        {
            if (node == null)
                return null;

            var leftSubtreeCount = this.GetSubtreeCount(node.LeftChild);
            if (leftSubtreeCount == rank)
                return node;

            if (leftSubtreeCount > rank)
                return this.SelectNodeByRank(node.LeftChild, rank);


            return this.SelectNodeByRank(node.RightChild, rank - (leftSubtreeCount + 1));
        }

        private Node<T> InsertNewNode(Node<T> node, T element)
        {
            // the node position was located
            if (node == null)
                // 2. Create a new red node
                node = new Node<T>(element);
            // 1. Locate the node position
            else if (this.IsLess(element, node.Value))
                // 3. Add new Node to the tree left side
                node.LeftChild = this.InsertNewNode(node.LeftChild, element);
            else if (this.IsGreater(element, node.Value))
                // 3. Add new Node to the tree right side
                node.RightChild = this.InsertNewNode(node.RightChild, element);

            // 4. Balance subtree if needed
            node = this.BalanceSubtreeIfNeeded(node);

            node.Count = 1
                + this.GetSubtreeCount(node.LeftChild)
                + this.GetSubtreeCount(node.RightChild);
            return node;
        }

        private Node<T> BalanceSubtreeIfNeeded(Node<T> node)
        {
            if (this.IsRedNode(node.RightChild)
                && !this.IsRedNode(node.LeftChild))
                node = this.RotateLeft(node);

            if (this.IsRedNode(node.LeftChild)
                && this.IsRedNode(node.LeftChild.LeftChild))
                node = this.RotateRight(node);

            if (this.IsRedNode(node.LeftChild)
                && this.IsRedNode(node.RightChild))
                this.FlipColors(node);
            return node;
        }

        private void FlipColors(Node<T> node)
        {
            node.Color = this.IsRedColor;
            node.LeftChild.Color = this.IsBlackColor;
            node.RightChild.Color = this.IsBlackColor;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var leftChild = node.LeftChild;
            node.LeftChild = leftChild.RightChild;
            leftChild.RightChild = node;

            leftChild.Color = node.Color;
            node.Color = this.IsRedColor;

            node.Count = 1 + this.GetSubtreeCount(node.LeftChild)
                + this.GetSubtreeCount(node.RightChild);

            return leftChild;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var rightChild = node.RightChild;
            node.RightChild = rightChild.LeftChild;
            rightChild.LeftChild = node;

            rightChild.Color = node.Color;
            node.Color = this.IsRedColor;


            node.Count = 1 + this.GetSubtreeCount(node.LeftChild)
                + this.GetSubtreeCount(node.RightChild);

            return rightChild;
        }

        private bool IsRedNode(Node<T> node)
        {
            return node != null
                && node.Color == this.IsRedColor;
        }

        private Node<T> DeleteNode(Node<T> node, T element)
        {
            if (node == null)
                return null;

            if (this.IsLess(element, node.Value))
                node.LeftChild = this.DeleteNode(node.LeftChild, element);
            else if (this.IsGreater(element, node.Value))
                node.RightChild = this.DeleteNode(node.RightChild, element);
            else
            {
                if (this.IsLeaf(node))
                    return null;
                else if (this.HasOnlyLeftSubtree(node))
                    return node.LeftChild;
                else if (this.HasOnlyRightSubtree(node))
                    return node.RightChild;
                else
                {
                    var tempNode = node;
                    var maxElementFromLeftSide = this.FindMaxElement(node.LeftChild);
                    node = maxElementFromLeftSide;
                    node.LeftChild = this.DeleteMaxNode(tempNode.LeftChild);
                    node.RightChild = tempNode.RightChild;
                }
            }

            node.Count = 1 + this.GetSubtreeCount(node.LeftChild) + this.GetSubtreeCount(node.RightChild);
            return node;
        }

        private Node<T> DeleteMaxNode(Node<T> node)
        {
            if (node.RightChild == null)
                return node.LeftChild;
            else node.RightChild = this.DeleteMaxNode(node.RightChild);

            node.Count = 1 + this.GetSubtreeCount(node.LeftChild) +
                this.GetSubtreeCount(node.RightChild);

            return node;
        }

        private Node<T> DeleteMinNode(Node<T> node)
        {
            if (node.LeftChild == null)
                return node.RightChild;
            else node.LeftChild = this.DeleteMinNode(node.LeftChild);

            node.Count = 1 + this.GetSubtreeCount(node.LeftChild) + this.GetSubtreeCount(node.RightChild);
            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
                return;

            this.EachInOrder(node.LeftChild, action);
            action.Invoke(node.Value);
            this.EachInOrder(node.RightChild, action);
        }

        private void PreOrderCopy(Node<T> node)
        {
            if (node == null)
                return;

            this.Insert(node.Value);
            this.PreOrderCopy(node.LeftChild);
            this.PreOrderCopy(node.RightChild);
        }

        private Node<T> FindElement(T element)
        {
            var currentNode = this.root;

            while (currentNode != null)
            {
                if (this.IsLess(element, currentNode.Value))
                    currentNode = currentNode.LeftChild;
                else if (this.IsGreater(element, currentNode.Value))
                    currentNode = currentNode.RightChild;
                else break;
            }

            return currentNode;
        }

        private Node<T> FindMaxElement(Node<T> node)
        {
            if (node.RightChild == null)
                return node;

            return this.FindMaxElement(node.RightChild);
        }

        private bool HasOnlyRightSubtree(Node<T> node)
        {
            return node.LeftChild == null
           && node.RightChild != null;
        }

        private bool HasOnlyLeftSubtree(Node<T> node)
        {
            return node.LeftChild != null
           && node.RightChild == null;
        }

        private bool IsLeaf(Node<T> node)
        {
            return node.LeftChild == null
            && node.RightChild == null;
        }

        private int GetValueRank(Node<T> subtree, T value)
        {
            if (subtree == null)
                return 0;

            if (this.IsLess(value, subtree.Value))
                return this.GetValueRank(subtree.LeftChild, value);
            else if (this.IsGreater(value, subtree.Value))
                return 1
                    + this.GetSubtreeCount(subtree.LeftChild)
                    + this.GetValueRank(subtree.RightChild, value);
            else return this.GetSubtreeCount(subtree.LeftChild);
        }

        private int GetSubtreeCount(Node<T> subtree)
        {
            if (subtree == null)
                return 0;

            return subtree.Count;
        }

        private bool IsEqual(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) == 0;
        }

        private bool IsGreater(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) > 0;
        }

        private bool IsLess(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) < 0;
        }

        private void ValidateTreeNotEmpty()
        {
            if (this.root == null)
                throw new InvalidOperationException("Tree is empty!!!");
        }
    }
}