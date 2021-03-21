namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public AATree() { }

        public bool IsEmpty()
            => this.root == null;

        public void Clear()
            => this.root = null;

        public void Insert(T element)
            => this.root = this.InsertNewNode(this.root, element);

        public int CountNodes()
            => this.GetSubtreeCount(this.root);

        public bool Search(T element)
            => this.FindNodeWithElement(element) != null;

        public void InOrder(Action<T> action)
            => this.VisitNodesWithActionInOrder(this.root, action);

        public void PreOrder(Action<T> action)
            => this.VisitNodesWithActionPreOrder(this.root, action);

        public void PostOrder(Action<T> action)
            => this.VisitNodesWithActionPostOrder(this.root, action);

        private void VisitNodesWithActionInOrder(Node<T> node, Action<T> action)
        {
            if (node == null) return;
            this.VisitNodesWithActionInOrder(node.Left, action);
            action(node.Element);
            this.VisitNodesWithActionInOrder(node.Right, action);
        }

        private void VisitNodesWithActionPreOrder(Node<T> node, Action<T> action)
        {
            if (node == null) return;

            action(node.Element);
            this.VisitNodesWithActionPreOrder(node.Left, action);
            this.VisitNodesWithActionPreOrder(node.Right, action);
        }

        private void VisitNodesWithActionPostOrder(Node<T> node, Action<T> action)
        {
            if (node == null) return;

            this.VisitNodesWithActionPostOrder(node.Left, action);
            this.VisitNodesWithActionPostOrder(node.Right, action);
            action(node.Element);
        }

        private Node<T> FindNodeWithElement(T element)
        {
            var currentNode = this.root;

            while (currentNode != null)
                if (this.IsLess(element, currentNode.Element))
                    currentNode = currentNode.Left;
                else if (this.IsGreater(element, currentNode.Element))
                    currentNode = currentNode.Right;
                else break;

            return currentNode;
        }

        private Node<T> InsertNewNode(Node<T> node, T element)
        {
            if (node == null)
                return new Node<T>(element);
            else if (this.IsLess(element, node.Element))
                node.Left = this.InsertNewNode(node.Left, element);
            else if (this.IsGreater(element, node.Element))
                node.Right = this.InsertNewNode(node.Right, element);
            else return node;

            node = this.BalanceTreeIfNeeded(node);

            this.UpdateCountOfNode(node);

            return node;
        }

        private Node<T> BalanceTreeIfNeeded(Node<T> node)
        {
            if (this.NodeHasLeftChildHorizontally(node))
                node = this.Skew(node);

            if (this.NodeHasTwoRightChildrenHorizontally(node))
                node = this.Split(node);

            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            node = this.RotateLeft(node);

            this.UpdateLevelOfNode(node);

            return node;
        }

        private void UpdateLevelOfNode(Node<T> node)
        {
            node.Level = 1 + this.GetSubtreeLevel(node.Left);
        }

        private int GetSubtreeLevel(Node<T> node)
            => node == null ? 0 : node.Count;

        private Node<T> RotateLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            this.UpdateCountOfNode(node);

            return right;
        }

        private bool NodeHasTwoRightChildrenHorizontally(Node<T> node)
            => node.Level == node.Right?.Level &&
            node.Level == node.Right.Right?.Level;

        private Node<T> Skew(Node<T> node)
            => this.RotateRight(node);

        private Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            this.UpdateCountOfNode(node);

            return left;
        }

        private void UpdateCountOfNode(Node<T> node)
        {
            node.Count = 1 +
                this.GetSubtreeCount(node.Left) +
                this.GetSubtreeCount(node.Right);
        }

        private int GetSubtreeCount(Node<T> node)
            => node == null ? 0 : node.Count;

        private bool NodeHasLeftChildHorizontally(Node<T> node)
                => node.Level == node.Left?.Level;

        private bool IsLess(T firstElement, T secondElement)
            => firstElement.CompareTo(secondElement) < 0;

        private bool IsGreater(T firstElement, T secondElement)
            => firstElement.CompareTo(secondElement) > 0;
    }
}