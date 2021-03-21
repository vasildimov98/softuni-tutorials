namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool IS_RED_COLOR = true;
        private const bool IS_BLACK_COLOR = false;

        private Node root;

        public RedBlackTree() { }

        private RedBlackTree(Node node)
        {
            this.InOrderCopyTree(node);
        }

        public int Count
            => this.GetSubtreeCount(this.root);

        public void Insert(T element)
        {
            this.root = this.InsertNewNode(this.root, element);
            this.root.Color = IS_BLACK_COLOR;
        }

        public void DeleteMin()
        {
            this.ValidateEmptyTree();
            this.root = this.DeleteMinNode(this.root);
        }

        public void DeleteMax()
        {
            this.ValidateEmptyTree();
            this.root = this.DeleteMaxNode(this.root);
        }

        public void Delete(T element)
        {
            this.ValidateEmptyTree();
            this.root = this.DeleteNode(this.root, element);
        }

        public bool Contains(T element)
        {
            return this.FindNodeElement(element, this.root) != null;
        }

        public int Rank(T element)
        {
            return this.FindElementRank(this.root, element);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Select(int rank)
        {
            var foundNode = this.FindNodeByRank(this.root, rank);

            if (foundNode == null)
                throw new InvalidOperationException("Node is not found!");

            return foundNode.Value;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNodeElement(element, this.root);

            return new RedBlackTree<T>(node);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var elementInRange = new Queue<T>();

            this.SelectElementInOrderByRange(this.root, elementInRange, startRange, endRange);

            return elementInRange;
        }

        private void SelectElementInOrderByRange(Node node, Queue<T> queue, T startRange, T endRange)
        {
            if (node == null) return;
            else if (this.ElementIsInLowerRange(startRange, node.Value))
                this.SelectElementInOrderByRange(node.Left, queue, startRange, endRange);
            else if (this.ElementIsInRanger(startRange, endRange, node.Value))
                queue.Enqueue(node.Value);
            else this.SelectElementInOrderByRange(node.Right, queue, startRange, endRange);
        }

        private bool ElementIsInRanger(T startRange, T endRange, T value)
        {
            return (this.IsLess(startRange, value)
                || this.IsEqual(startRange, value))
                && (this.IsGreater(endRange, value)
                || this.IsEqual(endRange, value));
        }

        private bool ElementIsInLowerRange(T startRange, T value)
        {
            return this.IsLess(startRange, value);
        }

        private void InOrderCopyTree(Node subtree)
        {
            if (subtree == null) return;

            this.InOrderCopyTree(subtree.Left);
            this.Insert(subtree.Value);
            this.InOrderCopyTree(subtree.Right);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null) return;

            this.EachInOrder(node.Left, action);
            action.Invoke(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private Node FindNodeByRank(Node node, int rank)
        {
            if (node == null) return null;

            var leftSubtreeCount = this.GetSubtreeCount(node.Left);
            if (leftSubtreeCount == rank) return node;
            if (leftSubtreeCount > rank)
                return this.FindNodeByRank(node.Left, rank);

            return this.FindNodeByRank(node.Right, rank - (leftSubtreeCount + 1));
        }

        private int FindElementRank(Node subtree, T element)
        {
            if (subtree == null) return 0;

            if (this.IsLess(element, subtree.Value))
                return this.FindElementRank(subtree.Left, element);
            else if (this.IsGreater(element, subtree.Value))
                return 1 +
                    this.GetSubtreeCount(subtree.Left) +
                    this.FindElementRank(subtree.Right, element);
            else return this.GetSubtreeCount(subtree.Left);
        }

        private Node DeleteNode(Node node, T element)
        {
            if (node == null)
                return null;
            else if (this.IsLess(element, node.Value))
                node.Left = this.DeleteNode(node.Left, element);
            else if (this.IsGreater(element, node.Value))
                node.Right = this.DeleteNode(node.Right, element);
            else
            {
                if (this.IsLeaf(node))
                    return null;
                else if (this.HasOnlyLeftSubtree(node))
                    return node.Left;
                else if (this.HasOnlyRightSubtree(node))
                    return node.Right;
                else
                {
                    var nodeToDelete = node;
                    var minNodeFromRightSide = this.GetMinNode(node.Right);
                    node = minNodeFromRightSide;
                    node.Right = this.DeleteMinNode(nodeToDelete.Right);
                    node.Left = nodeToDelete.Left;
                }
            }

            node = this.BalanceNodeIfNeeded(node);
            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);
            return node;
        }

        private Node GetMinNode(Node subtree)
        {
            if (subtree.Left == null)
                return subtree;
            else return this.GetMinNode(subtree.Left);
        }

        private bool HasOnlyRightSubtree(Node node)
            => node.Right != null
            && node.Left == null;

        private bool HasOnlyLeftSubtree(Node node)
            => node.Left != null
                && node.Right == null;

        private bool IsLeaf(Node node)
            => node.Left == null
                && node.Right == null;

        private Node DeleteMaxNode(Node node)
        {
            if (node.Right == null)
                return node.Left;
            else node.Right = this.DeleteMaxNode(node.Right);

            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);

            return node;
        }

        private Node DeleteMinNode(Node node)
        {
            if (node.Left == null)
                return node.Right;
            else node.Left = this.DeleteMinNode(node.Left);

            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);
            return node;
        }

        private Node FindNodeElement(T element, Node node)
        {
            if (node == null)
                return null;
            else if (this.IsLess(element, node.Value))
                return this.FindNodeElement(element, node.Left);
            else if (this.IsGreater(element, node.Value))
                return this.FindNodeElement(element, node.Right);
            else return node;
        }

        private Node InsertNewNode(Node node, T element)
        {
            if (node == null)
                node = new Node(element, IS_RED_COLOR);
            else if (this.IsLess(element, node.Value))
                node.Left = this.InsertNewNode(node.Left, element);
            else if (this.IsGreater(element, node.Value))
                node.Right = this.InsertNewNode(node.Right, element);
            else return node;

            node = this.BalanceNodeIfNeeded(node);

            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);
            return node;
        }

        private Node BalanceNodeIfNeeded(Node node)
        {
            if (this.IsRed(node.Right)
                && !this.IsRed(node.Left))
                node = this.RotateLeft(node);

            if (this.IsRed(node.Left)
                && this.IsRed(node.Left.Left))
                node = this.RotateRight(node);

            if (this.IsRed(node.Left)
                && this.IsRed(node.Right))
                this.FlipColours(node);

            return node;
        }

        private void FlipColours(Node node)
        {
            node.Color = IS_RED_COLOR;
            node.Left.Color = IS_BLACK_COLOR;
            node.Right.Color = IS_BLACK_COLOR;
        }

        private Node RotateRight(Node node)
        {
            var leftChild = node.Left;
            node.Left = leftChild.Right;
            leftChild.Right = node;

            leftChild.Color = node.Color;
            node.Color = IS_RED_COLOR;

            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);

            return leftChild;
        }

        private Node RotateLeft(Node node)
        {
            var rightChild = node.Right;
            node.Right = rightChild.Left;
            rightChild.Left = node;

            rightChild.Color = node.Color;
            node.Color = IS_RED_COLOR;

            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);
            return rightChild;
        }

        private bool IsRed(Node node)
            => node != null && node.Color == IS_RED_COLOR;

        private bool IsEqual(T firstValue, T secondValue) 
            => firstValue.CompareTo(secondValue) == 0;

        private bool IsLess(T firstValue, T secondValue)
            => firstValue.CompareTo(secondValue) < 0;

        private bool IsGreater(T firstValue, T secondValue)
            => firstValue.CompareTo(secondValue) > 0;

        private int GetSubtreeCount(Node subtree)
            => subtree == null ? 0 : subtree.Count;

        private void ValidateEmptyTree()
        {
            if (this.root == null)
                throw new InvalidOperationException("Tree is empty!");
        }

        private class Node
        {
            public Node(T value, bool color)
            {
                this.Value = value;
                this.Color = color;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public int Count { get; set; }
            public bool Color { get; set; }
        }
    }
}