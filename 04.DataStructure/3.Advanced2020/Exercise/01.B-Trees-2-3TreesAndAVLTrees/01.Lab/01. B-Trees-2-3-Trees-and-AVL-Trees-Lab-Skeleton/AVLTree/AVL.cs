namespace AVLTree
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.ComTypes;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private Node<T> Balance(Node<T> node)
        {
            var balanceFactor = this.GetHeight(node.Right) - this.GetHeight(node.Left);
            if (balanceFactor < -1) // 'left heavy!!';
            {
                balanceFactor = this.GetHeight(node.Left.Right) - this.GetHeight(node.Left.Left);
                if (balanceFactor > 0) // not 'left heavy' double rotation needed;
                {
                    node.Left = this.RotateLeft(node.Left);
                }

                return this.RotateRight(node);
            }

            if (balanceFactor > 1) // 'right heavy!!!'
            {
                balanceFactor = this.GetHeight(node.Right.Right) - this.GetHeight(node.Right.Left);
                if (balanceFactor < 0) // not 'right heavy' double rotation needed;
                {
                    node.Right = RotateRight(node.Right);
                }

                return this.RotateLeft(node);
            }

            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var rightNode = node.Right;
            node.Right = rightNode.Left;
            rightNode.Left = node;

            this.UpdateHeight(node);

            return rightNode;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var leftNode = node.Left;
            node.Left = leftNode.Right;
            leftNode.Right = node;

            this.UpdateHeight(node);

            return leftNode;
        }

        private int GetHeight(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            node = this.Balance(node);
            this.UpdateHeight(node);

            return node;
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
